using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Clases
{
    public class BaseDeDatos
    {
        private static OleDbConnection _conexion = new OleDbConnection();

        public static OleDbConnection ObtenerConexion()
        {
            if (_conexion.State == ConnectionState.Closed)
            {
                _conexion.ConnectionString = @"Provider=SQLOLEDB.1;Persist Security Info=False;User ID=gd;Initial Catalog=GD2C2013;Data Source=localhost\SQLSERVER2008;Password=gd2013";
                _conexion.Open();
            }
            return _conexion;
        }

        public static OleDbDataReader ObtenerDataReader(string commandtext, string commandtype, List<OleDbParameter> ListaParametro)
        {

            OleDbCommand comando = new OleDbCommand();
            comando.Connection = ObtenerConexion();
            comando.CommandText = commandtext;
            foreach (OleDbParameter elemento in ListaParametro)
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
            OleDbCommand comando = new OleDbCommand();
            comando.Connection = ObtenerConexion();
            comando.CommandText = commandtext;
            foreach (OleDbParameter elemento in ListaParametro)
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
            {   return false;   }
        }

        public static bool ObtenerCampo(int codigo, string tabla, string campo)
        {
            try
            {
                OleDbCommand comando = new OleDbCommand();
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
