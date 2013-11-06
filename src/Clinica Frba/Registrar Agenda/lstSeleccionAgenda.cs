using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Clases;

namespace Clinica_Frba.Registrar_Agenda
{
    public partial class lstSeleccionAgenda : Form
    {
        public lstSeleccionAgenda()
        {
            InitializeComponent();
        }

        //PARA SABER QUE PROFESIONAL ESTOY ACTUALIZANDO
        public Usuario Profesional { get; set; }

        private void lstSeleccionAgenda_Load(object sender, EventArgs e)
        {
            grillaAgenda.AutoGenerateColumns = false;
            generarGrilla();
            //grillaAgenda.DataSource = unProfesional.ObtenerAgenda() ;
        }

        private void generarGrilla()
        {
            DataGridViewTextBoxColumn ColDia = new DataGridViewTextBoxColumn();
            ColDia.DataPropertyName = "Dia";
            ColDia.HeaderText = "Día";
            ColDia.Width = 120;
            grillaAgenda.Columns.Add(ColDia);

            DataGridViewTextBoxColumn ColHoraDesde = new DataGridViewTextBoxColumn();
            ColHoraDesde.DataPropertyName = "HoraDesde";
            ColHoraDesde.HeaderText = "Hora Desde";
            ColHoraDesde.Width = 120;
            grillaAgenda.Columns.Add(ColHoraDesde);

            DataGridViewTextBoxColumn ColHoraHasta = new DataGridViewTextBoxColumn();
            ColHoraHasta.DataPropertyName = "HoraHasta";
            ColHoraHasta.HeaderText = "Hora Hasta";
            ColHoraHasta.Width = 120;
            grillaAgenda.Columns.Add(ColHoraHasta);
        }
    }
}
