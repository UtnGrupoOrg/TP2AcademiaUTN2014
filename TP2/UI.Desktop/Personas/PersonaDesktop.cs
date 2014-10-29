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
    public partial class PersonaDesktop : ApplicationForm
    {
        public PersonaDesktop()
        {
            InitializeComponent();
        }
        public Persona PersonaActual { get; set; }   
        
        public PersonaDesktop(ModoForm modo)
            :this()
        {
            this.Modo = modo;            
        }

        public PersonaDesktop(int ID,ModoForm modo)
            : this(modo)
        {
            PersonaActual = new PersonaLogic().GetOne(ID);
            this.RecuperarDatos();
        }

        public override void RecuperarDatos()
        {
            this.txtID.Text = this.PersonaActual.ID.ToString();
            this.txtNombre.Text = this.PersonaActual.Nombre;
            this.txtApellido.Text = this.PersonaActual.Apellido;
            this.txtLegajo.Text = this.PersonaActual.Legajo;
            this.txtEmail.Text = this.PersonaActual.Email;
            this.txtTelefono.Text = this.PersonaActual.Telefono;
            this.txtDireccion.Text = this.PersonaActual.Direccion;
            this.dtpNacimiento.Value = this.PersonaActual.FechaNacimiento;

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
                this.PersonaActual = new Persona();
                this.PersonaActual.State = Persona.States.New;
            }
            else if (Modo == ApplicationForm.ModoForm.Modificacion)
            {
                this.PersonaActual.State = Persona.States.Modified;
                this.PersonaActual.ID = int.Parse(this.txtID.Text);
            }
            else if (Modo == ApplicationForm.ModoForm.Baja)
            {
                this.PersonaActual.State = Persona.States.Deleted;
            }
            else if (Modo == ApplicationForm.ModoForm.Consulta)
            {
                this.PersonaActual.State = Persona.States.Unmodified;
            }

            if (Modo == ApplicationForm.ModoForm.Alta || Modo == ApplicationForm.ModoForm.Modificacion)
            {
                this.PersonaActual.Nombre = this.txtNombre.Text;
                this.PersonaActual.Apellido = this.txtApellido.Text;
                this.PersonaActual.Legajo = this.txtLegajo.Text;
                this.PersonaActual.Email = this.txtEmail.Text;
                this.PersonaActual.Telefono = this.txtTelefono.Text;
                this.PersonaActual.Direccion = this.txtDireccion.Text;
                this.PersonaActual.FechaNacimiento = this.dtpNacimiento.Value;                
            }
        }

        public override void GuardarCambios() 
        { 
            this.MapearDatos();
            try
            {
                new PersonaLogic().Save(this.PersonaActual);
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
                    DialogResult result = MessageBox.Show("Realmente desea eliminar la persona: " + this.txtNombre.Text, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
