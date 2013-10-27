using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Clases
{
    class Utiles
    {
        public static bool EsNumerico(string numero)
        {
            try
            {
                int test = Convert.ToInt32(numero);
                return true;
            }
            catch (Exception)
            {return false;}
        }

        public static bool EsFechaValida(DateTime fecha)
        {
            try { 
                DateTime hoy = DateTime.Today;
                if (fecha > hoy)
                {
                    return false;
                } return true;
            }
            catch { return false; }
        }

    public enum Operacion
    {
        Baja,
        Modificacion,
        Seleccion
    }
    }
}
