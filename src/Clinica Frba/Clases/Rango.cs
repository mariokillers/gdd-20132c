using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Clases
{
    public class Rango
    {
        public Dias Dia { get; set; }
        public string StringDia { get; set; }
        public TimeSpan HoraDesde { get; set; }
        public TimeSpan HoraHasta { get; set; }
        public List<Turno> TurnosDentro { get; set; }

        public Rango(Dias dia, TimeSpan horaDesde, TimeSpan horaHasta)
        {
            TurnosDentro = new List<Turno>();
            Dia = dia;
            StringDia = dia.Detalle;
            HoraDesde = horaDesde;
            HoraHasta = horaHasta;
            this.armarTurnos();
        }

        public void armarTurnos ()
        {
            int cantTurnos = (HoraHasta.Hours - HoraDesde.Hours) * 2;

            if (HoraDesde.Minutes != 0 && HoraHasta.Minutes == 0)
            {
                cantTurnos --;
            }
            else if (HoraDesde.Minutes == 0 && HoraHasta.Minutes != 0)
            {
                cantTurnos++;
            }

            /*--- PARA EL CASO QUE EMPIECE EN HORA CLAVADA---*/
            if (HoraDesde.Minutes == 0)
            {
                for (int i = 0; i < cantTurnos; i++)
                {
                    TimeSpan horario = new TimeSpan(HoraDesde.Hours + (i / 2), (i % 2) * 30, 0);
                    Turno turno = new Turno();
                    turno.Horario = horario;
                    TurnosDentro.Add(turno);
                }
            }
            /*--- PARA EL CASO QUE EMPIECE EN HORA Y MEDIA---*/
            else
            {
                for (int i = 1; i <= cantTurnos; i++)
                {
                    TimeSpan horario = new TimeSpan(HoraDesde.Hours + (i / 2), (i % 2) * 30, 0);
                    Turno turno = new Turno();
                    turno.Horario = horario;
                    TurnosDentro.Add(turno);
                }
            }
        }

        public Rango()
        {
        }
    }
}
