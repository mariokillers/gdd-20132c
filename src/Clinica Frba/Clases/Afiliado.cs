using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clinica_Frba.Clase_Persona;
using System.Data.OleDb;

namespace Clinica_Frba.Clases
{
    class Afiliado: Persona
    {
        public int Codigo_Persona { get; set; }
        public int Numero_Familiar { get; set; }
        public int Numero_Grupo { get; set; }
        public string Estado_Civil { get; set; }
        public int Cantidad_Hijos { get; set; }
        public bool Activo { get; set; }


        public bool Eliminar(int codigoGrupo, int numeroFamiliar)
        {
            List<OleDbParameter> Lista = new List<OleDbParameter>();
            //VER COMO ESTA EN LA DB (numeroAfiliado)
            Lista.Add(new OleDbParameter("@codigoGrupo", codigoGrupo));
            Lista.Add(new OleDbParameter("@numeroFamiliar", numeroFamiliar));
            return Clases.BaseDeDatos.EscribirEnBase("update mario_killers.Paciente set Activo =0 where (Codigo_Grupo=@codigoGrupo and Nro_Familiar=@numeroFamiliar)", "T", Lista);
        }

        public bool Agregar(Afiliado unAfiliado)
        {
            //ANTES DE DAR UNA ALTA DE AFILIADO,HAY QUE DAR DE ALTA LA PERSONA

            List<OleDbParameter> Lista = new List<OleDbParameter>();
            Lista.Add(new OleDbParameter("@persona", unAfiliado.Codigo_Persona));
            Lista.Add(new OleDbParameter("@estado_civil", unAfiliado.Estado_Civil));
            Lista.Add(new OleDbParameter("@grupo_familia", unAfiliado.Numero_Grupo));
            Lista.Add(new OleDbParameter("@nro_familiar", unAfiliado.Numero_Familiar));
            Lista.Add(new OleDbParameter("@cant_hijos", unAfiliado.Cantidad_Hijos));
            Lista.Add(new OleDbParameter("@activo", unAfiliado.Activo));

            return Clases.BaseDeDatos.EscribirEnBase("insert into mario_killers.Afiliado ( persona, estado_civil , grupo_familia, nro_familiar, cant_hijos, activo) values (@persona, @estado_civil, @grupo_familia, @nro_familiar, @cant_hijos, @activo)", "T", Lista);
        }
    }
}
