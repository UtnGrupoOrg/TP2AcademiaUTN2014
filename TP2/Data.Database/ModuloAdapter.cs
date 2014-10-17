using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Business.Entities;

namespace Data.Database
{
    public class ModuloAdapter : Adapter
    {
        public List<Modulo> GetAll()
        {
            List<Modulo> modulos = new List<Modulo>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("SELECT * FROM modulos", SqlConn);
                SqlDataReader drModulos = cmdGetAll.ExecuteReader();

                while (drModulos.Read())
                {
                    Modulo mod = new Modulo();
                    this.assignData(mod, drModulos);
                    modulos.Add(mod);
                }
                drModulos.Close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar datos de modulos", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return modulos;
        }

        public Business.Entities.Modulo GetOne(int ID)
        {
            Modulo mod = new Modulo();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("SELECT * FROM modulos WHERE id_modulo=@id", SqlConn);
                cmdGetOne.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drModulos = cmdGetOne.ExecuteReader();
                if (drModulos.Read())
                {
                    this.assignData(mod, drModulos);
                }
                drModulos.Close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar datos del modulo", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return mod;

        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE modulos WHERE id_modulo=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al eliminar el modulo", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Modulo modulo)
        {
            if (modulo.State == BusinessEntity.States.Deleted)
            {
                this.Delete(modulo.ID);
            }
            else if (modulo.State == BusinessEntity.States.New)
            {
                this.Insert(modulo);
            }
            else if (modulo.State == BusinessEntity.States.Modified)
            {
                this.Update(modulo);
            }
            modulo.State = BusinessEntity.States.Unmodified;
        }
        protected void Update(Modulo modulo)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE modulos SET desc_modulo = @desc_modulo " +
                                        "WHERE id_modulo=@id", SqlConn);
                insertParameters(cmdUpdate, modulo);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int, 1).Value = modulo.ID;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al modificar datos del modulo", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Modulo modulo)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO modulos(desc_modulo) " +
                                        "values(@desc_modulo@nombre,@apellido,@email) SELECT SCOPE_IDENTITY()", SqlConn);
                insertParameters(cmdInsert, modulo);
                modulo.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al crear modulo", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }
        /// <summary>
        /// Asigna los datos de la base de datos al objeto modulo
        /// </summary>
        /// <param name="modulo"></param>
        /// <param name="dataReader"></param>
        private void assignData(Modulo modulo, SqlDataReader dataReader)
        {
            modulo.ID = (int)dataReader["id_modulo"];
            modulo.Descripcion = (string)dataReader["desc_modulo"];
        }
        /// <summary>
        /// Agrega los datos del modulo al comando, excepto el ID.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="modulo"></param>
        private void insertParameters(SqlCommand command, Modulo modulo)
        {
            command.Parameters.Add("@desc_modulo", SqlDbType.VarChar, 50).Value = modulo.Descripcion;
        }
    }
}
