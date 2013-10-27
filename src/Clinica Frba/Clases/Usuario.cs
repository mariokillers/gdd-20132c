using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clinica_Frba.Clase_Persona;
using System.Data.OleDb;

namespace Clinica_Frba.Clases
{
    class Usuario
    {
        public int Codigo_Persona { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool Activo { get; set; }
        public int CantFallidos { get; set; }

        public Usuario(string userName)
        {
            List<OleDbParameter> ListaParametros = new List<OleDbParameter>();
            ListaParametros.Add(new OleDbParameter("@userName", userName));

            OleDbDataReader lector = Clases.BaseDeDatos.ObtenerDataReader("SELECT * FROM mario_killers.Usuario WHERE nombre = @userName", "T", ListaParametros);

            if (lector.HasRows)
            {
                lector.Read();
                Name = userName;
                Codigo_Persona = (int)lector["persona"];
                Password = (string)lector["pw"];
                Activo = (bool)lector["activo"];
                CantFallidos = (int)lector["intentos_login "];
            }
        }

        public bool ActualizarFallidos()
        {
            List<OleDbParameter> Lista = new List<OleDbParameter>();
            Lista.Add(new OleDbParameter("@intentos_login", CantFallidos + 1));
            Lista.Add(new OleDbParameter("@nombre", Name));
            //VER ESTO COMO SP
            if (CantFallidos == 2)
            {
                return Clases.BaseDeDatos.EscribirEnBase("update mario_killers.Usuario set activo=0, intentos_login=@intentos_login where nombre=@nombre", "T", Lista);
            }
            else
            {
                return Clases.BaseDeDatos.EscribirEnBase("update mario_killers.Usuario intentos_login=@intentos_login where nombre=@nombre", "T", Lista); 
            }
        }

        public bool ReiniciarFallidos()
        {
            List<OleDbParameter> Lista = new List<OleDbParameter>();
            return Clases.BaseDeDatos.EscribirEnBase("update mario_killers.Usuario intentos_login=0 where nombre=@nombre", "T", Lista);

        }

        public List<Funcionalidad> ObtenerFuncionalidadesPorUsuario()
        {
            List<Funcionalidad> Lista = new List<Funcionalidad>();

            List<OleDbParameter> ListaParametros = new List<OleDbParameter>();
            ListaParametros.Add(new OleDbParameter("@nombre", Name));
            OleDbDataReader lector = Clases.BaseDeDatos.ObtenerDataReader("", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Funcionalidad unaFuncionalidad = new Funcionalidad();
                    unaFuncionalidad.Id = (int)lector["codigo"];
                    unaFuncionalidad.Nombre = (string)lector["nombre"];
                    Lista.Add(unaFuncionalidad);
                }
            }
            return Lista;
        }
    }
}
