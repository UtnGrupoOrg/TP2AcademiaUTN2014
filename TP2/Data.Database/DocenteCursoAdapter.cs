using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class DocenteCursoAdapter : Adapter
    {
        public List<DocenteCurso> GetAll()
        {
            List<DocenteCurso> docente_cursos = new List<DocenteCurso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("SELECT * FROM docente_cursos", SqlConn);
                SqlDataReader drDocentesCursos = cmdGetAll.ExecuteReader();

                while (drDocentesCursos.Read())
                {
                    DocenteCurso docCur = new DocenteCurso();
                    this.assignData(docCur, drDocentesCursos);
                    docente_cursos.Add(docCur);
                }
                drDocentesCursos.Close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar datos de docente_cursos", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return docente_cursos;
        }

        public Business.Entities.DocenteCurso GetOne(int ID)
        {
            DocenteCurso docCur = new DocenteCurso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("SELECT * FROM docente_cursos WHERE id_dictado=@id", SqlConn);
                cmdGetOne.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drDocentesCursos = cmdGetOne.ExecuteReader();
                if (drDocentesCursos.Read())
                {
                    this.assignData(docCur, drDocentesCursos);
                }
                drDocentesCursos.Close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar datos del docenteCurso", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return docCur;

        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE docente_cursos WHERE id_dictado=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al eliminar el docenteCurso", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(DocenteCurso docenteCurso)
        {
            if (docenteCurso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(docenteCurso.ID);
            }
            else if (docenteCurso.State == BusinessEntity.States.New)
            {
                this.Insert(docenteCurso);
            }
            else if (docenteCurso.State == BusinessEntity.States.Modified)
            {
                this.Update(docenteCurso);
            }
            docenteCurso.State = BusinessEntity.States.Unmodified;
        }
        protected void Update(DocenteCurso docenteCurso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE docente_cursos SET id_curso = @id_curso," +
                                        "id_docente=@id_docente, cargo=@cargo "+
                                        "WHERE id_dictado=@id", SqlConn);
                insertParameters(cmdUpdate, docenteCurso);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int, 1).Value = docenteCurso.ID;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al modificar datos del docenteCurso", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(DocenteCurso docenteCurso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO docente_cursos(id_curso,id_docente,cargo) " +
                                        "values(@id_curso,@id_docente,@cargo) " +
                                        "SELECT SCOPE_IDENTITY()", SqlConn);
                insertParameters(cmdInsert, docenteCurso);
                docenteCurso.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al crear docenteCurso", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }
        /// <summary>
        /// Asigna los datos de la base de datos al objeto docenteCurso
        /// </summary>
        /// <param name="docenteCurso"></param>
        /// <param name="dataReader"></param>
        private void assignData(DocenteCurso docenteCurso, SqlDataReader dataReader)
        {
            docenteCurso.ID = (int)dataReader["id_dictado"];
            docenteCurso.IDCurso = (int)dataReader["id_curso"];
            docenteCurso.IDDocente = (int)dataReader["id_docente"];
            docenteCurso.Cargo = (DocenteCurso.TiposCargos)dataReader["cargo"];
        }
        /// <summary>
        /// Agrega los datos del docenteCurso al comando, excepto el ID.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="docenteCurso"></param>
        private void insertParameters(SqlCommand command, DocenteCurso docenteCurso)
        {
            command.Parameters.Add("@id_curso", SqlDbType.Int).Value = docenteCurso.IDCurso;
            command.Parameters.Add("@id_docente", SqlDbType.Int).Value = docenteCurso.IDDocente;
            command.Parameters.Add("@cargo", SqlDbType.Int).Value = docenteCurso.Cargo;
        }
    }
}
