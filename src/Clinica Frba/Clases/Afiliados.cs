using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Clinica_Frba.Clases
{
    class Afiliados
    {
        public static List<Afiliado> ObtenerAfiliados()
        {
            List<Afiliado> Lista = new List<Afiliado>();

            List<OleDbParameter> ListaParametros = new List<OleDbParameter>();
            OleDbDataReader lector = Clases.BaseDeDatos.ObtenerDataReader("", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Afiliado unAfiliado = new Afiliado();
                    //unAfiliado.Codigo = 0;//me lo devuelve la consulta
                    //unAfiliado.Descripcion = (string)lector["desripcion"];
                    Lista.Add(unAfiliado);
                }
            }
            return Lista;
        }
    }
}
