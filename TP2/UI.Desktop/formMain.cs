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
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }        

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formUsuarios formUsu = new formUsuarios();
            formUsu.Show();
        }

        private void materiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formMaterias formMat = new formMaterias();
            formMat.Show();
        }

        private void planesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formPlanes formPla = new formPlanes();
            formPla.Show();
        }      
    }
}
