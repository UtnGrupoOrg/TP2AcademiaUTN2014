using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class PlanAdapter : Adapter
    {

        public List<Plan> GetAll()
        {
            List<Plan> planes = new List<Plan>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("SELECT * FROM planes", SqlConn);
                SqlDataReader drPlanes = cmdGetAll.ExecuteReader();

                while (drPlanes.Read())
                {
                    Plan plan = new Plan();
                    this.assignData(plan, drPlanes);
                    planes.Add(plan);
                }
                drPlanes.Close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar datos de los planes", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return planes;

        }
        public Plan GetOne(int ID)
        {
            Plan plan = new Plan();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPlanes = new SqlCommand("SELECT * FROM planes WHERE id_plan=@id", SqlConn);
                cmdPlanes.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();
                if (drPlanes.Read())
                {
                    this.assignData(plan, drPlanes);
                }
                drPlanes.Close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar datos del plan", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return plan;
        }
        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE planes WHERE id_plan=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al eliminar el plan", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(Plan plan)
        {
            if (plan.State == BusinessEntity.States.Deleted)
            {
                this.Delete(plan.ID);
            }
            else if (plan.State == BusinessEntity.States.New)
            {
                this.Insert(plan);
            }
            else if (plan.State == BusinessEntity.States.Modified)
            {
                this.Update(plan);
            }
            plan.State = BusinessEntity.States.Unmodified;
        }
        private void Update(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE planes SET desc_plan=@desc_plan, id_especialidad=@id_especialidad, " +
                                        "WHERE id_plan=@id", SqlConn);
                insertParameters(cmdUpdate, plan);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = plan.ID;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al modificar datos del plan", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }
        private void Insert(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("INSET INTO planes(desc_plan=@desc_plan,id_especialidad=@id_especialidad) " +
                                        "SELECT SCOPE_IDENTITY()", SqlConn);
                insertParameters(cmdInsert, plan);
                plan.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al crear el plan", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }
        /// <summary>
        /// Asigna los datos de la base de datos a la plan
        /// </summary>
        /// <param name="plan"></param>
        /// <param name="dataReader"></param>
        private void assignData(Plan plan, SqlDataReader dataReader)
        {
            plan.ID = (int)dataReader["id_plan"];
            plan.Descripcion = (string)dataReader["desc_plan"];
            plan.IDEspecialidad = (int)dataReader["id_especialidad"];
        }
        /// <summary>
        /// Asigna los datos de la plan al comando, excepto el ID.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="plan"></param>
        private void insertParameters(SqlCommand command, Plan plan)
        {
            command.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.Descripcion;
            command.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = plan.IDEspecialidad;
        }
    }
}
