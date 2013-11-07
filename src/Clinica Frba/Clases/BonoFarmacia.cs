using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Clases
{
    class BonoFarmacia:Bono
    {
        public int Id { get; set; }
        public int Codigo_Compra { get; set; }
        public int Codigo_Receta { get; set; }
        public int Precio { get; set; }

        public BonoFarmacia(Afiliado unAfiliado)
        {
            Fecha_Compra = DateTime.Today;
            Numero_Afil_Principal = (int)unAfiliado.Numero_Grupo;
            Codigo_Plan = (int)unAfiliado.Plan_Medico;
            Precio = (int)(new Plan((int)unAfiliado.Plan_Medico)).Precio_Bono_Farmacia;
        }
    }
}
