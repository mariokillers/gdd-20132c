using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Clinica_Frba.Clases
{
    class Especialidades
    {
        public static List<Especialidad> ObtenerEspecialidades()
        {
            List<Especialidad> Lista = new List<Especialidad>();

            List<OleDbParameter> ListaParametros = new List<OleDbParameter>();
            OleDbDataReader lector = Clases.BaseDeDatos.ObtenerDataReader("", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    //instancio un tipo
                    TipoEspecialidad tipoEsp = new TipoEspecialidad((int)lector["tipo"]);
                   
                    Especialidad unaEspecialidad = new Especialidad();
                    unaEspecialidad.Codigo = 0;//me lo devuelve la consulta
                    unaEspecialidad.Descripcion = (string)lector["desripcion"];
                    unaEspecialidad.Tipo_Especialidad = tipoEsp.Descripcion;
                    Lista.Add(unaEspecialidad);
                }
            }
            return Lista;
        }
    }
}
