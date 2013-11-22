using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Clinica_Frba.Clases
{
    public class BonoConsulta
    {
        public int Id { get; set; }
        public int Codigo_Compra { get; set; }
        public int Contador { get; set; }
        public int Codigo_Plan { get; set; }
        public int Codigo_Turno { get; set; }
        public int Precio { get; set; }
        public bool Usado { get; set; }
        public int Grupo_Flia { get; set; }

        public BonoConsulta(Afiliado unAfiliado)
        {
            Precio = (int)(new Plan((int)unAfiliado.Plan_Medico)).Precio_Bono_Consulta;
            Codigo_Plan = (int)unAfiliado.Plan_Medico;
            Grupo_Flia = (int)unAfiliado.Numero_Grupo;
            //Codigo_Turno = (int)unAfiliado.ProximoTurno();
        }

        public BonoConsulta(int codigo)
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
                Grupo_Flia = (int)(decimal)lector["grupo"];
                //Detalle = "Bono Farmacia";
                Usado = (bool)lector["activo"];
            }
        }

        public bool PuedeUsarlo(int grupo)
        {
            if (grupo == Grupo_Flia)
            {
                return true;
            }
            else { return false; }
        }

        public bool Usar()
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@codigo", Id));
            //ListaParametros.Add(new SqlParameter("@codigo", Contador));

            return Clases.BaseDeDatosSQL.EscribirEnBase("update mario_killers.Bono_Consulta set activo =0 where codigo=@codigo ", "T", ListaParametros);
        }
    }
}
