using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Clinica_Frba
{
    public class BaseDeDatos
    {
        private static SqlConnection _conexion = new SqlConnection();

        public static SqlConnection ObtenerConexion()
        {
            if (_conexion.State == ConnectionState.Closed)
            {
                _conexion.ConnectionString = @"Provider=Microsoft.Jet.Oledb.4.0; Data Source=C:\Documents and Settings\Uri\Mis documentos\Historias Clinicas\Consultorio.mdb";
                _conexion.Open();
            }
            return _conexion;
        }

        public static SqlDataReader ObtenerDataReader(string commandtext, string commandtype, List<OleDbParameter> ListaParametro)
        {

            SqlCommand comando = new SqlCommand();
            comando.Connection = ObtenerConexion();
            comando.CommandText = commandtext;
            foreach (SqlParameter elemento in ListaParametro)
            {
                comando.Parameters.Add(elemento);
            }
            switch (commandtype)
            {
                case "T":
                    comando.CommandType = CommandType.Text;
                    break;
                case "TD":
                    comando.CommandType = CommandType.TableDirect;
                    break;
                case "SP":
                    comando.CommandType = CommandType.StoredProcedure;
                    break;
            }
            return comando.ExecuteReader();
        }

        public static bool EscribirEnBase(string commandtext, string commandtype, List<OleDbParameter> ListaParametro)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = ObtenerConexion();
            comando.CommandText = commandtext;
            foreach (SqlParameter elemento in ListaParametro)
            {
                comando.Parameters.Add(elemento);
            }
            switch (commandtype)
            {
                case "T":
                    comando.CommandType = CommandType.Text;
                    break;
                case "SP":
                    comando.CommandType = CommandType.StoredProcedure;
                    break;
            }
            try
            {
                comando.ExecuteNonQuery();
                return true;
            }
            catch
            { return false; }
        }

        public static bool ObtenerCampo(int codigo, string tabla, string campo)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = ObtenerConexion();
                comando.CommandText = "select " + campo + "from " + tabla + "where codigo= " + codigo;
                object objeto = comando.ExecuteScalar();
                return true;
            }
            catch
            {   return false;   }
        }
    }
}
