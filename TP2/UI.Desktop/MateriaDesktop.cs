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
    public partial class MateriaDesktop : ApplicationForm
    {
        public Materia MateriaActual { get; set; }
        public List<Plan> Planes { get; set; }
        public bool GuardaCambios { get; set; }

        public MateriaDesktop()
        {
            InitializeComponent();
            this.GuardaCambios = true; 
        }
        public MateriaDesktop(ModoForm modo)
            :this()
        {
            this.Modo = modo;
            Planes = new PlanLogic().GetAll();
            this.cbxPlan.DataSource = Planes;
        }
        public MateriaDesktop(ModoForm modo,Plan plan)
            : this()
        {
            this.Modo = modo;
            Planes = new List<Plan>();
            Planes.Add(plan);
            this.cbxPlan.DataSource = Planes;
            this.cbxPlan.Enabled = false;
        }
        public MateriaDesktop(int ID,ModoForm modo)
            : this(modo)
        {
            MateriaActual = new MateriaLogic().GetOne(ID);
            this.RecuperarDatos();
        }
        public MateriaDesktop(int ID, ModoForm modo,Plan plan)
            : this(modo,plan)
        {
            MateriaActual = new MateriaLogic().GetOne(ID);
            this.RecuperarDatos();
        }

        public override void RecuperarDatos()
        {
            this.txtID.Text = this.MateriaActual.ID.ToString();
            this.txtDescripcion.Text = this.MateriaActual.Descripcion;
            this.txtHorasSemanales.Text = this.MateriaActual.HSSemanales.ToString();
            this.txtHorasTotales.Text = this.MateriaActual.HSTotales.ToString();
            this.cbxPlan.SelectedItem = Planes.Find(x => x.ID == MateriaActual.IdPlan);

            if (Modo == ApplicationForm.ModoForm.Alta || Modo == ApplicationForm.ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }
            else if (Modo == ApplicationForm.ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
                this.txtDescripcion.ReadOnly = true;
                this.txtHorasSemanales.ReadOnly = true;
                this.txtHorasTotales.ReadOnly = true;
                this.cbxPlan.Enabled = false;
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
                this.MateriaActual = new Materia();
                this.MateriaActual.State = Materia.States.New;
            }
            else if (Modo == ApplicationForm.ModoForm.Modificacion)
            {
                this.MateriaActual.State = Materia.States.Modified;
                this.MateriaActual.ID = int.Parse(this.txtID.Text);
            }
            else if (Modo == ApplicationForm.ModoForm.Baja)
            {
                this.MateriaActual.State = Materia.States.Deleted;
            }
            else if (Modo == ApplicationForm.ModoForm.Consulta)
            {
                this.MateriaActual.State = Materia.States.Unmodified;
            }

            if (Modo == ApplicationForm.ModoForm.Alta || Modo == ApplicationForm.ModoForm.Modificacion)
            {
                this.MateriaActual.Descripcion = this.txtDescripcion.Text;
                this.MateriaActual.HSSemanales = Int32.Parse(this.txtHorasSemanales.Text);
                this.MateriaActual.HSTotales = Int32.Parse(this.txtHorasTotales.Text);
                this.MateriaActual.IdPlan = ((Plan)cbxPlan.SelectedItem).ID;
            }
        }

        public override void GuardarCambios() 
        { 
            this.MapearDatos();
            
            if (this.GuardaCambios)
            {
                try
                {
                    new MateriaLogic().Save(this.MateriaActual);
                }
                catch (Exception e)
                {
                    
                    MessageBox.Show( e.Message, "Error" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public override bool Validar()
        {
            int temp;
            if ( String.IsNullOrEmpty(this.txtDescripcion.Text) || String.IsNullOrEmpty(this.txtHorasSemanales.Text)
                || String.IsNullOrEmpty(this.txtHorasTotales.Text))
            {
                Notificar("Hay campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if( !(Int32.TryParse(this.txtHorasSemanales.Text,out temp)) || !(Int32.TryParse(this.txtHorasTotales.Text,out temp)))
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
                    DialogResult result = MessageBox.Show("Realmente desea eliminar la materia: " + this.txtDescripcion.Text, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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

        private void MateriaDesktop_Activated(object sender, EventArgs e)
        {
            txtDescripcion.Focus();
        }
        
    }
}
