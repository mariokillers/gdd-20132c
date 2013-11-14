using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Clases
{
    class Receta
    {
        public int Id { get; set; }
        public int Codigo_Bono_Farmacia { get; set; }
        public List<Medicamento> ListaMedicamentos { get; set; }

        public Receta(int codigoBono)
        {
            Codigo_Bono_Farmacia = codigoBono;
            ListaMedicamentos = new List<Medicamento>();
        }
    }
}
