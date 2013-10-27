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
            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT F.id, F.nombre FROM mario_killers.Rol R JOIN mario_killers.Funcionalidad_Rol FM ON R.id = FM.rol JOIN mario_killers.Funcionalidad F ON FM.funcionalidad = F.id", "T", ListaParametros);

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
            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT id FROM mario_killers.Funcionalidad WHERE nombre LIKE '%' + @txt + '%' ", "T", ListaParametros);

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

        public static List<String> ObtenerFuncionalidadesPorRol(int idRol)
        {
            List<String> Lista = new List<String>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@rol", idRol));
            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT F.id, F.nombre FROM mario_killers.Rol R JOIN mario_killers.Funcionalidad_Rol FM ON R.id = FM.rol JOIN mario_killers.Funcionalidad F ON FM.funcionalidad = F.id WHERE R.id = @rol", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Funcionalidad unaFuncionalidad = new Funcionalidad();
                    unaFuncionalidad.Id = (int)lector["id"];
                    unaFuncionalidad.Nombre = (string)lector["nombre"];
                    Lista.Add(unaFuncionalidad.Nombre);
                }
            }
            return Lista;
        }
    }
}
