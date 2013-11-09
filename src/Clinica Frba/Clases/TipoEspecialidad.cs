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
    class TipoEspecialidad
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }

        public TipoEspecialidad(decimal codigo)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@codigo", codigo));
            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("", "T", ListaParametros);

            if (lector.HasRows)
            {
                lector.Read();
                Descripcion = (string) lector ["descripcion"];
            }
        }
    }
}
