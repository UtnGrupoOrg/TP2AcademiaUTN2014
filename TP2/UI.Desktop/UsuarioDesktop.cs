﻿using System;
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
            this.cbbPersonas.DataSource = new PersonaLogic().GetAll();
            this.cbbPersonas.SelectedIndex = -1;
        }
        public UsuarioDesktop(int ID,ModoForm modo)
            : this(modo)
        {
            try
            {
                UsuarioActual = new UsuarioLogic().GetOne(ID);
                this.RecuperarDatos();
            }
            catch (Exception e)
            {
                
                Notificar(e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        public override void RecuperarDatos()
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtEmail.Text = this.UsuarioActual.Email;       
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.chkCambiaClave.Checked = this.UsuarioActual.CambiaClave;
            this.cbbPersonas.SelectedValue = this.UsuarioActual.IdPersona;
            if (Modo == ApplicationForm.ModoForm.Alta || Modo == ApplicationForm.ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }
            else if (Modo == ApplicationForm.ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
                this.chkHabilitado.AutoCheck = false;
                this.chkCambiaClave.AutoCheck = false;
                this.txtNombre.ReadOnly = true;
                this.txtApellido.ReadOnly = true;
                this.txtEmail.ReadOnly = true;
                this.txtClave.ReadOnly = true;
                this.txtConfirmarClave.ReadOnly = true;
                this.txtUsuario.ReadOnly = true;
                this.cbbPersonas.Enabled = false;
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
                this.UsuarioActual.CambiaClave = this.chkCambiaClave.Checked;
                this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                this.UsuarioActual.IdPersona = (int)this.cbbPersonas.SelectedValue;
            }
        }
        public override void GuardarCambios() 
        { 
            this.MapearDatos();
            try
            {
                new UsuarioLogic().Save(this.UsuarioActual);
                // Si se esta modificando el mismo usuario que tiene abierta la sesion, se modifica la propiedad en el formMain
                if (formMain.Usuario.ID == UsuarioActual.ID)
                {
                    formMain.Usuario = UsuarioActual;
                    formMain.Usuario.Clave = null;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show( e.Message, "Error" , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public override bool Validar()
        {
            if ( String.IsNullOrEmpty(this.txtNombre.Text) || String.IsNullOrEmpty(this.txtApellido.Text)
                || String.IsNullOrEmpty(this.txtUsuario.Text) || String.IsNullOrEmpty(this.txtEmail.Text) || String.IsNullOrEmpty(this.txtConfirmarClave.Text)
                || String.IsNullOrEmpty(this.txtClave.Text))
            {
                Notificar("Hay campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if(this.txtClave.Text.Length < 8)
            {
                Notificar("La contrasenia debe ser de 8 caracteres o mas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtClave.Focus();
                return false;
            }

            else if (!String.Equals(this.txtClave.Text, this.txtConfirmarClave.Text))
            {
                Notificar("Los campos de contrasenias nos son iguales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }else if(this.cbbPersonas.SelectedIndex== -1){
                Notificar("Debe seleccionar una persona", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.Aceptar();
        }
        private void UsuarioDesktop_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                this.Aceptar();
            }
        }
        private void Aceptar()
        {
            if (this.Modo == ModoForm.Baja)
            {
                DialogResult result = MessageBox.Show("Realmente desea eliminar el usuario: " + this.txtUsuario.Text, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    this.GuardarCambios();
                    this.Close();
                }
            }
            else if (this.Validar())                
            {
                this.GuardarCambios();
                this.Close();
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UsuarioDesktop_Activated(object sender, EventArgs e)
        {
            txtNombre.Focus();
        }


    }
}
