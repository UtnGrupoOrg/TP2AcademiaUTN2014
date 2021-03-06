﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities 
{
    public class Materia : BusinessEntity, IEquatable<Materia>
    {
        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        private int _HSSemanales;

        public int HSSemanales
        {
            get { return _HSSemanales; }
            set { _HSSemanales = value; }
        }
        private int _HSTotales;

        public int HSTotales
        {
            get { return _HSTotales; }
            set { _HSTotales = value; }
        }
        private int _IdPlan;

        public int IdPlan
        {
            get { return _IdPlan; }
            set { _IdPlan = value; }
        }
        public bool Equals(Materia materia)
        {
            if ((object)materia == null)
            {
                return false;
            }
            if (this.ID == materia.ID && this.Descripcion.Equals(materia.Descripcion)  && this._HSSemanales == materia._HSSemanales 
                && this._HSTotales==materia._HSTotales && this.IdPlan == materia.IdPlan)
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
}
