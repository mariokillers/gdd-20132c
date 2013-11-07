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
    class Usuarios
    {
        public static List<Rol> ObtenerRoles(Usuario user)
        {
            List<Rol> Lista = new List<Rol>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@nombre", user.Name));
            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("select * from mario_killers.roles_usuario(@nombre)", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Rol unRol = new Rol();
                    unRol.Nombre = (string)lector["nombre"];
                    unRol.Id = (int)lector["rol"];
                    unRol.Habilitado = true;
                    Lista.Add(unRol);
                }
            }
            return Lista;
        }
    }
}
