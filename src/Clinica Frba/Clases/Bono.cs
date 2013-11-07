using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Clases
{
    abstract class Bono
    {
        public DateTime Fecha_Compra { get; set; }
        public int Numero_Afil_Principal { get; set; }
        public int Codigo_Plan { get; set; }
    }
}
