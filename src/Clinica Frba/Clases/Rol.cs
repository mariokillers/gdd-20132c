using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Clinica_Frba.Clases
{
    class Rol
    {
        public string Nombre { get; set; }
        public int Id { get; set; }
        public List<Funcionalidad> ListaFuncionalidades { get; set; }
        public bool Habilitado { get; set; }

        public Rol() { }
        
    }
}
