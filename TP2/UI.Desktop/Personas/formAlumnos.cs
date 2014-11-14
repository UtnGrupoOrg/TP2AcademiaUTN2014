using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class formAlumnos : formPersonas
    {
        public formAlumnos() 
        {
            this.InitializeComponent();            
            this.Text = "Alumnos";            
        }        

        protected override void Listar()
        {
            try
            {
                this.dgvPersonas.DataSource = new PersonaLogic().GetAllWithPlanDescription();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void formAlumnos_Load(object sender, EventArgs e)
        {
            this.Listar();
      
        }
        protected override void tsbNuevo_Click(object sender, EventArgs e)
        {
            AlumnoDesktop formPersona = new AlumnoDesktop(ApplicationForm.ModoForm.Alta);
            formPersona.ShowDialog();
            this.Listar();
        }
        protected override void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvPersonas.SelectedRows.Count > 0)
            {
                int ID = Int32.Parse(((DataRowView)this.dgvPersonas.SelectedRows[0].DataBoundItem)["id_persona"].ToString());
                AlumnoDesktop formAlumno = new AlumnoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formAlumno.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccione un Alumno", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvPersonas.SelectedRows.Count > 0)
            {
                int ID = Int32.Parse(((DataRowView)this.dgvPersonas.SelectedRows[0].DataBoundItem)["id_persona"].ToString());
                AlumnoDesktop formAlumno = new AlumnoDesktop(ID, ApplicationForm.ModoForm.Baja);
                formAlumno.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccione un Alumno", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
