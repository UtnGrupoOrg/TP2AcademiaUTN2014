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
        private AlumnoInscripcion inscripcionActual { get; set; }

        public formInscripcion()
        {
            InitializeComponent();
        }
        public formInscripcion(Usuario usu)
            : this()
        {
            this.usu = usu;
            List<Materia> materias = new MateriaLogic().getMateriasDisponibles(usu.ID);

            if (materias.Count == 0)
            {
                MessageBox.Show("No hay materias disponibles para inscribirse", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }

            cbxMaterias.DataSource = materias; 
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
                try
                {
                    cbxComisiones.DataSource = new ComisionLogic().getAllWithMateriaAndYear(((Materia)cbxMaterias.SelectedItem).ID, DateTime.Today.Year);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Comision", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                cbxComisiones.DisplayMember = "desc_comision";
                cbxComisiones.SelectedIndex = -1;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInscribirse_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                DialogResult result = MessageBox.Show("Realmente desea inscribirse a '" + ((Materia)this.cbxMaterias.SelectedItem).Descripcion +
                "' en la comisión '" + ((DataRowView)cbxComisiones.SelectedItem)["desc_comision"].ToString() + "'", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    this.GuardarCambios();
                    this.Close();
                }
                
            }
        }

        private bool Validar()
        {
            if (this.cbxComisiones.SelectedIndex != -1 && this.cbxMaterias.SelectedIndex != -1)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Debe seleccionar una materia y comision", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private void GuardarCambios()
        {
            this.MapearDatos();
            try
            {
                new AlumnoInscripcionLogic().Save(inscripcionActual);
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Inscripcion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void MapearDatos()
        {
            inscripcionActual = new AlumnoInscripcion();
            this.inscripcionActual.State = BusinessEntity.States.New;
            this.inscripcionActual.IDAlumno = (int)usu.IdPersona;
            this.inscripcionActual.IDCurso = (int)((DataRowView)cbxComisiones.SelectedItem)["id_curso"];            
        }
    }
}
