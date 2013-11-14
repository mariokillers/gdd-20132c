using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Clinica_Frba.Clases
{
    class Listados
    {
        //FALTAN LOS QUERIES A TODAS

        public static List<Listado3> ObtenerEspecialidadesConMasBonosRecetados(DateTime año, int semestre)
        {
            List<Listado3> listaListado3 = new List<Listado3>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@año", año));
            ListaParametros.Add(new SqlParameter("@semestre", semestre));

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("", "T", ListaParametros);
            
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Listado3 unRegistro = new Listado3();
                    unRegistro.EspecialidadMedica = (string)lector["especialidad"];
                    unRegistro.CantBonos = (int)lector["cantidad"];
                    listaListado3.Add(unRegistro);
                }
            }
            return listaListado3;
        }

        public static List<Listado2> ObtenerCantBonosVencidosPorAfiliado(DateTime año, int semestre)
        {
            List<Listado2> listaListado2 = new List<Listado2>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@año", año));
            ListaParametros.Add(new SqlParameter("@semestre", semestre));

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Listado2 unRegistro = new Listado2();
                    unRegistro.Apellido = (string)lector["apellido"];
                    unRegistro.Nombre = (string)lector["nombre"];
                    unRegistro.CantBonos = (int)lector["cantidad"];
                    listaListado2.Add(unRegistro);
                }
            }
            return listaListado2;
        }

        public static List<Listado1> ObtenerEspecialidadesMasCancelaciones(DateTime año, int semestre)
        {
            List<Listado1> listaListado2 = new List<Listado1>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@año", año));
            ListaParametros.Add(new SqlParameter("@semestre", semestre));

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Listado1 unRegistro = new Listado1();
                    unRegistro.EspecialidadMedica = (string)lector["especialidad"];
                    unRegistro.CantCancelaciones = (int)lector["cantidad"];
                    listaListado2.Add(unRegistro);
                }
            }
            return listaListado2;
        }

        public static List<Listado2> ObtenerAfiliadosQueUsaronBonosQueNoCompraron(DateTime año, int semestre)
        {
            List<Listado2> listaListado2 = new List<Listado2>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@año", año));
            ListaParametros.Add(new SqlParameter("@semestre", semestre));

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Listado2 unRegistro = new Listado2();
                    unRegistro.Apellido = (string)lector["apellido"];
                    unRegistro.Nombre = (string)lector["nombre"];
                    unRegistro.CantBonos = (int)lector["cantidad"];
                    listaListado2.Add(unRegistro);
                }
            }
            return listaListado2;
        }
    }
}
