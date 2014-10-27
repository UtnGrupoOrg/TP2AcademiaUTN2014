using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Security.Cryptography;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {
        private const int MIN_PASS_CARACTERES = 8; 
        private UsuarioAdapter _UsuarioData;

        public UsuarioLogic()
        {
            
            UsuarioData = new UsuarioAdapter();
            
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
            try
            {                
                if (usuario.State == BusinessEntity.States.Modified || usuario.State == BusinessEntity.States.New)
                {
                    this.Validate(usuario);
                    usuario.Clave = this.Hash(usuario.Clave);                    
                }
                UsuarioData.Save(usuario);
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        public void Delete(int ID)
        {
            UsuarioData.Delete(ID);
        }
        /// <summary>
        /// Valida si el usuario y la contraseña son correctos.
        /// </summary>
        public Usuario identificarUsuario(string usu, string pass)
        {            
            List<Usuario> listUsuarios;
            listUsuarios = this.GetAllWithClave();
            Usuario usuario = listUsuarios.Find(u => u.NombreUsuario == usu);                
            if (usuario != null)
            {
                if (pass != null)
                {
                    if (usuario.isPassword(this.Hash(pass)))
                    {
                        return usuario;
                    }
                }
            }

            return null;
        }
        private string Hash(string clave)
        {
            // Hash de la contraseña
            HashAlgorithm hashAlg = new SHA256CryptoServiceProvider();
            byte[] bytValue = System.Text.Encoding.UTF8.GetBytes(clave);
            byte[] bytHash = hashAlg.ComputeHash(bytValue);
            clave = Convert.ToBase64String(bytHash);
            return clave;
        }
        private void Validate(Usuario usuario)
        {
            if (String.IsNullOrEmpty(usuario.Nombre) || String.IsNullOrEmpty(usuario.Apellido) || String.IsNullOrEmpty(usuario.NombreUsuario) || String.IsNullOrEmpty(usuario.Email)
                || String.IsNullOrEmpty(usuario.Clave)){
                throw new Exception("Hay campos del usuario que estan vacios");
            }
            if (usuario.Clave.Length < MIN_PASS_CARACTERES)
            {
                throw new Exception("La clave tiene menos de " + MIN_PASS_CARACTERES.ToString() + " caracteres");
            }
            try
            {
                new MailAddress(usuario.Email);
            }
            catch (FormatException){
                throw new FormatException("El formato del email es incorrecto");                
            }              

        }

        private List<Usuario> GetAllWithClave()
        {
            return UsuarioData.GetAllWithClave();
        }
    }
}
