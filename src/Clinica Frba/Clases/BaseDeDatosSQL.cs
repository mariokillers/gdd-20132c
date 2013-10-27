using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Clases
{
    public class BaseDeDatosSQL
    {
        private static SqlConnection _conexion = new SqlConnection();
        public static SqlConnection ObtenerConexion()
        {
            if (_conexion.State == ConnectionState.Closed)
            {
                _conexion.ConnectionString = @"User ID=gd;Initial Catalog=GD2C2013;Data Source=localhost\SQLSERVER2008;Password=gd2013";
                _conexion.Open();
            }
            return _conexion;
        }

        public static SqlDataReader ObtenerDataReader(string commandtext, string commandtype, List<SqlParameter> ListaParametro)
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

        public static bool EscribirEnBase(string commandtext, string commandtype, List<SqlParameter> ListaParametro)
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
            { return false; }
        }
    }

}
