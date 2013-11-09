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






            return ret;

        }
    }
}
