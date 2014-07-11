using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Database;

namespace Business.Logic
{
    class CursoLogic
    {
        private CursoAdapter _CursoData;

        public CursoAdapter CursoData
        {
            get { return _CursoData; }
            set { _CursoData = value; }
        }

        public CursoLogic()
        {
            CursoData = new CursoAdapter();
        }

        public List<Business.Entities.Curso> GetAll()
        {
            return CursoData.GetAll();
        }

        public Business.Entities.Curso GetOne(int ID)
        {
            return CursoData.GetOne(ID);
        }

        public void Save(Business.Entities.Curso curso)
        {
            CursoData.Save(curso);
        }

        public void Delete(int ID)
        {
            CursoData.Delete(ID);
        }
    }
}
