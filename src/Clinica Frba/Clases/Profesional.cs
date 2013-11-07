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
        public int Matricula { get; set; }
        public List<Especialidad> Especialidades { get; set; } 

        public Profesional(int codigoPersona)
        {

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@codigoPersona", codigoPersona));

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT * FROM mario_killers.ProfesionalYPersona where codigoPersona=@codigoPersona", "T", ListaParametros);
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
            ListaParametros.Add(new SqlParameter("@profesional", Id)); //ESTA ES LA PK, NO?
            ListaParametros.Add(new SqlParameter("@desde", fechaDesde.Date));
            ListaParametros.Add(new SqlParameter("@hasta", fechaHasta.Date));

            return Clases.BaseDeDatosSQL.EscribirEnBase("insert into mario_killers.Agenda ( profesional, desde , hasta) values (@profesional, @desde, @hasta)", "T", ListaParametros);
        }

        public List<Rango> ObtenerAgenda()
        {
            List<Rango> lista = new List<Rango>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@profesional", Id));
            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT * FROM mario_killers.Rango where profesional=@profesional", "T", ListaParametros);
            
            if (lector.HasRows)
            {
                lector.Read();
                Rango unRango = new Rango();
                unRango.Dia = Dias.ObtenerDia((int)lector["dia"]); //FORMATO STRING
                //unRango.HoraDesde = ;
                //unRango.HoraHasta =;
                lista.Add(unRango);
            }
            return lista;
        }
    }
}
