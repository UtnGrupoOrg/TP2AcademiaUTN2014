using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class formEspecialidades : Form
    {
        public formEspecialidades()
        {
            InitializeComponent();
            this.dgvEspecialidades.AutoGenerateColumns = false;
        }

        private void formEspecialidades_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void Listar()
        {
            this.dgvEspecialidades.DataSource = new EspecialidadLogic().GetAll();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            EspecialidadDesktop frmAdd = new EspecialidadDesktop(ApplicationForm.ModoForm.Alta);
            frmAdd.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvEspecialidades.SelectedRows.Count > 0)
            {
                int id = int.Parse(((DataRowView)this.dgvEspecialidades.SelectedRows[0].DataBoundItem)["ID"].ToString());
                EspecialidadDesktop frm = new EspecialidadDesktop(id, ApplicationForm.ModoForm.Modificacion);
                frm.ShowDialog();
                this.Listar();
            }

            else
            {
                MessageBox.Show("Seleccione una especialidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEspecialidades.SelectedRows.Count > 0)
            {
                
                int id = ((Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
                EspecialidadDesktop frm = new EspecialidadDesktop(id, ApplicationForm.ModoForm.Baja);
                frm.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccione una Especialidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
