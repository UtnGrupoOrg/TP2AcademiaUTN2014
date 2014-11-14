using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;
using System.Net.Mail;

namespace UIWeb.admin
{
    public partial class Planes : baseABM
    {
         PlanLogic _logic;

        private PlanLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new PlanLogic();
                }
                return _logic;
            }
        }

        private Plan Entity { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.LoadGrid();
            }
        }
        private void LoadGrid()
        {
            this.gridPanel.Visible = true;
            this.gridActionsPanel.Visible = true;
            this.lblMensaje.Visible = false;
            try
            {
                this.gridView.DataSource = this.Logic.GetAllWithEspecialidadDescription();
            }
            catch (Exception e)
            {

                this.SetError(e.Message);
            }
            gridView.SelectedIndex = -1;
            this.gridView.DataBind();
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedId = (int)this.gridView.SelectedValue;
        }

        private void LoadForm(int id)
        {
            try
            {
                this.Entity = this.Logic.GetOne(id);
            }
            catch (Exception e)
            {

                this.SetError(e.Message);
            }
            this.txtPlan.Text = this.Entity.Descripcion;
            this.ddlEspecialidad.SelectedIndex = this.ddlEspecialidad.Items.IndexOf(ddlEspecialidad.Items.FindByValue(Entity.IDEspecialidad.ToString()));
        }

        private void LoadEntity(Plan entity)
        {
            entity.Descripcion = this.txtPlan.Text;
            entity.IDEspecialidad = int.Parse(ddlEspecialidad.SelectedValue);
        }
        private void SaveEntity(Plan entity)
        {
            try
            {
                this.Logic.Save(entity);
            }
            catch (Exception e)
            {

                this.SetError(e.Message);
            }
        }
        private void EnableForm(bool enable)
        {
            this.txtPlan.Enabled = true;
            this.ddlEspecialidad.Enabled = true;
        }

        private void ClearForm()
        {
            this.txtPlan.Text = string.Empty;
        }
        protected void lbtnEditar_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.gridPanel.Visible = false;
                this.gridActionsPanel.Visible = false;
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.lbtnAceptar.Text = "Guardar";
                this.LoadForm(this.SelectedId);
                this.EnableForm(true);
            }
            else { lblMensaje.Visible = true; }
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
            else { lblMensaje.Visible = true; }
        }

        protected void lbtnNuevo_Click(object sender, EventArgs e)
        {
            this.gridPanel.Visible = false;
            this.gridActionsPanel.Visible = false;
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.lbtnAceptar.Text = "Nuevo";
            this.ClearForm();
            this.EnableForm(true);
        }

        protected void lbtnAceptar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                this.Entity = new Plan();
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
    }
}