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
            ListaParametros.Add(new SqlParameter("@txt", filtro));

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT id, rol FROM mario_killers.Rol WHERE activo = 1 AND rol like '%@txt%'", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    //FALTA TRAER LAS FUNCIONALIDADES POR ROL
                    Rol unRol = new Rol();
                    unRol.Id = (int)lector ["id"];
                    unRol.Nombre = (string)lector["rol"];
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
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@nombre", nombre));
            foreach (Funcionalidad unaFun in listaDeFunc)
            {
                //VER COMO AGREGAR LAS FUNCIONALIDADES
            }
            return Clases.BaseDeDatosSQL.EscribirEnBase("update mario_killers.Rol set Activo =0 where id=@id", "T", ListaParametros);
        }
    }
}
