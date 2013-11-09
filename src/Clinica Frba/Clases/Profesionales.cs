using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clinica_Frba.Abm_de_Profesional;
using System.Data.SqlClient;

namespace Clinica_Frba.Clases
{
    public class Profesionales
    {
        public static decimal AgregarProfesional(Profesional pro)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@nombre", pro.Nombre));
            ListaParametros.Add(new SqlParameter("@apellido", pro.Apellido));
            ListaParametros.Add(new SqlParameter("@fecha_nac", pro.FechaNacimiento));
            ListaParametros.Add(new SqlParameter("@sexo", pro.Sexo));
            ListaParametros.Add(new SqlParameter("@tipo_doc", (int)pro.TipoDocumento));
            ListaParametros.Add(new SqlParameter("@documento", (int)pro.NumeroDocumento));
            ListaParametros.Add(new SqlParameter("@direccion", pro.Direccion));
            ListaParametros.Add(new SqlParameter("@telefono", (int)pro.Telefono));
            ListaParametros.Add(new SqlParameter("@mail", pro.Mail));
            ListaParametros.Add(new SqlParameter("@matricula", (int)pro.Matricula));

            SqlParameter paramRet = new SqlParameter("@ret", System.Data.SqlDbType.Decimal);
            paramRet.Direction = System.Data.ParameterDirection.Output;

            ListaParametros.Add(paramRet);
            decimal ret = Clases.BaseDeDatosSQL.ExecStoredProcedure("mario_killers.agregarProfesional", ListaParametros);

            foreach (Especialidad unaEsp in pro.Especialidades)
            {
                Especialidades.AgregarEspecialidadEnProfesional(ret, unaEsp);
            }

            return ret;

        }

        public static List<Profesional> ObtenerProfesionales(String nombre, String apellido, String dni, String numeroMatricula, decimal especialidad)
        {
            List<Profesional> Lista = new List<Profesional>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            if (nombre != "") ListaParametros.Add(new SqlParameter("@nombre", "%" + nombre + "%")); else ListaParametros.Add(new SqlParameter("@nombre", "%%"));
            if (apellido != "") ListaParametros.Add(new SqlParameter("@apellido", "%" + apellido + "%")); else ListaParametros.Add(new SqlParameter("@apellido", "%%"));
            if (dni != "") ListaParametros.Add(new SqlParameter("@dni", "%" + dni + "%")); else ListaParametros.Add(new SqlParameter("@dni", "%%"));
            if (numeroMatricula != "") ListaParametros.Add(new SqlParameter("@matricula", "%" + numeroMatricula + "%")); else ListaParametros.Add(new SqlParameter("@matricula", "%%"));
            if (especialidad != 0) ListaParametros.Add(new SqlParameter("@especialidad", "%" + especialidad + "%")); else ListaParametros.Add(new SqlParameter("@especialidad", 0));

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT * FROM mario_killers.AfiliadosABM WHERE grupo_familia * 100 + nro_familiar LIKE @numeroAfiliado AND apellido LIKE @apellido AND nombre LIKE @nombre AND documento LIKE @dni AND plan_medico LIKE @codigoPlan", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Profesional unProfesional = new Profesional();
                    unProfesional.Id = (int)(decimal)lector["persona"];
                    unProfesional.Apellido = (string)lector["apellido"];
                    unProfesional.Nombre = (string)lector["nombre"];
                    unProfesional.Matricula = (int)(decimal)lector["matricula"];
                    unProfesional.NumeroDocumento = (decimal)lector["documento"];
                    unProfesional.FechaNacimiento = (DateTime)lector["fecha_nac"];
                    unProfesional.Direccion = (String)lector["direccion"];
                    unProfesional.TipoDocumento = (decimal)lector["tipo_doc"];
                    unProfesional.Sexo = (string)lector["sexo"];
                    unProfesional.Mail = (String)lector["mail"];
                    unProfesional.Telefono = (decimal)lector["telefono"];
                    Lista.Add(unProfesional);
                }
            }
            return Lista;
        }

        public static List<Profesional> ObtenerTodos()
        {
            List<Profesional> listaDeProfesionales = new List<Profesional>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT * FROM mario_killers.ProfesionalesABM", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Profesional unProfesional = new Profesional();
                    unProfesional.Id = (int)(decimal)lector["persona"];
                    unProfesional.Apellido = (string)lector["apellido"];
                    unProfesional.Nombre = (string)lector["nombre"];
                    unProfesional.Matricula = (int)(decimal)lector["matricula"];
                    unProfesional.NumeroDocumento = (decimal)lector["documento"];
                    unProfesional.FechaNacimiento = (DateTime)lector["fecha_nac"];
                    unProfesional.Direccion = (String)lector["direccion"];
                    unProfesional.TipoDocumento = (decimal)lector["tipo_doc"];
                    unProfesional.Sexo = (string)lector["sexo"];
                    unProfesional.Mail = (String)lector["mail"];
                    unProfesional.Telefono = (decimal)lector["telefono"];
                    listaDeProfesionales.Add(unProfesional);
                }
            }
            return listaDeProfesionales;
        }
    }
}
