using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Clases
{
    class Rango
    {
        public Dias Dia { get; set; }
        public TimeSpan HoraDesde { get; set; }
        public TimeSpan HoraHasta { get; set; }

        public Rango(Dias dia, TimeSpan horaDesde, TimeSpan horaHasta)
        {
            Dia = dia;
            HoraDesde = horaDesde;
            HoraHasta = horaHasta;
        }

        public Rango()
        {
        }
    }
}
