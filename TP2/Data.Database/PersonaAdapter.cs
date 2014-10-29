using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{   
    public class PersonaAdapter : Adapter
    {
        public List<Persona> GetAll()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("SELECT * FROM personas", SqlConn);
                SqlDataReader drPersonas = cmdGetAll.ExecuteReader();

                while (drPersonas.Read())
                {
                    Persona per = new Persona();
                    assignData(per, drPersonas);
                    personas.Add(per);
                }
                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar datos de las personas del tipo", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return personas;
        }
        /// <summary>
        /// Devuelve un list de personas del tipo indicado
        /// </summary>
        /// <param name="tipoPersona"></param>
        /// <returns>List de Personas</returns>
        public List<Persona> GetAll(Persona.TiposPersonas tipoPersona)
        {
            List<Persona> personasTipo = new List<Persona>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAllTipo = new SqlCommand("SELECT * FROM personas WHERE tipo_persona=@tipo", SqlConn);
                cmdGetAllTipo.Parameters.Add("@tipo", SqlDbType.Int).Value = (int)tipoPersona;
                SqlDataReader drPersonasTipo = cmdGetAllTipo.ExecuteReader();

                while (drPersonasTipo.Read())
                {
                    Persona per = new Persona();
                    assignData(per, drPersonasTipo);
                    personasTipo.Add(per);
                }
                drPersonasTipo.Close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar datos de las personas del tipo "
                    + Enum.GetName(typeof(Persona.TiposPersonas),tipoPersona),Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return personasTipo;             
        }
        public DataTable GetAllWithPlanDescription()
        {
            DataTable alumnos = new DataTable("alumnosConPLan");
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAllTipo = new SqlCommand("SELECT personas.*, planes.desc_plan FROM personas JOIN planes on planes.id_plan = personas.id_plan WHERE tipo_persona=@tipo", SqlConn);
                cmdGetAllTipo.Parameters.Add("@tipo", SqlDbType.Int).Value = Persona.TiposPersonas.Alumno;
                SqlDataReader drPersonasTipo = cmdGetAllTipo.ExecuteReader();

                alumnos.Load(drPersonasTipo);
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar datos de las personas del tipo "
                    + Enum.GetName(typeof(Persona.TiposPersonas), Persona.TiposPersonas.Alumno), Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return alumnos;      
        }

        public Persona GetOne(int ID)
        {
            Persona per = new Persona();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("SELECT * FROM personas where id_persona=@id", SqlConn);
                cmdGetOne.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPersona = cmdGetOne.ExecuteReader();
                if (drPersona.Read())
                {
                    assignData(per, drPersona);
                }
                drPersona.Close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar datos del usuario", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return per;
        }
        public Persona GetOneOfUser(int ID)
        {
            Persona per = new Persona();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("SELECT per.* FROM personas per INNER JOIN usuarios usu ON per.id_persona = usu.id_persona " +
                                                      "where usu.id_usuario = @id_usuario", SqlConn);

                cmdGetOne.Parameters.Add("@id_usuario", SqlDbType.Int).Value = ID;
                SqlDataReader drPersona = cmdGetOne.ExecuteReader();
                if (drPersona.Read())
                {
                    assignData(per, drPersona);
                }
                drPersona.Close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar datos del usuario", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return per;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE personas WHERE id_persona=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al eliminar la persona", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }     

        public void Save(Persona persona)
        {
            if (persona.State == BusinessEntity.States.Deleted)
            {
                this.Delete(persona.ID);
            }
            else if (persona.State == BusinessEntity.States.New)
            {
                this.Insert(persona);
            }
            else if (persona.State == BusinessEntity.States.Modified)
            {
                this.Update(persona);
            }
            persona.State = BusinessEntity.States.Unmodified;
        }

        protected void Update(Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE personas SET nombre=@nombre, apellido=@apellido, legajo=@legajo, " +
                                        "telefono=@telefono, direccion=@direccion, email=@email,fecha_nacimiento=@fecha_nac, " +
                                        "tipo_persona=@tipo,id_plan=@plan WHERE id_persona=@id", SqlConn);
                insertParameters(cmdUpdate, persona);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int,1).Value = persona.ID;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {                
                throw new Exception("Error al modificar datos de la persona", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO personas(nombre,apellido,legajo,telefono," +
                                        "direccion,email,fecha_nacimiento,tipo_persona,id_plan) values(@nombre," +
                                        "@apellido,@legajo,@telefono,@direccion,@email,@fecha_nac,@tipo,@plan) " +
                                        "SELECT SCOPE_IDENTITY()", SqlConn);
                insertParameters(cmdInsert, persona);
                persona.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al crear la persona", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }
        /// <summary>
        /// Asigna los datos de la base de datos al objeto persona
        /// </summary>
        /// <param name="per"></param>
        /// <param name="dataReader"></param>
        private void assignData(Persona per, SqlDataReader dataReader)
        {
            per.ID = (int)dataReader["id_persona"];
            per.Nombre = (string)dataReader["nombre"];
            per.Apellido = (string)dataReader["apellido"];
            per.Legajo = (string)dataReader["legajo"];
            per.Telefono = (string)dataReader["telefono"];
            per.Direccion = (string)dataReader["direccion"];
            per.Email = (string)dataReader["email"];
            per.FechaNacimiento = (DateTime)dataReader["fecha_nacimiento"];
            per.TipoPersona = (Persona.TiposPersonas)dataReader["tipo_persona"];
            per.IDPlan = dataReader["id_plan"] == DBNull.Value ? null : (int?)Convert.ToInt32(dataReader["id_plan"]);
        }
        /// <summary>
        /// Agrega los datos de la persona al comando, excepto el ID.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="persona"></param>
        private void insertParameters(SqlCommand command, Persona persona)
        {
            command.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
            command.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
            command.Parameters.Add("@legajo", SqlDbType.VarChar, 50).Value = persona.Legajo;
            command.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
            command.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
            command.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
            command.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
            command.Parameters.Add("@tipo", SqlDbType.Int).Value = (int)persona.TipoPersona;
            command.Parameters.Add("@plan", SqlDbType.Int).Value = (object)persona.IDPlan ?? DBNull.Value;
        }

    }
}
