using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class CursoAdapter : Adapter
    {
       
        public List<Curso> GetAll()
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("SELECT * FROM cursos", SqlConn);
                SqlDataReader drCurso = cmdGetAll.ExecuteReader();

                while (drCurso.Read())
                {
                    Curso curso = new Curso();
                    this.assignData(curso, drCurso);
                    cursos.Add(curso);
                }
                drCurso.Close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar datos de cursos", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return cursos;
        }
        public DataTable GetAllWithDescription()
        {

            DataTable cursos = new DataTable("Cursos");
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("SELECT cur.*, mat.desc_materia, com.desc_comision FROM cursos cur INNER JOIN materias mat on mat.id_materia = cur.id_materia INNER JOIN comisiones com on com.id_comision = cur.id_comision  ", SqlConn);
                SqlDataReader drCurso = cmdGetAll.ExecuteReader();
                cursos.Load(drCurso);
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar datos de cursos", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return cursos;
        }

        public Curso GetOne(int ID)
        {
            Curso curso = new Curso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("SELECT * FROM cursos WHERE id_curso=@id", SqlConn);
                cmdGetOne.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCurso = cmdGetOne.ExecuteReader();
                if (drCurso.Read())
                {
                    this.assignData(curso, drCurso);
                }
                drCurso.Close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar datos del curso", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return curso;

        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE cursos WHERE id_curso=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al eliminar el curso", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Curso curso)
        {
            if (curso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(curso.ID);
            }
            else if (curso.State == BusinessEntity.States.New)
            {
                this.Insert(curso);
            }
            else if (curso.State == BusinessEntity.States.Modified)
            {
                this.Update(curso);
            }
            curso.State = BusinessEntity.States.Unmodified;
        }
        protected void Update(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE cursos SET id_materia=@id_materia,id_comision=@id_comision," +
                                        "anio_calendario=@anio,cupo=@cupo WHERE id_curso=@id", SqlConn);
                insertParameters(cmdUpdate, curso);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int, 1).Value = curso.ID;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al modificar datos del curso", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO cursos(id_materia,id_comision,anio_calendario," +
                                        "cupo) values(@id_materia,@id_comision,@anio,@cupo) " +
                                        "SELECT SCOPE_IDENTITY()", SqlConn);
                insertParameters(cmdInsert, curso);
                curso.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al crear curso", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }
        /// <summary>
        /// Asigna los datos de la base de datos al curso
        /// </summary>
        /// <param name="curso"></param>
        /// <param name="dataReader"></param>
        private void assignData(Curso curso, SqlDataReader dataReader)
        {
            curso.ID = (int)dataReader["id_curso"];
            curso.IDMateria = (int)dataReader["id_materia"];
            curso.IDComision = (int)dataReader["id_comision"];
            curso.AnioCalendario = (int)dataReader["anio_calendario"];
            curso.Cupo = (int)dataReader["cupo"];
        }
        /// <summary>
        /// Asigna los datos del curso al comando, excepto el ID.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="curso"></param>
        private void insertParameters(SqlCommand command, Curso curso)
        {
            command.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.IDMateria;
            command.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.IDComision;
            command.Parameters.Add("@anio", SqlDbType.Int).Value = curso.AnioCalendario;
            command.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
        }

    }
}
