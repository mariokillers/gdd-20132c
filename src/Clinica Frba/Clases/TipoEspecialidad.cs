using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Clinica_Frba.Clases
{
    class TipoEspecialidad
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }

        public TipoEspecialidad(int codigo)
        {
            List<OleDbParameter> ListaParametros = new List<OleDbParameter>();
            ListaParametros.Add(new OleDbParameter("@codigo", codigo));

            OleDbConnection conexion = Clases.BaseDeDatos.ObtenerConexion();
            OleDbDataReader lector = Clases.BaseDeDatos.ObtenerDataReader("", "T", ListaParametros);

            if (lector.HasRows)
            {
                lector.Read();
                Descripcion = (string) lector ["descripcion"];
            }
        }
    }
}
