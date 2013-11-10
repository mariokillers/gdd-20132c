using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Clinica_Frba.Clases
{
    public class Agenda
    {
        public decimal Profesional { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }


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
        }
    }
}
