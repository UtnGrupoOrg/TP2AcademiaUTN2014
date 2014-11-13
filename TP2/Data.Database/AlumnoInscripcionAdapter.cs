using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class AlumnoInscripcionAdapter : Adapter
    {
        public List<AlumnoInscripcion> GetAll()
        {
            List<AlumnoInscripcion> alumnos_inscripciones = new List<AlumnoInscripcion>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("SELECT * FROM alumnos_inscripciones", SqlConn);
                SqlDataReader drIncripciones = cmdGetAll.ExecuteReader();

                while (drIncripciones.Read())
                {
                    AlumnoInscripcion ins = new AlumnoInscripcion();
                    this.assignData(ins, drIncripciones);
                    alumnos_inscripciones.Add(ins);
                }
                drIncripciones.Close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar datos de alumnos_inscripciones", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return alumnos_inscripciones;
        }

        public DataTable GetAllOfCurso(int id_curso)
        {
            DataTable alumnos_inscripciones = new DataTable("inscripciones");
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("SELECT per.nombre, per.apellido, per.email, per.legajo, ins.* " +
                                                      "  FROM personas per " +
                                                      "  INNER JOIN alumnos_inscripciones ins on per.id_persona = ins.id_alumno "+
                                                      "  where ins.id_curso = @id_curso" +
                                                      " Order by per.apellido", SqlConn);
                cmdGetAll.Parameters.Add("@id_curso", SqlDbType.Int).Value = id_curso;
                SqlDataReader drIncripciones = cmdGetAll.ExecuteReader();

                alumnos_inscripciones.Load(drIncripciones);
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar datos de alumnos en el curso " + id_curso.ToString(), Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return alumnos_inscripciones;
        }


        public Business.Entities.AlumnoInscripcion GetOne(int ID)
        {
            AlumnoInscripcion ins = new AlumnoInscripcion();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("SELECT * FROM alumnos_inscripciones WHERE id_inscripcion=@id", SqlConn);
                cmdGetOne.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drIncripciones = cmdGetOne.ExecuteReader();
                if (drIncripciones.Read())
                {
                    this.assignData(ins, drIncripciones);
                }
                drIncripciones.Close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar datos de la inscripcion", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return ins;

        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE alumnos_inscripciones WHERE id_inscripcion=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al eliminar la inscripcion", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(AlumnoInscripcion inscripcion)
        {
            if (inscripcion.State == BusinessEntity.States.Deleted)
            {
                this.Delete(inscripcion.ID);
            }
            else if (inscripcion.State == BusinessEntity.States.New)
            {
                this.Insert(inscripcion);
            }
            else if (inscripcion.State == BusinessEntity.States.Modified)
            {
                this.Update(inscripcion);
            }
            inscripcion.State = BusinessEntity.States.Unmodified;
        }
        protected void Update(AlumnoInscripcion inscripcion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE alumnos_inscripciones SET id_alumno = @id_alumno," +
                                        "id_curso=@id_curso, condicion = @condicion, nota=@nota "  +
                                        "WHERE id_inscripcion=@id", SqlConn);
                insertParameters(cmdUpdate, inscripcion);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int, 1).Value = inscripcion.ID;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al modificar datos de la inscripcion", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(AlumnoInscripcion inscripcion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO alumnos_inscripciones(id_alumno,id_curso,condicion," +
                                        "nota) values(@id_alumno,@id_curso,@condicion,@nota) " +
                                        "SELECT SCOPE_IDENTITY()", SqlConn);
                insertParameters(cmdInsert, inscripcion);
                inscripcion.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al crear la inscripcion", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }
        /// <summary>
        /// Asigna los datos de la base de datos al objeto inscripcion
        /// </summary>
        /// <param name="inscripcion"></param>
        /// <param name="dataReader"></param>
        private void assignData(AlumnoInscripcion inscripcion, SqlDataReader dataReader)
        {
            inscripcion.ID = (int)dataReader["id_inscripcion"];
            inscripcion.IDAlumno = (int)dataReader["id_alumno"];
            inscripcion.IDCurso = (int)dataReader["id_curso"];
            inscripcion.Condicion = (string)dataReader["condicion"];
            inscripcion.Nota = (int)dataReader["nota"];
        }
        /// <summary>
        /// Agrega los datos del inscripcion al comando, excepto el ID.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="inscripcion"></param>
        private void insertParameters(SqlCommand command, AlumnoInscripcion inscripcion)
        {
            command.Parameters.Add("@id_alumno", SqlDbType.Int).Value = inscripcion.IDAlumno;
            command.Parameters.Add("@id_curso", SqlDbType.Int).Value = inscripcion.IDCurso;
            command.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = (object)inscripcion.Condicion ?? DBNull.Value;
            command.Parameters.Add("@nota", SqlDbType.Int).Value = (object)inscripcion.Nota ?? DBNull.Value;

        }

        public DataTable GetStudentState (int idAlumno)
        {
            DataTable studentState=new DataTable("StudentState");
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetState = new SqlCommand("SELECT aluins.id_alumno, mat.desc_materia as materia,aluins.condicion,aluins.nota as nota,cur.anio_calendario FROM alumnos_inscripciones aluins LEFT JOIN cursos cur ON aluins.id_curso= cur.id_curso LEFT JOIN materias mat ON cur.id_materia=mat.id_materia WHERE id_alumno=@idAlumno", SqlConn);
                cmdGetState.Parameters.Add("@idAlumno", SqlDbType.Int).Value = idAlumno;
                SqlDataReader drStudentState = cmdGetState.ExecuteReader();
                studentState.Load(drStudentState);
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar datos de alumnos   " ,Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return studentState;
        }

        public DataTable GetOneWithPersona(int id)
        {
            DataTable alumnos_inscripciones = new DataTable("inscripciones");
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("SELECT per.nombre, per.apellido, per.email, per.legajo, ins.* " +
                                                      "  FROM personas per " +
                                                      "  INNER JOIN alumnos_inscripciones ins on per.id_persona = ins.id_alumno " +
                                                      "  where ins.id_inscripcion = @id" +
                                                      " Order by per.apellido", SqlConn);
                cmdGetAll.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataReader drIncripciones = cmdGetAll.ExecuteReader();

                alumnos_inscripciones.Load(drIncripciones);
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar datos de alumnos y la inscripcion:  " + id.ToString(), Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return alumnos_inscripciones;
        }
    }
}
