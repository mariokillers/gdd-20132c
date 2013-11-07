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
                _conexion.ConnectionString = @"User ID=gd;Initial Catalog=GD2C2013;Data Source=localhost\SQLSERVER2008;Password=gd2013;MultipleActiveResultSets=True";
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

        public static int ObtenerUltimoAgregado(SqlTransaction trans)
        {
            SqlDataReader reader = ObtenerDataReader("SELECT @@IDENTITY AS Id", "T", trans);
            if (reader.HasRows)
            {
                reader.Read();

                return Convert.ToInt32(reader["Id"]);
            }
            throw new Exception("error al obtener id");
        }

        public static SqlTransaction EscribirEnBase(string commandtext, string commandtype, List<SqlParameter> ListaParametro, SqlTransaction trans)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = ObtenerConexion();
            comando.CommandText = commandtext;
            comando.Transaction = trans;
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
            comando.ExecuteNonQuery();

            return trans;
        }

        public static SqlDataReader ObtenerDataReader(string commandtext, string commandtype, SqlTransaction trans)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = trans.Connection;
            comando.CommandText = commandtext;
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
            comando.Transaction = trans;

            return comando.ExecuteReader();
        }

        public static String ExecStoredProcedure(string commandtext, List<SqlParameter> ListaParametro, SqlTransaction trans)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = ObtenerConexion();
            comando.CommandText = commandtext;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Transaction = trans;

            foreach (SqlParameter elemento in ListaParametro)
            {
                comando.Parameters.Add(elemento);
            }

            comando.ExecuteNonQuery();
            return (String)comando.Parameters["@Ret"].Value;
        }


        /*
        SqlCommand cmd = new SqlCommand("MyStoredProcedure", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter parm = new SqlParameter("@pkid", SqlDbType.Int);
        parm.Value = 1;
        parm.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(parm);
        SqlParameter parm2 = new SqlParameter("@ProductName", SqlDbType.VarChar);
        parm2.Size = 50;
        parm2.Direction = ParameterDirection.Output; // This is important!
        cmd.Parameters.Add(parm2);
        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();
         *         // Print the output value
    Console.WriteLine(cmd.Parameters["@ProductName"].Value); 
    Console.ReadLine()
        */


        internal static string ExecStoredProcedure(string p, List<SqlParameter> ListaParametros)
        {
            throw new NotImplementedException();
        }
    }

}
