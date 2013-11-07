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

        public static bool SePasaDeHoras(List<Rango> listaDeRangos)
        {
            int cantHoras = 1;
            //int cantHoras = listaDeRangos.Sum(item => (item.HoraHasta - item.HoraDesde));
            if (cantHoras > 48)
            {
                return true;
            }
            else { return false; }
        }

        public static bool SonFechasValidas(DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                if (fechaDesde > fechaHasta)
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
        
        public static List<Dias> ObtenerTodosLosDias()
        {
            List<Dias> lista = new List<Dias>();
            lista.Add(new Dias(1, "Domingo"));
            lista.Add(new Dias(2, "Lunes"));
            lista.Add(new Dias(3, "Martes"));
            lista.Add(new Dias(4, "Miercoles"));
            lista.Add(new Dias(5, "Jueves"));
            lista.Add(new Dias(6, "Viernes"));
            lista.Add(new Dias(7, "Sábado"));

            return lista;
        }
        
        public static List<Hora> ObtenerHorasDiasHabilesDesde()
        {
            List<Hora> lista = new List<Hora>();
            for (int i = 7; i <= 20; i++)
            {
                TimeSpan unaHora = new TimeSpan(i, 00, 0);
                string hora = unaHora.Hours.ToString() +":"+ unaHora.Minutes.ToString();
                lista.Add(new Hora(unaHora, hora));
            }

            return lista;
        }

        public static List<Hora> ObtenerHorasDiasHabilesHasta()
        {
            List<Hora> lista = new List<Hora>();
            for (int i = 7; i <= 20; i++)
            {
                TimeSpan unaHora = new TimeSpan(i, 00, 0);
                string hora = unaHora.Hours.ToString() + ":" + unaHora.Minutes.ToString();
                lista.Add(new Hora(unaHora, hora));
            }

            return lista;
        }

        public static List<Hora> ObtenerHorasDiasSabadosDesde()
        {
            List<Hora> lista = new List<Hora>();
            for (int i = 10; i <= 14; i++)
            {
                TimeSpan unaHora = new TimeSpan(i, 00, 0);
                string hora = unaHora.Hours.ToString() + ":" + unaHora.Minutes.ToString();
                lista.Add(new Hora(unaHora, hora));
            }
            
            return lista;
        }

        public static List<Hora> ObtenerHorasDiasSabadosHasta()
        {
            List<Hora> lista = new List<Hora>();
            for (int i = 10; i <= 14; i++)
            {
                TimeSpan unaHora = new TimeSpan(i, 0, 0);
                string hora = unaHora.Hours.ToString() + ":" + unaHora.Minutes.ToString();

                lista.Add(new Hora(unaHora, hora));
            }
            return lista;
        }
    }
}
