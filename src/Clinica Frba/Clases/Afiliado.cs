using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clinica_Frba.Clase_Persona;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Clinica_Frba.Abm_de_Profesional;

namespace Clinica_Frba.Clases
{
    public class Afiliado: Persona
    {
        public int Codigo_Persona { get; set; }
        public decimal Numero_Familiar { get; set; }
        public decimal Numero_Grupo { get; set; }
        public decimal Estado_Civil { get; set; }
        public decimal Cantidad_Hijos { get; set; }
        public bool Activo { get; set; }
        public decimal Plan_Medico { get; set; }

        public Afiliado(int codigoPersona)
        {
            Codigo_Persona = codigoPersona;
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@persona", codigoPersona));

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT * FROM mario_killers.Afiliado join mario_killers.Grupo_Familia on grupo_familia=codigo where persona=@persona", "T", ListaParametros);

            if (lector.HasRows)
            {
                lector.Read();
                
                //Apellido = (string)lector["apellido"];
                //Nombre = (string)lector["nombre"];
                Numero_Grupo = (decimal)lector["grupo_familia"];
                Numero_Familiar = (decimal)lector["nro_familiar"];
                //NumeroDocumento = (int)lector["documento"];
                Plan_Medico = (decimal)lector["plan_medico"];
                //FechaNacimiento = (DateTime)lector["fecha_nac"];
                //Direccion = (String)lector["direccion"];
                //TipoDocumento = (int)lector["tipo_doc"];
                //Sexo = (String)lector["sexo"];
                //Mail = (String)lector["mail"];
                //Telefono = (int)lector["telefono"];
                Cantidad_Hijos = (decimal)lector["cant_hijos"];
                Estado_Civil = (decimal)lector["estado_civil"];
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

        public int ActualizarHistoriaClinica(Profesional unProfesional, DateTime hora, string sintomas, string diagnosticos, int codigoEspecialidad)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@afiliado", this.Id));
            ListaParametros.Add(new SqlParameter("@profesional", unProfesional.Id));
            ListaParametros.Add(new SqlParameter("@especialidad", codigoEspecialidad));
            ListaParametros.Add(new SqlParameter("@hora_atencion", hora));
            ListaParametros.Add(new SqlParameter("@diagnostico", diagnosticos));
            ListaParametros.Add(new SqlParameter("@sintomas", sintomas));
            SqlParameter paramRet = new SqlParameter("@ret", System.Data.SqlDbType.Decimal);
            paramRet.Direction = System.Data.ParameterDirection.Output;
            ListaParametros.Add(paramRet);

            int ret = (int)Clases.BaseDeDatosSQL.ExecStoredProcedure("mario_killers.agregarHClinica", ListaParametros);
            return ret;
        }

        public Afiliado(string numeroAfiliado)
        {
            int numGrupo = Int32.Parse(numeroAfiliado.Remove(numeroAfiliado.Length - 2));
            int numFamiliar = Int32.Parse(Utiles.ObtenerUltimos(numeroAfiliado, 2));

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@grupo_familia", numGrupo));
            ListaParametros.Add(new SqlParameter("@nro_familiar", numFamiliar));

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT * FROM mario_killers.AfiliadosParaCompra WHERE grupo_familia=@grupo_familia AND nro_familiar= @nro_familiar", "T", ListaParametros);

            if (lector.HasRows)
            {
                lector.Read();
                Apellido = (string)lector["apellido"];
                Codigo_Persona = (int)(decimal)lector["persona"];
                Nombre = (string)lector["nombre"];
                Numero_Grupo = numGrupo;
                Numero_Familiar = numFamiliar;
                NumeroDocumento = (decimal)lector["documento"];
                Plan_Medico = (decimal)lector["plan_medico"];
                FechaNacimiento = (DateTime)lector["fecha_nac"];
                Direccion = (String)lector["direccion"];
                TipoDocumento = (decimal)lector["tipo_doc"];
                Sexo = (String)lector["sexo"];
                Mail = (String)lector["mail"];
                Telefono = (decimal)lector["telefono"];
                Cantidad_Hijos = (decimal)lector["cant_hijos"];
                Estado_Civil = (decimal)lector["estado_civil"];
                Activo = (bool)lector["activo"];
            }
        }

        public bool Agregar(Afiliado unAfiliado)
        {
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
                SqlParameter paramRet = new SqlParameter("@ret", System.Data.SqlDbType.Decimal);
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
