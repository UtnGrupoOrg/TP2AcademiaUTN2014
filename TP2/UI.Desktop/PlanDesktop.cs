﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class PlanDesktop : ApplicationForm
    {
        public PlanDesktop()
        {
            InitializeComponent();

        }
        public Plan PlanActual { get; set; }
        public List<Especialidad> Especialidades { get; set; }
        public List<Materia> MateriasConCambios { get; set; }

        public List<Materia> Materias { get; set; }

        public PlanDesktop(ModoForm modo)
            : this()
        {
            this.Modo = modo;
            try
            {
                Especialidades = new EspecialidadLogic().GetAll();
                this.cbbEspecialidades.DataSource = Especialidades;
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Especialidades", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }          
        }        
        public PlanDesktop(int ID, ModoForm modo)
            : this(modo)
        {
            try
            {
                PlanActual = new PlanLogic().GetOne(ID);
                this.RecuperarDatos();
                Materias = new MateriaLogic().GetAllByPlan(this.PlanActual);
                this.UpdateLbMaterias(Materias);
            }
            catch (Exception e)
            {
                
                Notificar(e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void RecuperarDatos()
        {
            this.txtID.Text = this.PlanActual.ID.ToString();
            this.txtDescripcion.Text = this.PlanActual.Descripcion;
            this.cbbEspecialidades.SelectedItem = Especialidades.Find(x => x.ID == PlanActual.IDEspecialidad);

            if (Modo == ApplicationForm.ModoForm.Alta || Modo == ApplicationForm.ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }
            else if (Modo == ApplicationForm.ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
                this.txtDescripcion.ReadOnly = true;
                this.cbbEspecialidades.Enabled = false;
            }
            else if (Modo == ApplicationForm.ModoForm.Consulta)
            {
                this.btnAceptar.Text = "Aceptar";
            }


        }
        public override void MapearDatos()
        {
            if (Modo == ApplicationForm.ModoForm.Alta)
            {
                this.PlanActual = new Plan();
                this.PlanActual.State = Plan.States.New;
            }
            else if (Modo == ApplicationForm.ModoForm.Modificacion)
            {
                this.PlanActual.State = Plan.States.Modified;
                this.PlanActual.ID = int.Parse(this.txtID.Text);
            }
            else if (Modo == ApplicationForm.ModoForm.Baja)
            {
                this.PlanActual.State = Plan.States.Deleted;
            }
            else if (Modo == ApplicationForm.ModoForm.Consulta)
            {
                this.PlanActual.State = Plan.States.Unmodified;
            }

            if (Modo == ApplicationForm.ModoForm.Alta || Modo == ApplicationForm.ModoForm.Modificacion)
            {
                this.PlanActual.Descripcion = this.txtDescripcion.Text;
                this.PlanActual.IDEspecialidad= ((Especialidad)cbbEspecialidades.SelectedItem).ID;
            }


        }
        public override void GuardarCambios()
        {
            this.MapearDatos();
            try
            {
                if (this.Modo == ModoForm.Baja)
                {
                    DialogResult result = MessageBox.Show("Realmente desea eliminar el plan: " + this.txtDescripcion.Text, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        new PlanLogic().Save(this.PlanActual);
                    }
                }
                else
                {
                    if (MateriasConCambios != null)
                    {
                        foreach (Materia ma in MateriasConCambios)
                        {
                            try
                            {
                                new MateriaLogic().Save(ma);
                            }
                            catch (Exception e)
                            {

                                MessageBox.Show(e.Message, "Plan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    new PlanLogic().Save(this.PlanActual);
                }
            }
            catch (Exception e)
            {
                
                Notificar(e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }         
        }
        public override bool Validar()
        {
            if (String.IsNullOrEmpty(this.txtDescripcion.Text))
            {
                Notificar("Hay campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }            
            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                GuardarCambios();
                this.Close();
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PlanDesktop_Activated(object sender, EventArgs e)
        {
            txtDescripcion.Focus();
        }
        private void UpdateLbMaterias(List<Materia> materias)
        {
            lbMaterias.DataSource = null;
            this.lbMaterias.DataSource = materias;
            this.lbMaterias.DisplayMember = "descripcion";
        }
        private void CambiarLista(MateriaDesktop materiaDesktop){
            materiaDesktop.GuardaCambios = false;
            materiaDesktop.ShowDialog();

            if (MateriasConCambios == null)
            {
                MateriasConCambios = new List<Materia>();
            }

            Materia materiaCambiada = materiaDesktop.MateriaActual;
            if (materiaCambiada != null)
            {
                this.MateriasConCambios.Add(materiaCambiada);
                if (materiaCambiada.State == BusinessEntity.States.New)
                {
                    Materias.Add(materiaCambiada);
                }
                else if (materiaCambiada.State == BusinessEntity.States.Deleted)
                {
                    Materias.Remove(materiaCambiada);
                }
            }
            UpdateLbMaterias(Materias);
        }

        private void bntAgregar_Click(object sender, EventArgs e)
        {
            if (PlanActual != null)
            {
                MateriaDesktop materiaDesktop = new MateriaDesktop(ApplicationForm.ModoForm.Alta, PlanActual);
                CambiarLista(materiaDesktop);
            }
            else
            {
                Notificar("Debe crear el plan primero para agregar materias", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnQuitar_Click_1(object sender, EventArgs e)
        {
            Materia matSeleccionada = (Materia)lbMaterias.SelectedItem;
            MateriaDesktop materiaDesktop = new MateriaDesktop(matSeleccionada, ApplicationForm.ModoForm.Baja, PlanActual);
            CambiarLista(materiaDesktop);
        }
    }
}

