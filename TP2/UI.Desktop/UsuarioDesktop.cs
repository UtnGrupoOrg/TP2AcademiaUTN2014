using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        public Usuario UsuarioActual { get; set; }

        public UsuarioDesktop()
        {
            InitializeComponent();
        }
        public UsuarioDesktop(ModoForm modo)
            :this()
        {
            this.Modo = modo;
        }
        public UsuarioDesktop(int ID,ModoForm modo)
            : this(modo)
        {
            UsuarioActual = new UsuarioLogic().GetOne(ID);
            this.MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtEmail.Text = this.UsuarioActual.Email;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtConfirmarClave.Text = this.UsuarioActual.Clave;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            if (Modo == ApplicationForm.ModoForm.Alta || Modo == ApplicationForm.ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }
            else if (Modo == ApplicationForm.ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
            }
            else if (Modo == ApplicationForm.ModoForm.Consulta)
            {
                this.btnAceptar.Text = "Aceptar";
            }


        }
        public override void MapearADatos() 
        {
            if (Modo == ApplicationForm.ModoForm.Alta)
            {
                this.UsuarioActual = new Usuario();
                this.UsuarioActual.State = Usuario.States.New;
            }
            else if (Modo == ApplicationForm.ModoForm.Modificacion)
            {
                this.UsuarioActual.State = Usuario.States.Modified;
                this.UsuarioActual.ID = int.Parse(this.txtID.Text);
            }
            else if (Modo == ApplicationForm.ModoForm.Baja)
            {
                this.UsuarioActual.State = Usuario.States.Deleted;
            }
            else if (Modo == ApplicationForm.ModoForm.Consulta)
            {
                this.UsuarioActual.State = Usuario.States.Unmodified;
            }

            if (Modo == ApplicationForm.ModoForm.Alta || Modo == ApplicationForm.ModoForm.Modificacion)
            {
                this.UsuarioActual.Nombre = this.txtNombre.Text;
                this.UsuarioActual.Apellido = this.txtApellido.Text;
                this.UsuarioActual.Email = this.txtEmail.Text;
                this.UsuarioActual.Clave = this.txtClave.Text;
                this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
            }


        }
        public override void GuardarCambios() 
        { 
            this.MapearADatos();
            new UsuarioLogic().Save(this.UsuarioActual);
        }
        public override bool Validar()
        {
            if ( String.IsNullOrEmpty(this.txtNombre.Text) || String.IsNullOrEmpty(this.txtApellido.Text)
                || String.IsNullOrEmpty(this.txtUsuario.Text) || String.IsNullOrEmpty(this.txtEmail.Text) || String.IsNullOrEmpty(this.txtConfirmarClave.Text)
                || String.IsNullOrEmpty(this.txtClave.Text))
            {
                Notificar("Hay campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }else if(this.txtClave.Text.Length < 8)
            {
                Notificar("La contrasenia debe ser de 8 caracteres o mas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!String.Equals(this.txtClave.Text, this.txtConfirmarClave.Text))
            {
                Notificar("Los campos de contrasenias nos son iguales", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    return false;
                }
            }
            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
