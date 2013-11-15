using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Clinica_Frba.Clases
{
    class Receta
    {
        public int Codigo_Bono_Farmacia { get; set; }
        public int Codigo_Historia_Clinica { get; set; }
        public List<Medicamento> ListaMedicamentos { get; set; }

        public Receta(int codigoBono)
        {
            Codigo_Bono_Farmacia = codigoBono;
            ListaMedicamentos = new List<Medicamento>();
        }

        public bool RegistrarReceta()
        {
            try 
            {
                foreach (Medicamento unMedicamento in ListaMedicamentos)
                {
                    unMedicamento.BonoFarmacia = Codigo_Bono_Farmacia;
                    unMedicamento.AgregarAReceta(Codigo_Historia_Clinica);
                }
                return true;
            }
            catch { return false; }
        }
    }
}
