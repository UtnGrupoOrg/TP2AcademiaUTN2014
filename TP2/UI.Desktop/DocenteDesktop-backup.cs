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
    public partial class DocenteDesktop : ApplicationForm
    {
        public DocenteDesktop()
        {
            InitializeComponent();
        }
        public Persona DocenteActual { get; set; }   
        
        public DocenteDesktop(ModoForm modo)
            :this()
        {
            this.Modo = modo;            
        }

        public DocenteDesktop(int ID,ModoForm modo)
            : this(modo)
        {
            DocenteActual = new PersonaLogic().GetOne(ID);
            this.RecuperarDatos();
        }

        public override void RecuperarDatos()
        {
            this.txtID.Text = this.DocenteActual.ID.ToString();
            this.txtNombre.Text = this.DocenteActual.Nombre;
            this.txtApellido.Text = this.DocenteActual.Apellido;
            this.txtLegajo.Text = this.DocenteActual.Legajo;
            this.txtEmail.Text = this.DocenteActual.Email;
            this.txtTelefono.Text = this.DocenteActual.Telefono;
            this.txtDireccion.Text = this.DocenteActual.Direccion;
            this.dtpNacimiento.Value = this.DocenteActual.FechaNacimiento;

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
                this.DocenteActual = new Persona();
                this.DocenteActual.State = Persona.States.New;
            }
            else if (Modo == ApplicationForm.ModoForm.Modificacion)
            {
                this.DocenteActual.State = Persona.States.Modified;
                this.DocenteActual.ID = int.Parse(this.txtID.Text);
            }
            else if (Modo == ApplicationForm.ModoForm.Baja)
            {
                this.DocenteActual.State = Persona.States.Deleted;
            }
            else if (Modo == ApplicationForm.ModoForm.Consulta)
            {
                this.DocenteActual.State = Persona.States.Unmodified;
            }

            if (Modo == ApplicationForm.ModoForm.Alta || Modo == ApplicationForm.ModoForm.Modificacion)
            {
                this.DocenteActual.Nombre = this.txtNombre.Text;
                this.DocenteActual.Apellido = this.txtApellido.Text;
                this.DocenteActual.Legajo = this.txtLegajo.Text;
                this.DocenteActual.Email = this.txtEmail.Text;
                this.DocenteActual.Telefono = this.txtTelefono.Text;
                this.DocenteActual.Direccion = this.txtDireccion.Text;
                this.DocenteActual.FechaNacimiento = this.dtpNacimiento.Value;
                this.DocenteActual.TipoPersona = Persona.TiposPersonas.Docente;
            }
        }

        public override void GuardarCambios() 
        { 
            this.MapearDatos();
            try
            {
                new PersonaLogic().Save(this.DocenteActual);
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
                    DialogResult result = MessageBox.Show("Realmente desea eliminar el docente: " + this.txtNombre.Text, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
