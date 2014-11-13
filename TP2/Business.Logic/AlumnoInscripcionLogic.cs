using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
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

        public DataTable GetAllOfCurso(int id_curso)
        {
            return InscripcionData.GetAllOfCurso(id_curso);
        }

        public AlumnoInscripcion GetOne(int ID)
        {
            return InscripcionData.GetOne(ID);
        }

        public void Save(AlumnoInscripcion inscripciona)
        {
            InscripcionData.Save(inscripciona);
            // TODO validar si ya se terminaron los cupos
            // TODO validar que los campos de la condicion sean libre o regular
            // TODO validar que el alumno no este inscripto a ese curso
        }

        public void Delete(int ID)
        {
            this.InscripcionData.Delete(ID);            
        }

        public DataTable GetOneWithPersona(int id)
        {
            return this.InscripcionData.GetOneWithPersona(id);
        }

        public DataTable GetStudenState(int id)
        {
            return this.InscripcionData.GetStudentState(id);
        }
    }
}
