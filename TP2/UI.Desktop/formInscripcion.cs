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
    public partial class formInscripcion : Form
    {
        private Usuario usu;

        public formInscripcion()
        {
            InitializeComponent();
        }
        public formInscripcion(Usuario usu)
            : this()
        {
            this.usu = usu;
            cbxMaterias.DataSource = new MateriaLogic().getMateriasDisponibles(usu.ID);     
            cbxMaterias.SelectedIndex = -1;
        }

        private void cbxMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxMaterias.SelectedIndex == -1)
            {
                cbxComisiones.DataSource = null;
            }
            else
            {                
                cbxComisiones.DataSource = new ComisionLogic().getAllWithMateriaAndYear(((Materia)cbxMaterias.SelectedItem).ID, DateTime.Today.Year);
                cbxComisiones.DisplayMember = "descripcion";
                cbxComisiones.SelectedIndex = -1;
            }
        }
    }
}
