using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Clinica_Frba.Clases
{
    public class Turnos
    {
        public static List<Turno> ObtenerTurnos(int persona)
        {
            List<Turno> listTurno = new List<Turno>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@id", persona));

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT * FROM mario_killers.TurnosPorPaciente WHERE paciente_id = @id", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Turno unTurno = new Turno();
                    unTurno.Id = (decimal)lector["id"];
                    unTurno.Codigo_Persona = (int)(decimal)lector["paciente_id"];
                    unTurno.Nombre_Persona = (String)lector["paciente"];
                    unTurno.Codigo_Profesional = (int)(decimal)lector["profesional_id"];
                    unTurno.Nombre_Profesional = (String)lector["profesional"];
                    unTurno.Fecha = (DateTime)lector["fecha"];
                    unTurno.Codigo_Especialidad = (decimal)lector["especialidad"];
                    listTurno.Add(unTurno);
                }
            }
            return listTurno;
        }

        public static void Cancelar(Turno turno, decimal tipoCanc, String motivo)
        {

        }
    }
}
