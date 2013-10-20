using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Clase_Persona
{
    class Persona
    {
        public string User { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDocumento{ get; set; }
        public int NumeroDocumento{ get; set; }
        public int Telefono{ get; set; }
        public string Direccion{ get; set; }
        public string Mail{ get; set; }
        public string Sexo{ get; set; }
        public DateTime FechaNacimiento{ get; set; }
    }
}
