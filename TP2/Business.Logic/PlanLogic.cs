using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Database;
using Business.Entities;
using System.Data;

namespace Business.Logic
{
    public class PlanLogic : BusinessLogic
    {
        private PlanAdapter _PlanData;

        public PlanAdapter PlanData
        {
            get { return _PlanData; }
            set { _PlanData = value; }
        }

        public PlanLogic()
        {
            this.PlanData = new PlanAdapter();
        }

        public List<Plan> GetAll()
        {
            return this.PlanData.GetAll();
        }

        public Plan GetOne(int ID)
        {
            return this.PlanData.GetOne(ID);
        }

        public void Save(Plan plan)
        {
            if (Validar(plan))
            {
                 this.PlanData.Save(plan);
            }
           
        }

        public void Delete(int ID)
        {
            this.PlanData.Delete(ID);
        }

        public DataTable GetAllWithEspecialidadDescription()
        {
            return this.PlanData.GetAllWithEspecialidadDescription();
        }

        public  bool Validar(Plan plan)
        {
            if (plan.State==Entities.Plan.States.New||plan.State==Entities.Plan.States.Modified)
            {
                if (String.IsNullOrEmpty(plan.Descripcion))
                {
                    throw new Exception("Hay datos vacios o incorrectos");
                }
            }
            return true;
        }
    }
}
