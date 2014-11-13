using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using System.Net.Mail;
using System.Drawing;

namespace UIWeb
{
    public partial class Cursos : UIWeb.@baseABM
    {
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
        private DataTable inscripcionWithPersonaData;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.LoadCursos();
            }
        }
        private void LoadCursos()
        {
            gridViewCursos.SelectedIndex = -1;
            this.gridPanelCursos.Visible = true;            
            Persona per = null;
            try
            {
                per = new PersonaLogic().GetOneOfUser(Int32.Parse(User.Identity.Name));
            }
            catch (Exception)
            {
                
            }
            int id_persona = per.ID;
            try
            {
                DataTable tabla = new DocenteCursoLogic().GetAllWithDescription(id_persona);
                this.gridViewCursos.DataSource = tabla;
            }
            catch (Exception)
            {

                throw;
            }
            this.gridViewCursos.DataBind();

        }

        private void LoadInscriptos(int IdCurso)
        {
            this.MessageBox.Visible = false;
            GridViewInscriptos.SelectedIndex = -1;
            this.tit.InnerText = ViewState["materia"] as string+ " " + ViewState["anio"] as string;
            this.gridPanelCursos.Visible = false;
            this.gridPanelInscriptos.Visible = true;   
            DataTable tabla=null;
            try
            {
                tabla = this.Logic.GetAllOfCurso(IdCurso);
                
            }
            catch (Exception e)
            {

                this.SetError(e.Message);
            }
            if (tabla.Rows.Count == 0)
            {
                this.SetMessage("No hay alumnos inscriptos en esta comision");
                this.LoadCursos();
            }
            else
            {
                this.GridViewInscriptos.DataSource = tabla;
            }
            
            
            this.GridViewInscriptos.DataBind();

        }

        protected void gridViewCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["Curso"] = ((int)this.gridViewCursos.SelectedValue).ToString();
            ViewState["materia"] = this.gridViewCursos.SelectedRow.Cells[2].Text;
            ViewState["anio"] = this.gridViewCursos.SelectedRow.Cells[4].Text;
            LoadInscriptos((int)this.gridViewCursos.SelectedValue);
        }
        protected void GridViewInscriptos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedId = (int)this.GridViewInscriptos.SelectedValue;
            this.gridPanelInscriptos.Visible = false;
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Modificacion;
            this.LoadForm(this.SelectedId);
            this.EnableForm(false);
        }
        private void LoadForm(int id)
        {
            inscripcionWithPersonaData = this.Logic.GetOneWithPersona(id);
            this.txtNombre.Text = inscripcionWithPersonaData.Rows[0]["nombre"].ToString();
            this.txtApellido.Text = inscripcionWithPersonaData.Rows[0]["apellido"].ToString();
            this.txtLegajo.Text = inscripcionWithPersonaData.Rows[0]["legajo"].ToString();
            this.txtNota.Text = inscripcionWithPersonaData.Rows[0]["nota"].ToString();
            string condicion=null;
            if (inscripcionWithPersonaData.Rows[0]["condicion"].ToString() == "")
            {
                condicion = null;
            }
            else
            {
                condicion = inscripcionWithPersonaData.Rows[0]["condicion"].ToString();
            }

            this.ddlCondiciones.SelectedValue = condicion;
        }

        private void LoadEntity(AlumnoInscripcion inscripcion)
        {
            inscripcionWithPersonaData = this.Logic.GetOneWithPersona(inscripcion.ID);
            inscripcion.IDCurso = Int32.Parse(inscripcionWithPersonaData.Rows[0]["id_curso"].ToString());
            inscripcion.IDAlumno = Int32.Parse(inscripcionWithPersonaData.Rows[0]["id_alumno"].ToString());
            inscripcion.Condicion = ddlCondiciones.SelectedValue;
            int? nota;
            if (string.IsNullOrEmpty(this.txtNota.Text))
            {
                nota = null;
            }else{
                nota = (int?)Int32.Parse(this.txtNota.Text);
            }
            inscripcion.Nota = nota;
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
        private void EnableForm(bool enable)
        {
            this.txtNombre.Enabled = enable;
            this.txtApellido.Enabled = enable;
            this.txtLegajo.Enabled = enable;
        }

        protected void lbtnAceptar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                this.Entity = new AlumnoInscripcion();
                this.Entity.ID = this.SelectedId;
                this.Entity.State = BusinessEntity.States.Modified;
                this.LoadEntity(this.Entity);
                this.SaveEntity(this.Entity);
                this.LoadInscriptos(this.Entity.IDCurso);
                this.formPanel.Visible = false;
            }
        }
        protected void lbtnCancelar_Click(object sender, EventArgs e)
        {
            this.LoadInscriptos(Int32.Parse(ViewState["Curso"].ToString()));
            this.formPanel.Visible = false;
        }

        protected void gridViewCursos_RowCreated1(object sender, GridViewRowEventArgs e)
        {
            SeleccionTabla(gridViewCursos, e);
        } 

        protected void GridViewInscriptos_RowCreated(object sender, GridViewRowEventArgs e)
        {
            SeleccionTabla(GridViewInscriptos, e);
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
        protected void SetError(string error)
        {
            this.ErrorBox.Visible = true;
            this.ErrorText.Text = error;
        }
        protected void SetMessage(string message)
        {
            this.MessageBox.Visible = true;
            this.MessageText.Text = message;
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int numero;
            bool esNumero = int.TryParse(this.txtNota.Text,out numero);
            if (esNumero)
            {
                int num = int.Parse(this.txtNota.Text);
                if (num >= 0 && num <= 10)
                {
                    args.IsValid = true;
                }
                else args.IsValid = false;
            }
            else args.IsValid = false;
            
        }


    }

}