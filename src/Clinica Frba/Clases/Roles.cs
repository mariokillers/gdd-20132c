using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Clinica_Frba.Clases
{
    class Roles
    {
        public static List<Rol> ObtenerRoles(string filtro)
        {
            List<Rol> listaDeRoles = new List<Rol>();

            List<OleDbParameter> ListaParametros = new List<OleDbParameter>();
            ListaParametros.Add(new OleDbParameter("@txt", filtro));

            OleDbConnection conexion = Clases.BaseDeDatos.ObtenerConexion();
            OleDbDataReader lector = Clases.BaseDeDatos.ObtenerDataReader("SELECT id, rol FROM mario_killers.Rol WHERE activo = 1 AND rol like '%@txt%'", "T", ListaParametros);

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
            List<OleDbParameter> ListaParametros = new List<OleDbParameter>();
            ListaParametros.Add(new OleDbParameter("@id", id));
            return Clases.BaseDeDatos.EscribirEnBase("update mario_killers.Rol set Activo =0 where id=@id", "T", ListaParametros);
        }

        public static bool Agregar(string nombre, List<Funcionalidad> listaDeFunc)
        {
            List<OleDbParameter> ListaParametros = new List<OleDbParameter>();
            ListaParametros.Add(new OleDbParameter("@nombre", nombre));
            foreach (Funcionalidad unaFun in listaDeFunc)
            {
                //VER COMO AGREGAR LAS FUNCIONALIDADES
            }
            return Clases.BaseDeDatos.EscribirEnBase("update mario_killers.Rol set Activo =0 where id=@id", "T", ListaParametros);
        }
    }
}
