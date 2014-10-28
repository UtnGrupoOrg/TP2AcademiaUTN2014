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
    public partial class formAlumnos : Form
    {
        public formAlumnos()
        {
            InitializeComponent();
            this.dgvAlumnos.AutoGenerateColumns = false;
        }



        private void formAlumnos_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void Listar()
        {
            try
            {
                this.dgvAlumnos.DataSource = new PersonaLogic().GetAllWithPlanDescription();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
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
            AlumnoDesktop formAlumno = new AlumnoDesktop(ApplicationForm.ModoForm.Alta);
            formAlumno.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvAlumnos.SelectedRows.Count > 0)
            {
                int ID = Int32.Parse(((DataRowView)this.dgvAlumnos.SelectedRows[0].DataBoundItem)["id_persona"].ToString());
                AlumnoDesktop formAlumno = new AlumnoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formAlumno.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccione una Alumno", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvAlumnos.SelectedRows.Count > 0)
            {
                int ID = Int32.Parse(((DataRowView)this.dgvAlumnos.SelectedRows[0].DataBoundItem)["id_persona"].ToString());
                AlumnoDesktop formAlumno = new AlumnoDesktop(ID, ApplicationForm.ModoForm.Baja);
                formAlumno.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccione una Alumno", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
