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
    public class Especialidades
    {
        public static void AgregarEspecialidadEnProfesional(decimal id, Especialidad esp){

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@id", (int)id));
            ListaParametros.Add(new SqlParameter("@codigoEsp", esp.Codigo));

            Clases.BaseDeDatosSQL.EscribirEnBase("INSERT INTO mario_killers.Especialidad_Profesional (profesional, especialidad) VALUES (@id, @codigoEsp)", "T", ListaParametros);
        }
        
        public static List<Especialidad> ObtenerEspecialidades()
        {
            List<Especialidad> Lista = new List<Especialidad>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT * FROM mario_killers.Especialidad", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    //instancio un tipo
                   // TipoEspecialidad tipoEsp = new TipoEspecialidad((decimal)lector["tipo"]);
                   
                    Especialidad unaEspecialidad = new Especialidad();
                    unaEspecialidad.Codigo = (decimal)lector["codigo"];
                    unaEspecialidad.Descripcion = (string)lector["descripcion"];
                    unaEspecialidad.Tipo_Especialidad = (decimal)lector["tipo"];
                    Lista.Add(unaEspecialidad);
                }
            }
            return Lista;
        }
    }
}
