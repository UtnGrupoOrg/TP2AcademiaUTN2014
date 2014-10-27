using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class ComisionAdapter : Adapter
    {
        public List<Comision> GetAll()
        {
            List<Comision> comisiones = new List<Comision>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("SELECT * FROM comisiones", SqlConn);
                SqlDataReader drComisiones = cmdGetAll.ExecuteReader();

                while (drComisiones.Read())
                {
                    Comision com = new Comision();
                    this.assignData(com, drComisiones);
                    comisiones.Add(com);
                }
                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar datos de las comisiones", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return comisiones;
        }

        public Business.Entities.Comision GetOne(int ID)
        {
            Comision com = new Comision();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("SELECT * FROM comisiones WHERE id_comision=@id", SqlConn);
                cmdGetOne.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drComisiones = cmdGetOne.ExecuteReader();
                if (drComisiones.Read())
                {
                    this.assignData(com, drComisiones);
                }
                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar datos de la comision", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return com;

        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE comisiones WHERE id_comision=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al eliminar la comision", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Comision comision)
        {
            if (comision.State == BusinessEntity.States.Deleted)
            {
                this.Delete(comision.ID);
            }
            else if (comision.State == BusinessEntity.States.New)
            {
                this.Insert(comision);
            }
            else if (comision.State == BusinessEntity.States.Modified)
            {
                this.Update(comision);
            }
            comision.State = BusinessEntity.States.Unmodified;
        }
        public void Update(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE comisiones SET desc_comision = @desc_comision," +
                                        "anio_especialidad=@anio_especialidad, id_plan = @id_plan " +
                                        "WHERE id_comision=@id", SqlConn);
                insertParameters(cmdUpdate, comision);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int, 1).Value = comision.ID;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al modificar datos de la comision", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO comisiones(desc_comision,anio_especialidad,id_plan) " +
                                        "values(@desc_comision,@anio_especialidad,@id_plan) " +
                                        "SELECT SCOPE_IDENTITY()", SqlConn);
                this.OpenConnection();
                
                insertParameters(cmdInsert, comision);
                comision.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al crear comision", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }
        /// <summary>
        /// Asigna los datos de la base de datos al objeto comision
        /// </summary>
        /// <param name="comision"></param>
        /// <param name="dataReader"></param>
        private void assignData(Comision comision, SqlDataReader dataReader)
        {
            comision.ID = (int)dataReader["id_comision"];
            comision.Descripcion = (string)dataReader["desc_comision"];
            comision.AnioEspecialidad = (int)dataReader["anio_especialidad"];
            comision.IdPlan = (int)dataReader["id_plan"];
        }
        /// <summary>
        /// Agrega los datos del comision al comando, excepto el ID.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="comision"></param>
        private void insertParameters(SqlCommand command, Comision comision)
        {
            command.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.Descripcion;
            command.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comision.AnioEspecialidad;
            command.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.IdPlan;
        }

        public DataTable GetAllWithPlanDescription()
        {
            DataTable comisiones = new DataTable("Comisiones");
            
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAllWithPlanDescription = new SqlCommand("Select com.id_comision, com.desc_comision, com.anio_especialidad, pla.id_plan, pla.desc_plan " +
                "from comisiones com " +
                "join planes pla on com.id_plan = pla.id_plan", this.SqlConn);
                SqlDataReader drComisiones = cmdGetAllWithPlanDescription.ExecuteReader();
                comisiones.Load(drComisiones);
                
                
            }
            catch (Exception Ex)
            {

                throw new Exception("Error al recuperar datos de las materias", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return comisiones;
        }

        public List<Comision> getAllWithMateriaAndYear(int id_materia, int anio)
        {
            List<Comision> comisiones = new List<Comision>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("getComisionWithMateriaAndYear", SqlConn);
                cmdGetAll.CommandType = CommandType.StoredProcedure;
                cmdGetAll.Parameters.Add("id_materia", SqlDbType.Int).Value = id_materia;
                cmdGetAll.Parameters.Add("anio", SqlDbType.Int).Value = anio;   
                SqlDataReader drComisiones = cmdGetAll.ExecuteReader();

                while (drComisiones.Read())
                {
                    Comision com = new Comision();
                    this.assignData(com, drComisiones);
                    comisiones.Add(com);
                }
                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar datos de las comisiones que tienen la materia:" + id_materia.ToString(), Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return comisiones;
        }
    }
}
