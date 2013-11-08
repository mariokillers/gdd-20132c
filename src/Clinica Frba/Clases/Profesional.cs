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

        public Profesional(int personaId)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@persona", personaId));
            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT * FROM mario_killers.ProfesionalYPersona where codigoPersona=@persona", "T", ListaParametros);

            if (lector.HasRows)
            {
                lector.Read();
                if (lector["matricula"] != DBNull.Value)
                {
                    Matricula = (int)(decimal)lector["matricula"];
                }
                else { Matricula = -1; } //LE PONGO EN -1 PORQUE NO TIENE MATRICULA
                Mail = (string)lector["mail"];
                Nombre = (string)lector["nombre"];
                Apellido = (string)lector["apellido"];
                Id = (int)lector["codigoPersona"];
                //unProfesional.Id_User = Name; VER PORQUE NO FUNCIONA
                NumeroDocumento = (decimal)lector["documento"];
                Direccion = (string)lector["direccion"];
                FechaNacimiento = (DateTime)lector["fechaNac"];
                Sexo = (string)lector["sexo"];
                Telefono = (int)(decimal)lector["tel"];
                TipoDocumento = (decimal)lector["tipo_doc"];
            }
        }

        public Profesional()
        { }
        public bool RegistrarRango(List<Rango> listaDeRangos)
        {
            try 
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(new SqlParameter("@profesional", Id)); 
                foreach (Rango unRango in listaDeRangos)
                {
                    ListaParametros.Add(new SqlParameter("@dia", unRango.Dia.Id));
                    ListaParametros.Add(new SqlParameter("@hora_desde", unRango.HoraDesde));
                    ListaParametros.Add(new SqlParameter("@hora_hasta", unRango.HoraHasta));
                    Clases.BaseDeDatosSQL.EscribirEnBase("insert into mario_killers.Rango ( profesional, dia, hora_desde , hora_hasta) values (@profesional, @dia,@hora_desde, @hora_hasta)", "T", ListaParametros);
                }
                return true;
            }
            catch { return false; }
        }

        public bool RegistrarAgenda(DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(new SqlParameter("@profesional", Id)); 
                ListaParametros.Add(new SqlParameter("@desde", fechaDesde.Date));
                ListaParametros.Add(new SqlParameter("@hasta", fechaHasta.Date));

                return Clases.BaseDeDatosSQL.EscribirEnBase("insert into mario_killers.Agenda ( profesional, desde , hasta) values (@profesional, @desde, @hasta)", "T", ListaParametros);
            }
            catch { return false; }
        }

        public DateTime ObtenerAgendaDesde()
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@profesional", Id));

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT * FROM mario_killers.Agenda where profesional=@profesional", "T", ListaParametros);

            if (lector.HasRows)
            {
                lector.Read();

            } return (DateTime)lector["desde"];
        }

        public DateTime ObtenerAgendaHasta()
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@profesional", Id));

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT * FROM mario_killers.Agenda where profesional=@profesional", "T", ListaParametros);

            if (lector.HasRows)
            {
                lector.Read();

            } return (DateTime)lector["hasta"];
        }

        public bool EliminarAgenda()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(new SqlParameter("@profesional", Id));
                return Clases.BaseDeDatosSQL.EscribirEnBase("delete from mario_killers.Rango where profesional=@profesional", "T", ListaParametros);
            }
            catch { return false; }
        }

        public List<Rango> ObtenerAgenda()
        {
            List<Rango> lista = new List<Rango>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@profesional", Id));
            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT * FROM mario_killers.Rango where profesional=@profesional", "T", ListaParametros);
            
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Rango unRango = new Rango();
                    unRango.Dia = new Dias((int)(decimal)lector["dia"]);
                    unRango.StringDia = unRango.Dia.Detalle;
                    unRango.HoraDesde = (TimeSpan)lector["hora_desde"];
                    unRango.HoraHasta = (TimeSpan)lector["hora_hasta"];
                    lista.Add(unRango);
                }
            }
            return lista;
        }
    }
}
