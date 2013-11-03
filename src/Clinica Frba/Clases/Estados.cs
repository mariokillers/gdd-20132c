using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Clinica_Frba.Clases
{
    class Estados
    {
        public static List<Estado> ObtenerEstados()
        {
            List<Estado> Lista = new List<Estado>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT * FROM mario_killers.Estado_Civil", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Estado unTipo = new Estado();
                    unTipo.Id = (decimal)lector["id"];
                    unTipo.Estado_Civil = (string)lector["estado"];
                    Lista.Add(unTipo);
                }
            }
            return Lista;
        }
    }
}
