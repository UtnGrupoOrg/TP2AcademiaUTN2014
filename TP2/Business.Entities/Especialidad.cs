using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Especialidad : BusinessEntity
    {
        private int _Descripcion;

        public int Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
    }
}
