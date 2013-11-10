using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Clases
{
    class Turno
    {
        public decimal Id { get; set; }
        public decimal Codigo_Persona { get; set; }
        public decimal Codigo_Profesional { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Codigo_Especialidad { get; set; }
        public bool Estado { get; set; }
        public DateTime Horario_Llegada { get; set; }
    }
}
