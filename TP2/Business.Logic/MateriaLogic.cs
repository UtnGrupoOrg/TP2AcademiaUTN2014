using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Database;
using System.Data;
using Business.Entities;

namespace Business.Logic
{
    public class MateriaLogic :BusinessLogic
    {
        private MateriaAdapter _MateriaData;

        public MateriaAdapter MateriaData
        {
            get { return _MateriaData; }
            set { _MateriaData = value; }
        }

        public MateriaLogic()
        {
            this.MateriaData = new MateriaAdapter();
        }

        public List<Materia> GetAll()
        {
            return this.MateriaData.GetAll();
        }
        public DataTable GetAllWithPlanDescription()
        {
            return this.MateriaData.GetAllWithPlanDescription();
        }
        public List<Materia> GetAllByPlan(Plan plan){
            return this.MateriaData.GetAllByPlan(plan);
        }
        public Materia GetOne(int ID)
        {
            return this.MateriaData.GetOne(ID);
        }

        public void Save(Materia materia) 
        {
            if (Validar(materia))
            {
                this.MateriaData.Save(materia);
            }
            
        }

        private bool Validar(Materia materia)
        {
            if (materia.State == Entities.Materia.States.New || materia.State == Materia.States.Modified)
            {
                if (string.IsNullOrEmpty(materia.Descripcion)||materia.HSSemanales<0||materia.HSTotales<0)
                {
                    throw new Exception("Hay campos vacios o erróneos");   
                }
            }
            return true; 
        }

        public void Delete(int ID)
        {
            this.MateriaData.Delete(ID);
        }
        // Devuelve las materias que no esten regular para un alumno

        public List<Materia> getMateriasDisponibles(int id)
        {
            List<Materia> materias = null;
            Persona persona = new PersonaLogic().GetOneOfUser(id);
            if (persona.TipoPersona == Persona.TiposPersonas.Alumno)
            {
                materias = this.MateriaData.getMateriasDisponibles(persona.ID);
            }
            return materias;
        }
        public List<Materia> getMateriasDisponiblesOfPersona(int id)
        {
            List<Materia> materias = null;
            Persona persona = new PersonaLogic().GetOne(id);
            if (persona.TipoPersona == Persona.TiposPersonas.Alumno)
            {
                materias = this.MateriaData.getMateriasDisponibles(persona.ID);
            }
            return materias;
        }
    }
}
