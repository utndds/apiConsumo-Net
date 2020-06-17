using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3
{
    public class ColeccionPersonas
    {

        public static ColeccionPersonas instance;
        public List<Persona> personas = new List<Persona>();
        private ColeccionPersonas()
        {
            personas.Add(new Persona(1, "Jorge", 23));
            personas.Add(new Persona(2, "Facundo", 12));
            personas.Add(new Persona(3, "Mariana", 37));
            personas.Add(new Persona(4, "Sofia", 18));
            personas.Add(new Persona(5, "Marcelo", 10));
        }

        public static ColeccionPersonas getInstance()
        {
            if (instance == null)
            {
                ColeccionPersonas.instance = new ColeccionPersonas();
            }

            return instance;

        }

        public List<Persona> verPersonas()
        {
            return personas;
        }

        public Persona verPersona(int id)
        {
            return personas.Find(x => x.id == id);
        }

        public void agregarPersona(Persona persona)
        {
            personas.Add(persona);
        }

        public void eliminarPersona(int id)
        {
            personas.RemoveAll(x => x.id == id);
        }

        public void reemplazarPersona(int id, Persona persona)
        {
            this.eliminarPersona(id);
            this.agregarPersona(persona);
        }

    }
}
