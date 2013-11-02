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

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT * FROM mario_killers.AfiliadosABM WHERE grupo_familia * 100 + nro_familiar LIKE @numeroAfiliado AND apellido LIKE @apellido AND nombre LIKE @nombre AND documento LIKE @dni AND plan_medico LIKE @codigoPlan", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Afiliado unAfiliado = new Afiliado();
                    unAfiliado.Id = (decimal)lector["persona"];
                    unAfiliado.Apellido = (string)lector["apellido"];
                    unAfiliado.Nombre = (string)lector["nombre"];
                    unAfiliado.Numero_Grupo = (decimal)lector["grupo_familia"];
                    unAfiliado.Numero_Familiar = (decimal)lector["nro_familiar"];
                    unAfiliado.NumeroDocumento = (decimal)lector["documento"];
                    unAfiliado.Plan_Medico = (decimal)lector["plan_medico"];
                    unAfiliado.FechaNacimiento = (DateTime)lector["fecha_nac"];
                    unAfiliado.Direccion = (String)lector["direccion"];
                    //unAfiliado.TipoDocumento = (decimal)lector["tipo_doc"];
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
                    unAfiliado.Numero_Familiar = (decimal)lector["nro_familiar"];
                    unAfiliado.NumeroDocumento = (decimal)lector["documento"];
                    unAfiliado.Plan_Medico = (decimal)lector["plan_medico"];
                    listaDeAfiliados.Add(unAfiliado);
                }
            }
            return listaDeAfiliados; ;
        }

        public static bool Eliminar(decimal id)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@id", id));
            return Clases.BaseDeDatosSQL.EscribirEnBase("UPDATE mario_killers.Afiliado SET Activo =0 where persona = @id", "T", ListaParametros);
        }
    }
}
