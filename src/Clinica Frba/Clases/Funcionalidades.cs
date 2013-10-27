using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Clinica_Frba.Clases
{
    class Funcionalidades
    {
        public static List<Funcionalidad> ObtenerFuncionalidades()
        {
            List<Funcionalidad> Lista = new List<Funcionalidad>();

            List<OleDbParameter> ListaParametros = new List<OleDbParameter>();
            OleDbDataReader lector = Clases.BaseDeDatos.ObtenerDataReader("", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Funcionalidad unaFuncionalidad = new Funcionalidad();
                    unaFuncionalidad.Id = 0;//me lo devuelve la consulta
                    unaFuncionalidad.Nombre = (string)lector["nombre"];
                    Lista.Add(unaFuncionalidad);
                }
            }
            return Lista;
        }
    }
}
