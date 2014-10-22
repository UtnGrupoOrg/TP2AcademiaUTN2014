using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using System.Net.Mail;

namespace UIWeb
{
    public partial class Usuarios : System.Web.UI.Page
    {        
        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }
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
        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }
        private Usuario Entity { get;set;}
        private int SelectedId
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }
        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectedId != 0);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.LoadGrid();
            }
        }
        private void LoadGrid()
        {
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
            this.Logic.Save(usuario);
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
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedId);
            }
        }

        protected void lbtnNuevo_Click(object sender, EventArgs e)
        {
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
                switch (this.FormMode)
                {
                    case FormModes.Alta:
                        {
                            this.Entity = new Usuario();
                            this.LoadEntity(this.Entity);
                            this.Entity.State = BusinessEntity.States.New;
                            this.SaveEntity(this.Entity);
                            this.LoadGrid();
                            this.formPanel.Visible = false;
                            break;
                        }
                    case FormModes.Baja:
                        {
                            this.Entity = new Usuario();
                            this.Entity.ID = this.SelectedId;
                            this.Entity.State = BusinessEntity.States.Deleted;
                            this.SaveEntity(this.Entity);
                            this.LoadGrid();
                            this.formPanel.Visible = false;
                            break;
                        }
                    case FormModes.Modificacion:
                        {
                            this.Entity = new Usuario();
                            this.Entity.ID = this.SelectedId;
                            this.Entity.State = BusinessEntity.States.Modified;
                            this.LoadEntity(this.Entity);
                            this.SaveEntity(this.Entity);
                            this.LoadGrid();
                            this.formPanel.Visible = false;
                            break;
                        }
                    default:
                        {
                            this.LoadGrid();
                            this.formPanel.Visible = false;
                            break;
                        }
                }
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



    }

}