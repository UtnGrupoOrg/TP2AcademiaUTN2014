using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using System.Net.Mail;
using System.Drawing;

namespace UIWeb
{
    public partial class Inscripcion : UIWeb.@baseABM
    {        
        AlumnoInscripcionLogic _logic;

        private AlumnoInscripcionLogic Logic
        {
            get {
                if (_logic == null)
                {
                    _logic = new AlumnoInscripcionLogic();
                }
                return _logic;
            }
        }

        private AlumnoInscripcion Entity { get;set;}
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.LoadGrid();
            }
        }
        private void LoadGrid()
        {
            gridMaterias.SelectedIndex = -1;
            this.EnableGridComisiones(false);
            List<Materia> materias = new MateriaLogic().getMateriasDisponibles(this.UserID);
            if (!materias.Any())
            {
                this.SetMessage("No hay materias disponibles para inscribirse");
                this.lbtnSiguiente.Visible = false; 
            }
            this.gridMaterias.DataSource = materias;
            this.gridMaterias.DataBind();
        }
        protected void LoadComisiones(int id_materia)
        {
            gridComisiones.SelectedIndex = -1;
            this.EnableGridComisiones(true);
            this.gridComisiones.DataSource = new ComisionLogic().getAllWithMateriaAndYear(id_materia, DateTime.Today.Year);
            this.gridComisiones.DataBind();            
        }

        protected void gridMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedId = (int)this.gridMaterias.SelectedValue;            
        }
        protected void gridComisiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedId = (int)this.gridComisiones.SelectedValue;
        }
        protected void EnableGridComisiones(bool value)
        {
            this.subtit.Visible = value;
            this.gridMateriasPanel.Visible = !value;
            this.lbtnSiguiente.Visible = !value;
            this.lbtnAtras.Visible = value;
            this.lbtnInscribirse.Visible = value;
            this.gridComisionesPanel.Visible = value;
        }

        private void SaveEntity(AlumnoInscripcion inscripcion)
        {
            try
            {
                this.Logic.Save(inscripcion);                
            }
            catch (Exception e)
            {

                this.SetError(e.Message);
            }
        }
        protected void loadEntity(AlumnoInscripcion inscripcion)
        {            
            inscripcion.State = BusinessEntity.States.New;
            inscripcion.IDAlumno = new PersonaLogic().GetOneOfUser(this.UserID).ID;
            inscripcion.IDCurso = this.SelectedId;
        }
        
        protected void lbtnSiguiente_Click(object sender, EventArgs e)
        {
            ViewState["materia"] = new MateriaLogic().GetOne(this.SelectedId).Descripcion;
            LoadComisiones(this.SelectedId);            
        }

        protected void lbtnAtras_Click(object sender, EventArgs e)
        {
            this.LoadGrid();
        }
        protected void lbtnInscribirse_Click(object sender, EventArgs e)
        {
            this.Entity = new AlumnoInscripcion();
            this.loadEntity(this.Entity);
            this.SaveEntity(this.Entity);
            this.SetMessage("Te inscribiste con exito a " + ViewState["materia"] as string);
            this.LoadGrid();
        }

        protected void gridMaterias_RowCreated(object sender, GridViewRowEventArgs e)
        {
            SeleccionTabla(gridMaterias, e);
        }
        protected void gridComisiones_RowCreated(object sender, GridViewRowEventArgs e)
        {
            SeleccionTabla(gridComisiones, e);
        }

        protected void SeleccionTabla(GridView grid, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.Cells[0].Style["display"] = "none";
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Style["display"] = "none";
                e.Row.ToolTip = "Click to select row";
                e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(grid, "Select$" + e.Row.RowIndex);
            }
        }

        protected void SetError(string error){
            this.ErrorBox.Visible=true;
            this.ErrorText.Text= error;
        }
        protected void SetMessage(string message)
        {
            this.MessageBox.Visible = true;
            this.MessageText.Text = message;
        }

    }

}