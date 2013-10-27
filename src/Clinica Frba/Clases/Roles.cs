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
            OleDbDataReader lector = Clases.BaseDeDatos.ObtenerDataReader("", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    //FALTA TRAER LAS FUNCIONALIDADES POR ROL
                    Rol unRol = new Rol();
                    unRol.Id = (int)lector ["id"];
                    unRol.Nombre = (string)lector["nombre"];
                    unRol.Habilitado = true;
                    listaDeRoles.Add(unRol);
                }
            }
            return listaDeRoles;
        }
    }
}
