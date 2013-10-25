using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clinica_Frba.Clase_Persona;

namespace Clinica_Frba.Abm_de_Profesional
{
    class Profesional : Persona
    {
        public int Codigo_Persona { get; set; }
        public int Matricula { get; set; }
        public int Codigo_Especialidad { get; set; } //VER SI NO ES PREFERIBLE TENER EL NOMBRE
    }
}
