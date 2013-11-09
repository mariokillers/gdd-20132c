﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clinica_Frba.Clase_Persona;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Clinica_Frba.Clases
{
    public class Afiliado: Persona
    {
        public int Codigo_Persona { get; set; }
        public int Numero_Familiar { get; set; }
        public int Numero_Grupo { get; set; }
        public int Estado_Civil { get; set; }
        public int Cantidad_Hijos { get; set; }
        public bool Activo { get; set; }
        public int Plan_Medico { get; set; }

        public Afiliado(int codigoPersona)
        {
            Codigo_Persona = codigoPersona;
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@persona", codigoPersona));

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT * FROM mario_killers.Afiliado where persona=@persona", "T", ListaParametros);

            if (lector.HasRows)
            {
                lector.Read();
                
                //Apellido = (string)lector["apellido"];
                //Nombre = (string)lector["nombre"];
                Numero_Grupo = (int)lector["grupo_familia"];
                Numero_Familiar = (int)lector["nro_familiar"];
                //NumeroDocumento = (int)lector["documento"];
                //Plan_Medico = (int)lector["plan_medico"];
                //FechaNacimiento = (DateTime)lector["fecha_nac"];
                //Direccion = (String)lector["direccion"];
                //TipoDocumento = (int)lector["tipo_doc"];
                //Sexo = (String)lector["sexo"];
                //Mail = (String)lector["mail"];
                //Telefono = (int)lector["telefono"];
                Cantidad_Hijos = (int)lector["cant_hijos"];
                Estado_Civil = (int)lector["estado_civil"];
                Activo = (bool)lector["activo"];
            }
        }
       
        public bool Eliminar(int codigoGrupo, int numeroFamiliar)
        {
            List<SqlParameter> Lista = new List<SqlParameter>();
            //VER COMO ESTA EN LA DB (numeroAfiliado)
            Lista.Add(new SqlParameter("@codigoGrupo", codigoGrupo));
            Lista.Add(new SqlParameter("@numeroFamiliar", numeroFamiliar));
            return Clases.BaseDeDatosSQL.EscribirEnBase("update mario_killers.Paciente set Activo =0 where (Codigo_Grupo=@codigoGrupo and Nro_Familiar=@numeroFamiliar)", "T", Lista);
        }
        
        public Afiliado()
        { }

        public bool Agregar(Afiliado unAfiliado)
        {
            //ANTES DE DAR UNA ALTA DE AFILIADO,HAY QUE DAR DE ALTA LA PERSONA

            List<SqlParameter> Lista = new List<SqlParameter>();
            Lista.Add(new SqlParameter("@persona", unAfiliado.Codigo_Persona));
            Lista.Add(new SqlParameter("@estado_civil", unAfiliado.Estado_Civil));
            Lista.Add(new SqlParameter("@grupo_familia", unAfiliado.Numero_Grupo));
            Lista.Add(new SqlParameter("@nro_familiar", unAfiliado.Numero_Familiar));
            Lista.Add(new SqlParameter("@cant_hijos", unAfiliado.Cantidad_Hijos));
            Lista.Add(new SqlParameter("@activo", unAfiliado.Activo));

            return Clases.BaseDeDatosSQL.EscribirEnBase("insert into mario_killers.Afiliado ( persona, estado_civil , grupo_familia, nro_familiar, cant_hijos, activo) values (@persona, @estado_civil, @grupo_familia, @nro_familiar, @cant_hijos, @activo)", "T", Lista);
        }

        public bool ComprarBonos(Compra unaCompra)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(new SqlParameter("@persona", Codigo_Persona));
                ListaParametros.Add(new SqlParameter("@fecha", unaCompra.Fecha));
                ListaParametros.Add(new SqlParameter("@plan_medico", unaCompra.Codigo_Plan));
                SqlParameter paramRet = new SqlParameter("@ret", System.Data.SqlDbType.int);
                paramRet.Direction = System.Data.ParameterDirection.Output;
                ListaParametros.Add(paramRet);

                //INSERTA LA COMPRA Y TOMA EL ID QUE ACABA DE INSERTAR
                int ret = (int)Clases.BaseDeDatosSQL.ExecStoredProcedure("mario_killers.hacerCompra", ListaParametros);

                if (ret != -1)
                {
                    if (unaCompra.BonosConsulta.Count != 0)
                    {
                        foreach (BonoConsulta unBono in unaCompra.BonosConsulta)
                        {
                            AgregarBonoConsultaEnCompra(ret, unBono);
                        }
                    }
                    if (unaCompra.BonosFarmacia.Count != 0)
                    {
                        foreach (BonoFarmacia unBono in unaCompra.BonosFarmacia)
                        {
                            AgregarBonoFarmaciaEnCompra(ret, unBono);
                        }
                    }
                    return true;
                }
                else { return false; }
            }
            catch { return false; }
        }

        public static bool AgregarBonoConsultaEnCompra(int idCompra, BonoConsulta unBono)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@compra", idCompra));
            ListaParametros.Add(new SqlParameter("@plan_medico", unBono.Codigo_Plan));

            return Clases.BaseDeDatosSQL.EscribirEnBase("INSERT INTO mario_killers.Bono_Consulta(compra, plan_medico) VALUES (@compra, @plan_medico)", "T", ListaParametros);
        }

        public static bool AgregarBonoFarmaciaEnCompra(int idCompra, BonoFarmacia unBono)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@compra", idCompra));
            ListaParametros.Add(new SqlParameter("@plan_medico", unBono.Codigo_Plan));

            return Clases.BaseDeDatosSQL.EscribirEnBase("INSERT INTO mario_killers.Bono_Farmacia(compra, plan_medico) VALUES (@compra, @plan_medico)", "T", ListaParametros);
        }
    }
}
