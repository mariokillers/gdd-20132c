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
            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("select * from mario_killers.Medicamento", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Medicamento unMedicamento = new Medicamento();
                    unMedicamento.Detalle = (string)lector["detalle"];
                    Lista.Add(unMedicamento);
                }
            }
            return Lista;
        }

        public static List<Medicamento> ObtenerMedicamentos(string filtro)
        {
            List<Medicamento> Lista = new List<Medicamento>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@detalle", "%" + filtro + "%"));
            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("select * from mario_killers.Medicamento where detalle like @detalle", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Medicamento unMedicamento = new Medicamento();
                    unMedicamento.Detalle = (string)lector["detalle"];
                    Lista.Add(unMedicamento);
                }
            }
            return Lista;
        }
    }
}
