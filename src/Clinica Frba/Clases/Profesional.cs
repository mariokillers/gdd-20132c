using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clinica_Frba.Clase_Persona;
using System.Data.SqlClient;
using Clinica_Frba.Clases;

namespace Clinica_Frba.Abm_de_Profesional
{
    public class Profesional : Persona
    {
        public int Matricula { get; set; }
        private List<Especialidad> Especialidades { get; set; } 

        /*public Profesional(int codigoPersona)
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
        }*/

        public Profesional(int personaId)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@persona", personaId));
            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT * FROM mario_killers.ProfesionalYPersona where codigoPersona=@persona", "T", ListaParametros);

            if (lector.HasRows)
            {
                lector.Read();
                Matricula = (int)(decimal)lector["matricula"];
                Mail = (string)lector["mail"];
                Nombre = (string)lector["nombre"];
                Apellido = (string)lector["apellido"];
                Id = (decimal)lector["codigoPersona"];
                //unProfesional.Id_User = Name; VER PORQUE NO FUNCIONA
                NumeroDocumento = (decimal)lector["documento"];
                Direccion = (string)lector["direccion"];
                FechaNacimiento = (DateTime)lector["fechaNac"];
                Sexo = (string)lector["sexo"];
                Telefono = (decimal)lector["telefono"];
                TipoDocumento = (decimal)lector["tipo_doc"];
            }
        }

        public Profesional()
        { }

        public bool RegistrarAgenda(DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(new SqlParameter("@profesional", Id)); //ESTA ES LA PK, NO?
                ListaParametros.Add(new SqlParameter("@desde", fechaDesde.Date));
                ListaParametros.Add(new SqlParameter("@hasta", fechaHasta.Date));

                return Clases.BaseDeDatosSQL.EscribirEnBase("insert into mario_killers.Agenda ( profesional, desde , hasta) values (@profesional, @desde, @hasta)", "T", ListaParametros);
            }
            catch { return false; }
        }

        public bool EliminarAgenda()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(new SqlParameter("@profesional", Id));
                return Clases.BaseDeDatosSQL.EscribirEnBase("delete from mario_killers.Agenda where profesional=@profesional", "T", ListaParametros);
            }
            catch { return false; }
        }

        static List<Rango> ObtenerAgenda()
        {
            List<Rango> lista = new List<Rango>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            //ListaParametros.Add(new SqlParameter("@profesional", Id));
            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT * FROM mario_killers.Rango where profesional=@profesional", "T", ListaParametros);
            
            if (lector.HasRows)
            {
                lector.Read();
                Rango unRango = new Rango();
                unRango.Dia = new Dias((int)lector["dia"]);
                unRango.HoraDesde = (TimeSpan)lector["hora_desde"];
                unRango.HoraHasta = (TimeSpan)lector["hora_hasta"];
                lista.Add(unRango);
            }
            return lista;
        }
    }
}
