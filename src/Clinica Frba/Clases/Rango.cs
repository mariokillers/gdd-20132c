using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Clases
{
    class Rango
    {
        public string Dia { get; set; }
        public TimeSpan HoraDesde { get; set; }
        public TimeSpan HoraHasta { get; set; }

        public Rango(string unDia, TimeSpan horaDesde, TimeSpan horaHasta)
        {
            Dia = unDia;
            HoraDesde = horaDesde;
            HoraHasta = horaHasta;
        }

        public Rango()
        {
        }
    }
}
