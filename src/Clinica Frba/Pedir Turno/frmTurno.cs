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
        public Turno unTurno = new Turno();
        public List<Turno> listaCompleta = new List<Turno>();
        public decimal unaEspecialidad { get; set; }
        private void frmTurno_Load(object sender, EventArgs e)
        {
            unaAgenda.armarAgenda(unProfesional.Id);

            dtpFechas.MinDate = unaAgenda.FechaDesde;
            dtpFechas.MaxDate = unaAgenda.FechaHasta;

            //MessageBox.Show("Desde: " + unaAgenda.FechaDesde + ", Hasta: " + unaAgenda.FechaHasta, "test", MessageBoxButtons.OK);

            grillaHorarios.AutoGenerateColumns = false;
            grillaHorarios.MultiSelect = false;

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

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Utiles.ObtenerDiasHabilesAgenda(unaAgenda).Contains(new Dias(dtpFechas.Value.DayOfWeek).Id))
                {
                    MessageBox.Show("La fecha seleccionada no esta disponible, por favor seleccione otra", "Aviso", MessageBoxButtons.OK);
                    limpiarGrilla();
                }
                else
                {
                    limpiarGrilla();

                    listaCompleta = Utiles.ObtenerTurnosAgenda(unaAgenda, ((DateTime)dtpFechas.Value).Date);

                    foreach (Turno turno in listaCompleta)
                    {
                        if(Turnos.VerificarTurnoLibre(turno)) listaTurnos.Add(turno);
                    }

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
            listaTurnos = new List<Turno>();
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            try
            {
                unTurno = (Turno)grillaHorarios.CurrentRow.DataBoundItem;
                unTurno.Codigo_Profesional = unProfesional.Id;
                unTurno.Codigo_Especialidad = unaEspecialidad;
                unTurno.Codigo_Persona = unUsuario.Codigo_Persona;

                Turnos.AgregarTurno(unTurno);

                MessageBox.Show("El turno se ha registrado con exito!", "Aviso", MessageBoxButtons.OK);

                this.Close();
            }
            catch
            {
                MessageBox.Show("No se ha seleccionado ningun turno, por favor seleccione uno", "Aviso", MessageBoxButtons.OK);
            }
        }
    }
}
