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
    public partial class formPersonas : Form
    {
        public formPersonas()
        {
            InitializeComponent();
            this.dgvPersonas.AutoGenerateColumns = false;
        }

        protected virtual void Listar()
        {
            // Subclases tienen que implementar este metodo indicando el datasource de el dgvPersonas
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected virtual void tsbNuevo_Click(object sender, EventArgs e)
        {
            DocenteDesktop formPersona = new DocenteDesktop(ApplicationForm.ModoForm.Alta);
            formPersona.ShowDialog();
            this.Listar();
        }

        protected virtual void tsbEditar_Click(object sender, EventArgs e)
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
                MessageBox.Show("Seleccione una Persona", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected virtual void tsbEliminar_Click(object sender, EventArgs e)
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
                MessageBox.Show("Seleccione una Persona", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void formPersonas_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

    }
}
