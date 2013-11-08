using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Clases
{
    class BonoConsulta
    {
        public int Id { get; set; }
        public int Codigo_Compra { get; set; }
        public int Contador { get; set; }
        public int Codigo_Plan { get; set; }
        public int Codigo_Turno { get; set; }
        public int Precio { get; set; }

        public BonoConsulta(Afiliado unAfiliado)
        {
            Precio = (int)(new Plan((int)unAfiliado.Plan_Medico)).Precio_Bono_Consulta;
            Codigo_Plan = (int)unAfiliado.Plan_Medico;
        }
    }
}
