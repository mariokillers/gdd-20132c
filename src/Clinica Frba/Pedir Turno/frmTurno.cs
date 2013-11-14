using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Clases;
using Clinica_Frba.Abm_de_Profesional;

namespace Clinica_Frba.Pedir_Turno
{
    public partial class frmTurno : Form
    {
        public frmTurno()
        {
            InitializeComponent();
        }

        public Usuario unUsuario = new Usuario();
        public Profesional unProfesional = new Profesional();
        public Agenda unaAgenda = new Agenda();
        public List<Rango> listaRangos = new List<Rango>();

        private void frmTurno_Load(object sender, EventArgs e)
        {
            unaAgenda.armarAgenda(unProfesional.Id);

            //MessageBox.Show("Desde: " + unaAgenda.FechaDesde + ", Hasta: " + unaAgenda.FechaHasta, "test", MessageBoxButtons.OK);

            grillaFechas.AutoGenerateColumns = false;
            grillaHorarios.AutoGenerateColumns = false;

         /*   DataGridViewTextBoxColumn ColFecha = new DataGridViewTextBoxColumn();
            ColFecha.DataPropertyName = "Fecha";
            ColFecha.HeaderText = "Fecha";
            ColFecha.Width = 120;
            grillaHorarios.Columns.Add(ColFecha);*/

            DataGridViewTextBoxColumn ColDiaString = new DataGridViewTextBoxColumn();
            ColDiaString.DataPropertyName = "Fecha";
            ColDiaString.HeaderText = "Fecha";
            ColDiaString.Width = 120;
            grillaFechas.Columns.Add(ColDiaString);

            DataGridViewTextBoxColumn ColFecha = new DataGridViewTextBoxColumn();
            ColFecha.DataPropertyName = "StringDia";
            ColFecha.HeaderText = "Dia";
            ColFecha.Width = 120;
            grillaFechas.Columns.Add(ColFecha);

            DataGridViewTextBoxColumn ColDia = new DataGridViewTextBoxColumn();
            ColDia.DataPropertyName = "StringDia";
            ColDia.HeaderText = "Dia";
            ColDia.Width = 120;
            grillaHorarios.Columns.Add(ColDia);

            DataGridViewTextBoxColumn ColHora = new DataGridViewTextBoxColumn();
            ColHora.DataPropertyName = "HoraDesde";
            ColHora.HeaderText = "Horario";
            ColHora.Width = 120;
            grillaHorarios.Columns.Add(ColHora);
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            /*--VER COMO CARAJO ARMAR LOS TURNOS DIVIDIENDO LOS RANGOS--*/

            listaRangos = unaAgenda.Rangos;

            grillaHorarios.DataSource = listaRangos;
        }
    }
}
