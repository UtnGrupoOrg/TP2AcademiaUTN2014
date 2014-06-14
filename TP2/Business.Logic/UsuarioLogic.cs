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
            UsuarioData= new  UsuarioAdapter();
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
        public bool identificarUsuario(string usu, string pass)
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
