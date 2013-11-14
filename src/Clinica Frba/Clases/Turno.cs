using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Clases
{
    public class Turno
    {
        public decimal Id { get; set; }
        public decimal Codigo_Persona { get; set; }
        public decimal Codigo_Profesional { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Horario { get; set; }
        public decimal Codigo_Especialidad { get; set; }
        public bool Estado { get; set; }
        public string Diagnostico { get; set; }
        public string Sintomas { get; set; }
        public DateTime Horario_Llegada { get; set; }
        public DateTime Horario_Atencion { get; set; }
    }
}
