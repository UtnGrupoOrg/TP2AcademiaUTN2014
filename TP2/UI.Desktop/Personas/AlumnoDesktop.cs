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
    public partial class AlumnoDesktop : PersonaDesktop
    {
        public List<Plan> Planes { get; set; } 

        public AlumnoDesktop() 
        {
            this.InitializeComponent();
        }
        public AlumnoDesktop(ModoForm modo)
            : this()
        {
            this.Modo = modo;
            try
            {
                Planes = new PlanLogic().GetAll();
                this.cbxPlan.DataSource = Planes;
            }
            catch (Exception e)
            {

               MessageBox.Show(e.Message,"Alumno", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        public AlumnoDesktop(int ID,ModoForm modo)
            : this(modo)
        {
            PersonaActual = new PersonaLogic().GetOne(ID);
            this.RecuperarDatos();
        }

        public override void RecuperarDatos()
        {
            base.RecuperarDatos();
            this.cbxPlan.SelectedItem = Planes.Find(x => x.ID == PersonaActual.IDPlan);
            if (Modo == ApplicationForm.ModoForm.Baja)
            {
                this.cbxPlan.Enabled = false;
            }
        }

        public override void MapearDatos()
        {
 	         base.MapearDatos();
             if (Modo == ApplicationForm.ModoForm.Alta || Modo == ApplicationForm.ModoForm.Modificacion)
             {
                 this.PersonaActual.IDPlan = ((Plan)cbxPlan.SelectedItem).ID;
                 this.PersonaActual.TipoPersona = Persona.TiposPersonas.Alumno;
             }
        }
    }
}
