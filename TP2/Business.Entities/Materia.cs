using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Materia : BusinessEntity
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
    }
}
