using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UIWeb
{
    public partial class Inscripcion : baseABM
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.LoadGrid();
            }
        }

        protected void gridViewMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadGrid(){
            //this.gridViewMaterias.DataSource = this.Logic.GetAll();
            this.gridViewMaterias.DataBind();
        }
    }
}