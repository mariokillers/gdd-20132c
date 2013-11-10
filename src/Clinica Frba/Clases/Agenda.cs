using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Clinica_Frba.Abm_de_Profesional;

namespace Clinica_Frba.Clases
{
    public class Agenda
    {
        public decimal Profesional { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public List<Rango> Rangos { get; set; }

        public Agenda()
        {
            Rangos = new List<Rango>();
        }

        public void armarAgenda(decimal pro)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@id", pro));
            String query = @"SELECT desde, hasta 
                         FROM mario_killers.Agenda
                         WHERE profesional = @id";

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader(query, "T", ListaParametros);

            if (lector.HasRows)
            {
                lector.Read();
                this.FechaDesde = (DateTime)lector["desde"];
                this.FechaHasta = (DateTime)lector["hasta"];
            }

            /*---ARMAR LOS RANGOS----*/
            List<SqlParameter> ListaParametros2 = new List<SqlParameter>();
            ListaParametros2.Add(new SqlParameter("@id", pro));
            String queryRangos = @"SELECT dia, hora_desde, hora_hasta
                            FROM mario_killers.Rango    
                            WHERE profesional = @id";
            SqlDataReader lector2 = Clases.BaseDeDatosSQL.ObtenerDataReader(queryRangos, "T", ListaParametros2);

            if (lector2.HasRows)
            {
                while (lector2.Read())
                {
                    TimeSpan desde = (TimeSpan)lector2["hora_desde"];
                    TimeSpan hasta = (TimeSpan)lector2["hora_hasta"];
                    int dia = (int)(decimal)lector2["dia"];
                    Dias diau = new Dias(dia);
                    Rango unRango = new Rango(diau, desde, hasta);
                    this.Rangos.Add(unRango);
                }
            }
        }
    }
}
