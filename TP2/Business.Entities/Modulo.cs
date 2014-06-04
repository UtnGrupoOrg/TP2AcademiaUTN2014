using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Modulo : BusinessEntity
    {
        private int _Descripcion;

        public int Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
    }
}
