using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

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
        public bool Activo { get; set; }
        public int Grupo_Flia { get; set; }

        public BonoConsulta(Afiliado unAfiliado)
        {
            Precio = (int)(new Plan((int)unAfiliado.Plan_Medico)).Precio_Bono_Consulta;
            Codigo_Plan = (int)unAfiliado.Plan_Medico;
            Grupo_Flia = (int)unAfiliado.Numero_Grupo;
        }

        public BonoConsulta(int codigo)
        {
            Id = codigo;
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@codigo", codigo));

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT * FROM mario_killers.BonoConsultaYcompra where codigo=@codigo", "T", ListaParametros);

            if (lector.HasRows)
            {
                lector.Read();
                Codigo_Plan = (int)(decimal)lector["plan_medico"];
                Codigo_Compra = (int)(decimal)lector["compra"];
                Compra unaCompra = new Compra(Codigo_Compra);
                Grupo_Flia = (int)(decimal)lector["grupo"];
                Activo = (bool)lector["activo"];
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

        public bool Usar(Afiliado afiliado, Turno turno)
        {

            //NUMERO DE CONSULTAS DEL AFILIADO
            int cant_atenciones = 0;
            List<SqlParameter> ListaParametros3 = new List<SqlParameter>();
            ListaParametros3.Add(new SqlParameter("@persona", afiliado.Codigo_Persona));
            String query = @"SELECT COUNT(*) AS cant_aten
                             FROM mario_killers.Atencion A JOIN mario_killers.Turno T ON T.id = A.id
                             WHERE T.persona = @persona";

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader(query, "T", ListaParametros3);
            if (lector.HasRows)
            {
                lector.Read();
                cant_atenciones = (int)lector["cant_aten"] + 1;
            }

            //REGISTRAR HORARIO LLEGADA
            DateTime horario_llegada = (DateTime)(DateTime.Parse(System.Configuration.ConfigurationSettings.AppSettings["Fecha"])).AddHours(System.DateTime.Now.TimeOfDay.Hours).AddMinutes(System.DateTime.Now.Minute);
            List<SqlParameter> ListaParametros2 = new List<SqlParameter>();
            ListaParametros2.Add(new SqlParameter("@codigo", turno.Id));
            ListaParametros2.Add(new SqlParameter("@horario_llegada", (DateTime)horario_llegada));

            Clases.BaseDeDatosSQL.EscribirEnBase("update mario_killers.Turno set horario_llegada = @horario_llegada where id=@codigo ", "T", ListaParametros2);

            //USAR BONO Y REGISTRAR CANT CONSULTAS
            
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@codigo", Id));
            ListaParametros.Add(new SqlParameter("@cant", cant_atenciones));

            return Clases.BaseDeDatosSQL.EscribirEnBase("update mario_killers.Bono_Consulta set activo = 0, cant_consultas = @cant where id = @codigo", "T", ListaParametros);
        }
    }
}
