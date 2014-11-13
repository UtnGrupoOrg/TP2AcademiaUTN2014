using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class EspecialidadLogic : BusinessLogic
    {
        private EspecialidadAdapter _EspecialidadData;

        public EspecialidadAdapter EspecialidadData
        {
            get { return _EspecialidadData; }
            set { _EspecialidadData = value; }
        }

        public EspecialidadLogic()
        {
            this.EspecialidadData = new EspecialidadAdapter();
        }

        public List<Especialidad> GetAll()
        {
            return EspecialidadData.GetAll();
        }

        public Especialidad GetOne(int ID)
        {
            return EspecialidadData.GetOne(ID);
        }

        public void Save(Especialidad especialidad)
        {

            if (validar(especialidad))
            {
                EspecialidadData.Save(especialidad);
            }
            
        }

        public void Delete(int ID)
        {            
           EspecialidadData.Delete(ID);
        }

        private bool validar(Especialidad especialidad)
        {
            
                if (especialidad.State == Entities.Especialidad.States.New|| especialidad.State==Entities.Especialidad.States.Modified)
                {
                    if (string.IsNullOrEmpty(especialidad.Descripcion))
                    {
                        throw new Exception("Hay valores vacios");
                    }
                }   
                return true;
        }
    }
}
