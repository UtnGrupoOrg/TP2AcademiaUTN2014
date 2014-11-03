using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using System.Web.Security;


namespace UIWeb
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {

                if (!this.RoleExists())
                {
                    this.GenerateRoles();
                }

                if (User.Identity.IsAuthenticated)
                {
                    Response.Redirect("~/default.aspx");
                }
            }            
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new UsuarioLogic().identificarUsuario(txtUsuario.Text, txtClave.Text);
            if (usuario != null)
            {
                Persona per = new PersonaLogic().GetOneOfUser(usuario.ID);
                string rol = Enum.GetName(typeof(Persona.TiposPersonas), per.TipoPersona);
                if (!Roles.IsUserInRole(usuario.NombreUsuario,rol))
                {
                    Roles.AddUserToRole(usuario.NombreUsuario, rol);
                }

                FormsAuthentication.RedirectFromLoginPage(usuario.NombreUsuario, true);
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
        protected bool RoleExists()
        {
            foreach(Persona.TiposPersonas tiper in Enum.GetValues(typeof(Persona.TiposPersonas))){
                if (!Roles.RoleExists(Enum.GetName(typeof(Persona.TiposPersonas), tiper)))
                {
                    return false;
                }
            }
            return true;
        }
        protected void GenerateRoles()
        {            
            foreach (Persona.TiposPersonas tiper in Enum.GetValues(typeof(Persona.TiposPersonas)))
            {
                Roles.CreateRole(Enum.GetName(typeof(Persona.TiposPersonas), tiper));
            }
        }
    }
}