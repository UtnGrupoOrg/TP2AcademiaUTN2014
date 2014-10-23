﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Comision : BusinessEntity
    {
        private int _idComision;

        public int IdComision
        {
            get { return _idComision; }
            set { _idComision = value; }
        }
        
        private int _AnioEspecialidad;

        public int AnioEspecialidad
        {
            get { return _AnioEspecialidad; }
            set { _AnioEspecialidad = value; }
        }
        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        private int _IDPlan;

        public int IdPlan
        {
            get { return _IDPlan; }
            set { _IDPlan = value; }
        }
    }
}
