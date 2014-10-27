using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Entities;

namespace UI.Desktop
{
    public partial class formMain : Form
    {        
        private Usuario _usuario;

        public Usuario Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public formMain()
        {
            InitializeComponent();            
        }
        public formMain(Usuario usuario)
            :this()
        {
            this.Usuario = usuario;
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

        private void comisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formComisiones formCom = new formComisiones();
            formCom.Show();
        }

        private void inscripcionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formInscripcion formIns = new formInscripcion(this.Usuario);
            if (!formIns.IsDisposed)
            {
                formIns.Show();
            }
            
        }      
    }
}
