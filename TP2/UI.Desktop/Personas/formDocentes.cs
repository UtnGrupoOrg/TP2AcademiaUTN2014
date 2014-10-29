using System;
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
    public partial class formDocentes : formPersonas
    {
        public formDocentes() 
        {
            this.InitializeComponent();            
            this.Text = "Docentes";            
        }        

        protected override void Listar()
        {
            try
            {
                this.dgvPersonas.DataSource = new PersonaLogic().GetAll(Persona.TiposPersonas.Docente);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void formDocentes_Load(object sender, EventArgs e)
        {
            this.Listar();
      
        }
        protected override void tsbNuevo_Click(object sender, EventArgs e)
        {
            DocenteDesktop formPersona = new DocenteDesktop(ApplicationForm.ModoForm.Alta);
            formPersona.ShowDialog();
            this.Listar();
        }

        protected override void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvPersonas.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
                DocenteDesktop formPersona = new DocenteDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formPersona.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccione un docente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvPersonas.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
                DocenteDesktop formPersona = new DocenteDesktop(ID, ApplicationForm.ModoForm.Baja);
                formPersona.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccione un docente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
