using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Clinica_Frba.Clases
{
    class Medicamentos
    {
        public static List<Medicamento> ObtenerMedicamentos()
        {
            List<Medicamento> Lista = new List<Medicamento>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("", "T", ListaParametros);

            if (lector.HasRows)
            {
                Medicamento unMedicamento = new Medicamento();
                unMedicamento.Id = (int) lector ["id"];
                unMedicamento.Detalle = (string)lector["detalle"];
                Lista.Add(unMedicamento);
            }
            return Lista;
        }
    }
}
