using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Clinica_Frba.Clases
{
    class Afiliados
    {
        public static List<Afiliado> ObtenerAfiliados(String nombre, String apellido, String dni, String numeroAfiliado, decimal codigoPlan)
        {
            List<Afiliado> Lista = new List<Afiliado>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            if (nombre != "") ListaParametros.Add(new SqlParameter("@nombre", "%" + nombre + "%")); else ListaParametros.Add(new SqlParameter("@nombre", "%%"));
            if (apellido != "") ListaParametros.Add(new SqlParameter("@apellido", "%" + apellido + "%")); else ListaParametros.Add(new SqlParameter("@apellido", "%%"));
            if (dni != "") ListaParametros.Add(new SqlParameter("@dni", "%" + dni + "%")); else ListaParametros.Add(new SqlParameter("@dni", "%%"));
            if (numeroAfiliado != "") ListaParametros.Add(new SqlParameter("@numeroAfiliado", "%" + numeroAfiliado.Remove(numeroAfiliado.Length - 2) + "%")); else ListaParametros.Add(new SqlParameter("@numeroAfiliado", "%%"));
            if (codigoPlan != 0) ListaParametros.Add(new SqlParameter("@codigoPlan", "%" + codigoPlan + "%")); else ListaParametros.Add(new SqlParameter("@codigoPlan", 0));

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT grupo_familia, nro_familiar, apellido, nombre, documento, plan_medico FROM mario_killers.AfiliadosABM WHERE grupo_familia * 100 + nro_familiar LIKE @numeroAfiliado AND apellido LIKE @apellido AND nombre LIKE @nombre AND documento LIKE @dni AND plan_medico LIKE @codigoPlan", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Afiliado unAfiliado = new Afiliado();
                    unAfiliado.Apellido = (string)lector["apellido"];
                    unAfiliado.Nombre = (string)lector["nombre"];
                    unAfiliado.Numero_Grupo = (decimal)lector["grupo_familia"];
                    unAfiliado.Numero_Familiar = (int)lector["nro_familiar"];
                    unAfiliado.NumeroDocumento = (decimal)lector["documento"];
                    unAfiliado.Plan_Medico = (decimal)lector["plan_medico"];
                    Lista.Add(unAfiliado);
                }
            }
            return Lista;
        }

        public static List<Afiliado> ObtenerTodos()
        {
            List<Afiliado> listaDeAfiliados = new List<Afiliado>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT * FROM mario_killers.AfiliadosABM", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Afiliado unAfiliado = new Afiliado();
                    unAfiliado.Apellido = (string)lector["apellido"];
                    unAfiliado.Nombre = (string)lector["nombre"];
                    unAfiliado.Numero_Grupo = (decimal)lector["grupo_familia"];
                    unAfiliado.Numero_Familiar = (int)lector["nro_familiar"];
                    unAfiliado.NumeroDocumento = (decimal)lector["documento"];
                    unAfiliado.Plan_Medico = (decimal)lector["plan_medico"];
                    listaDeAfiliados.Add(unAfiliado);
                }
            }
            return listaDeAfiliados; ;
        }
    }
}
