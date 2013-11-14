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
        public List<Turno> listaTurnos = new List<Turno>();
        public List<Turno> listaVacia = new List<Turno>();

        private void frmTurno_Load(object sender, EventArgs e)
        {
            unaAgenda.armarAgenda(unProfesional.Id);

            dtpFechas.MinDate = unaAgenda.FechaDesde;
            dtpFechas.MaxDate = unaAgenda.FechaHasta;

            //MessageBox.Show("Desde: " + unaAgenda.FechaDesde + ", Hasta: " + unaAgenda.FechaHasta, "test", MessageBoxButtons.OK);

            grillaHorarios.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn ColDia = new DataGridViewTextBoxColumn();
            ColDia.DataPropertyName = "DiaString";
            ColDia.HeaderText = "Dia";
            ColDia.Width = 120;
            grillaHorarios.Columns.Add(ColDia);

            /*   DataGridViewTextBoxColumn ColFecha = new DataGridViewTextBoxColumn();
               ColFecha.DataPropertyName = "Fecha";
               ColFecha.HeaderText = "Fecha";
               ColFecha.Width = 120;
               grillaHorarios.Columns.Add(ColFecha);*/

            DataGridViewTextBoxColumn ColHora = new DataGridViewTextBoxColumn();
            ColHora.DataPropertyName = "Horario";
            ColHora.HeaderText = "Horario";
            ColHora.Width = 120;
            grillaHorarios.Columns.Add(ColHora);

            cargarGrillaFechas();
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            /*---FALTA EL FILTRO DE LA FECHA SELECCIONADA Y SI ES UN TURNO ACTIVO---*/
            try
            {
                if (!Utiles.ObtenerDiasHabilesAgenda(unaAgenda).Contains(new Dias(dtpFechas.Value.DayOfWeek).Id))
                {
                    MessageBox.Show("La fecha seleccionada no esta disponible, por favor seleccione otra", "Aviso", MessageBoxButtons.OK);
                    //MessageBox.Show("La fecha seleccionada es: " + (new Dias(dtpFechas.Value.DayOfWeek)).Detalle, "Aviso", MessageBoxButtons.OK);
                    limpiarGrilla();
                }
                else
                {
                    listaTurnos = Utiles.ObtenerTurnosAgenda(unaAgenda);

                    grillaHorarios.DataSource = listaTurnos;
                }
            }
            catch
            {
                MessageBox.Show("La fecha seleccionada no esta disponible, por favor seleccione otra", "Aviso", MessageBoxButtons.OK);
                limpiarGrilla();
            }
        }

        public void limpiarGrilla()
        {
            grillaHorarios.DataSource = listaVacia;
        }

        public void cargarGrillaFechas()
        {

        }
    }
}
