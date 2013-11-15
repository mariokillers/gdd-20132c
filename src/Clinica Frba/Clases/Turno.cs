using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clinica_Frba.Abm_de_Profesional;
using System.Data.SqlClient;

namespace Clinica_Frba.Clases
{
    public class Turno
    {
        public decimal Id { get; set; }
        public decimal Codigo_Persona { get; set; }
        public String Nombre_Persona { get; set; }
        public decimal Codigo_Profesional { get; set; }
        public String Nombre_Profesional { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Horario { get; set; }
        public Dias Dia { get; set; }
        public String DiaString { get; set; }
        public decimal Codigo_Especialidad { get; set; }
        public bool Estado { get; set; }
        public string Diagnostico { get; set; }
        public string Sintomas { get; set; }
        public DateTime Horario_Llegada { get; set; }
        public DateTime Horario_Atencion { get; set; }


        public int DameEspecialidadDelTurno(DateTime fecha, Afiliado afiliado, Profesional profesional)
        {
            int i = -1;
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@profesional", profesional.Id));
            ListaParametros.Add(new SqlParameter("@persona", afiliado.Codigo_Persona));
            ListaParametros.Add(new SqlParameter("@horario", fecha));

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT * FROM mario_killers.Turno where (profesional=@profesional and persona=@persona and horario=@horario)", "T", ListaParametros);

            if (lector.HasRows)
            {
                lector.Read();
                i= (int)(decimal)lector["especialidad"];
            }
            return i;
        }
    }
}
