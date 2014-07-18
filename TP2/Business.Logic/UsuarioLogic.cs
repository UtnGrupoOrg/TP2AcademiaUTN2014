using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {
        private UsuarioAdapter _UsuarioData;

        public UsuarioLogic()
        {
            try
            {
                UsuarioData = new UsuarioAdapter();
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExceptionManejada;
            }
        }

        public UsuarioAdapter UsuarioData
        {
            get { return _UsuarioData; }
            set { _UsuarioData = value; }
        }

        public List<Usuario> GetAll()
        {
            return UsuarioData.GetAll();
        }

        public Usuario GetOne(int ID)
        {
            return UsuarioData.GetOne(ID);
        }

        public void Save(Usuario usuario)
        {
            UsuarioData.Save(usuario);
        }

        public void Delete(int ID)
        {
            UsuarioData.Delete(ID);
        }
        /// <summary>
        /// Valida si el usuario y la contraseña son correctos.
        /// </summary>
        /// <param name="usu"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public bool identificarUsuario(string usu, string pass) // TODO validar por valores nulos
        {
            List<Usuario> listUsuarios = this.GetAll();
            Usuario usuario = listUsuarios.Find(u => u.NombreUsuario == usu);
            bool estado = false;
            if (usuario != null)
            {
                if(usuario.isPassword(pass))
                {
                    return estado = true;
                }
            }            
            return estado;
        }
    }
}
