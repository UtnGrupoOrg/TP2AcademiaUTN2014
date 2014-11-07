using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class EspecialidadDesktop : UI.Desktop.ApplicationForm
    {
        public Especialidad EspecialidadActual { get; set; }
        
        public EspecialidadDesktop()
        {
            InitializeComponent();
            this.EspecialidadActual = new Especialidad();
        }

        public EspecialidadDesktop(ModoForm modo)
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

        public EspecialidadDesktop(int id, ModoForm modo) : this()
        {
            this.Modo = modo;
            this.EspecialidadActual.ID = id;
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
            this.EspecialidadActual.State = BusinessEntity.States.Deleted;

            this.btnAceptar.Text = "Eliminar";
            this.txtIDEspecialidad.Enabled = false;
            this.txtNombreEspecialidad.Enabled = false;

            this.MapearDatos();
        }

        private void prepararParaModificacion()
        {
            this.EspecialidadActual.State = BusinessEntity.States.Modified;

            this.MapearDatos();
        }

        private void prepararParaConsulta()
        {
            this.EspecialidadActual.State = BusinessEntity.States.Unmodified;
        }

        private void prepararParaAlta()
        {
            this.EspecialidadActual.State = BusinessEntity.States.New;
            btnAceptar.Text = "Guardar";
        }

        public override void MapearDatos()
        {
            Especialidad esp = new EspecialidadLogic().GetOne(this.EspecialidadActual.ID);
            this.txtIDEspecialidad.Text = this.EspecialidadActual.ID.ToString();
            this.txtNombreEspecialidad.Text = this.EspecialidadActual.Descripcion;
            
        }

        public override void RecuperarDatos()
        {
            this.EspecialidadActual.Descripcion = this.txtNombreEspecialidad.Text;
        }

        public override bool Validar()
        {
            if (string.IsNullOrWhiteSpace(this.txtNombreEspecialidad.Text))
            {
                Notificar("Debe seleccionar alguna Especialidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public override void GuardarCambios()
        {
            new EspecialidadLogic().Save(this.EspecialidadActual);
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
