using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Clases
{
    class Dias
    {
        public string Detalle { get; set; }
        public int Id { get; set; }

        public Dias(int id, string detalle)
        {
            Detalle = detalle;
            Id = id;
        }

        public static string ObtenerDia(int id)
        {
            switch (id)
            {
                case 1:
                    return "Domingo";
                case 2:
                    return "Lunes";
                case 3:
                    return "Martes";
                case 4:
                    return "Miercoles";
                case 5:
                    return "Jueves";
                case 6:
                    return "Viernes";
                case 7:
                    return "Sábado";
            }
            return "";
        }
    }
}
