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
        public static int MIN_PASS_CARACTERES = 8; 
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
            try
            {                
                if (usuario.State == BusinessEntity.States.Modified || usuario.State == BusinessEntity.States.New)
                {
                    usuario.Clave = this.Hash(usuario.Clave);
                    this.Validate(usuario);
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
        public bool identificarUsuario(string usu, string pass) // TODO validar por valores nulos
        {
            List<Usuario> listUsuarios;
            bool estado = false;
            listUsuarios = this.GetAll();
            Usuario usuario = listUsuarios.Find(u => u.NombreUsuario == usu);                
            if (usuario != null)
            {
                if (usuario.isPassword(this.Hash(pass)))
                {
                    return estado = true;
                }
            }  
      
            return estado;
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
            else if (usuario.Clave.Length < MIN_PASS_CARACTERES)
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
    }
}
