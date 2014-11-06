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
    public partial class Materiass : UIWeb.@baseABM
    {
         MateriaLogic _logic;

        private MateriaLogic Logic
        {
            get {
                if (_logic == null)
                {
                    _logic = new MateriaLogic();
                }
                return _logic;
            }
        }

        private Materia Entity { get;set;}
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.LoadGrid();
            }
        }
        private void LoadGrid()
        {
            this.gridContainer.Visible = true;
            this.formPanel.Visible = false;
            this.formActionsPanel.Visible = false;
            this.grdMaterias.DataSource = this.Logic.GetAllWithPlanDescription();
            this.grdMaterias.DataBind();
        }

        private void LoadForm(int id)
        {
            Materia mat = new MateriaLogic().GetOne(SelectedId);
            this.Entity = this.Logic.GetOne(id);
            this.txtDescripcion.Text = this.Entity.Descripcion;
            this.txtHorasSemanales.Text = this.Entity.HSSemanales.ToString();
            this.txtHorasTotales.Text = this.Entity.HSTotales.ToString();
            ddlPlan.SelectedIndex = ddlPlan.Items.IndexOf(ddlPlan.Items.FindByValue(mat.IdPlan.ToString()));
            this.ddlPlan.DataBind();
        }
        
        private void LoadEntity(Materia materia)
        {
            materia.Descripcion = this.txtDescripcion.Text;
            materia.HSSemanales = Int32.Parse(txtHorasSemanales.Text);
            materia.HSTotales = Int32.Parse(txtHorasTotales.Text);
            materia.IdPlan= Int32.Parse(ddlPlan.SelectedValue);
        }
        private void SaveEntity(Materia materia)
        {
            this.Logic.Save(materia);
        }
        private void EnableForm(bool enable)
        {
            this.txtDescripcion.Enabled = enable;
            this.txtHorasSemanales.Enabled = enable;
            this.txtHorasTotales.Enabled = enable;
            this.ddlPlan.Enabled = enable;
        }

        private void ClearForm()
        {
            this.txtDescripcion.Text = string.Empty;
            this.txtHorasSemanales.Text = string.Empty;
            this.txtHorasTotales.Text = string.Empty;
        }

   
    
        protected void lbtnEditar_Click1(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.gridContainer.Visible = false;                  
                this.formPanel.Visible = true;
                this.formActionsPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedId);
                this.EnableForm(true);
            }
        }

        protected void lbtnEliminar_Click1(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.gridContainer.Visible = false;             
                this.formPanel.Visible = true;
                this.formActionsPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedId);
                this.lbtnAceptar.Text = "Eliminar";
            }
        }

        protected void lbtnNuevo_Click1(object sender, EventArgs e)
        {
            this.gridContainer.Visible = false;            
            this.formPanel.Visible = true;
            this.formActionsPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        protected void grdMaterias_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.Cells[0].Style["display"] = "none";
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Style["display"] = "none";
                e.Row.ToolTip = "Click to select row";
                e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.grdMaterias, "Select$" + e.Row.RowIndex);
            }
        }

        protected void grdMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedId = (int)this.grdMaterias.SelectedValue;
        }

        protected void lbtnCancelar_Click1(object sender, EventArgs e)
        {
            this.LoadGrid();
            this.formPanel.Visible = false;
        }

        protected void lbtnAceptar_Click1(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                this.Entity = new Materia();
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

    }
}
