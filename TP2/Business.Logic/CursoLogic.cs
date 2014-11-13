using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Database;
using System.Data;

namespace Business.Logic
{
    public class CursoLogic
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
            if (Validar(curso))
            {
                CursoData.Save(curso);
            }
            
        }

        private bool Validar(Entities.Curso curso)
        {
            if (curso.State==Entities.Curso.States.New||curso.State==Entities.Curso.States.Modified)
            {
                if (curso.Cupo<0|| !Enumerable.Range(1960,2050).Contains(curso.AnioCalendario))
                {
                    throw new Exception("Hay campos vacios o erroneos");
                }
            }
            return true;
        }

        public DataTable GetAllWithDescription()
        {
            return CursoData.GetAllWithDescription();
        }
        public void Delete(int ID)
        {
            CursoData.Delete(ID);
        }
    }
}
