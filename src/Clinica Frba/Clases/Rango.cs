using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Clases
{
    class Rango
    {
        public string Dia { get; set; }
        public int HoraDesde { get; set; }
        public int HoraHasta { get; set; }

        //PASAR TODO A TIMESPAN?
        public Rango(string unDia, int horaDesde, int horaHasta)
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
