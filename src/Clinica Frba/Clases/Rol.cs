using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Clinica_Frba.Clases
{
    public class Rol
    {
        public string Nombre { get; set; }
        public int Id { get; set; }
        private List<Funcionalidad> ListaFuncionalidades { get; set; }
        public bool Habilitado { get; set; }

        public Rol(int id)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@idRol", id));

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT * FROM mario_killers.Rol where id=@idRol and activo=1", "T", ListaParametros);
            if (lector.HasRows)
            {
                lector.Read();
                Id = id;
                Nombre = ((string)lector["nombre"]);
                Habilitado = (bool)lector["activo"];

                //FALTA TODO LO DE FUNCIONALIDADES 
            }
        }
        public Rol() { }

    }
}
