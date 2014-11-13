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
            MostrarControles();
        }

        private void MostrarControles()
        {
            switch (Persona.TipoPersona)
            {
                case Persona.TiposPersonas.Alumno:
                    {
                        this.inscripcionToolStripMenuItem.Visible = true;
                        break;
                    }
                case Persona.TiposPersonas.Administrativo:
                    {
                        this.usuariosToolStripMenuItem.Visible = true;
                        this.materiasToolStripMenuItem.Visible = true;
                        this.planesToolStripMenuItem.Visible = true;
                        this.comisionesToolStripMenuItem.Visible = true;
                        this.alumnosToolStripMenuItem.Visible = true;
                        this.docentesToolStripMenuItem.Visible = true;
                        this.especialidadesToolStripMenuItem.Visible = true;
                        this.cursosToolStripMenuItem.Visible = true;
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

        private void alumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formAlumnos formAlu = new formAlumnos();
            formAlu.Show();
        }

        private void docentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formDocentes formDoc = new formDocentes();
            formDoc.Show();
        }

        private void cursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formCursos formCursos = new formCursos();
            formCursos.Show();
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formEspecialidades formEspecialidades = new formEspecialidades();
            formEspecialidades.Show();
        }      
    }
}
