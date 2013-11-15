using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Abm_de_Profesional;
using Clinica_Frba.Clases;

namespace Clinica_Frba.Registrar_Llegada
{
    public partial class frmRegistrarLlegada : Form
    {
        public frmRegistrarLlegada()
        {
            InitializeComponent();
        }

        public Afiliado afiliado = new Afiliado();
        public Profesional profesional = new Profesional();
        public Agenda unaAgenda = new Agenda();
        public List<Turno> listaTurnos = new List<Turno>();

        private void frmRegistrarLlegada_Load(object sender, EventArgs e)
        {
            grillaHorarios.AutoGenerateColumns = false;

            if (profesional != null) unaAgenda.armarAgenda(profesional.Id);

            DataGridViewTextBoxColumn ColDia = new DataGridViewTextBoxColumn();
            ColDia.DataPropertyName = "DiaString";
            ColDia.HeaderText = "Dia";
            ColDia.Width = 120;
            grillaHorarios.Columns.Add(ColDia);

            DataGridViewTextBoxColumn ColFecha = new DataGridViewTextBoxColumn();
            ColFecha.DataPropertyName = "Fecha";
            ColFecha.HeaderText = "Fecha";
            ColFecha.Width = 120;
            grillaHorarios.Columns.Add(ColFecha);

            DataGridViewTextBoxColumn ColHora = new DataGridViewTextBoxColumn();
            ColHora.DataPropertyName = "Horario";
            ColHora.HeaderText = "Horario";
            ColHora.Width = 120;
            grillaHorarios.Columns.Add(ColHora);

            
        }

        public void cargarGrilla()
        {
            listaTurnos = Utiles.ObtenerTurnosDia(unaAgenda, (DateTime.Parse(System.Configuration.ConfigurationSettings.AppSettings["Fecha"])));
            grillaHorarios.DataSource = listaTurnos;
        }

        private void cmdSeleccionar_Click(object sender, EventArgs e)
        {
            lstSeleccionProfesionales formProfesional = new lstSeleccionProfesionales();
            formProfesional.Operacion = "Seleccion";
            formProfesional.formLlegada = this;
            formProfesional.Show();
            this.Hide();
        }
    }
}
