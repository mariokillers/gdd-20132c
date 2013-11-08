using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Clases
{
    public class Compra
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Codigo_Persona { get; set; }
        public int Codigo_Plan { get; set; }
        public List<BonoConsulta> BonosConsulta { get; set; }
        public List<BonoFarmacia> BonosFarmacia { get; set; }

        public Compra(Afiliado unAfiliado)
        {
            Fecha = DateTime.Today;
            Codigo_Persona = (int)unAfiliado.Id;
            Codigo_Plan = (int)unAfiliado.Plan_Medico;
        }
    }
}
