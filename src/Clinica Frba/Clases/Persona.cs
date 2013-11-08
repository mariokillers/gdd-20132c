using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clinica_Frba.Clases;
using System.Data.SqlClient;

namespace Clinica_Frba.Clase_Persona
{
    public abstract class Persona
    {
        public int Id { get; set; }
        public int Id_User { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public decimal TipoDocumento { get; set; }
        public decimal NumeroDocumento  { get; set; }
        public decimal Telefono { get; set; }
        public string Direccion { get; set; }
        public string Mail  { get; set; }
        public string Sexo  { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public Persona()
        { }
    }
}
