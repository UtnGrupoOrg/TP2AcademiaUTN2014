using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Data.Database;

namespace Business.Logic
{
    public class DocenteCursoLogic
    {
        private DocenteCursoAdapter _DocenteCursoData;

        public DocenteCursoAdapter DocenteCursoData
        {
            get { return _DocenteCursoData; }
            set { _DocenteCursoData = value; }
        }
        public DocenteCursoLogic()
        {
            this.DocenteCursoData = new DocenteCursoAdapter();
        }

        public DataTable GetAllWithDescription(int ID)
        {
            return DocenteCursoData.GetAllWithDescription(ID);
        }
    }
}
