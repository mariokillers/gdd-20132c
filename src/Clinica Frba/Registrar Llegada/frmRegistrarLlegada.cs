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
        public Turno turno = new Turno();

        private void frmRegistrarLlegada_Load(object sender, EventArgs e)
        {
            grillaHorarios.AutoGenerateColumns = false;
            grillaHorarios.MultiSelect = false;

            if (profesional != null) unaAgenda.armarAgenda(profesional.Id);

            generarGrilla();
        }

        private void generarGrilla()
        {
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
            if (profesional != null) unaAgenda.armarAgenda(profesional.Id);
            listaTurnos = Utiles.ObtenerTurnosDia(unaAgenda, (DateTime.Parse(System.Configuration.ConfigurationSettings.AppSettings["Fecha"])));
            grillaHorarios.DataSource = listaTurnos;
        }

        private void cmdSeleccionar_Click(object sender, EventArgs e)
        {
            lstSeleccionProfesionales formProfesional = new lstSeleccionProfesionales();
            formProfesional.Operacion = "Seleccion";
            formProfesional.formLlegada = this;
            cmdSeleccionar.Enabled = false;
            btnTurno.Enabled = true;
            formProfesional.Show();
            this.Hide();
        }

        private void cmdConfirmarBono_Click(object sender, EventArgs e)
        {
            try
            {
                BonoConsulta unBono = new BonoConsulta(Int32.Parse(txtBono.Text));
                if (unBono.Usado)
                {
                    if (unBono.PuedeUsarlo((int)afiliado.Numero_Grupo))
                    {
                        unBono.Usar(afiliado);
                    }
                }
                else { MessageBox.Show("El bono ya ha sido usado", "Error!", MessageBoxButtons.OK); }
            }
            catch { MessageBox.Show("No existe un Bono Consulta con ese codigo", "Error!", MessageBoxButtons.OK); }
        
        }

        private void btnTurno_Click(object sender, EventArgs e)
        {
            turno = (Turno)grillaHorarios.CurrentRow.DataBoundItem;
            if (turno.Codigo_Persona == afiliado.Codigo_Persona)
            {
                cmdConfirmarBono.Enabled = true;
                txtBono.Enabled = true;
            }
            else
            {
                MessageBox.Show("El turno seleccionado no corresponde al afiliado", "Error", MessageBoxButtons.OK);   
            }
        }

    }
}