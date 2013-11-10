using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clinica_Frba.Abm_de_Profesional;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Clinica_Frba.Clases
{
    public class Profesionales
    {
        public static decimal AgregarProfesional(Profesional pro)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@nombre", pro.Nombre));
            ListaParametros.Add(new SqlParameter("@apellido", pro.Apellido));
            ListaParametros.Add(new SqlParameter("@fecha_nac", pro.FechaNacimiento));
            ListaParametros.Add(new SqlParameter("@sexo", pro.Sexo));
            ListaParametros.Add(new SqlParameter("@tipo_doc", (int)pro.TipoDocumento));
            ListaParametros.Add(new SqlParameter("@documento", (int)pro.NumeroDocumento));
            ListaParametros.Add(new SqlParameter("@direccion", pro.Direccion));
            ListaParametros.Add(new SqlParameter("@telefono", (int)pro.Telefono));
            ListaParametros.Add(new SqlParameter("@mail", pro.Mail));
            ListaParametros.Add(new SqlParameter("@matricula", (int)pro.Matricula));

            SqlParameter paramRet = new SqlParameter("@ret", System.Data.SqlDbType.Decimal);
            paramRet.Direction = System.Data.ParameterDirection.Output;

            ListaParametros.Add(paramRet);
            decimal ret = Clases.BaseDeDatosSQL.ExecStoredProcedure("mario_killers.agregarProfesional", ListaParametros);

            foreach (Especialidad unaEsp in pro.Especialidades)
            {
                Especialidades.AgregarEspecialidadEnProfesional(ret, unaEsp);
            }

            return ret;
        }

        public static void EliminarProfesional(decimal pro)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@id", pro));
            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("UPDATE mario_killers.Profesional SET activo = 0 WHERE persona = @id", "T", ListaParametros);

            List<SqlParameter> ListaParametros2 = new List<SqlParameter>();
            ListaParametros2.Add(new SqlParameter("@id", pro));
            SqlDataReader lector2 = Clases.BaseDeDatosSQL.ObtenerDataReader("UPDATE mario_killers.Turno SET activo = 0 WHERE profesional = @id", "T", ListaParametros2);
        }

        public static void ModificarProfesional(Profesional pro)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@id", pro.Id));
            ListaParametros.Add(new SqlParameter("@sexo", pro.Sexo));
            ListaParametros.Add(new SqlParameter("@direccion", pro.Direccion));
            ListaParametros.Add(new SqlParameter("@telefono", (int)pro.Telefono));
            ListaParametros.Add(new SqlParameter("@mail", pro.Mail));
            ListaParametros.Add(new SqlParameter("@matricula", (int)pro.Matricula));

            SqlParameter paramRet = new SqlParameter("@ret", System.Data.SqlDbType.Decimal);
            paramRet.Direction = System.Data.ParameterDirection.Output;
            ListaParametros.Add(paramRet);

            decimal ret = Clases.BaseDeDatosSQL.ExecStoredProcedure("mario_killers.modificarProfesional", ListaParametros);

            foreach (Especialidad unaEsp in pro.Especialidades)
            {
                Especialidades.AgregarEspecialidadEnProfesional(pro.Id, unaEsp);
            }
        }

        public static void EliminarEspecialidades(Profesional pro, List<Especialidad> list)
        {
            foreach (Especialidad unaEsp in list)
            {
                Especialidades.EliminarEspecialidadEnProfesional(pro.Id, unaEsp);
            }
        }

        public static List<Profesional> ObtenerProfesionales(String nombre, String apellido, String dni, String numeroMatricula, decimal especialidad)
        {
            List<Profesional> Lista = new List<Profesional>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            if (nombre != "") ListaParametros.Add(new SqlParameter("@nombre", "%" + nombre + "%")); else ListaParametros.Add(new SqlParameter("@nombre", "%%"));
            if (apellido != "") ListaParametros.Add(new SqlParameter("@apellido", "%" + apellido + "%")); else ListaParametros.Add(new SqlParameter("@apellido", "%%"));
            if (dni != "") ListaParametros.Add(new SqlParameter("@dni", "%" + dni + "%")); else ListaParametros.Add(new SqlParameter("@dni", "%%"));
            if (numeroMatricula != "") ListaParametros.Add(new SqlParameter("@matricula", "%" + numeroMatricula + "%")); else ListaParametros.Add(new SqlParameter("@matricula", "%%"));
            if (especialidad != 0) ListaParametros.Add(new SqlParameter("@especialidad", "%" + especialidad + "%")); else ListaParametros.Add(new SqlParameter("@especialidad", 0));

            String query = @"SELECT PRO.persona AS persona, PRO.matricula AS matricula, P.nombre AS nombre, P.apellido AS apellido, 
                   P.documento AS documento, p.direccion AS direccion, P.fecha_nac AS fecha_nac, P.mail AS mail, TD.id AS tipo_doc, 
                   P.sexo AS sexo, P.telefono AS telefono 
                   FROM mario_killers.Profesional PRO JOIN mario_killers.Persona P ON PRO.persona = P.id 
                                                      JOIN mario_killers.Especialidad_Profesional EP ON EP.profesional = PRO.persona 
                                                      JOIN mario_killers.Especialidad E ON E.codigo = EP.especialidad 
                                                      JOIN mario_killers.Tipo_Documento TD ON TD.id = P.tipo_doc 
                   WHERE PRO.activo = 1 AND apellido LIKE @apellido AND nombre LIKE @nombre AND documento LIKE @dni AND 
                         (matricula LIKE @matricula OR matricula IS NULL) AND E.codigo LIKE @especialidad 
                   GROUP BY PRO.persona, PRO.matricula, P.nombre, P.apellido, P.documento, P.direccion, P.fecha_nac, P.mail, 
                            TD.id, P.sexo, P.telefono";

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader(query, "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Profesional unProfesional = new Profesional();
                    unProfesional.Id = (int)(decimal)lector["persona"];
                    unProfesional.Apellido = (string)lector["apellido"];
                    unProfesional.Nombre = (string)lector["nombre"];
                    if (DBNull.Value != lector["matricula"])
                    {
                        unProfesional.Matricula = (int)(decimal)lector["matricula"];
                    }
                    else
                    {
                        unProfesional.Matricula = -1;
                    }
                    unProfesional.NumeroDocumento = (decimal)lector["documento"];
                    unProfesional.FechaNacimiento = (DateTime)lector["fecha_nac"];
                    unProfesional.Direccion = (String)lector["direccion"];
                    unProfesional.TipoDocumento = (decimal)lector["tipo_doc"];
                    unProfesional.Sexo = (string)lector["sexo"];
                    unProfesional.Mail = (String)lector["mail"];
                    unProfesional.Telefono = (decimal)lector["telefono"];


                    //ARMO LA LISTA DE ESPECIALIDADES
                    List<SqlParameter> ListaParametros2 = new List<SqlParameter>();
                    ListaParametros2.Add(new SqlParameter("@nombre", "%" + unProfesional.Nombre + "%"));
                    ListaParametros2.Add(new SqlParameter("@apellido", "%" + unProfesional.Apellido + "%"));
                    ListaParametros2.Add(new SqlParameter("@dni", "%" + unProfesional.NumeroDocumento + "%"));
                    ListaParametros2.Add(new SqlParameter("@matricula", "%" + unProfesional.Matricula + "%"));
                    //if (especialidad != 0) ListaParametros2.Add(new SqlParameter("@especialidad", "%" + especialidad + "%")); else ListaParametros2.Add(new SqlParameter("@especialidad", 0));
                    
                    String queryEsp = @"SELECT E.codigo AS codigo, E.descripcion AS descripcion, E.tipo AS tipo
                                        FROM mario_killers.Profesional PRO JOIN mario_killers.Persona P ON PRO.persona = P.id 
                                                      JOIN mario_killers.Especialidad_Profesional EP ON EP.profesional = PRO.persona 
                                                      JOIN mario_killers.Especialidad E ON E.codigo = EP.especialidad 
                                        WHERE PRO.activo = 1 AND apellido LIKE @apellido AND nombre LIKE @nombre AND documento LIKE @dni AND 
                                                (matricula LIKE @matricula OR matricula IS NULL)
                                        GROUP BY E.codigo, E.descripcion, E.tipo";
                    SqlDataReader lectorEsp = Clases.BaseDeDatosSQL.ObtenerDataReader(queryEsp, "T", ListaParametros2);

                    while (lectorEsp.Read())
                    {
                        Especialidad unaEspecialidad = new Especialidad();
                        unaEspecialidad.Codigo = (decimal)lectorEsp["codigo"];
                        unaEspecialidad.Descripcion = (string)lectorEsp["descripcion"];
                        unaEspecialidad.Tipo_Especialidad = (decimal)lectorEsp["tipo"];

                        //MessageBox.Show("Profesional: "+ unProfesional.Apellido + ", Especialidad: " + unaEspecialidad.Descripcion, "Prueba", MessageBoxButtons.OK);

                        unProfesional.Especialidades.Add(unaEspecialidad);
                    }

                    Lista.Add(unProfesional);
                }
            }

            return Lista;
        }

        public static List<Profesional> ObtenerTodos()
        {
            List<Profesional> listaDeProfesionales = new List<Profesional>();

            List<SqlParameter> ListaParametros = new List<SqlParameter>();

            SqlDataReader lector = Clases.BaseDeDatosSQL.ObtenerDataReader("SELECT * FROM mario_killers.ProfesionalesABM", "T", ListaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Profesional unProfesional = new Profesional();
                    unProfesional.Id = (int)(decimal)lector["persona"];
                    unProfesional.Apellido = (string)lector["apellido"];
                    unProfesional.Nombre = (string)lector["nombre"];
                    unProfesional.Matricula = (int)(decimal)lector["matricula"];
                    unProfesional.NumeroDocumento = (decimal)lector["documento"];
                    unProfesional.FechaNacimiento = (DateTime)lector["fecha_nac"];
                    unProfesional.Direccion = (String)lector["direccion"];
                    unProfesional.TipoDocumento = (decimal)lector["tipo_doc"];
                    unProfesional.Sexo = (string)lector["sexo"];
                    unProfesional.Mail = (String)lector["mail"];
                    unProfesional.Telefono = (decimal)lector["telefono"];
                    listaDeProfesionales.Add(unProfesional);
                }
            }
            return listaDeProfesionales;
        }
    }
}
