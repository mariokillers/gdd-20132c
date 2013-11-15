using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Clinica_Frba.Clases
{
    class Listados
    {
        //FALTAN LOS QUERIES A TODAS MENOS EL 2

        public static List<Listado3> ObtenerEspecialidadesConMasBonosRecetados(DateTime desde, DateTime hasta)
        {
            List<Listado3> listaListado3 = new List<Listado3>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@año", desde));
            ListaParametros.Add(new SqlParameter("@semestre", hasta));

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

        public static List<Listado2> ObtenerCantBonosVencidosPorAfiliado(DateTime desde, DateTime hasta)
        {
            List<Listado2> listaListado2 = new List<Listado2>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@desde", desde));
            ListaParametros.Add(new SqlParameter("@hasta", hasta));

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT TOP 5 Persona.nombre AS nombre, Persona.apellido AS apellido, COUNT(Bono_Farmacia.codigo) AS cantidad FROM mario_killers.Bono_Farmacia JOIN mario_killers.Compra ON Bono_Farmacia.compra = Compra.id JOIN mario_killers.Afiliado ON Compra.persona = Afiliado.persona JOIN mario_killers.Persona ON Afiliado.persona = Persona.id WHERE Compra.fecha + 60 between @desde and @hasta GROUP BY Persona.nombre, Persona.apellido ORDER BY COUNT(Bono_Farmacia.codigo) DESC", "T", ListaParametros);

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

        public static List<Listado1> ObtenerEspecialidadesMasCancelaciones(DateTime desde, DateTime hasta)
        {
            List<Listado1> listaListado2 = new List<Listado1>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@desde", desde));
            ListaParametros.Add(new SqlParameter("@hasta", hasta));

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

        public static List<Listado2> ObtenerAfiliadosQueUsaronBonosQueNoCompraron(DateTime desde, DateTime hasta)
        {
            List<Listado2> listaListado2 = new List<Listado2>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@desde", desde));
            ListaParametros.Add(new SqlParameter("@hasta", hasta));

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
