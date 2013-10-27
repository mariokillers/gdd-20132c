using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clinica_Frba.Clase_Persona;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

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
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@userName", userName));

            //ESTA HARDCODEADO, VER QUE ONDA
            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT * FROM mario_killers.Usuario where nombre=@userName", "T", ListaParametros);
            if (lector.HasRows)
            {
                lector.Read();
                Name = userName;
                //Codigo_Persona = (int)lector["persona"];
                Password = ((string)lector["pw"]).ToUpper();
                Activo = (bool)lector["activo"];
                CantFallidos = (int)lector["intentos_login"];
            }
        }

        public bool ActualizarFallidos()
        {
            List<SqlParameter> Lista = new List<SqlParameter>();
            Lista.Add(new SqlParameter("@intentos_login", CantFallidos + 1));
            Lista.Add(new SqlParameter("@nombre", Name));
            //VER ESTO COMO SP
            if (CantFallidos == 2)
            {
                return Clases.BaseDeDatosSQL.EscribirEnBase("update mario_killers.Usuario set activo=0, intentos_login=@intentos_login where nombre=@nombre", "T", Lista);
            }
            else
            {
                return Clases.BaseDeDatosSQL.EscribirEnBase("update mario_killers.Usuario intentos_login=@intentos_login where nombre=@nombre", "T", Lista); 
            }
        }

        public bool ReiniciarFallidos()
        {
            List<SqlParameter> Lista = new List<SqlParameter>();
            return Clases.BaseDeDatosSQL.EscribirEnBase("update mario_killers.Usuario set intentos_login=1 where nombre='admin'", "T", Lista);

        }
    }
}
