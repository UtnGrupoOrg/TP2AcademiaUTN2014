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
    public partial class formMaterias : Form
    {
        public formMaterias()
        {
            InitializeComponent();
            this.dgvMaterias.AutoGenerateColumns = false;
        }
        public void Listar()
        {
            MateriaLogic ul = new MateriaLogic();            
            this.dgvMaterias.DataSource = ul.GetAll();     
       
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
            formMateria.Planes = new PlanLogic().GetAll();
            formMateria.ShowDialog();
            this.Listar();
        }
    }
}
