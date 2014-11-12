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

namespace UIWeb.admin
{
    public partial class Personas : UIWeb.@baseABM
    {
        PersonaLogic _logic;        

        protected int? Tipo
        {
            get {
                if (ViewState["Tipo"] == null)
                {
                    return null;
                }else{
                    return Int32.Parse(ViewState["Tipo"].ToString());
                }                
            }
            set {
                ViewState["Tipo"] = value;
            }
        }

        private PersonaLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new PersonaLogic();
                }
                return _logic;
            }
        }

        private Persona Entity { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["tipo"] != null)
                {
                    Tipo = Int32.Parse(Request.QueryString["tipo"]);
                    switch ((Persona.TiposPersonas)Tipo)
                    {
                        case Persona.TiposPersonas.Alumno:
                            {
                                gridView.Columns[8].Visible = true;
                                lblPlan.Visible = true;
                                ddlPlan.Visible = true;
                                lbtnInscribir.Visible = true;
                                break;
                            }
                        case Persona.TiposPersonas.Docente:
                            {                                
                                break;
                            }
                        case Persona.TiposPersonas.Administrativo:
                            {
                                break;
                            }
                    }
                    this.LoadGrid();
                }
                else { }
            }
        }
        private void LoadGrid()
        {
            if (Tipo != null)
            {
                this.gridPanel.Visible = true;
                this.gridActionsPanel.Visible = true;
                this.gridView.DataSource = Logic.GetAllWithPlanDescription((Persona.TiposPersonas)Tipo);
                this.gridView.DataBind();
            }
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedId = (int)this.gridView.SelectedValue;
        }

        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.txtNombre.Text = this.Entity.Nombre;
            this.txtApellido.Text = this.Entity.Apellido;
            this.txtEmail.Text = this.Entity.Email;
            this.txtDireccion.Text = this.Entity.Direccion;
            this.txtTelefono.Text = this.Entity.Telefono;
            this.txtLegajo.Text = this.Entity.Legajo;
            this.txtAnio.Text = this.Entity.FechaNacimiento.Year.ToString();
            this.txtMes.Text = this.Entity.FechaNacimiento.Month.ToString();
            this.txtDia.Text = this.Entity.FechaNacimiento.Day.ToString();
            if ((Persona.TiposPersonas)Tipo == Persona.TiposPersonas.Alumno) { 
                this.ddlPlan.SelectedValue = this.Entity.IDPlan.ToString();
            }
        }

        private void LoadEntity(Persona persona)
        {
            persona.Nombre = this.txtNombre.Text;
            persona.Apellido = this.txtApellido.Text;
            persona.Email = this.txtEmail.Text;
            persona.Direccion = this.txtDireccion.Text;
            persona.Telefono = this.txtTelefono.Text;
            persona.Legajo = this.txtLegajo.Text;
            persona.FechaNacimiento = (DateTime)this.getDate();
            persona.TipoPersona = (Persona.TiposPersonas)this.Tipo;
            if ((Persona.TiposPersonas)Tipo == Persona.TiposPersonas.Alumno) { 
                persona.IDPlan = Int32.Parse(this.ddlPlan.SelectedValue);
            }
        }
        private void SaveEntity(Persona persona)
        {
            try
            {
                this.Logic.Save(persona);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void EnableForm(bool enable)
        {
            this.txtNombre.Enabled = enable;
            this.txtApellido.Enabled = enable;
            this.txtEmail.Enabled = enable;
            this.txtDireccion.Enabled = enable;
            this.txtTelefono.Enabled = enable;
            this.txtLegajo.Enabled = enable;
            this.txtAnio.Enabled = enable;
            this.txtMes.Enabled = enable;
            this.txtDia.Enabled = enable;
            if ((Persona.TiposPersonas)Tipo == Persona.TiposPersonas.Alumno)
            {
                this.ddlPlan.Enabled = enable;
            }
        }

        private void ClearForm()
        {
            this.txtNombre.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtLegajo.Text = string.Empty;
            this.txtAnio.Text = string.Empty;
            this.txtMes.Text = string.Empty;
            this.txtDia.Text = string.Empty;
        }
        protected void lbtnEditar_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.gridPanel.Visible = false;
                this.gridActionsPanel.Visible = false;
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedId);
                this.EnableForm(true);
            }
        }
        protected void lbtnEliminar_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.gridPanel.Visible = false;
                this.gridActionsPanel.Visible = false;
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedId);
                this.lbtnAceptar.Text = "Eliminar";
            }
        }

        protected void lbtnNuevo_Click(object sender, EventArgs e)
        {
            this.gridPanel.Visible = false;
            this.gridActionsPanel.Visible = false;
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        protected void lbtnAceptar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                this.Entity = new Persona();
                switch (this.FormMode)
                {
                    case FormModes.Alta:
                        {
                            this.LoadEntity(this.Entity);
                            this.Entity.State = BusinessEntity.States.New;
                            break;
                        }
                    case FormModes.Baja:
                        {
                            this.Entity.ID = this.SelectedId;
                            this.Entity.State = BusinessEntity.States.Deleted;
                            break;
                        }
                    case FormModes.Modificacion:
                        {
                            this.Entity.ID = this.SelectedId;
                            this.Entity.State = BusinessEntity.States.Modified;
                            this.LoadEntity(this.Entity);
                            break;
                        }
                }
                this.SaveEntity(this.Entity);
                this.LoadGrid();
                this.formPanel.Visible = false;


            }
        }
        protected void lbtnCancelar_Click(object sender, EventArgs e)
        {
            this.LoadGrid();
            this.formPanel.Visible = false;
        }

        protected void gridView_RowCreated1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.Cells[0].Style["display"] = "none";
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Style["display"] = "none";
                e.Row.ToolTip = "Click to select row";
                e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.gridView, "Select$" + e.Row.RowIndex);
            }
        }

        protected void validateEmail(object source, ServerValidateEventArgs args)
        {
            try
            {
                new MailAddress(args.Value.ToString());
                args.IsValid = true;
            }
            catch (FormatException)
            {
                args.IsValid = false;
            }
        }
        
        protected void validateDate(object source, ServerValidateEventArgs args)
        {
            DateTime? date = this.getDate();
            if (date != null)
            {
                if (((DateTime)date).Year <= DateTime.Today.Year && ((DateTime)date).Year > 1920)
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }
            }
            else
            {
                args.IsValid = false;
            }
        }
        protected DateTime? getDate(){
            string date = this.txtDia.Text + "/" + this.txtMes.Text + "/" + this.txtAnio.Text;
            DateTime temp;
            if (DateTime.TryParse(date, out temp))
            {
                return temp;
            }
            else
            {
                return null;
            }
            
        }

        protected void lbtnInscribir_Click(object sender, EventArgs e)
        {

        }

    }
}