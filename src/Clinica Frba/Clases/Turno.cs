using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Clases
{
    class Turno
    {
        public int Id { get; set; }
        public int Codigo_Persona { get; set; }
        public int Codigo_Profesional { get; set; }
        public DateTime Fecha { get; set; }
        public int Codigo_Especialidad { get; set; }
        public bool Estado { get; set; }
        public DateTime Horario_Llegada { get; set; }
    }
}
