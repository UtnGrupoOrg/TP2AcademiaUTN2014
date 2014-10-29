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
using System.Net.Mail;

namespace UI.Desktop
{
    public partial class AlumnoDesktop : ApplicationForm
    {
        public AlumnoDesktop()
        {
            InitializeComponent();
        }
        public Persona AlumnoActual { get; set; }
        public List<Plan> Planes { get; set; }        
        
        public AlumnoDesktop(ModoForm modo)
            :this()
        {
            this.Modo = modo;
            Planes = new PlanLogic().GetAll();
            this.cbxPlan.DataSource = Planes;
        }
        public AlumnoDesktop(ModoForm modo,Plan plan)
            : this()
        {
            this.Modo = modo;
            Planes = new List<Plan>();
            Planes.Add(plan);
            this.cbxPlan.DataSource = Planes;
            this.cbxPlan.Enabled = false;
        }
        public AlumnoDesktop(int ID,ModoForm modo)
            : this(modo)
        {
            AlumnoActual = new PersonaLogic().GetOne(ID);
            this.RecuperarDatos();
        }
        public AlumnoDesktop(int ID, ModoForm modo, Plan plan)
            : this(modo,plan)
        {
            AlumnoActual = new PersonaLogic().GetOne(ID);
            this.RecuperarDatos();
        }

        public override void RecuperarDatos()
        {
            this.txtID.Text = this.AlumnoActual.ID.ToString();
            this.txtNombre.Text = this.AlumnoActual.Nombre;
            this.txtApellido.Text = this.AlumnoActual.Apellido;
            this.txtLegajo.Text = this.AlumnoActual.Legajo;
            this.txtEmail.Text = this.AlumnoActual.Email;
            this.txtTelefono.Text = this.AlumnoActual.Telefono;
            this.txtDireccion.Text = this.AlumnoActual.Direccion;
            this.dtpNacimiento.Value = this.AlumnoActual.FechaNacimiento;
            this.cbxPlan.SelectedItem = Planes.Find(x => x.ID == AlumnoActual.IDPlan);

            if (Modo == ApplicationForm.ModoForm.Alta || Modo == ApplicationForm.ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }
            else if (Modo == ApplicationForm.ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
                this.txtNombre.ReadOnly = true;
                this.txtApellido.ReadOnly = true;
                this.txtLegajo.ReadOnly = true;
                this.txtEmail.ReadOnly = true;
                this.txtTelefono.ReadOnly = true;
                this.txtDireccion.ReadOnly = true;
                this.dtpNacimiento.Enabled = false;
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
                this.AlumnoActual = new Persona();
                this.AlumnoActual.State = Persona.States.New;
            }
            else if (Modo == ApplicationForm.ModoForm.Modificacion)
            {
                this.AlumnoActual.State = Persona.States.Modified;
                this.AlumnoActual.ID = int.Parse(this.txtID.Text);
            }
            else if (Modo == ApplicationForm.ModoForm.Baja)
            {
                this.AlumnoActual.State = Persona.States.Deleted;
            }
            else if (Modo == ApplicationForm.ModoForm.Consulta)
            {
                this.AlumnoActual.State = Persona.States.Unmodified;
            }

            if (Modo == ApplicationForm.ModoForm.Alta || Modo == ApplicationForm.ModoForm.Modificacion)
            {
                this.AlumnoActual.Nombre = this.txtNombre.Text;
                this.AlumnoActual.Apellido = this.txtApellido.Text;
                this.AlumnoActual.Legajo = this.txtLegajo.Text;
                this.AlumnoActual.Email = this.txtEmail.Text;
                this.AlumnoActual.Telefono = this.txtTelefono.Text;
                this.AlumnoActual.Direccion = this.txtDireccion.Text;
                this.AlumnoActual.FechaNacimiento = this.dtpNacimiento.Value;
                this.AlumnoActual.IDPlan = ((Plan)cbxPlan.SelectedItem).ID;
                this.AlumnoActual.TipoPersona = Persona.TiposPersonas.Alumno;
            }
        }

        public override void GuardarCambios() 
        { 
            this.MapearDatos();
            try
            {
                new PersonaLogic().Save(this.AlumnoActual);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public override bool Validar()
        {
            int temp;
            if ( String.IsNullOrEmpty(this.txtNombre.Text) || String.IsNullOrEmpty(this.txtApellido.Text)
                || String.IsNullOrEmpty(this.txtLegajo.Text) || String.IsNullOrEmpty(this.txtTelefono.Text))
            {
                Notificar("Hay campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!(Int32.TryParse(this.txtTelefono.Text, out temp)))
            {
                Notificar("Existe un error en el formato de los numeros", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                try
                {
                    new MailAddress(this.txtEmail.Text);
                }
                catch (FormatException)
                {
                    Notificar("El formato del email es incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                    return false;
                }
            }
            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                if (this.Modo == ModoForm.Baja)
                {
                    DialogResult result = MessageBox.Show("Realmente desea eliminar el alumno: " + this.txtNombre.Text, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
