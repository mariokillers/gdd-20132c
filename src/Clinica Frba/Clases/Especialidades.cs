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
            ListaParametros.Add(new SqlParameter("@codigoEsp", (int)esp.Codigo));

            Clases.BaseDeDatosSQL.EscribirEnBase("INSERT INTO mario_killers.Especialidad_Profesional (profesional, especialidad) VALUES (@id, @codigoEsp)", "T", ListaParametros);
        }

        public static void EliminarEspecialidadEnProfesional(decimal id, Especialidad esp)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@id", (int)id));
            ListaParametros.Add(new SqlParameter("@codigoEsp", (int)esp.Codigo));

            Clases.BaseDeDatosSQL.EscribirEnBase("DELETE FROM mario_killers.Especialidad_Profesional WHERE profesional = @id AND especialidad = @codigoEsp", "T", ListaParametros);
        }

        public static List<Especialidad> ObtenerEspecialidadesProfesional(decimal id)
        {
            List<Especialidad> Lista = new List<Especialidad>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@id", (int)id));

            String query = @"SELECT E.codigo AS codigo, E.descripcion AS descripcion, E.tipo AS tipo
                            FROM mario_killers.Especialidad E JOIN mario_killers.Especialidad_Profesional EP ON E.codigo = EP.especialidad
                            WHERE EP.profesional = @id";

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader(query, "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Especialidad unaEspecialidad = new Especialidad();
                    unaEspecialidad.Codigo = (decimal)lector["codigo"];
                    unaEspecialidad.Descripcion = (string)lector["descripcion"];
                    unaEspecialidad.Tipo_Especialidad = (decimal)lector["tipo"];
                    Lista.Add(unaEspecialidad);
                }
            }
            return Lista;
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
