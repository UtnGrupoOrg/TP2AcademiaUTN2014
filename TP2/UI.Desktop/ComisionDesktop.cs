using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class ComisionDesktop : UI.Desktop.ApplicationForm
    {
        const int START_YEAR = 1960;
        public Comision  ComisionActual { get; set; }
        private List<Plan> Planes { get; set; }
        private List<int> Fechas { get; set; }
        
        public ComisionDesktop()
        {
            InitializeComponent();
            this.ComisionActual = new Comision();
            Planes = new PlanLogic().GetAll();
            this.cbxPlanes.DataSource = Planes;
            Fechas = new List<int>();
            Fechas.AddRange(Enumerable.Range(START_YEAR, DateTime.Now.Year - START_YEAR + 1));
            this.cbxAnio.DataSource = Fechas;
        }

        public ComisionDesktop(ModoForm modo)
            : this()
        {
            this.Modo = modo;
            if (Modo == ModoForm.Alta)
            {
                this.prepararParaAlta();
            }
            else if (Modo == ModoForm.Consulta)
            {
                this.prepararParaConsulta();
            }
        }

        private void prepararParaAlta()
        {
            this.ComisionActual.State = BusinessEntity.States.New;
            
            this.btnAceptar.Text = "Guardar";
        }

        private void prepararParaConsulta()
        {
            this.ComisionActual.State = BusinessEntity.States.Unmodified;
        }

        public ComisionDesktop(int id, ModoForm modo) : this()
        {
            this.Modo = modo;
            this.ComisionActual.ID = id;
            if (Modo == ModoForm.Modificacion)
            {
                this.prepararParaModificacion();
            }
            else if (Modo == ModoForm.Baja)
            {
                this.prepararParaBaja();
            }
            this.MapearDatos();
        }

        private void prepararParaBaja()
        {
            this.ComisionActual.State = BusinessEntity.States.Deleted;
            
            this.btnAceptar.Text = "Eliminar";
            this.cbxPlanes.Enabled = false;
            this.txtDescripcion.ReadOnly = true;
            this.txtIdComision.ReadOnly = true;
            this.cbxPlanes.Enabled = false;

            this.MapearDatos();
        }

        private void prepararParaModificacion()
        {
            this.ComisionActual.State = BusinessEntity.States.Modified;
            
            this.MapearDatos();
        }

        private void ComisionDesktop_Load(object sender, EventArgs e)
        {
            
        }

        public override void MapearDatos()
        {
            Comision comi = new ComisionLogic().GetOne(this.ComisionActual.ID);
            this.txtIdComision.Text = this.ComisionActual.ID.ToString();
            this.txtDescripcion.Text = comi.Descripcion;
            this.cbxAnio.SelectedItem = Fechas.Find(x => x == comi.AnioEspecialidad);
            this.cbxPlanes.SelectedItem = Planes.Find(x => x.ID == comi.IdPlan);

        }

        public override void RecuperarDatos()
        {
            
            this.ComisionActual.Descripcion = this.txtDescripcion.Text;
            this.ComisionActual.AnioEspecialidad = (int)this.cbxAnio.SelectedItem;
            this.ComisionActual.IdPlan = ((Plan)this.cbxPlanes.SelectedItem).ID;
        }

        public override bool Validar()
        {
            if (string.IsNullOrEmpty(this.txtDescripcion.Text))
	        {
		        Notificar("Debe completar la descripcion",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
            new ComisionLogic().Save(ComisionActual);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            if (Modo == ModoForm.Baja)
            {
                this.GuardarCambios();
            }
            else if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                if (this.Validar())
                {
                    this.RecuperarDatos();
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
