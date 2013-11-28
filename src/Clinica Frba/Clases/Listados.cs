using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Clinica_Frba.Clases
{
    class Listados
    {
        public static List<Listado2> Listado2(int desde, int hasta, int ano)
        {
            List<Listado2> listaListado2 = new List<Listado2>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@desde", desde));
            ListaParametros.Add(new SqlParameter("@hasta", hasta));
            ListaParametros.Add(new SqlParameter("@ano", (decimal)ano));

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT nombre, apellido, documento, mes, cant_bonos FROM mario_killers.listado_2_view WHERE (nro_mes BETWEEN  @desde AND @hasta AND ano=@ano)", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Listado2 unRegistro = new Listado2();
                    unRegistro.Apellido = (string)lector["apellido"];
                    unRegistro.Nombre = (string)lector["nombre"];
                    unRegistro.Documento = (int)(decimal)lector["documento"];
                    unRegistro.CantBonos = (int)lector["cant_bonos"];
                    unRegistro.Mes = (string)lector["mes"];
                    unRegistro.ano = ano;
                    listaListado2.Add(unRegistro);
                }
            }
            return listaListado2;
        }

        public static List<Listado3> Listado3(int desde, int hasta, int ano)
        {
            List<Listado3> listaListado3 = new List<Listado3>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@desde", desde));
            ListaParametros.Add(new SqlParameter("@hasta", hasta));
            ListaParametros.Add(new SqlParameter("@ano", (decimal)ano));

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT desc_esp, desc_tipo_esp,cant_bonos,mes FROM mario_killers.listado_3_view WHERE (nro_mes BETWEEN  @desde AND @hasta AND ano=@ano)", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Listado3 unRegistro = new Listado3();
                    unRegistro.EspecialidadMedica = (string)lector["desc_esp"];
                    unRegistro.TipoEspecialidadMedica = (string)lector["desc_tipo_esp"];
                    unRegistro.CantBonos = (int)lector["cant_bonos"];
                    unRegistro.Mes = (string)lector["mes"];
                    unRegistro.ano = ano;
                    listaListado3.Add(unRegistro);
                }
            }
            return listaListado3;
        }

        public static List<Listado1> Listado1(int desde, int hasta, int ano)
        {
            List<Listado1> listaListado1 = new List<Listado1>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@desde", desde));
            ListaParametros.Add(new SqlParameter("@hasta", hasta));
            ListaParametros.Add(new SqlParameter("@ano", (decimal)ano));

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT especialidad, cancelaciones, horario, mes FROM mario_killers.listado_1_view WHERE (numero_mes BETWEEN  @desde AND @hasta AND ano=@ano)", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Listado1 unRegistro = new Listado1();
                    unRegistro.EspecialidadMedica = (string)lector["especialidad"];
                    unRegistro.CantCancelaciones = (int)lector["cancelaciones"];
                    unRegistro.Horario = (DateTime)lector["horario"];
                    unRegistro.Mes = (string)lector["mes"];
                    unRegistro.ano = ano;
                    listaListado1.Add(unRegistro);
                }
            }
            return listaListado1;
        }

        public static List<Listado4> Listado4(int desde, int hasta, int ano)
        {
            List<Listado4> listaListado4 = new List<Listado4>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@desde", desde));
            ListaParametros.Add(new SqlParameter("@hasta", hasta));
            ListaParametros.Add(new SqlParameter("@ano", (decimal)ano));

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT cantidad_de_bonos, nombre, apellido, documento FROM mario_killers.listado_4_view WHERE (nro_mes BETWEEN  @desde AND @hasta AND año=@ano)", "T", ListaParametros);
            
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Listado4 unRegistro = new Listado4();
                    unRegistro.Nombre = (string)lector["nombre"];
                    unRegistro.Apellido = (string)lector["apellido"];
                    unRegistro.CantBonos = (int)lector["cantidad_de_bonos"];
                    unRegistro.Documento = (int)(decimal)lector["documento"];
                    unRegistro.Mes = (string)lector["mes"];
                    unRegistro.ano = ano;
                    listaListado4.Add(unRegistro);
                }
            }
            return listaListado4;
        }
    }
}
