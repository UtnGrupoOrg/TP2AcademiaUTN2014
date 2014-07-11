using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    class PersonaLogic : BusinessLogic
    {
        private PersonaAdapter _PersonaData;

        public PersonaAdapter PersonaData
        {
            get { return _PersonaData; }
            set { _PersonaData = value; }
        }

        public PersonaLogic()
        {
            PersonaData = new PersonaAdapter();
        }
        public List<Personas> GetAll()
        {
            return PersonaData.GetAll();
        }
        public List<Personas> GetAll(Personas.TiposPersonas tipoPersona)
        {
            return PersonaData.GetAll(tipoPersona);
        }

        public Usuario GetOne(int ID)
        {
            return PersonaData.GetOne(ID);
        }

        public void Save(Personas persona)
        {
            PersonaData.Save(persona);
        }

        public void Delete(int ID)
        {
            PersonaData.Delete(ID);
        }


    }
}
