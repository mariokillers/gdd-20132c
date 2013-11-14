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
        public string Detalle { get; set; }
        public int Codigo_Compra { get; set; }
        public int Codigo_Receta { get; set; }
        public int Codigo_Plan { get; set; }
        public int Grupo_Flia { get; set; }
        public int Precio { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public BonoFarmacia(Afiliado unAfiliado)
        {
            Precio = (int)(new Plan((int)unAfiliado.Plan_Medico)).Precio_Bono_Farmacia;
            Codigo_Plan = (int)unAfiliado.Plan_Medico;
            Detalle = "Bono Farmacia";
            Grupo_Flia = (int)unAfiliado.Numero_Grupo;
        }

        public BonoFarmacia(int codigo)
        {
            Id = codigo;
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@codigo", codigo));

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT * FROM mario_killers.BonoYcompra where codigo=@codigo", "T", ListaParametros);

            if (lector.HasRows)
            {
                lector.Read();
                Codigo_Plan = (int)(decimal)lector["plan_medico"];
                Codigo_Compra = (int)(decimal)lector["compra"];
                Compra unaCompra = new Compra(Codigo_Compra);
                FechaVencimiento = unaCompra.Fecha.AddDays(60);
                Grupo_Flia = (int)(decimal)lector["grupo"];
                Detalle = "Bono Farmacia";
            }
        }

        public bool EstasVencido(DateTime hoy)
        {
            return (FechaVencimiento.Date < hoy.Date);
        }

        public bool PuedeUsarlo(BonoFarmacia unBono)
        {
            if (unBono.Grupo_Flia == Grupo_Flia)
            {
                return true;
            }
            else { return false; }
        }
    }
}