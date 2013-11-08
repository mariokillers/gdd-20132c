﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Windows.Forms;

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
                    unAfiliado.Id = (int)(decimal)lector["persona"];
                    unAfiliado.Apellido = (string)lector["apellido"];
                    unAfiliado.Nombre = (string)lector["nombre"];
                    unAfiliado.Numero_Grupo = (decimal)lector["grupo_familia"];
                    unAfiliado.Numero_Familiar = (decimal)lector["nro_familiar"];
                    unAfiliado.NumeroDocumento = (decimal)lector["documento"];
                    unAfiliado.Plan_Medico = (decimal)lector["plan_medico"];
                    unAfiliado.FechaNacimiento = (DateTime)lector["fecha_nac"];
                    unAfiliado.Direccion = (String)lector["direccion"];
                    unAfiliado.TipoDocumento = (decimal)lector["tipo_doc"];
                    unAfiliado.Sexo = (string)lector["sexo"];
                    unAfiliado.Mail = (String)lector["mail"];
                    unAfiliado.Telefono = (decimal)lector["telefono"];
                    unAfiliado.Cantidad_Hijos = (decimal)lector["cant_hijos"];
                    unAfiliado.Estado_Civil = (decimal)lector["estado_civil"];
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
                    unAfiliado.Id = (int)lector["persona"];
                    unAfiliado.Apellido = (string)lector["apellido"];
                    unAfiliado.Nombre = (string)lector["nombre"];
                    unAfiliado.Numero_Grupo = (decimal)lector["grupo_familia"];
                    unAfiliado.Numero_Familiar = (decimal)lector["nro_familiar"];
                    unAfiliado.NumeroDocumento = (decimal)lector["documento"];
                    unAfiliado.Plan_Medico = (decimal)lector["plan_medico"];
                    unAfiliado.FechaNacimiento = (DateTime)lector["fecha_nac"];
                    unAfiliado.Direccion = (String)lector["direccion"];
                    unAfiliado.TipoDocumento = (decimal)lector["tipo_doc"];
                    unAfiliado.Sexo = (String)lector["sexo"];
                    unAfiliado.Mail = (String)lector["mail"];
                    unAfiliado.Telefono = (decimal)lector["telefono"];
                    unAfiliado.Cantidad_Hijos = (decimal)lector["cant_hijos"];
                    unAfiliado.Estado_Civil = (decimal)lector["estado_civil"];
                    listaDeAfiliados.Add(unAfiliado);
                }
            }
            return listaDeAfiliados; ;
        }

        public static void Modificar(Afiliado afil)
        {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(new SqlParameter("@id", afil.Id));
                ListaParametros.Add(new SqlParameter("@estado_civil", afil.Estado_Civil));
                ListaParametros.Add(new SqlParameter("@cant_hijos", afil.Cantidad_Hijos));

                Clases.BaseDeDatosSQL.EscribirEnBase("UPDATE mario_killers.Afiliado SET estado_civil = @estado_civil, cant_hijos = @cant_hijos WHERE persona = @id", "T", ListaParametros);

                List<SqlParameter> ListaParametros2 = new List<SqlParameter>();
                ListaParametros2.Add(new SqlParameter("@id", afil.Id));
                ListaParametros2.Add(new SqlParameter("@direccion", afil.Direccion));
                ListaParametros2.Add(new SqlParameter("@mail", afil.Mail));
                ListaParametros2.Add(new SqlParameter("@sexo", (char)afil.Sexo[0]));
                ListaParametros2.Add(new SqlParameter("@telefono", afil.Telefono));
                
                Clases.BaseDeDatosSQL.EscribirEnBase("UPDATE mario_killers.Persona SET direccion = @direccion, mail = @mail, sexo = @sexo, telefono = @telefono WHERE id = @id", "T", ListaParametros2);

                List<SqlParameter> ListaParametros3 = new List<SqlParameter>();
                ListaParametros3.Add(new SqlParameter("@plan_medico", afil.Plan_Medico));
                ListaParametros3.Add(new SqlParameter("@grupo_familia", afil.Numero_Grupo));

                Clases.BaseDeDatosSQL.EscribirEnBase("UPDATE mario_killers.Grupo_Familia SET plan_medico = @plan_medico WHERE codigo = @grupo_familia", "T", ListaParametros3);
   
        }
        
        public static decimal AgregarGrupo(Afiliado afil)
        {

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@plan_medico", afil.Plan_Medico));
            ListaParametros.Add(new SqlParameter("@afil_viejo", afil.Id));
            SqlParameter paramRet = new SqlParameter("@ret", System.Data.SqlDbType.Decimal);
            paramRet.Direction = System.Data.ParameterDirection.Output;
            ListaParametros.Add(paramRet);

            decimal ret = Clases.BaseDeDatosSQL.ExecStoredProcedure("mario_killers.agregarPlanAlGrupo", ListaParametros);

            return (ret*100 + 1);        
        }

        public static decimal AgregarAfiliado(Afiliado afil)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@nombre", afil.Nombre));
            ListaParametros.Add(new SqlParameter("@apellido", afil.Apellido));
            ListaParametros.Add(new SqlParameter("@fecha_nac", afil.FechaNacimiento));
            ListaParametros.Add(new SqlParameter("@sexo", afil.Sexo));
            ListaParametros.Add(new SqlParameter("@tipo_doc", (int)afil.TipoDocumento));
            ListaParametros.Add(new SqlParameter("@documento", (int)afil.NumeroDocumento));
            ListaParametros.Add(new SqlParameter("@direccion", afil.Direccion));
            ListaParametros.Add(new SqlParameter("@telefono", (int)afil.Telefono));
            ListaParametros.Add(new SqlParameter("@estado_civil", (int)afil.Estado_Civil));
            ListaParametros.Add(new SqlParameter("@mail", afil.Mail));
            ListaParametros.Add(new SqlParameter("@cant_hijos", (int)afil.Cantidad_Hijos));
            ListaParametros.Add(new SqlParameter("@plan_medico", (int)afil.Plan_Medico));
            ListaParametros.Add(new SqlParameter("@nro_flia", (int)afil.Numero_Familiar));
            
            SqlParameter paramRet = new SqlParameter("@ret", System.Data.SqlDbType.Decimal);
            paramRet.Direction = System.Data.ParameterDirection.Output;
            ListaParametros.Add(paramRet);

            decimal ret = Clases.BaseDeDatosSQL.ExecStoredProcedure("mario_killers.agregarAfiliado", ListaParametros);
            
            return ret;
        }

        public static bool Eliminar(decimal id)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@id", id));
            return Clases.BaseDeDatosSQL.EscribirEnBase("UPDATE mario_killers.Afiliado SET Activo =0 where persona = @id", "T", ListaParametros);
        }
    }
}
