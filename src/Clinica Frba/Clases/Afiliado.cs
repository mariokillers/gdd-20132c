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
        public Persona Persona { get; set; }
        public int Numero_Familiar { get; set; }
        public int Numero_Grupo { get; set; }
        public string Estado_Civil { get; set; }
        public int Cantidad_Hijos { get; set; }
        public bool Activo { get; set; }

        //baja logica de afiliado
        public bool Eliminar(int codigoGrupo, int numeroFamiliar)
        {
            List<OleDbParameter> Lista = new List<OleDbParameter>();
            //VER COMO ESTA EN LA DB (numeroAfiliado)
            Lista.Add(new OleDbParameter("@codigoGrupo", codigoGrupo));
            Lista.Add(new OleDbParameter("@numeroFamiliar", numeroFamiliar));
            return Clases.BaseDeDatos.EscribirEnBase("update Paciente set Activo =0 where (Codigo_Grupo=@codigoGrupo and Nro_Familiar=@numeroFamiliar)", "T", Lista);
        }
    }
}
