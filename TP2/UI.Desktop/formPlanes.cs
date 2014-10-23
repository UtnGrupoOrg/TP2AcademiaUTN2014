using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Logic;

namespace UI.Desktop
{
    public partial class formPlanes : Form
    {      

        public formPlanes()
        {
            InitializeComponent();
            this.dgvPlanes.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            PlanLogic pl = new PlanLogic();
            try
            {
                this.dgvPlanes.DataSource = pl.GetAllWithEspecialidadDescription();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void formPlanes_Load(object sender, EventArgs e)
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
            PlanDesktop planDesktop = new PlanDesktop(ApplicationForm.ModoForm.Alta);
            planDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvPlanes.SelectedRows.Count > 0)
            {
                int ID = Int32.Parse(((DataRowView)this.dgvPlanes.SelectedRows[0].DataBoundItem)["id_plan"].ToString());
                PlanDesktop planDesktop = new PlanDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                planDesktop.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccione un plan", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvPlanes.SelectedRows.Count > 0)
            {
                int ID = Int32.Parse(((DataRowView)this.dgvPlanes.SelectedRows[0].DataBoundItem)["id_plan"].ToString());
                PlanDesktop planDesktop = new PlanDesktop(ID, ApplicationForm.ModoForm.Baja);
                planDesktop.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccione un plan", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
