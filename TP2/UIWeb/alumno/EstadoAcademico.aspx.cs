using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UIWeb.alumno
{
    public partial class EstadoAcademico : UIWeb.@baseABM
    {

        Persona alumno;
        AlumnoInscripcionLogic _logic;
        private AlumnoInscripcionLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new AlumnoInscripcionLogic();
                }
                return _logic;
            }
        }
        private AlumnoInscripcion Entity { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            alumno = (new PersonaLogic()).GetOneOfUser(UserID);
            if (!IsPostBack)
            {
                this.LoadGrid();
            }
        }

        private void LoadGrid()
        {
            grdEstadoAcadamico.SelectedIndex = -1;
            if (Logic.GetStudenState(alumno.ID) == null)
            {
                this.grdEstadoAcadamico.Visible = false;
                Response.Write("no hay inscripciones");
            }
            else
            {
                grdEstadoAcadamico.DataSource = this.Logic.GetStudenState(alumno.ID);
                grdEstadoAcadamico.DataBind();
            }
            
        }

        protected void lbtnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}