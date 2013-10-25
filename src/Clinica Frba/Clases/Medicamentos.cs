using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Clinica_Frba.Clases
{
    class Medicamentos
    {
        public static List<Medicamento> ObtenerMedicamentos()
        {
            List<Medicamento> Lista = new List<Medicamento>();

            List<OleDbParameter> ListaParametros = new List<OleDbParameter>();

            OleDbConnection conexion = Clases.BaseDeDatos.ObtenerConexion();
            OleDbDataReader lector = Clases.BaseDeDatos.ObtenerDataReader("", "T", ListaParametros);

            if (lector.HasRows)
            {
                Medicamento unMedicamento = new Medicamento();
                unMedicamento.Id = (int) lector ["id"];
                unMedicamento.Detalle = (string)lector["detalle"];
                Lista.Add(unMedicamento);
            }
            return Lista;
        }
    }
}
