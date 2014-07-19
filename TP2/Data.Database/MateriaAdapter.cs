using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class MateriaAdapter : Adapter
    {
        public List<Materia> GetAll()
        {
            List<Materia> materias = new List<Materia>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("SELECT * FROM materias", SqlConn);
                SqlDataReader drMaterias = cmdGetAll.ExecuteReader();

                while (drMaterias.Read())
                {
                    Materia mat = new Materia();
                    this.assignData(mat, drMaterias);
                    materias.Add(mat);
                }
                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar datos de las materias", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return materias;

        }
        public Materia GetOne(int ID)
        {
            Materia mat = new Materia();
            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("SELECT * FROM materias WHERE id_materia=@id", SqlConn);
                cmdMaterias.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();
                if (drMaterias.Read())
                {
                    this.assignData(mat, drMaterias);
                }
                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar datos de la materia", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return mat;
        }
        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE materias WHERE id_materia=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al eliminar la materia", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(Materia materia)
        {
            if (materia.State == BusinessEntity.States.Deleted)
            {
                this.Delete(materia.ID);
            }
            else if (materia.State == BusinessEntity.States.New)
            {
                this.Insert(materia);
            }
            else if (materia.State == BusinessEntity.States.Modified)
            {
                this.Update(materia);
            }
            materia.State = BusinessEntity.States.Unmodified;
        }
        private void Update(Materia materia)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE materias SET desc_materia=@desc_materia, hs_semanales=@hs_semanales, " +
                                        "hs_totales=@hs_totales, id_plan=@plan WHERE id_materia=@id", SqlConn);
                insertParameters(cmdUpdate, materia);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = materia.ID;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al modificar datos de la materia", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }
        private void Insert(Materia materia)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("INSET INTO materias(desc_materia=@desc_materia,hs_semanales=@hs_semanales, " +
                                        "hs_totales=@hs_totales, id_plan=@plan) SELECT SCOPE_IDENTITY()", SqlConn);
                insertParameters(cmdInsert, materia);
                materia.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al crear la materia", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }
        /// <summary>
        /// Asigna los datos de la base de datos a la materia
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="dataReader"></param>
        private void assignData(Materia mat, SqlDataReader dataReader)
        {
            mat.ID = (int)dataReader["id_materia"];
            mat.Descripcion = (string)dataReader["desc_materia"];
            mat.HSSemanales = (int)dataReader["hs_semanales"];
            mat.HSTotales = (int)dataReader["hs_totales"];
            mat.IdPlan = (int)dataReader["id_plan"];
        }
        /// <summary>
        /// Asigna los datos de la materia al comando, excepto el ID.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="materia"></param>
        private void insertParameters(SqlCommand command, Materia materia)
        {
            command.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = materia.Descripcion;
            command.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = materia.HSSemanales;
            command.Parameters.Add("@hs_totales", SqlDbType.Int).Value = materia.HSTotales;
            command.Parameters.Add("@plan", SqlDbType.Int).Value = materia.IdPlan;
        }
    }
}
