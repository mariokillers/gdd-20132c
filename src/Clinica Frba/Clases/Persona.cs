using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clinica_Frba.Clases;
using System.Data.SqlClient;

namespace Clinica_Frba.Clase_Persona
{
    public class Persona
    {
        public decimal Id { get; set; }
        public int Id_User { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public decimal TipoDocumento { get; set; }
        public decimal NumeroDocumento  { get; set; }
        public decimal Telefono { get; set; }
        public string Direccion { get; set; }
        public string Mail  { get; set; }
        public char Sexo  { get; set; }
        public DateTime FechaNacimiento { get; set; }
        /*
        public Persona(int userId)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@id", userId));

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT * FROM mario_killers.Persona where id=@id", "T", ListaParametros);
            
            if (lector.HasRows)
            {
                lector.Read();
                Id_User = userId;
                Nombre = ((string)lector["nombre"]);
                Apellido = (string)lector["apellido"];
                TipoDocumento = Utiles.ObtenerTipoDoc((int)lector["tipo_doc"]); 
                NumeroDocumento = (int)lector["documeto"];
                Telefono = (int)lector["telefono"];
                Direccion = (string)lector["direccion"];
                Mail = (string)lector["mail"];
                Sexo = (char)lector["sexo"];
                FechaNacimiento = (DateTime)lector["fecha_nac"];
            }
        }*/

        public Persona()
        { }

    }
}
