using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clinica_Frba.Clase_Persona;

namespace Clinica_Frba.Abm_de_Profesional
{
    class Profesional : Persona
    {
        public Persona Persona { get; set; }
        public int Matricula { get; set; }
    }
}
