using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Clases
{
    class Plan
    {
        public decimal Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio_Bono_Consulta { get; set; }
        public decimal Precio_Bono_Farmacia { get; set; }
    }
}
