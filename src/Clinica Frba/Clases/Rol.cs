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

        public Rol()
        {

        }

        public bool Eliminar()
        {
            List<OleDbParameter> ListaParametros = new List<OleDbParameter>();
            ListaParametros.Add(new OleDbParameter("@id", this.Id));
            return Clases.BaseDeDatos.EscribirEnBase("update mario_killers.Rol set Activo =0 where id=@id", "T", ListaParametros);


        }
    }
}
