using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Business.Entities;

namespace Data.Database
{
    public class ModuloUsuarioAdapter : Adapter
    {
        public List<ModuloUsuario> GetAll()
        {
            List<ModuloUsuario> modulos_usuarios = new List<ModuloUsuario>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("SELECT * FROM modulos_usuarios", SqlConn);
                SqlDataReader drModulosUsuarios = cmdGetAll.ExecuteReader();

                while (drModulosUsuarios.Read())
                {
                    ModuloUsuario modUsr = new ModuloUsuario();
                    this.assignData(modUsr, drModulosUsuarios);
                    modulos_usuarios.Add(modUsr);
                }
                drModulosUsuarios.Close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar datos de modulos_usuarios", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return modulos_usuarios;
        }

        public Business.Entities.ModuloUsuario GetOne(int ID)
        {
            ModuloUsuario modUsr = new ModuloUsuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("SELECT * FROM modulos_usuarios WHERE id_modulo_usuario=@id", SqlConn);
                cmdGetOne.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drModulosUsuarios = cmdGetOne.ExecuteReader();
                if (drModulosUsuarios.Read())
                {
                    this.assignData(modUsr, drModulosUsuarios);
                }
                drModulosUsuarios.Close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar datos del moduloUsuario", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return modUsr;

        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE modulos_usuarios WHERE id_modulo_usuario=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al eliminar el moduloUsuario", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(ModuloUsuario moduloUsuario)
        {
            if (moduloUsuario.State == BusinessEntity.States.Deleted)
            {
                this.Delete(moduloUsuario.ID);
            }
            else if (moduloUsuario.State == BusinessEntity.States.New)
            {
                this.Insert(moduloUsuario);
            }
            else if (moduloUsuario.State == BusinessEntity.States.Modified)
            {
                this.Update(moduloUsuario);
            }
            moduloUsuario.State = BusinessEntity.States.Unmodified;
        }
        protected void Update(ModuloUsuario moduloUsuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE modulos_usuarios SET id_modulo = @id_modulo," +
                                        "id_usuario=@id_usuario, alta = @alta, baja=@baja,modificacion=@modificacion," +
                                        "consulta=@consulta WHERE id_modulo_usuario=@id", SqlConn);
                insertParameters(cmdUpdate, moduloUsuario);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int, 1).Value = moduloUsuario.ID;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al modificar datos del moduloUsuario", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(ModuloUsuario moduloUsuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO modulos_usuarios(id_modulo,id_usuario,alta," +
                                        "baja,modificacion,consulta) values(@id_modulo,@id_usuario,@alta," +
                                        "@baja,@modificaion,@consulta) SELECT SCOPE_IDENTITY()", SqlConn);
                insertParameters(cmdInsert, moduloUsuario);
                moduloUsuario.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al crear moduloUsuario", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }
        /// <summary>
        /// Asigna los datos de la base de datos al objeto moduloUsuario
        /// </summary>
        /// <param name="moduloUsuario"></param>
        /// <param name="dataReader"></param>
        private void assignData(ModuloUsuario moduloUsuario, SqlDataReader dataReader)
        {
            moduloUsuario.ID = (int)dataReader["id_modulo_usuario"];
            moduloUsuario.IDModulo = (int)dataReader["id_modulo"];
            moduloUsuario.IDUsuario = (int)dataReader["id_usuario"];
            moduloUsuario.PermiteAlta = (bool)dataReader["alta"];
            moduloUsuario.PermiteBaja = (bool)dataReader["baja"];
            moduloUsuario.PermiteModificacion = (bool)dataReader["modificacion"];
            moduloUsuario.PermiteConsulta = (bool)dataReader["consulta"];
        }
        /// <summary>
        /// Agrega los datos del moduloUsuario al comando, excepto el ID.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="moduloUsuario"></param>
        private void insertParameters(SqlCommand command, ModuloUsuario moduloUsuario)
        {
            command.Parameters.Add("@id_modulo", SqlDbType.Int).Value = moduloUsuario.IDModulo;
            command.Parameters.Add("@id_usuario", SqlDbType.Int).Value = moduloUsuario.IDUsuario;
            command.Parameters.Add("@alta", SqlDbType.Bit).Value = moduloUsuario.PermiteAlta;
            command.Parameters.Add("@baja", SqlDbType.Bit).Value = moduloUsuario.PermiteBaja;
            command.Parameters.Add("@modificacion", SqlDbType.Bit).Value = moduloUsuario.PermiteModificacion;
            command.Parameters.Add("@consulta", SqlDbType.Bit).Value = moduloUsuario.PermiteConsulta;
        }
    }
}
