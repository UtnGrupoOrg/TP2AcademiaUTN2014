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
        public List<Persona> GetAll()
        {
            return PersonaData.GetAll();
        }
        public List<Persona> GetAll(Persona.TiposPersonas tipoPersona)
        {
            return PersonaData.GetAll(tipoPersona);
        }

        public Persona GetOne(int ID)
        {
            return PersonaData.GetOne(ID);
        }

        public void Save(Persona persona)
        {
            PersonaData.Save(persona);
        }

        public void Delete(int ID)
        {
            this.PersonaData.Delete(ID);
            
        }
        


    }
}
