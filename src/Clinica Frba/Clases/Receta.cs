using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Clases
{
    class Receta
    {
        public int Id { get; set; }
        public int Codigo_Atencion { get; set; }
        public List<MedicamentoEnReceta> ListaMedicamentos { get; set; }

    }
}
