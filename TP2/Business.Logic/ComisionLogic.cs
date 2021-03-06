﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Database;
using Business.Entities;
using System.Data;


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
            if (validar(comision))
            {
                this.ComisionData.Save(comision);
            }
            
        }

        public void Update(Comision comi)
        {
            this.ComisionData.Update(comi);
        }

        public DataTable GetAllWithPlanDescription()
        {
            return this.ComisionData.GetAllWithPlanDescription();
        }

        public DataTable getAllWithMateriaAndYear(int id_materia, int anio)
        {
            return this.ComisionData.getAllWithMateriaAndYear(id_materia, anio);
        }

        public bool validar(Comision comision)
        {
            if (comision.State==Entities.Comision.States.New||comision.State==Entities.Comision.States.Modified)
            {
                if (string.IsNullOrEmpty(comision.Descripcion)|| !Enumerable.Range(1960,2050).Contains(comision.AnioEspecialidad))
                {
                    throw new Exception("Hay datos vacios o erróneos");
                }
            }
            return true;
        }
    }
}
