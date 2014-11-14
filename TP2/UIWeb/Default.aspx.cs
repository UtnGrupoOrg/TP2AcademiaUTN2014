using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Business.Logic;
using Business.Entities;

namespace UIWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Usuario usu = (new UsuarioLogic().GetOne(Int32.Parse(HttpContext.Current.User.Identity.Name.ToString())));

                Persona per = new PersonaLogic().GetOne(usu.IdPersona);
                if (per.TipoPersona == Persona.TiposPersonas.Alumno)
                {
                    Session["idAlumno"] = per.ID;
                }


                this.titulo.InnerText = "Bienvenido " + usu.NombreUsuario + " (" + per.TipoPersona + ")";
            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }
        }
    }
}