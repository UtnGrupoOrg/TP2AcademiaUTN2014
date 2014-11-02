using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using System.Web.Security;


namespace UIWeb
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if ((new UsuarioLogic().identificarUsuario(txtUsuario.Text, txtClave.Text)) != null)
            {
                FormsAuthentication.RedirectFromLoginPage(txtUsuario.Text, true);
            }
            else
            {
                respuesta.Visible = true;
                respuesta.Text = "Usuario y/o contraseña incorrectos";
            }
        }

        protected void lnkOlvideClave_Click(object sender, EventArgs e)
        {
            respuesta.Visible = true;
            respuesta.Text = "Tendrá que hacer memoria";
        }
    }
}