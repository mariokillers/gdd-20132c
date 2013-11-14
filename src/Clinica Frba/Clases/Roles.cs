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
    class Roles
    {
        public static List<Rol> ObtenerRoles(string filtro)
        {
            List<Rol> listaDeRoles = new List<Rol>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@txt", "%" + filtro + "%"));

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT id, nombre FROM mario_killers.Rol WHERE nombre like @txt", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Rol unRol = new Rol();
                    unRol.Id = (int)(decimal)lector["id"];
                    unRol.Nombre = (string)lector["nombre"];
                    unRol.Habilitado = (bool)lector["activo"];
                    listaDeRoles.Add(unRol);
                }
            }
            return listaDeRoles;
        }

        public static List<Rol> ObtenerRolesActivo(string filtro)
        {
            List<Rol> listaDeRoles = new List<Rol>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@txt", "%" + filtro + "%"));

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT id, nombre FROM mario_killers.Rol WHERE activo=1AND nombre like @txt", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Rol unRol = new Rol();
                    unRol.Id = (int)(decimal)lector["id"];
                    unRol.Nombre = (string)lector["nombre"];
                    unRol.Habilitado = (bool)lector["activo"];
                    listaDeRoles.Add(unRol);
                }
            }
            return listaDeRoles;
        }

        public static bool Eliminar(int id)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(new SqlParameter("@id", id));
                return Clases.BaseDeDatosSQL.EscribirEnBase("update mario_killers.Rol set Activo =0 where id=@id", "T", ListaParametros);
            }
            catch { return false; }
        }

        public static bool ModificarNombre(string nombre, int idRol)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(new SqlParameter("@id", idRol));
                ListaParametros.Add(new SqlParameter("@nombre", nombre));
                return Clases.BaseDeDatosSQL.EscribirEnBase("update mario_killers.Rol set nombre =@nombre where id=@id", "T", ListaParametros);
            }
            catch { return false; }
        }

        public static bool CambiarEstado(int idRol, bool estado)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(new SqlParameter("@id", idRol));
                ListaParametros.Add(new SqlParameter("@estado", estado));
                return Clases.BaseDeDatosSQL.EscribirEnBase("update mario_killers.Rol set activo =@estado where id=@id", "T", ListaParametros);
            }
            catch { return false; }
        }

        public static bool Agregar(string nombre, List<Funcionalidad> listaDeFunc)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(new SqlParameter("@nombreRol", nombre));
                SqlParameter paramRet = new SqlParameter("@ret", System.Data.SqlDbType.Decimal);
                paramRet.Direction = System.Data.ParameterDirection.Output;
                ListaParametros.Add(paramRet);

                //INSERTA EL ROL EN LA BASE DE DATOS
                int ret = (int)Clases.BaseDeDatosSQL.ExecStoredProcedure("mario_killers.agregarRol", ListaParametros);

                if (ret != -1)
                {
                    //TENGO QUE DAR DE ALTA LAS FUNCIONALIDADES DE ESE ROL
                    foreach (Funcionalidad unaFunc in listaDeFunc)
                    {
                        //AGREGO EN FUNCIONALIDAD_ROL EL ROL Y LA FUNC.
                        Funcionalidades.AgregarFuncionalidadEnRol(ret, unaFunc);
                    }
                    return true;
                }
                else { return false; }
            }
            catch { return false; }
        }

        public static List<Rol> ObtenerTodos()
        {
            List<Rol> listaDeRoles = new List<Rol>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT id, nombre, activo FROM mario_killers.Rol", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Rol unRol = new Rol();
                    unRol.Id = ((int)(decimal)lector["id"]);
                    unRol.Nombre = (string)lector["nombre"];
                    unRol.Habilitado = (bool)lector["activo"];
                    listaDeRoles.Add(unRol);
                }
            }
            return listaDeRoles; ;
        }

        public static List<Rol> ObtenerTodosActivos()
        {
            List<Rol> listaDeRoles = new List<Rol>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT id, nombre, activo FROM mario_killers.Rol WHERE activo=1", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Rol unRol = new Rol();
                    unRol.Id = ((int)(decimal)lector["id"]);
                    unRol.Nombre = (string)lector["nombre"];
                    unRol.Habilitado = (bool)lector["activo"];
                    listaDeRoles.Add(unRol);
                }
            }
            return listaDeRoles; ;
        }
    }
}
