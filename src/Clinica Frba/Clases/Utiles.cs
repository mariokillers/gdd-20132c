using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Clinica_Frba.Clases
{
    static class Utiles
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

        public static string ObtenerUltimos(this string cadena, int cantidad)
        {
            if (cantidad >= cadena.Length)
                return cadena;
            return cadena.Substring(cadena.Length - cantidad);
        }

        public static string DameEnLetras(int numero)
        {
            switch (numero)
            {
                case 1:
                    return "UNO";
                case 2:
                    return "DOS";
                case 3:
                    return "TRES";
                case 4:
                    return "CUATRO";
                case 5:
                    return "CINCO";
                default:
                    return "";
            }
        }

        public static bool EsHoraValida(TimeSpan desde, TimeSpan hasta)
        {
            if(desde.Hours < hasta.Hours){ return true; }
            else if (desde.Hours == hasta.Hours && desde.Minutes < hasta.Minutes) { return true; }
            else { return false; }
        }

        public static bool NoSePisan(Dias dia, TimeSpan desde, TimeSpan hasta, List<Rango> lista)
        {
            foreach (Rango unRango in lista)
            {
                if ((unRango.HoraDesde <= desde && desde <= unRango.HoraHasta || unRango.HoraDesde <= hasta && hasta <= unRango.HoraHasta) && dia.Id == unRango.Dia.Id)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool SonFechasValidas(DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                if (fechaDesde >= fechaHasta)
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
            lista.Add(new Dias(2, "Lunes"));
            lista.Add(new Dias(3, "Martes"));
            lista.Add(new Dias(4, "Miercoles"));
            lista.Add(new Dias(5, "Jueves"));
            lista.Add(new Dias(6, "Viernes"));
            lista.Add(new Dias(7, "Sábado"));

            return lista;
        }
        
        public static List<Hora> ObtenerHorasDiasHabiles()
        {
            int cont = 0;
            List<Hora> lista = new List<Hora>();
            for (int i = 7; i <= 20; i++)
            {
                cont++;
                if (cont != 2)
                {
                    TimeSpan unaHora = new TimeSpan(i, 00, 0);
                    string hora = unaHora.Hours.ToString() + ":" + unaHora.Minutes.ToString() + "0";
                    lista.Add(new Hora(unaHora, hora));
                }
                else
                {   
                    //REINICIO EL CONTADOR PORQUE ES MEDIA HORA
                    cont = 0;
                    i--;
                    TimeSpan unaHora = new TimeSpan(i, 30, 0);
                    string hora = unaHora.Hours.ToString() + ":" + unaHora.Minutes.ToString();
                    lista.Add(new Hora(unaHora, hora));
                }
            }
            return lista;
        }

        public static List<Hora> ObtenerHorasDiasSabados()
        {
            int cont = 0;
            List<Hora> lista = new List<Hora>();
            for (int i = 10; i <= 14; i++)
            {
                cont++;
                if (cont != 2)
                {
                    TimeSpan unaHora = new TimeSpan(i, 00, 0);
                    string hora = unaHora.Hours.ToString() + ":" + unaHora.Minutes.ToString() + "0";
                    lista.Add(new Hora(unaHora, hora));
                }
                else
                {
                    cont = 0;
                    i--;
                    TimeSpan unaHora = new TimeSpan(i, 30, 0);
                    string hora = unaHora.Hours.ToString() + ":" + unaHora.Minutes.ToString();
                    lista.Add(new Hora(unaHora, hora));
                }
            }
            
            return lista;
        }

        public static List<TipoCancelacion> ObtenerTiposCancelacion()
        {
            List<TipoCancelacion> list = new List<TipoCancelacion>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT * FROM mario_killers.Tipo_Cancelacion", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    TipoCancelacion unTipo = new TipoCancelacion();
                    unTipo.id = (decimal)lector["id"];
                    unTipo.descripcion = (string)lector["descripcion"];
                    list.Add(unTipo);
                }
            }
            return list;
        }

        public static List<Turno> ObtenerTurnosAgenda(Agenda unaAgenda, DateTime fecha)
        {
            List<Turno> listaTurnos = new List<Turno>();

            foreach (Rango unRango in unaAgenda.Rangos)
            {
                if (unRango.Dia.Id == ((new Dias(fecha.DayOfWeek)).Id))
                {
                    foreach (Turno unTurno in unRango.TurnosDentro)
                    {
                        DateTime aux = fecha;
                        aux = fecha.AddHours(unTurno.Horario.Hours);
                        aux = aux.AddMinutes(unTurno.Horario.Minutes);
                        unTurno.Fecha = aux;

                    }
                    listaTurnos.AddRange(unRango.TurnosDentro);
                }
            }
            return listaTurnos;
        }

        public static List<int> ObtenerDiasHabilesAgenda(Agenda unaAgenda)
        {
            List<int> listaDias = new List<int>();

            foreach (Rango unRango in unaAgenda.Rangos)
            {
                if (!listaDias.Contains(unRango.Dia.Id))
                {
                    listaDias.Add(unRango.Dia.Id);
                }
            }
            return listaDias;
        }

        public static List<Turno> ObtenerTurnosDia(Agenda unaAgenda, DateTime fecha)
        {
            List<Turno> list = new List<Turno>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT * FROM mario_killers.TurnosPorPaciente", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Turno unTurno = new Turno();
                    unTurno.Id = (decimal)lector["id"];
                    unTurno.Codigo_Persona = (decimal)lector["persona_id"];
                    unTurno.Nombre_Persona = (String)lector["persona"];
                    unTurno.Codigo_Profesional = (decimal)lector["profesional_id"];
                    unTurno.Nombre_Profesional = (String)lector["profesional"];
                    unTurno.Fecha = fecha;
                    unTurno.Codigo_Especialidad = (decimal)lector["especialidad"];
                    list.Add(unTurno);
                }
            }
            return list;
        }
    }
}
