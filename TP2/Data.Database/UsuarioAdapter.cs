using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data.SqlClient;
using System.Data;

namespace Data.Database
{
    public class UsuarioAdapter:Adapter
    {  
        
        public List<Usuario> GetAll() 
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("SELECT * FROM usuarios", SqlConn);
                SqlDataReader drUsuarios = cmdGetAll.ExecuteReader();

                while (drUsuarios.Read())
                {
                    Usuario usr = new Usuario();
                    this.assignData(usr, drUsuarios);
                    usuarios.Add(usr);
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {                
                throw new Exception("Error al recuperar datos de usuarios", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return usuarios;
        }

        public Business.Entities.Usuario GetOne(int ID)
        {
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("SELECT * FROM usuarios WHERE id_usuario=@id", SqlConn);
                cmdGetOne.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdGetOne.ExecuteReader();
                if(drUsuarios.Read())
                {
                    this.assignData(usr, drUsuarios);
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {               
                throw new Exception("Error al recuperar datos del usuario", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return usr;

        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE usuarios WHERE id_usuario=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {                
                throw new Exception("Error al eliminar el usuario", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Usuario usuario)
        {
            if (usuario.State == BusinessEntity.States.Deleted)
            {
                this.Delete(usuario.ID);
            }
            else if (usuario.State == BusinessEntity.States.New)
            {
                this.Insert(usuario);
            }
            else if(usuario.State == BusinessEntity.States.Modified)
            {
                this.Update(usuario);
            }
            usuario.State = BusinessEntity.States.Unmodified;
        }

        protected void Update(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE usuarios SET nombre_usuario = @nombre_usuario,"+
                                        "clave=@clave, habilitado = @habilitado, nombre=@nombre,apellido=@apellido,"+
                                        "email=@email WHERE id_usuario=@id", SqlConn);                
                insertParameters(cmdUpdate, usuario);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int, 1).Value = usuario.ID;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {  
                throw new Exception("Error al modificar datos del usuario", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO usuarios(nombre_usuario,clave,habilitado," +
                                        "nombre,apellido,email) values(@nombre_usuario,@clave,@habilitado," +
                                        "@nombre,@apellido,@email) SELECT SCOPE_IDENTITY()", SqlConn);
                insertParameters(cmdInsert, usuario);
                usuario.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {                
                throw new Exception("Error al crear usuario", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }
        /// <summary>
        /// Asigna los datos de la base de datos al objeto usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="dataReader"></param>
        private void assignData(Usuario usuario, SqlDataReader dataReader)
        {
            usuario.ID = (int)dataReader["id_usuario"];
            usuario.NombreUsuario = (string)dataReader["nombre_usuario"];
            usuario.Clave = (string)dataReader["clave"];
            usuario.Habilitado = (bool)dataReader["habilitado"];
            usuario.Nombre = (string)dataReader["nombre"];
            usuario.Apellido = (string)dataReader["apellido"];
            usuario.Email = (string)dataReader["email"];
        }
        /// <summary>
        /// Agrega los datos del usuario al comando, excepto el ID.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="usuario"></param>
        private void insertParameters(SqlCommand command, Usuario usuario)
        {
            command.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
            command.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
            command.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
            command.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
            command.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
            command.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
        }
    }
}
