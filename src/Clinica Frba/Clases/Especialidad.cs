using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Clinica_Frba.Clases
{
    public class Especialidad
    {
        public decimal Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Tipo_Especialidad { get; set; }

        public Especialidad() { }

        public Especialidad(int codigo)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@codigo", codigo));

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT * FROM mario_killers.Especialidad WHERE codigo=@codigo", "T", ListaParametros);

            if (lector.HasRows)
            {
                lector.Read();
                Codigo = codigo;
                Descripcion = (string)lector["descripcion"];
                Tipo_Especialidad =(decimal)lector["tipo"];
            }
        }
    }
}