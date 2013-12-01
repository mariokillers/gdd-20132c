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
            btnTurno.Enabled = false;

            if (profesional != null) unaAgenda.armarAgenda(profesional.Id);

            generarGrilla();
        }

        private void generarGrilla()
        {
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

        public Boolean cargarGrilla()
        {
            if (profesional != null) unaAgenda.armarAgenda(profesional.Id);
            listaTurnos = Utiles.ObtenerTurnosDia(unaAgenda, (DateTime.Parse(System.Configuration.ConfigurationSettings.AppSettings["Fecha"])));
            if (listaTurnos.Count != 0)
            {
                grillaHorarios.DataSource = listaTurnos;                
                cmdSeleccionar.Enabled = false;
                btnTurno.Enabled = true;
                txtNumAfil.Text = "";
                txtNumAfil.Enabled = true;                
                return true;
            }
            else
            {
                MessageBox.Show("El profesional no tiene turnos para este día", "Error!", MessageBoxButtons.OK);
                grillaHorarios.DataSource = new List<Turno>();
                cmdSeleccionar.Enabled = true;
                btnTurno.Enabled = false;
                txtNumAfil.Enabled = false;
                return false;/*
                lstSeleccionProfesionales formProfesional = new lstSeleccionProfesionales();
                formProfesional.Operacion = "Seleccion";
                formProfesional.formLlegada = this;
                formProfesional.Show();
                this.Hide();*/
            }
        }

        private void cmdSeleccionar_Click(object sender, EventArgs e)
        {
            lstSeleccionProfesionales formProfesional = new lstSeleccionProfesionales();
            formProfesional.Operacion = "Seleccion";
            formProfesional.formLlegada = this;
            formProfesional.Show();
            this.Hide();
        }

        private void cmdConfirmarBono_Click(object sender, EventArgs e)
        {
            try
            {
                BonoConsulta unBono = new BonoConsulta(Int32.Parse(txtBono.Text));
                if (unBono.Grupo_Flia != 0)
                {
                    if (unBono.Activo)
                    {
                        if (unBono.PuedeUsarlo((int)afiliado.Numero_Grupo))
                        {
                            if (Utiles.LlegoAHorario(turno)) //COMENTAR PARA TESTS
                            {
                                unBono.Usar(afiliado, turno);
                                afiliado.CrearAtencion(unBono.Id, (int)turno.Id);
                                cmdConfirmarBono.Enabled = false;
                                txtBono.Enabled = false;
                                MessageBox.Show("Se ha registrado la llegada del afiliado correctamente", "EnHoraBuena!", MessageBoxButtons.OK);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Ha perdido el turno por incumplimiento de horario.", "Aviso!", MessageBoxButtons.OK);
                                grillaHorarios.Enabled = true;
                                btnTurno.Enabled = true;
                                cmdConfirmarBono.Enabled = false;
                                txtBono.Text = "";
                                txtBono.Enabled = false;
                                cargarGrilla();
                            }
                        }
                    }
                    else { MessageBox.Show("El bono ya ha sido usado", "Error!", MessageBoxButtons.OK); }
                }
                else { MessageBox.Show("No existe un bono con ese numero", "Error!", MessageBoxButtons.OK); }   
            }
            catch { MessageBox.Show("No existe un Bono Consulta con ese codigo", "Error!", MessageBoxButtons.OK); }
        }

        private void btnTurno_Click(object sender, EventArgs e)
        {
            try
            {
                afiliado = new Afiliado(txtNumAfil.Text);
                turno = (Turno)grillaHorarios.CurrentRow.DataBoundItem;
                if (turno.Codigo_Persona == afiliado.Codigo_Persona)
                {
                    cmdConfirmarBono.Enabled = true;
                    txtBono.Enabled = true;
                    btnTurno.Enabled = false;
                    grillaHorarios.Enabled = false;
                    txtNumAfil.Enabled = false;
                }
                else
                {
                    MessageBox.Show("El turno seleccionado no corresponde al afiliado", "Error", MessageBoxButtons.OK);
                }
            }
            catch { MessageBox.Show("Inserte correctamente el numero de afiliado", "Error!", MessageBoxButtons.OK); }
        }

    }
}