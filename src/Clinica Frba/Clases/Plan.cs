using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Clinica_Frba.Clases
{
    class Plan
    {
        public decimal Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio_Bono_Consulta { get; set; }
        public decimal Precio_Bono_Farmacia { get; set; }

        public Plan(int idPlan)
        {
            Codigo = idPlan;
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@codigo", Codigo));

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT * FROM mario_killers.Plan_Medico where codigo=@codigo", "T", ListaParametros);

            if (lector.HasRows)
            {
                lector.Read();
                Descripcion = (string)lector["descripcion"];
                Precio_Bono_Consulta = (decimal)lector["precio_bono_consulta"];
                Precio_Bono_Farmacia = (decimal)lector["precio_bono_farmacia"];
            }
        }

        public Plan() { }
    }
}
