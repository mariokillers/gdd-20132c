using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Clinica_Frba.Clases
{
    public class BonoFarmacia
    {
        public int Id { get; set; }
        public int Codigo_Compra { get; set; }
        public int Codigo_Receta { get; set; }
        public int Codigo_Plan { get; set; }
        public int Codigo_Turno { get; set; }
        public int Precio { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public BonoFarmacia(Afiliado unAfiliado)
        {
            Precio = (int)(new Plan((int)unAfiliado.Plan_Medico)).Precio_Bono_Farmacia;
            Codigo_Plan = (int)unAfiliado.Plan_Medico;
        }

        public BonoFarmacia(int codigo)
        {
            Id = codigo;
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@codigo", codigo));

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT * FROM mario_killers.Bono_Farmacia where codigo=@codigo", "T", ListaParametros);

            if (lector.HasRows)
            {
                lector.Read();
                Codigo_Turno = (int)lector["turno"];
                Codigo_Plan = (int)lector["plan_medico"];
                Codigo_Compra = (int)lector ["compra"];
                Compra unaCompra = new Compra(Codigo_Compra);
                FechaVencimiento = unaCompra.Fecha.AddDays(60);
            }
        }

        public bool EstasVencido(DateTime hoy)
        {
            return (FechaVencimiento.Date < hoy.Date);
        }
    }
}