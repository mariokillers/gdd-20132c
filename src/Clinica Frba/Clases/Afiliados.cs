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

            String auxAfil = numeroAfiliado.ToString();


            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter ("@nombre", "%"+nombre+"%"));
            ListaParametros.Add(new SqlParameter("@apellido", "%"+apellido+"%"));
            ListaParametros.Add(new SqlParameter("@dni", dni));
            ListaParametros.Add(new SqlParameter("@numeroAfiliado", auxAfil.Remove(auxAfil.Length - 2)));
            ListaParametros.Add(new SqlParameter("@codigoPlan", codigoPlan));

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT grupo_familia, nro_familiar, apellido, nombre, documento, plan_familiar FROM mario_killers.AfiliadosABM WHERE grupo_familia *100 + nro_familiar = @numeroAfiliado OR apellido LIKE @apellido OR nombre LIKE @nombre OR documento = @dni OR plan_familiar = @codigoPlan", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Afiliado unAfiliado = new Afiliado();
                    unAfiliado.Apellido = (string)lector["apellido"];
                    unAfiliado.Nombre = (string)lector["nombre"];
                    unAfiliado.Numero_Grupo = (decimal)lector["grupo_familia"];
                    unAfiliado.Numero_Familiar = (int)lector["nro_familiar"];
                    unAfiliado.Documento = (decimal)lector["documento"];
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
                    unAfiliado.Documento = (decimal)lector["documento"];
                    unAfiliado.Plan_Medico = (decimal)lector["plan_medico"];
                    listaDeAfiliados.Add(unAfiliado);
                }
            }
            return listaDeAfiliados; ;
        }
    }
}
