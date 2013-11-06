using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clinica_Frba.Clase_Persona;
using System.Data.SqlClient;
using Clinica_Frba.Clases;

namespace Clinica_Frba.Abm_de_Profesional
{
    class Profesional : Persona
    {
        public Persona Persona { get; set; }
        public int Matricula { get; set; }
        public List<Especialidad> Especialidades { get; set; } 

        public bool RegistrarAgenda()
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            //ListaParametros.Add(new SqlParameter("@dia", dia));

            return Clases.BaseDeDatosSQL.EscribirEnBase("", "T", ListaParametros);
        }

        public Profesional(int codigoPersona)
        {

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@codigoPersona", codigoPersona));

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT * FROM mario_killers.Profesional where persona=@codigoPersona", "T", ListaParametros);
            if (lector.HasRows)
            {
                lector.Read();
                Matricula = (int)lector["matricula"];

                //FALTA EL TEMA DE LAS ESPECIALIDADES
            }
        }

        public bool registrarAgenda(DateTime fechaDesde, DateTime fechaHasta)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@profesional", Persona)); //ESTA ES LA PK, NO?
            ListaParametros.Add(new SqlParameter("@desde", fechaDesde.Date));
            ListaParametros.Add(new SqlParameter("@hasta", fechaHasta.Date));

            return Clases.BaseDeDatosSQL.EscribirEnBase("insert into mario_killers.Agenda ( profesional, desde , hasta) values (@profesional, @desde, @hasta)", "T", ListaParametros);
        }
    }
}
