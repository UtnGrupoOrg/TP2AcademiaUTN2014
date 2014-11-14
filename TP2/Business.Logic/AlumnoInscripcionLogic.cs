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

        public void Save(AlumnoInscripcion inscripcion)
        {
            // Validar que no se pueda agregar una inscripcion que ya tenga la misma persona y mismo curso
            InscripcionData.Save(inscripcion);            
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
