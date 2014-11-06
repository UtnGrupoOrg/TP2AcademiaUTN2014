using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Business.Logic;


namespace UIWeb
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lbtnCuenta.Text = (new UsuarioLogic().GetOne(Int32.Parse(HttpContext.Current.User.Identity.Name.ToString()))).NombreUsuario;
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}