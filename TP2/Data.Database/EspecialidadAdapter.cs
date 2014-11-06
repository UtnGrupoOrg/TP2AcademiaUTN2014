using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class EspecialidadAdapter : Adapter
    {
        public List<Especialidad> GetAll()
        {
            List<Especialidad> especialidad = new List<Especialidad>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("SELECT * FROM especialidades", SqlConn);
                SqlDataReader drEspecialidad = cmdGetAll.ExecuteReader();

                while (drEspecialidad.Read())
                {
                    Especialidad esp = new Especialidad();
                    this.assignData(esp, drEspecialidad);
                    especialidad.Add(esp);
                }
                drEspecialidad.Close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar datos de las especialidades", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return especialidad;
        }

        public Business.Entities.Especialidad GetOne(int ID)
        {
            Especialidad esp = new Especialidad();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("SELECT * FROM especialidades WHERE id_especialidad=@id", SqlConn);
                cmdGetOne.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drEspecialidad = cmdGetOne.ExecuteReader();
                if (drEspecialidad.Read())
                {
                    this.assignData(esp, drEspecialidad);
                }
                drEspecialidad.Close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar datos de la especialidad", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return esp;

        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE especialidades WHERE id_especialidad=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al eliminar la especialidad", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Especialidad especialidad)
        {
            if (especialidad.State == BusinessEntity.States.Deleted)
            {
                this.Delete(especialidad.ID);
            }
            else if (especialidad.State == BusinessEntity.States.New)
            {
                this.Insert(especialidad);
            }
            else if (especialidad.State == BusinessEntity.States.Modified)
            {
                this.Update(especialidad);
            }
            especialidad.State = BusinessEntity.States.Unmodified;
        }
        protected void Update(Especialidad especialidad)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE especialidades SET desc_especialidad=@desc_esp " +                                        
                                        "WHERE id_especialidad=@id", SqlConn);
                insertParameters(cmdUpdate, especialidad);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int, 1).Value = especialidad.ID;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al modificar datos de la especialidad", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Especialidad especialidad)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO especialidades(desc_especialidad) " +
                                       "values(@desc_esp) SELECT SCOPE_IDENTITY()", SqlConn);
                insertParameters(cmdInsert, especialidad);
                especialidad.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al crear la especialidad", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }
        /// <summary>
        /// Asigna los datos de la base de datos a la especialidad
        /// </summary>
        /// <param name="esp"></param>
        /// <param name="dataReader"></param>
        private void assignData(Especialidad esp, SqlDataReader dataReader)
        {
            esp.ID = (int)dataReader["id_especialidad"];
            esp.Descripcion = (string)dataReader["desc_especialidad"];
        }
        /// <summary>
        /// Asigna los datos de la especialidad al comando, excepto el ID.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="especialidad"></param>
        private void insertParameters(SqlCommand command, Especialidad especialidad)
        {
            command.Parameters.Add("desc_esp", SqlDbType.VarChar, 50).Value = especialidad.Descripcion;
        }



    }
}
