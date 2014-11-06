﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;

namespace UIWeb.admin
{
    public partial class Cursos : baseABM
    {

        private Curso Curso { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.LoadGrid();
            }

        }

        private void LoadGrid()
        {
            formPanel.Visible = false;
            gvCursos.Visible = true;
            formActionsPanel.Visible = true;
            this.gvCursos.DataSource = new CursoLogic().GetAllWithDescription();
            this.panelGv.Visible = true;
            this.gvCursos.DataBind();
            this.gridActionsPanel.Visible = true;
            lblMensaje.Visible = false;          
            
            
        }

        protected void lbNuevo_Click(object sender, EventArgs e)
        {
            this.FormMode = FormModes.Alta;
            loadPanelAbm();
        }

        

        protected void lbEditar_Click(object sender, EventArgs e)
        {
            if (SelectedId!=0)
            {
                this.FormMode = FormModes.Modificacion;
                loadPanelAbm();
            }
            else { lblMensaje.Visible = true; }
           
        }

        protected void lbEliminar_Click(object sender, EventArgs e)
        {
            if (SelectedId!=0)
            {
                this.FormMode = FormModes.Baja;
                loadPanelAbm();
            }
            else { lblMensaje.Visible = true; }
        }

        private void loadPanelAbm()
        {
            panelGv.Visible = false;

            formPanel.Visible = true;
            lblMensaje.Visible = false;
            switch (this.FormMode)
            {
                case FormModes.Alta: this.resetForm(); this.enableForm();
                    break;
                case FormModes.Baja: this.loadForm(); this.lockForm();
                    break;
                case FormModes.Modificacion: this.loadForm(); this.enableForm();
                    break;
                default:
                    break;
            }
            
        }
        /// <summary>
        /// Bloquea el abm. esto sirve para la baja y modificacion
        /// </summary>
        private void lockForm()
        {
            
            this.txtAnioCurso.Enabled = false;
            this.txtCupo.Enabled = false;
            this.ddlComisiones.Enabled = false;
            this.ddlMaterias.Enabled = false;
        }
        /// <summary>
        /// Carga el abm con los datos del la fila seleccionada. Es para editar y eliminar.
        /// </summary>
        private void loadForm()
        {
            Curso = new CursoLogic().GetOne(SelectedId);
            txtCupo.Text = Curso.Cupo.ToString();
            txtAnioCurso.Text = Curso.AnioCalendario.ToString();
            ddlComisiones.SelectedIndex = ddlComisiones.Items.IndexOf(ddlComisiones.Items.FindByValue(Curso.IDComision.ToString()));
            ddlMaterias.SelectedIndex = ddlMaterias.Items.IndexOf(ddlMaterias.Items.FindByValue(Curso.IDMateria.ToString()));
        }
        /// <summary>
        /// Habilita la edicion de los campos del abm
        /// </summary>
        private void enableForm()
        {
            
            this.txtAnioCurso.Enabled = true;
            this.txtCupo.Enabled = true;
            this.ddlComisiones.Enabled = true;
            this.ddlMaterias.Enabled = true;
        }
        /// <summary>
        /// Limpia los campos del abm
        /// </summary>
        private void resetForm()
        {
            
            this.txtCupo.Text = "";
            this.txtAnioCurso.Text = "";
        }

        protected void gvCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedId = (int)this.gvCursos.SelectedValue;
        }

        

        private void loadCurso()
        {
            
            Curso.Cupo = int.Parse(txtCupo.Text);
            Curso.AnioCalendario = int.Parse(txtAnioCurso.Text);
            Curso.IDComision = int.Parse(ddlComisiones.SelectedValue);
            Curso.IDMateria = int.Parse(ddlMaterias.SelectedValue);
        }
        
        

        protected void gvCursos_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.Cells[0].Style["display"] = "none";
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Style["display"] = "none";
                e.Row.ToolTip = "Click to select row";
                e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.gvCursos, "Select$" + e.Row.RowIndex);
            }
        }

        protected void lbtnAceptar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                this.Curso = new Curso();
                switch (this.FormMode)
                {
                    case FormModes.Alta: this.loadCurso(); this.Curso.State = BusinessEntity.States.New;
                        break;
                    case FormModes.Baja: this.Curso.ID = this.SelectedId; this.Curso.State = BusinessEntity.States.Deleted;
                        break;
                    case FormModes.Modificacion: this.Curso.ID = SelectedId; this.Curso.State = BusinessEntity.States.Modified; this.loadCurso();
                        break;
                    default:
                        break;
                }
                new CursoLogic().Save(this.Curso);
                this.LoadGrid();
                formPanel.Visible = false;
            }
        }

        protected void lbtnCancelar_Click(object sender, EventArgs e)
        {
            this.LoadGrid();
            
        }
    }
}