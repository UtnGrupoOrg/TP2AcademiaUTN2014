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
    public partial class formDocentes : Form
    {
        public formDocentes()
        {
            InitializeComponent();
            this.dgvDocentes.AutoGenerateColumns = false;
        }

        private void Listar()
        {
            try
            {
                this.dgvDocentes.DataSource = new PersonaLogic().GetAll(Persona.TiposPersonas.Docente);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            DocenteDesktop formDocente = new DocenteDesktop(ApplicationForm.ModoForm.Alta);
            formDocente.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvDocentes.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.Persona)this.dgvDocentes.SelectedRows[0].DataBoundItem).ID;
                DocenteDesktop formDocente = new DocenteDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formDocente.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccione un Docente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvDocentes.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.Persona)this.dgvDocentes.SelectedRows[0].DataBoundItem).ID;
                DocenteDesktop formDocente = new DocenteDesktop(ID, ApplicationForm.ModoForm.Baja);
                formDocente.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccione un Docente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void formDocentes_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

    }
}
