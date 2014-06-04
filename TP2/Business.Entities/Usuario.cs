using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Usuario:BusinessEntity
    {
        private int _Id;
        private Nullable<int> _TipoDoc;
        private Nullable<int> _NroDoc;
        private string _FechaNac;
        private string _Apellido;
        private string _Nombre;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _Celular;
        private string _Usuario;
        private string _Clave;


        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public Nullable<int> TipoDoc
        {
            get { return _TipoDoc; }
            set { _TipoDoc = value; }
        }
        public Nullable<int> NroDoc
        {
            get { return _NroDoc; }
            set { _NroDoc = value; }
        }
        public string FechaNac
        {
            get { return _FechaNac; }
            set { _FechaNac = value; }
        }
        public string Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }
        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public string Celular
        {
            get { return _Celular; }
            set { _Celular = value; }
        }
        public string NombreUsuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }
        public string Clave
        {
            get { return _Clave; }
            set { _Clave = value; }
        }

    }
}
