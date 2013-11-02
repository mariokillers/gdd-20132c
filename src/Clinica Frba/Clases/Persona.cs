﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clinica_Frba.Clases;

namespace Clinica_Frba.Clase_Persona
{
    class Persona
    {
        public int Id { get; set; }
        public int Id_User { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDocumento { get; set; }
        public decimal NumeroDocumento  { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public string Mail  { get; set; }
        public char Sexo  { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
