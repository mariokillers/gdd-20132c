using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Clases
{
    class Sexo
    {
        public String Id { get; set; }

        public static List<Sexo> ObtenerSexos()
        {
            List<Sexo> listaDeSexos = new List<Sexo>();

            Sexo sex0 = new Sexo();
            sex0.Id = "X";
            listaDeSexos.Add(sex0);

            Sexo sex1 = new Sexo();
            sex1.Id = "M";
            listaDeSexos.Add(sex1);

            Sexo sex2 = new Sexo();
            sex2.Id = "F";
            listaDeSexos.Add(sex2);

            return listaDeSexos;
        }
    }
}
