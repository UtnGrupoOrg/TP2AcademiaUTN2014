using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;

namespace UI.Desktop
{
    public partial class DocenteDesktop : PersonaDesktop
    {
        public DocenteDesktop() :base()
        {
            
        }
        public DocenteDesktop(ModoForm modo)
            : base(modo)
        {

        }
        public DocenteDesktop(int ID,ModoForm modo)
            : base(ID,modo)
        {

        }

        public override void MapearDatos()
        {
 	         base.MapearDatos();
             if (Modo == ApplicationForm.ModoForm.Alta || Modo == ApplicationForm.ModoForm.Modificacion)
             {                 
                 this.PersonaActual.TipoPersona = Persona.TiposPersonas.Docente;
             }
        }
    }
}
