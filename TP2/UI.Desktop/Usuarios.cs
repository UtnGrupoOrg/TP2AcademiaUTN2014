using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Logic;

namespace UI.Desktop
{
    public class Usuarios
    {
        private UsuarioLogic _UsuarioNegocio;

        public UsuarioLogic UsuarioNegocio
        {
            get { return _UsuarioNegocio; }
            set { _UsuarioNegocio = value; }
        }

        public Usuarios()
        {
            UsuarioNegocio = new UsuarioLogic();
        }
        /// <summary>
        /// <para>Llama al identificarUsuario de <see cref="Business.Logic.UsuarioLogic"/></para>
        /// <seealso cref="Business.Logic.UsuarioLogic.identificarUsuario"/>
        /// </summary>
        /// <param name="usu"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public bool identificarUsuario(string usu, string pass)
        {
            return UsuarioNegocio.identificarUsuario(usu, pass);
        }
    }
}
