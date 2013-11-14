using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Clases
{
    class Medicamento
    {
        public string Detalle { get; set; }
        public int Cantidad { get; set; }
        public string CantidadEnLetras { get; set; }
        //provisorio
        public int Codigo_Bono_Farmacia { get; set; }
    }
}
