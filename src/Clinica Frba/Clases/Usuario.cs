using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clinica_Frba.Clase_Persona;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Clinica_Frba.Abm_de_Profesional;

namespace Clinica_Frba.Clases
{
    public class Usuario
    {
        public int Codigo_Persona { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool Activo { get; set; }
        public decimal CantFallidos { get; set; }

        public Usuario(string userName)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@userName", userName));

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT * FROM mario_killers.Usuario where nombre=@userName", "T", ListaParametros);
            if (lector.HasRows)
            {
                lector.Read();
                Name = userName;
                if (lector["persona"] != DBNull.Value)
                {
                    Codigo_Persona = (int)(decimal)lector["persona"]; 
                }
                else { Codigo_Persona = 13288527; } //LE METO FRUTA PARA QUE FUNQUE
                Password = ((string)lector["pw"]).ToUpper();
                Activo = (bool)lector["activo"];
                CantFallidos = (decimal)lector["intentos_login"];
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
            Lista.Add(new SqlParameter("@nombre", Name));
            return Clases.BaseDeDatosSQL.EscribirEnBase("update mario_killers.Usuario set intentos_login=0 where nombre=@nombre", "T", Lista);
        }
    }
}
