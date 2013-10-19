using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Clase_Persona
{
    class Persona
    {
        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        private string _Nombre;
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private string _Apellido;
        public string Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }


        private string _TipoDocumento;
        public string TipoDocumento
        {
            get { return _TipoDocumento; }
            set { _TipoDocumento = value; }
        }

        private int _NumeroDocumento;
        public int NumeroDocumento
        {
            get { return _NumeroDocumento; }
            set { _NumeroDocumento = value; }
        }

        private int _Telefono;
        public int Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        private string _Direccion;
        public string Direccion
        {
            get { return _Direccion; }
            set {   _Direccion = value;  }
        }

        private string _Mail;
        public string Mail
        {
            get { return _Mail; }
            set { _Mail = value; }
        }

        private string _Sexo;
        public string Sexo
        {
            get { return _Sexo; }
            set { _Sexo = value; }
        }

        private DateTime _FechaNacimiento;
        public DateTime FechaNacimiento
        {
            get { return _FechaNacimiento; }
            set { _FechaNacimiento = value; }
        }
    }
}
