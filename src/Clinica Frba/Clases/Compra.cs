using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Clases
{
    class Compra
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Codigo_Persona { get; set; }
        public int Codigo_Plan { get; set; }
    }
}
