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

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT id, nombre FROM mario_killers.Rol WHERE activo = 1 AND nombre like @txt", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    //FALTA TRAER LAS FUNCIONALIDADES POR ROL
                    Rol unRol = new Rol();
                    unRol.Id = (int)(decimal)lector["id"];
                    unRol.Nombre = (string)lector["nombre"];
                    unRol.Habilitado = true;
                    listaDeRoles.Add(unRol);
                }
            }
            return listaDeRoles;
        }

        public static bool Eliminar(int id)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@id", id));
            return Clases.BaseDeDatosSQL.EscribirEnBase("update mario_killers.Rol set Activo =0 where id=@id", "T", ListaParametros);
        }

        public static bool Agregar(string nombre, List<Funcionalidad> listaDeFunc)
        {
            try
            {
                int idRol = -1;
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(new SqlParameter("@nombreRol", nombre));

                //INSERTA EL ROL EN LA BASE DE DATOS
                Clases.BaseDeDatosSQL.EscribirEnBase("INSERT INTO mario_killers.Rol (nombre, activo) VALUES (@nombreRol, 1)", "T", ListaParametros);


                List<SqlParameter> Lista = new List<SqlParameter>();
                Lista.Add(new SqlParameter("@nombreRol", nombre));
                SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT id from mario_killers.Rol WHERE nombre= @nombreRol", "T", Lista);
                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        idRol = (int)(decimal)lector["id"];
                    }
                }
                if (idRol != -1)
                {

                    //TENGO QUE DAR DE ALTA LAS FUNCIONALIDADES DE ESE ROL
                    foreach (Funcionalidad unaFunc in listaDeFunc)
                    {
                        //AGREGO EN FUNCIONALIDAD_ROL EL ROL Y LA FUNC.
                        Funcionalidades.AgregarFuncionalidadEnRol(idRol, unaFunc);
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

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT id, nombre FROM mario_killers.Rol WHERE activo = 1", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    //FALTA TRAER LAS FUNCIONALIDADES POR ROL
                    Rol unRol = new Rol();
                    unRol.Id = ((int)(decimal)lector["id"]);
                    unRol.Nombre = (string)lector["nombre"];
                    unRol.Habilitado = true;
                    listaDeRoles.Add(unRol);
                }
            }
            return listaDeRoles; ;
        }
    }
}
