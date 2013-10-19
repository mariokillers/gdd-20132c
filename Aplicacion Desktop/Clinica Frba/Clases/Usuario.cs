using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Clases
{
    class Usuario
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool State { get; set; }
        public int CantFallidos { get; set; }
    }
}
