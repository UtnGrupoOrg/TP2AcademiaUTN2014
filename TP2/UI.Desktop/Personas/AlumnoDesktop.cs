using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            Planes = new PlanLogic().GetAll();
            this.cbxPlan.DataSource = Planes;
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
