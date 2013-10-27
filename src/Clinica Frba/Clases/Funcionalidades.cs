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
    class Funcionalidades
    {
        public static List<Funcionalidad> ObtenerFuncionalidades()
        {
            List<Funcionalidad> Lista = new List<Funcionalidad>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Funcionalidad unaFuncionalidad = new Funcionalidad();
                    unaFuncionalidad.Id = (int)lector["id"];
                    unaFuncionalidad.Nombre = (string)lector["nombre"];
                    Lista.Add(unaFuncionalidad);
                }
            }
            return Lista;
        }

        public static List<Funcionalidad> ObtenerFuncionalidades(string filtro)
        {
            List<Funcionalidad> Lista = new List<Funcionalidad>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@txt", filtro));
            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Funcionalidad unaFuncionalidad = new Funcionalidad();
                    unaFuncionalidad.Id = (int)lector["id"];
                    unaFuncionalidad.Nombre = (string)lector["nombre"];
                    Lista.Add(unaFuncionalidad);
                }
            }
            return Lista;
        }
    }
}
