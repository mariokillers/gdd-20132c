﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Clinica_Frba.Clases
{
    class Planes
    {
        public static List<Plan> ObtenerPlanes()
        {
            List<Plan> Lista = new List<Plan>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Plan unPlan = new Plan();
                    unPlan.Codigo = (int)lector["codigo "];
                    unPlan.Descripcion = (string)lector["desripcion"];
                    unPlan.Precio_Bono_Consulta = (int)lector["precio_bono_consulta"];
                    unPlan.Precio_Bono_Farmacia = (int)lector["precio_bono_farmacia"];
                    Lista.Add(unPlan);
                }
            }
            return Lista;
        }
    }
}