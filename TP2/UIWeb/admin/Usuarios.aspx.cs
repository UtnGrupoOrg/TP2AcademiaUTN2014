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
    public partial class Usuarios : UIWeb.@baseABM
    {        
        UsuarioLogic _logic;

        private UsuarioLogic Logic
        {
            get {
                if (_logic == null)
                {
                    _logic = new UsuarioLogic();
                }
                return _logic;
            }
        }

        private Usuario Entity { get;set;}
       
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
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
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
            this.ckxHabilitado.Checked = this.Entity.Habilitado;
            this.txtNombreUsuario.Text = this.Entity.NombreUsuario;
        }
        
        private void LoadEntity(Usuario usuario)
        {
            usuario.Nombre = this.txtNombre.Text;
            usuario.Apellido = this.txtApellido.Text;
            usuario.NombreUsuario = this.txtNombreUsuario.Text;
            usuario.Email = this.txtEmail.Text;
            usuario.Clave = this.txtClave.Text;
            usuario.Habilitado = this.ckxHabilitado.Checked;
        }
        private void SaveEntity(Usuario usuario)
        {
            try
            {
                this.Logic.Save(usuario);
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
            this.txtNombreUsuario.Enabled = enable;
            this.txtClave.Visible = enable;
            this.lblClave.Visible = enable;
            this.txtRepetirClave.Visible = enable;
            this.lblRepetirClave.Visible = enable;
        }

        private void ClearForm()
        {
            this.txtNombre.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.ckxHabilitado.Checked = false;
            this.txtNombreUsuario.Text = string.Empty;
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
                this.Entity = new Usuario();
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

    }

}