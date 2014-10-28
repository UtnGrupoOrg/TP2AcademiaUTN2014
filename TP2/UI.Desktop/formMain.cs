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
    public partial class formMain : Form
    {
        public static Usuario Usuario { get; set; }
        protected Persona Persona { get; set; }

        public formMain()
        {
            InitializeComponent();            
        }
        public formMain(Usuario usuario)
            :this()
        {
            formMain.Usuario = usuario;
            Persona = new PersonaLogic().GetOne((int)Usuario.IdPersona);
        }

        private void OcultarControles()
        {
            switch (Persona.TipoPersona)
            {
                case Persona.TiposPersonas.Alumno:
                    {

                        break;
                    }
                case Persona.TiposPersonas.Docente:
                    {
                        break;
                    }
            }
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
            formInscripcion formIns = new formInscripcion(formMain.Usuario);
            if (!formIns.IsDisposed)
            {
                formIns.Show();
            }
            
        }      
    }
}
