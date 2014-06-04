using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Plan : BusinessEntity
    {
        private int _Descripcion;

        public int Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        private int _IDEspecialidad;

        public int IDEspecialidad
        {
            get { return _IDEspecialidad; }
            set { _IDEspecialidad = value; }
        }
    }
}
