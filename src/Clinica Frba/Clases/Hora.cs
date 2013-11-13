using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Clases
{
    public class Hora
    {
        public string HoraAMostrar { get; set; }
        public TimeSpan LaHora { get; set; }

        public Hora(TimeSpan hora, string detalle)
        {
            HoraAMostrar = detalle;
            LaHora = hora;
        }
    }
}
