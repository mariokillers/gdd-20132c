using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Clases
{
    class BonoConsulta:Bono
    {
        public int Id { get; set; }
        public int Codigo_Compra { get; set; }
        public int Contador { get; set; }
        public int Codigo_Turno { get; set; }
        public int Precio { get; set; }

        public BonoConsulta(Afiliado unAfiliado)
        {
            Fecha_Compra = DateTime.Today;
            Numero_Afil_Principal = (int)unAfiliado.Numero_Grupo;
            Codigo_Plan = (int)unAfiliado.Plan_Medico;
            Precio = (int)(new Plan((int)unAfiliado.Plan_Medico)).Precio_Bono_Consulta;
        }
    }
}
