using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Clinica_Frba.Clases
{
    public class Grupos
    {
        public static List<Grupo> ObtenerGrupos(String numero)
        {
            List<Grupo> Lista = new List<Grupo>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            if (numero != "") ListaParametros.Add(new SqlParameter("@numero", "%" + numero + "%")); else ListaParametros.Add(new SqlParameter("@numero", "%%"));

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT * FROM mario_killers.Grupo_Familia WHERE codigo LIKE @numero", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Grupo unGrupo = new Grupo();
                    unGrupo.nroGrupo = (decimal)lector["codigo"];
                    unGrupo.planMedico = (decimal)lector["plan_medico"];

                    Lista.Add(unGrupo);
                }
            }
            return Lista;
        }
    }
}
