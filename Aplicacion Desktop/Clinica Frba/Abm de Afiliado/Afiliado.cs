using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clinica_Frba.Clase_Persona;

namespace Clinica_Frba.Abm_de_Afiliado
{
    class Afiliado : Persona
    {
        private int _AfilNum;
        public int AfilNum
        {
            get {   return _AfilNum;  }
            set {   _AfilNum = value; }
        }

        private int _CodigoEnGrupoFamiliar;
        public int CodigoEnGrupoFamiliar
        {
            get { return _CodigoEnGrupoFamiliar; }
            set { _CodigoEnGrupoFamiliar = value; }
        }

        private string _EstadoCivil;
        public string EstadoCivil
        {
            get { return _EstadoCivil; }
            set { _EstadoCivil = value; }
        }

        private int _CantHijos;
        public int CantHijos
        {
            get { return _CantHijos; }
            set { _CantHijos = value; }
        }

        private int _CodigoPersona;
        public int CodigoPersona
        {
            get { return _CodigoPersona; }
            set { _CodigoPersona = value; }
        }

        private int _CodigoGrupoFamiliar;
        public int CodigoGrupoFamiliar
        {
            get { return _CodigoGrupoFamiliar; }
            set { _CodigoGrupoFamiliar = value; }
        }
    }
}
