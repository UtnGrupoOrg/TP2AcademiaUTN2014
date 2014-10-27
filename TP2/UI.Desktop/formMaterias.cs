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
    public partial class formMaterias : Form
    {
        public formMaterias()
        {
            InitializeComponent();
            this.dgvMaterias.AutoGenerateColumns = false;
        }
        public void Listar()
        {
            try
            {
                this.dgvMaterias.DataSource = new MateriaLogic().GetAllWithPlanDescription();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void formMaterias_Load(object sender, EventArgs e)
        {
            this.Listar();
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
            MateriaDesktop formMateria = new MateriaDesktop(ApplicationForm.ModoForm.Alta);
            formMateria.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvMaterias.SelectedRows.Count > 0)
            {
                int ID = Int32.Parse(((DataRowView)this.dgvMaterias.SelectedRows[0].DataBoundItem)["id_materia"].ToString());
                MateriaDesktop formMateria = new MateriaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formMateria.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccione una materia", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvMaterias.SelectedRows.Count > 0)
            {
                int ID = Int32.Parse(((DataRowView)this.dgvMaterias.SelectedRows[0].DataBoundItem)["id_materia"].ToString());
                MateriaDesktop formMateria = new MateriaDesktop(ID, ApplicationForm.ModoForm.Baja);
                formMateria.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccione una materia", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
