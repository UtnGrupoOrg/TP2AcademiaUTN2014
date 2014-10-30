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
    public partial class CursoDesktop : ApplicationForm
    {
        public Curso cursoActual { get; set; }
        private List<Materia> materias;
        private List<Comision> comisiones;
        public bool GuardaCambios { get; set; }

        public CursoDesktop()
        {
            InitializeComponent();
            materias = new MateriaLogic().GetAll();
            this.cbxMaterias.DataSource = materias;
            comisiones = new ComisionLogic().GetAll();
            this.cbxComision.DataSource = comisiones;
            this.GuardaCambios = true;
        }

        public CursoDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
            this.txtAnio.Text = DateTime.Now.Year.ToString();
        }

        public CursoDesktop(int ID, ModoForm modo):this()
        {
            this.Modo = modo;
            CursoLogic curso = new CursoLogic();
            cursoActual= curso.GetOne(ID);
            this.MapearDeDatos(); 
        }

        private void MapearDeDatos()
        {
            this.txtIdCurso.Text = cursoActual.ID.ToString();
            this.txtAnio.Text = cursoActual.AnioCalendario.ToString();
            this.cbxMaterias.SelectedItem = materias.Find(x => x.ID == cursoActual.IDMateria);
            this.cbxComision.SelectedItem = comisiones.Find(x => x.ID == cursoActual.IDComision);
            this.txtCupo.Text = cursoActual.Cupo.ToString();
            if (Modo == ApplicationForm.ModoForm.Alta || Modo == ApplicationForm.ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }
            else if (Modo == ApplicationForm.ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
                this.txtCupo.ReadOnly = true;
                this.cbxComision.Enabled = false;
                this.cbxMaterias.Enabled = false;
            }
            else if (Modo == ApplicationForm.ModoForm.Consulta)
            {
                this.btnAceptar.Text = "Aceptar";
            }
        }
        public override void MapearDatos()
        {
            if (Modo == ApplicationForm.ModoForm.Alta)
            {
                this.cursoActual = new Curso();
                this.cursoActual.State = Curso.States.New;
                this.txtAnio.Text =DateTime.Now.Year.ToString();
            }
            else if (Modo == ApplicationForm.ModoForm.Modificacion)
            {
                this.cursoActual.State = Curso.States.Modified;
                this.cursoActual.ID = int.Parse(this.txtIdCurso.Text);
            }
            else if (Modo == ApplicationForm.ModoForm.Baja)
            {
                this.cursoActual.State = Curso.States.Deleted;
            }
            else if (Modo == ApplicationForm.ModoForm.Consulta)
            {
                this.cursoActual.State = Materia.States.Unmodified;
            }

            if (Modo == ApplicationForm.ModoForm.Alta || Modo == ApplicationForm.ModoForm.Modificacion)
            {
                this.cursoActual.AnioCalendario = Int32.Parse(this.txtAnio.Text);
                this.cursoActual.Cupo = Int32.Parse(this.txtCupo.Text);
                this.cursoActual.IDComision = ((Comision)cbxComision.SelectedItem).ID;
                this.cursoActual.IDMateria = ((Materia)cbxMaterias.SelectedItem).ID;
            }
        }
        public override void GuardarCambios()
        {
            this.MapearDatos();

            if (this.GuardaCambios)
            {
                new CursoLogic().Save(this.cursoActual);
            }
        }

        public override bool Validar()
        {
            int temp;
            if (String.IsNullOrEmpty(this.txtCupo.Text))
            {
                Notificar("Hay campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!(Int32.TryParse(this.txtCupo.Text, out temp)))
            {
                Notificar("Existe un error en el formato de los numeros", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                if (this.Modo == ModoForm.Baja)
                {
                    DialogResult result = MessageBox.Show("Realmente desea eliminar el curso " , this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        this.GuardarCambios();
                    }
                }
                else
                {
                    this.GuardarCambios();
                }
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
     
    }
}
