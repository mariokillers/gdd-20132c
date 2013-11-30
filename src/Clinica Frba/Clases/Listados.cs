using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Clinica_Frba.Clases
{
    class Listados
    {
        public static List<Listado2> Listado2(int semestre, int ano)
        {
            List<Listado2> listaListado2 = new List<Listado2>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@ano", (decimal)ano));
            ListaParametros.Add(new SqlParameter("@fecha", DateTime.Parse(System.Configuration.ConfigurationSettings.AppSettings["Fecha"])));

            if (semestre == 1)
            {
                string query = @"SELECT TOP 5 *, [1]+[2]+[3]+[4]+[5]+[6] Total_Primer_Semestre
                            FROM ( SELECT Bono_Farmacia.codigo AS ID_Bono_Farmacia,
                            MONTH(Compra.fecha) Mes,
                            YEAR(Compra.fecha) AS Anio,
                            Persona.nombre Nombre,
                            Persona.apellido Apellido,
                            Persona.documento Documento
                            FROM mario_killers.Bono_Farmacia
		                    JOIN mario_killers.Compra ON Bono_Farmacia.compra = Compra.id
		                    JOIN mario_killers.Afiliado ON Compra.persona = Afiliado.persona
		                    JOIN mario_killers.Persona ON Persona.id = Afiliado.persona 
	                        WHERE @fecha < Compra.fecha + 60 
	                        ) AS Pivot_source
                            PIVOT (COUNT(ID_Bono_Farmacia) FOR Mes IN ([1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12])) as Bonos_Por_Mes
                            WHERE Anio=@ano
                            ORDER BY Total_Primer_Semestre DESC";

                SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader(query, "T", ListaParametros);

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        Listado2 unRegistro = new Listado2();
                        unRegistro.Apellido = (string)lector["Apellido"];
                        unRegistro.Nombre = (string)lector["Nombre"];
                        unRegistro.Documento = (int)(decimal)lector["Documento"];
                        unRegistro.CantBonos = (int)lector["Total_Primer_Semestre"];
                        unRegistro.CantBonos1 = (int)lector["1"];
                        unRegistro.CantBonos2 = (int)lector["2"];
                        unRegistro.CantBonos3 = (int)lector["3"];
                        unRegistro.CantBonos4 = (int)lector["4"];
                        unRegistro.CantBonos5 = (int)lector["5"];
                        unRegistro.CantBonos6 = (int)lector["6"];
                        unRegistro.ano = ano;
                        listaListado2.Add(unRegistro);
                    }
                }
                return listaListado2;
            }
            else 
            {
                string query = @"SELECT TOP 5 *, [7]+[8]+[9]+[10]+[11]+[12] Total_Segundo_Semestre
                            FROM ( SELECT Bono_Farmacia.codigo AS ID_Bono_Farmacia,
                            MONTH(Compra.fecha) Mes,
                            YEAR(Compra.fecha) AS Anio,
                            Persona.nombre Nombre,
                            Persona.apellido Apellido,
                            Persona.documento Documento
                            FROM mario_killers.Bono_Farmacia
		                    JOIN mario_killers.Compra ON Bono_Farmacia.compra = Compra.id
		                    JOIN mario_killers.Afiliado ON Compra.persona = Afiliado.persona
		                    JOIN mario_killers.Persona ON Persona.id = Afiliado.persona 
	                        WHERE @fecha < Compra.fecha + 60
	                        ) AS Pivot_source
                            PIVOT (COUNT(ID_Bono_Farmacia) FOR Mes IN ([1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12])) as Bonos_Por_Mes
                            WHERE Anio=@ano
                            ORDER BY Total_Segundo_Semestre DESC";

                SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader(query, "T", ListaParametros);

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        Listado2 unRegistro = new Listado2();
                        unRegistro.Apellido = (string)lector["Apellido"];
                        unRegistro.Nombre = (string)lector["Nombre"];
                        unRegistro.Documento = (int)(decimal)lector["Documento"];
                        unRegistro.CantBonos = (int)lector["Total_Segundo_Semestre"];
                        unRegistro.CantBonos1 = (int)lector["7"];
                        unRegistro.CantBonos2 = (int)lector["8"];
                        unRegistro.CantBonos3 = (int)lector["9"];
                        unRegistro.CantBonos4 = (int)lector["10"];
                        unRegistro.CantBonos5 = (int)lector["11"];
                        unRegistro.CantBonos6 = (int)lector["12"];
                        unRegistro.ano = ano;
                        listaListado2.Add(unRegistro);
                    }
                }
                return listaListado2;
            }
        }

        public static List<Listado3> Listado3(int semestre, int ano)
        {
            List<Listado3> listaListado3 = new List<Listado3>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@ano", (decimal)ano));

            if (semestre == 1)
            {
                string query = @"SELECT TOP 5 Desc_Especialidad, Desc_Tipo_Especialidad, [1], [2], [3], [4], [5], [6], Total_Primer_Semestre
                                FROM mario_killers.listado_3_view
                                WHERE Anio = @ano
                                ORDER BY Total_Primer_Semestre DESC ";

                SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader(query, "T", ListaParametros);

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        Listado3 unRegistro = new Listado3();
                        unRegistro.EspecialidadMedica = (string)lector["Desc_Especialidad"];
                        unRegistro.TipoEspecialidadMedica = (string)lector["Desc_Tipo_Especialidad"];
                        unRegistro.CantCancelaciones = (int)lector["Total_Primer_Semestre"];
                        unRegistro.CantCancelaciones1 = (int)lector["1"];
                        unRegistro.CantCancelaciones2 = (int)lector["2"];
                        unRegistro.CantCancelaciones3 = (int)lector["3"];
                        unRegistro.CantCancelaciones4 = (int)lector["4"];
                        unRegistro.CantCancelaciones5 = (int)lector["5"];
                        unRegistro.CantCancelaciones6 = (int)lector["6"];
                        unRegistro.ano = ano;
                        listaListado3.Add(unRegistro);
                    }
                }
                return listaListado3;
            }
            else 
            {
                string query = @"SELECT TOP 5 Desc_Especialidad, Desc_Tipo_Especialidad, [7], [8], [9], [10], [11], [12], Total_Segundo_Semestre
                                FROM mario_killers.listado_3_view
                                WHERE Anio = @ano
                                ORDER BY Total_Segundo_Semestre DESC ";

                SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader(query, "T", ListaParametros);

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        Listado3 unRegistro = new Listado3();
                        unRegistro.EspecialidadMedica = (string)lector["Desc_Especialidad"];
                        unRegistro.TipoEspecialidadMedica = (string)lector["Desc_Tipo_Especialidad"];
                        unRegistro.CantCancelaciones = (int)lector["Total_Segundo_Semestre"];
                        unRegistro.CantCancelaciones1 = (int)lector["7"];
                        unRegistro.CantCancelaciones2 = (int)lector["8"];
                        unRegistro.CantCancelaciones3 = (int)lector["9"];
                        unRegistro.CantCancelaciones4 = (int)lector["10"];
                        unRegistro.CantCancelaciones5 = (int)lector["11"];
                        unRegistro.CantCancelaciones6 = (int)lector["12"];
                        unRegistro.ano = ano;
                        listaListado3.Add(unRegistro);
                    }
                }
                return listaListado3;
            }
        }

        public static List<Listado1> Listado1(int semestre, int ano)
        {
            List<Listado1> listaListado1 = new List<Listado1>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@ano", (decimal)ano));

            if (semestre == 1)
            {
                SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT TOP 5 Total_Primer_Semestre,Desc_Especialidad, Desc_Tipo_Especialidad, [1], [2], [3], [4], [5], [6] FROM mario_killers.listado_1_view WHERE Anio=@ano ORDER BY Total_Primer_Semestre", "T", ListaParametros);

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        Listado1 unRegistro = new Listado1();
                        unRegistro.EspecialidadMedica = (string)lector["Desc_Especialidad"];
                        unRegistro.TipoEspecialidadMedica = (string)lector["Desc_Tipo_Especialidad"];
                        unRegistro.CantCancelaciones = (int)lector["Total_Primer_Semestre"];
                        unRegistro.CantCancelaciones1 = (int)lector["1"];
                        unRegistro.CantCancelaciones2 = (int)lector["2"];
                        unRegistro.CantCancelaciones3 = (int)lector["3"];
                        unRegistro.CantCancelaciones4 = (int)lector["4"];
                        unRegistro.CantCancelaciones5 = (int)lector["5"];
                        unRegistro.CantCancelaciones6 = (int)lector["6"];
                        unRegistro.ano = ano;
                        listaListado1.Add(unRegistro);
                    }
                }
                return listaListado1;
            }
            else
            {
                SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT TOP 5 Total_Segundo_Semestre,Desc_Especialidad, Desc_Tipo_Especialidad, [7], [8], [9], [10], [11], [12] FROM mario_killers.listado_1_view WHERE Anio=@ano ORDER BY Total_Segundo_Semestre", "T", ListaParametros);

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        Listado1 unRegistro = new Listado1();
                        unRegistro.EspecialidadMedica = (string)lector["Desc_Especialidad"];
                        unRegistro.TipoEspecialidadMedica = (string)lector["Desc_Tipo_Especialidad"];
                        unRegistro.CantCancelaciones = (int)lector["Total_Primer_Semestre"];
                        unRegistro.CantCancelaciones1 = (int)lector["7"];
                        unRegistro.CantCancelaciones2 = (int)lector["8"];
                        unRegistro.CantCancelaciones3 = (int)lector["9"];
                        unRegistro.CantCancelaciones4 = (int)lector["10"];
                        unRegistro.CantCancelaciones5 = (int)lector["11"];
                        unRegistro.CantCancelaciones6 = (int)lector["12"];
                        unRegistro.ano = ano;
                        listaListado1.Add(unRegistro);
                    }
                }
                return listaListado1;
            }
        }

        public static List<Listado4> Listado4(int semestre, int ano)
        {
            List<Listado4> listaListado4 = new List<Listado4>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@ano", (decimal)ano));

            if (semestre == 1)
            {
                string query =@"SELECT TOP 5 Nombre, Apellido, Documento, [1], [2], [3], [4], [5], [6], Total_Primer_Semestre
                                FROM mario_killers.listado_4_view
                                WHERE Anio = @ano
                                ORDER BY Total_Primer_Semestre DESC ";

                SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader(query, "T", ListaParametros);

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        Listado4 unRegistro = new Listado4();
                        unRegistro.Nombre = (string)lector["Nombre"];
                        unRegistro.Apellido = (string)lector["Apellido"];
                        unRegistro.CantBonos = (int)lector["Total_Primer_Semestre"];
                        unRegistro.CantBonos1 = (int)lector["1"];
                        unRegistro.CantBonos2 = (int)lector["2"];
                        unRegistro.CantBonos3 = (int)lector["3"];
                        unRegistro.CantBonos4 = (int)lector["4"];
                        unRegistro.CantBonos5 = (int)lector["5"];
                        unRegistro.CantBonos6 = (int)lector["6"];
                        unRegistro.Documento = (int)(decimal)lector["Documento"];
                        unRegistro.ano = ano;
                        listaListado4.Add(unRegistro);
                    }
                }
                return listaListado4;
            }
            else 
            {
                string query = @"SELECT TOP 5 Nombre, Apellido, Documento, [7], [8], [9], [10], [11], [12], Total_Segundo_Semestre
                                FROM mario_killers.listado_4_view
                                WHERE Anio = @ano
                                ORDER BY Total_Segundo_Semestre DESC";

                SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader(query, "T", ListaParametros);

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        Listado4 unRegistro = new Listado4();
                        unRegistro.Nombre = (string)lector["Nombre"];
                        unRegistro.Apellido = (string)lector["Apellido"];
                        unRegistro.CantBonos = (int)lector["Total_Segundo_Semestre"];
                        unRegistro.CantBonos1 = (int)lector["7"];
                        unRegistro.CantBonos2 = (int)lector["8"];
                        unRegistro.CantBonos3 = (int)lector["9"];
                        unRegistro.CantBonos4 = (int)lector["10"];
                        unRegistro.CantBonos5 = (int)lector["11"];
                        unRegistro.CantBonos6 = (int)lector["12"];
                        unRegistro.Documento = (int)(decimal)lector["Documento"];
                        unRegistro.ano = ano;
                        listaListado4.Add(unRegistro);
                    }
                }
                return listaListado4;
            }
        }
    }
}
