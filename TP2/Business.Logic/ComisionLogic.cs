using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class ComisionLogic :BusinessLogic
    {

        private ComisionAdapter _ComisionData;

        public ComisionAdapter ComisionData
        {
            get { return _ComisionData; }
            set { _ComisionData = value; }
        }

        public ComisionLogic()
        {
            this.ComisionData = new ComisionAdapter();
        }

        public List<Comision> GetAll()
        {
            return this.ComisionData.GetAll();
        }

        public Comision GetOne(int ID)
        {
            return this.ComisionData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            this.ComisionData.Delete(ID);
        }

        public void Save(Comision comision)
        {
            this.ComisionData.Save(comision);
        }
    }
}
