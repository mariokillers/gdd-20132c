using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Clinica_Frba.Clases
{
    public class Compra
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Codigo_Persona { get; set; }
        public int Codigo_Plan { get; set; }
        public List<BonoConsulta> BonosConsulta { get; set; }
        public List<BonoFarmacia> BonosFarmacia { get; set; }

        public Compra(Afiliado unAfiliado)
        {
            Fecha = DateTime.Today;
            Codigo_Persona = (int)unAfiliado.Id;
            Codigo_Plan = (int)unAfiliado.Plan_Medico;
        }

        public Compra(int codigo)
        {
            Id = codigo;
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@codigo", codigo));

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT * FROM mario_killers.Compra where id=@codigo", "T", ListaParametros);

            if (lector.HasRows)
            {
                lector.Read();
                Fecha= (DateTime)lector["fecha"];
                Codigo_Plan = (int)lector["plan_medico"];
                Codigo_Persona = (int)lector["persona"];
            }
        }
    }
}
