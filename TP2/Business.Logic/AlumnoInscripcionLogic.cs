using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class AlumnoInscripcionLogic : BusinessLogic
    {
        private AlumnoInscripcionAdapter _InscripcionData;

        public AlumnoInscripcionAdapter InscripcionData
        {
            get { return _InscripcionData; }
            set { _InscripcionData = value; }
        }

        public AlumnoInscripcionLogic()
        {
            InscripcionData = new AlumnoInscripcionAdapter();
        }
        public List<AlumnoInscripcion> GetAll()
        {
            return InscripcionData.GetAll();
        }

        public AlumnoInscripcion GetOne(int ID)
        {
            return InscripcionData.GetOne(ID);
        }

        public void Save(AlumnoInscripcion inscripciona)
        {
            InscripcionData.Save(inscripciona);
            // TODO validar si ya se terminaron los cupos
        }

        public void Delete(int ID)
        {
            this.InscripcionData.Delete(ID);            
        }
    }
}
