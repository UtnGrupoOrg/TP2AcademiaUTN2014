using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class ComisionDesktop : UI.Desktop.ApplicationForm
    {

        public Comision  ComisionActual { get; set; }
        public List<Plan> Planes { get; set; }
        
        public ComisionDesktop()
        {
            InitializeComponent();
            

        }

        public ComisionDesktop(ModoForm modo)
            : this()
        {
            this.Modo = modo;
            this.Planes = new PlanLogic().GetAll();
            this.cbxPlanes.DataSource = Planes;
            this.cbxPlanes.DisplayMember = "Descripcion";
        }

        public ComisionDesktop(int id, ModoForm modo) : this()
        {
            this.Modo = modo;
            this.ComisionActual = new ComisionLogic().GetOne(id);
            this.Planes = new PlanLogic().GetAll();
            this.cbxPlanes.DataSource = Planes;
            this.cbxPlanes.DisplayMember = "Descripcion";
            this.MapearADatos();
        }

        private void ComisionDesktop_Load(object sender, EventArgs e)
        {
            
        }

        public override void MapearADatos()
        {
            
            this.txtIdComision.Text = ComisionActual.ID.ToString(); 
            this.txtAnioEspecialidad.Text = ComisionActual.AnioEspecialidad.ToString() ;
            this.txtDescripcion.Text = ComisionActual.Descripcion;
            this.cbxPlanes.SelectedItem = Planes.Find(x => x.ID == ComisionActual.IdPlan);
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
	        {
		        this.btnAceptar.Text ="Guardar";
	        }
            else if (Modo == ModoForm.Baja)
	        {
		        this.btnAceptar.Text = "Eliminar";
                this.txtAnioEspecialidad.ReadOnly = true;
                this.txtDescripcion.ReadOnly = true;
                this.cbxPlanes.Enabled = false;
	        } 
            else if (Modo == ModoForm.Consulta)
	        {
		        this.btnAceptar.Text = "Aceptar";
	        }

        }

        public override void MapearDeDatos()
        {
             if (Modo == ApplicationForm.ModoForm.Alta)
            {
                this.ComisionActual = new Comision();
                this.ComisionActual.State = BusinessEntity.States.New;
            }
            else if (Modo == ApplicationForm.ModoForm.Modificacion)
            {
                this.ComisionActual.State = Materia.States.Modified;
                this.ComisionActual.ID = int.Parse(this.txtIdComision.Text);
            }
            else if (Modo == ApplicationForm.ModoForm.Baja)
            {
                this.ComisionActual.State = Materia.States.Deleted;
            }
            else if (Modo == ApplicationForm.ModoForm.Consulta)
            {
                this.ComisionActual.State = Materia.States.Unmodified;
            }

            if (Modo == ApplicationForm.ModoForm.Alta || Modo == ApplicationForm.ModoForm.Modificacion)
            {
                this.ComisionActual.Descripcion = this.txtDescripcion.Text;
                this.ComisionActual.AnioEspecialidad = int.Parse(this.txtAnioEspecialidad.Text);
                this.ComisionActual.IdPlan = ((Plan)cbxPlanes.SelectedItem).ID;
            }
        }

        public override bool Validar()
        {
            int temp;
            if (string.IsNullOrEmpty(this.txtDescripcion.Text))
	        {
		        Notificar("Debe completar la descripcion",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
	        }
            if (!(int.TryParse(this.txtAnioEspecialidad.Text,out temp)) || temp<1900)
	        {
                Notificar("Verifique el año de especialidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
	        }
            if (cbxPlanes.SelectedIndex == -1)
            {
                Notificar("Debe seleccionar algun Plan" ,MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public override void GuardarCambios()
        {
            if (Modo == ModoForm.Alta)
            {
                this.MapearDeDatos();
                new ComisionLogic().Save(this.ComisionActual); 
            }
            else if (Modo == ModoForm.Modificacion)
            {
                new ComisionLogic().Update(ComisionActual);
            }
            else if (Modo == ModoForm.Baja)
            {
                new ComisionLogic().Delete(ComisionActual.ID);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                if (this.Validar())
                {
                    this.GuardarCambios();
                }
            }
            if (Modo == ModoForm.Baja)
            {
                DialogResult result = MessageBox.Show("Realmente desea eliminar la comision: " + this.txtDescripcion.Text, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    this.GuardarCambios();
                }
            }
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
