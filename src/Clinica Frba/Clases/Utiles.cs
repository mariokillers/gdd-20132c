using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Clinica_Frba.Clases
{
    class Utiles
    {
        public static bool EsNumerico(string numero)
        {
            try
            {
                int test = Convert.ToInt32(numero);
                return true;
            }
            catch (Exception)
            {return false;}
        }

        public static bool EsFechaValida(DateTime fecha)
        {
            try { 
                DateTime hoy = DateTime.Today;
                if (fecha > hoy)
                {
                    return false;
                } return true;
            }
            catch { return false; }
        }

        public static string ObtenerTipoDoc(decimal tipoDoc)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@id", tipoDoc));

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT tipo FROM mario_killers.Tipo_Documento where id=@id", "T", ListaParametros);
            if (lector.HasRows)
            {
                lector.Read();
            }
            return ((string)lector["tipo"]);
        }

        public static string ObtenerPlan(decimal codigo)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@codigo", codigo));

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT descripcion FROM mario_killers.Plan_Medico where codigo=@codigo", "T", ListaParametros);
            if (lector.HasRows)
            {
                lector.Read();
            }
            return ((string)lector["descripcion"]);
        }

        public static string ObtenerEstado(decimal id)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@id", id));

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT estado FROM mario_killers.Estado_Civil where id=@id", "T", ListaParametros);
            if (lector.HasRows)
            {
                lector.Read();
            }
            return ((string)lector["estado"]);
        }

        public static List<string> ObtenerTodosLosDias()
        {
            List<string> lista = new List<string>();



            return lista;
        }
    }
}
