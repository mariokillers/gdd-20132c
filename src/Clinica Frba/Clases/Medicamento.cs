using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Clinica_Frba.Clases
{
    public class Medicamento
    {
        public string Detalle { get; set; }
        public int Cantidad { get; set; }
        public int BonoFarmacia { get; set; }
        public string CantidadEnLetras { get; set; }

        public bool AgregarAReceta(int codigoHistoria)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@medicamento", Detalle));
            ListaParametros.Add(new SqlParameter("@cantidad", Cantidad));
            ListaParametros.Add(new SqlParameter("@historia_clinica", codigoHistoria));
            ListaParametros.Add(new SqlParameter("@bono_farmacia", BonoFarmacia));

            return Clases.BaseDeDatosSQL.EscribirEnBase("INSERT INTO mario_killers.Medicamento_HistoriaClinica (historia_clinica, cantidad, medicamento, bono_farmacia) VALUES (@historia_clinica, @cantidad, @medicamento, @bono_farmacia)", "T", ListaParametros);
        }
    }
}
