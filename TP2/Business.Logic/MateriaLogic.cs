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
        public Materia GetOne(int ID)
        {
            return this.MateriaData.GetOne(ID);
        }

        public void Save(Materia materia) 
        {
            this.MateriaData.Save(materia);
        }

        public void Delete(int ID)
        {
            this.MateriaData.Delete(ID);
        }

    }
}
