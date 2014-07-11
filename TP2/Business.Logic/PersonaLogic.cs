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

        public List<Personas> GetAll(Personas.TiposPersonas tipoPersona)
        {
            return PersonaData.GetAll(tipoPersona);
        }

        public Usuario GetOne(int ID, Personas.TiposPersonas tipoPersona)
        {
            return PersonaData.GetOne(ID,tipoPersona);
        }

        public void Save(Personas persona)
        {
            PersonaData.Save(persona);
        }

        public void Delete(int ID)
        {
            this.PersonaData.Delete(ID);
            
        }
        


    }
}
