using System;
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
        public decimal Codigo_Persona { get; set; }
        public decimal Numero_Familiar { get; set; }
        public decimal Numero_Grupo { get; set; }
        public decimal Estado_Civil { get; set; }
        public decimal Cantidad_Hijos { get; set; }
        public bool Activo { get; set; }
        public decimal Plan_Medico { get; set; }
        

        public bool Eliminar(int codigoGrupo, int numeroFamiliar)
        {
            List<SqlParameter> Lista = new List<SqlParameter>();
            //VER COMO ESTA EN LA DB (numeroAfiliado)
            Lista.Add(new SqlParameter("@codigoGrupo", codigoGrupo));
            Lista.Add(new SqlParameter("@numeroFamiliar", numeroFamiliar));
            return Clases.BaseDeDatosSQL.EscribirEnBase("update mario_killers.Paciente set Activo =0 where (Codigo_Grupo=@codigoGrupo and Nro_Familiar=@numeroFamiliar)", "T", Lista);
        }

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

    }
}
