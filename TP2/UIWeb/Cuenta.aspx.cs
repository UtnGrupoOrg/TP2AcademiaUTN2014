﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using System.Net.Mail;
using System.Drawing;

namespace UIWeb
{
    public partial class Cuenta : UIWeb.@baseABM
    {
        UsuarioLogic _usuarioLogic;

        private UsuarioLogic UsuarioLogic
        {
            get
            {
                if (_usuarioLogic == null)
                {
                    _usuarioLogic = new UsuarioLogic();
                }
                return _usuarioLogic;
            }
        }
        PersonaLogic _personaLogic;       

        public PersonaLogic PersonaLogic
        {
            get
            {
                if (_personaLogic == null)
                {
                    _personaLogic = new PersonaLogic();
                }
                return _personaLogic;
            }          
        }

        private Usuario Usuario { get; set; }
        private Persona Persona { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!Page.IsPostBack)
            {                
                this.EnableForm(true);
                this.formPanel.Visible = true;
                this.LoadForm(UserID);
            }            
        }

        private void LoadForm(int id)
        {
            try
            {
                this.Usuario = this.UsuarioLogic.GetOne(id);
                this.txtNombre.Text = this.Usuario.Nombre;
                this.txtApellido.Text = this.Usuario.Apellido;
                this.txtEmail.Text = this.Usuario.Email;
                this.Persona = this.PersonaLogic.GetOne((int)this.Usuario.IdPersona);
                this.txtDireccion.Text = this.Persona.Direccion;
                this.txtTelefono.Text = this.Persona.Telefono;
                this.txtLegajo.Text = this.Persona.Legajo;
                this.txtAnio.Text = this.Persona.FechaNacimiento.Year.ToString();
                this.txtMes.Text = this.Persona.FechaNacimiento.Month.ToString();
                this.txtDia.Text = this.Persona.FechaNacimiento.Day.ToString();
            }
            catch (Exception e)
            {

                this.SetError(e.Message);
            }

        }

        private void LoadEntity()
        {
            try
            {
                this.Usuario = UsuarioLogic.GetOne(UserID);
                this.Persona = PersonaLogic.GetOne((int)Usuario.IdPersona);
                this.Usuario.State = BusinessEntity.States.Modified;
                this.Persona.State = BusinessEntity.States.Modified;
                this.Usuario.Nombre = this.txtNombre.Text;
                this.Usuario.Apellido = this.txtApellido.Text;
                this.Usuario.Email = this.txtEmail.Text;
                this.Usuario.Clave = this.txtClave.Text;
                this.Usuario.Email = this.txtEmail.Text;
                this.Persona.Nombre = this.txtNombre.Text;
                this.Persona.Apellido = this.txtApellido.Text;
                this.Persona.Email = this.txtEmail.Text;
                this.Persona.Direccion = this.txtDireccion.Text;
                this.Persona.Telefono = this.txtTelefono.Text;
                this.Persona.Legajo = this.txtLegajo.Text;
                this.Persona.FechaNacimiento = (DateTime)this.getDate();
            }
            catch (Exception e)
            {

                this.SetError(e.Message);
            }
        }
        private void SaveEntity()
        {
            try
            {
                this.UsuarioLogic.Save(this.Usuario);
                this.PersonaLogic.Save(this.Persona);
            }
            catch (Exception e)
            {

                this.SetError(e.Message);
            }
        }
        private void EnableForm(bool enable)
        {
            this.txtNombre.Enabled = enable;
            this.txtApellido.Enabled = enable;
            this.txtEmail.Enabled = enable;
            this.txtClave.Visible = enable;
            this.txtRepetirClave.Visible = enable;
            this.txtDireccion.Enabled = enable;
            this.txtTelefono.Enabled = enable;
            this.txtAnio.Enabled = enable;
            this.txtMes.Enabled = enable;
            this.txtDia.Enabled = enable;
        }      

        protected void lbtnAceptar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {              
                this.LoadEntity();
                this.SaveEntity();
                this.SetMessage("Datos actualizados");
            }
        }

        protected void validateEmail(object source, ServerValidateEventArgs args)
        {
            try
            {
                new MailAddress(args.Value.ToString());
                args.IsValid = true;
            }
            catch (FormatException)
            {
                args.IsValid = false;
            }
        }
        protected void validateDate(object source, ServerValidateEventArgs args)
        {
            DateTime? date = this.getDate();
            if (date != null)
            {
                if (((DateTime)date).Year <= DateTime.Today.Year && ((DateTime)date).Year > 1920)
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }
            }
            else
            {
                args.IsValid = false;
            }
        }
        protected DateTime? getDate()
        {
            string date = this.txtDia.Text + "/" + this.txtMes.Text + "/" + this.txtAnio.Text;
            DateTime temp;
            if (DateTime.TryParse(date, out temp))
            {
                return temp;
            }
            else
            {
                return null;
            }

        }
        protected void SetError(string error)
        {
            this.ErrorBox.Visible = true;
            this.ErrorText.Text = error;
        }
        protected void SetMessage(string message)
        {
            this.MessageBox.Visible = true;
            this.MessageText.Text = message;
        }

    }

}