using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Database;
using Business.Entities;
using System.Data;
using System.Net.Mail;

namespace Business.Logic
{
    public class PersonaLogic : BusinessLogic
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
            if (Validar(persona))
            {
                 PersonaData.Save(persona);
            }
           
        }

        private bool Validar(Persona persona)
        {
            if (persona.State==Persona.States.Modified||persona.State==Persona.States.New)
            {
                if (string.IsNullOrEmpty(persona.Nombre)||string.IsNullOrEmpty(persona.Apellido)||persona.FechaNacimiento>DateTime.Now.Date||string.IsNullOrEmpty(persona.Legajo)||string.IsNullOrEmpty(persona.Telefono))
                {
                    throw new Exception("Hay campos vacios o erróneos");
                }
                else
                {
                    try
                    {
                        new MailAddress(persona.Email);
                    }
                    catch (FormatException)
                    {
                        throw new Exception("Formato de mail erróneo");
                    }
                }
            }
            return true;
        }

        public void Delete(int ID)
        {
            this.PersonaData.Delete(ID);
            
        }
        public Persona GetOneOfUser(int ID){
            return this.PersonaData.GetOneOfUser(ID);
        }

        public DataTable GetAllWithPlanDescription()
        {
            return this.PersonaData.GetAllWithPlanDescription();
        }
        public DataTable GetAllWithPlanDescription(Persona.TiposPersonas tipoPersona)
        {
            return this.PersonaData.GetAllWithPlanDescription(tipoPersona);
        }
    }
}
