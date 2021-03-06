﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;


namespace UIWeb.admin
{
    public partial class Comisiones : UIWeb.@baseABM
    {
        ComisionLogic _logic;
        const int START_YEAR = 1960;
        List<int> Fechas;
        List<Plan> Planes;
        
        private ComisionLogic Logic
        {
            get {
                if (_logic == null)
                {
                    _logic = new ComisionLogic();
                }
                return _logic;
            }
        }

        private Comision Entity { get;set;}
       
        private void LoadGrid()
        {
            this.gridView.Visible = true;
            this.formPanel.Visible = false;
            this.formActionsPanel.Visible = false;
            try
            {
                this.gridView.DataSource = this.Logic.GetAllWithPlanDescription();
            }
            catch (Exception e)
            {

                SetError(e.Message);
            }
            gridView.SelectedIndex = -1;
            this.gridView.DataBind();
        }

        private void LoadForm(int id)
        {
            try
            {
                Comision com = new ComisionLogic().GetOne(SelectedId);
                this.Entity = this.Logic.GetOne(id);
                this.txtDescripcion.Text = this.Entity.Descripcion;
                Plan plan = (Planes.Find(x => x.ID == com.IdPlan));
                ddlPlanes.SelectedIndex = ddlPlanes.Items.IndexOf(ddlPlanes.Items.FindByValue(plan.Descripcion));
                ddlAnioCalendario.SelectedIndex = ddlAnioCalendario.Items.IndexOf(ddlAnioCalendario.Items.FindByValue(com.AnioEspecialidad.ToString()));
                this.ddlPlanes.DataBind();
            }
            catch (Exception e)
            {
                this.SetError(e.Message);
            }
        }
        
        private void LoadEntity(Comision comision)
        {
            comision.Descripcion = this.txtDescripcion.Text;
            string busca = ddlPlanes.SelectedValue;
            comision.IdPlan = (Planes.Find(x => x.Descripcion == busca)).ID;
            comision.AnioEspecialidad = Int32.Parse(ddlAnioCalendario.SelectedValue);
        }
        private void SaveEntity(Comision comision)
        {
            try
            {
                this.Logic.Save(comision);
            }
            catch (Exception e)
            {

                this.SetError(e.Message);
            }
        }
        private void EnableForm(bool enable)
        {
            this.txtDescripcion.Enabled = enable;
            this.ddlPlanes.Enabled = enable;
            this.ddlAnioCalendario.Enabled=enable;
        }

        private void ClearForm()
        {
            this.txtDescripcion.Text = string.Empty;
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

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedId = (int)this.gridView.SelectedValue;
        }

        protected void lbtnNuevo_Click(object sender, EventArgs e)
        {
            this.gridActionsPanel.Visible = false;
            this.formPanel.Visible = true;
            this.formActionsPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.lbtnAceptar.Text = "Nuevo";
            this.ClearForm();
            this.EnableForm(true);
        }

        protected void lbtnEditar_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.gridPanel.Visible = false;
                this.gridActionsPanel.Visible = false;
                this.formPanel.Visible = true;
                this.formActionsPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.lbtnAceptar.Text = "Guardar";
                this.LoadForm(this.SelectedId);
                this.EnableForm(true);
            }
        }

        protected void lbtnEliminar_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.gridPanel.Visible = false;
                this.formPanel.Visible = true;
                this.formActionsPanel.Visible = true;
                this.gridActionsPanel.Visible = false;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedId);
                this.lbtnAceptar.Text = "Eliminar";
            }
        }

        protected void lbtnAceptar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                this.Entity = new Comision();
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
                this.gridActionsPanel.Visible = true;
                this.gridPanel.Visible = true;
            }
        }

        protected void lbtnCancelar_Click(object sender, EventArgs e)
        {
            this.LoadGrid();
            this.gridPanel.Visible = true;
            this.gridActionsPanel.Visible = true;
            this.formPanel.Visible = false;
        }

        protected void UpdatePanel_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.LoadGrid();
            }
            try
            {
                Planes = (new PlanLogic()).GetAll();
            }
            catch (Exception ex)
            {

                SetError(ex.Message);
            }
            Fechas = new List<int>();
            Fechas.AddRange(Enumerable.Range(START_YEAR, DateTime.Now.Year - START_YEAR + 1));
            this.ddlAnioCalendario.DataSource = Fechas;
            foreach (int fecha in Fechas)
            {
                this.ddlAnioCalendario.Items.Add(fecha.ToString());
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
