﻿using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI.Desktop
{
    public  partial class formComision : Form
    {
        public formComision()
        {
            InitializeComponent();
            this.dgvComisiones.AutoGenerateColumns = false;
            
        }

        private void formPadreDeListas_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void Listar()
        {
            this.dgvComisiones.DataSource = (new ComisionLogic()).GetAll();
        }

        protected virtual void btActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ComisionDesktop frmAdd = new ComisionDesktop(ApplicationForm.ModoForm.Alta);
            frmAdd.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvComisiones.SelectedRows.Count > 0)
            {
                int id = ((Comision)dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                ComisionDesktop frm = new ComisionDesktop(id, ApplicationForm.ModoForm.Modificacion);
                frm.ShowDialog();
                this.Listar(); 
            }

            else
            {
                MessageBox.Show("Seleccione una comision", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvComisiones.SelectedRows.Count>0)
            {
                int id = ((Comision)dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                ComisionDesktop frm = new ComisionDesktop(id, ApplicationForm.ModoForm.Baja);
                frm.ShowDialog();
                this.Listar(); 
            }
            else
            {
                MessageBox.Show("Seleccione una comision", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }



      



    }
}
