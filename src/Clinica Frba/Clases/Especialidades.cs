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
    class Especialidades
    {
        public static List<Especialidad> ObtenerEspecialidades()
        {
            List<Especialidad> Lista = new List<Especialidad>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    //instancio un tipo
                    TipoEspecialidad tipoEsp = new TipoEspecialidad((int)lector["tipo"]);
                   
                    Especialidad unaEspecialidad = new Especialidad();
                    unaEspecialidad.Codigo = 0;//me lo devuelve la consulta
                    unaEspecialidad.Descripcion = (string)lector["desripcion"];
                    unaEspecialidad.Tipo_Especialidad = tipoEsp.Descripcion;
                    Lista.Add(unaEspecialidad);
                }
            }
            return Lista;
        }
    }
}
