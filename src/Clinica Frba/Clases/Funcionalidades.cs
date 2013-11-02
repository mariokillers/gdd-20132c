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
            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT * from mario_killers.Funcionalidad", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Funcionalidad unaFuncionalidad = new Funcionalidad();
                    unaFuncionalidad.Id = (decimal)lector["id"];
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
            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT id, nombre FROM mario_killers.Funcionalidad WHERE nombre LIKE '%' + @txt + '%' ", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Funcionalidad unaFuncionalidad = new Funcionalidad();
                    unaFuncionalidad.Id = (decimal)lector["id"];
                    unaFuncionalidad.Nombre = (string)lector["nombre"];
                    Lista.Add(unaFuncionalidad);
                }
            }
            return Lista;
        }

        public static List<Funcionalidad> ObtenerFuncionalidades(decimal idRol)
        {
            List<Funcionalidad> Lista = new List<Funcionalidad>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@rol", idRol));
            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT F.id, F.nombre FROM mario_killers.Rol R JOIN mario_killers.Funcionalidad_Rol FM ON R.id = FM.rol JOIN mario_killers.Funcionalidad F ON FM.funcionalidad = F.id WHERE R.id = @rol", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Funcionalidad unaFuncionalidad = new Funcionalidad();
                    unaFuncionalidad.Id = (decimal)lector["id"];
                    unaFuncionalidad.Nombre = (string)lector["nombre"];
                    Lista.Add(unaFuncionalidad);
                }
            }
            return Lista;
        }

        public static List<String> ObtenerFuncionalidadesPorRol(decimal idRol)
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
                    unaFuncionalidad.Id = (decimal)lector["id"];
                    unaFuncionalidad.Nombre = (string)lector["nombre"];
                    Lista.Add(unaFuncionalidad.Nombre);
                }
            }
            return Lista;
        }

        public static bool EliminarFuncionalidadPorRol(decimal idRol, Funcionalidad unaFunc)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@idRol", idRol));
            ListaParametros.Add(new SqlParameter("@idFunc", unaFunc.Id));

            //ver que necesito para eliminar una func.
            return Clases.BaseDeDatosSQL.EscribirEnBase("delete from mario_killers.Funcionalidad_Rol where (rol=@idRol AND funcionalidad=@idFunc)", "T", ListaParametros);

        }

        public static bool AgregarFuncionalidadEnRol(decimal idRol, Funcionalidad unaFunc)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@idRol", idRol));
            ListaParametros.Add(new SqlParameter("@idFunc", unaFunc.Id));

            return Clases.BaseDeDatosSQL.EscribirEnBase("INSERT INTO mario_killers.Funcionalidad_Rol (rol, funcionalidad) VALUES (@idRol, @idFunc)", "T", ListaParametros);
        }
    }
}
