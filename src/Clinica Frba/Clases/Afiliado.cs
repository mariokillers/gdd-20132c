using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clinica_Frba.Clase_Persona;

namespace Clinica_Frba.Clases
{
    class Afiliado: Persona
    {
        public Persona Persona { get; set; }
        public int Numero_En_Grupo { get; set; }
        public int Numero_Grupo { get; set; }
        public string Estado_Civil { get; set; }
        public int Cantidad_Hijos { get; set; }
    }
}
