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

namespace Clinica_Frba.Cancelar_Atencion
{
    public partial class frmCancelarDias : Form
    {
        public frmCancelarDias()
        {
            InitializeComponent();
        }
        public Profesional unProfesional = new Profesional();
        public Agenda unaAgenda = new Agenda();

        private void cmdRango_Click(object sender, EventArgs e)
        {
            lbl26.Visible = true;
            dtpFin.Visible = true;
            label5.Text = "Seleccione Dia Inicio Rango:";
            dtpInicio.Enabled = false;
            cmdRango.Enabled = false;

            dtpFin.MinDate = dtpInicio.Value;
            dtpFin.MaxDate = unaAgenda.FechaHasta;
        }

        private void frmCancelarDias_Load(object sender, EventArgs e)
        {
            try
            {
                unaAgenda.armarAgendaSinEspecialidad(unProfesional.Id);

                dtpInicio.MinDate = unaAgenda.FechaDesde;
                dtpInicio.MaxDate = unaAgenda.FechaHasta;

                List<TipoCancelacion> listaDeTipos = Utiles.ObtenerTiposCancelacion();
                cmbCancelacion.DataSource = listaDeTipos;
                cmbCancelacion.ValueMember = "id";
                cmbCancelacion.DisplayMember = "descripcion";

                lbl1.Text = "Profesional: " + unProfesional.Apellido + ", " + unProfesional.Nombre;
            }
            catch
            {
                MessageBox.Show("El profesional no tiene una agenda disponible", "Error", MessageBoxButtons.OK);
                this.Close();
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            if (txtMotivo.Text != "")
            {
                try
                {
                    DateTime fechaInicio = dtpInicio.Value;
                    if ((Utiles.EsFechaValidaPorUnDia(DateTime.Parse(System.Configuration.ConfigurationSettings.AppSettings["Fecha"]).Date, fechaInicio.Date)))
                    {
                        if (lbl26.Visible == false) //Si solo se selecciono una fecha
                        {
                            if (!Utiles.ObtenerDiasHabilesAgenda(unaAgenda).Contains(new Dias(fechaInicio.DayOfWeek).Id))
                            {
                                MessageBox.Show("La fecha seleccionada no forma parte de su agenda, por favor seleccione otra", "Aviso", MessageBoxButtons.OK);
                            }
                            else
                            {
                                try
                                {
                                    Turnos.AnularDia(unProfesional.Id, fechaInicio, (decimal)cmbCancelacion.SelectedValue, txtMotivo.Text);
                                    MessageBox.Show("La fecha seleccionada ha sido cancelada correctamente!", "Aviso", MessageBoxButtons.OK);
                                    this.Close();
                                }
                                catch
                                {
                                    MessageBox.Show("Error al intentar cancelar el dia", "Error", MessageBoxButtons.OK);
                                }
                            }
                        }
                        else
                        {
                            DateTime fechaFin = dtpFin.Value;
                            try
                            {
                                Turnos.AnularRango(unProfesional.Id, fechaInicio, fechaFin, (decimal)cmbCancelacion.SelectedValue, txtMotivo.Text);
                                MessageBox.Show("El rango seleccionado ha sido cancelado correctamente!", "Aviso", MessageBoxButtons.OK);
                                this.Close();
                            }
                            catch
                            {
                                MessageBox.Show("Error al intentar cancelar el rango", "Error", MessageBoxButtons.OK);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("El dia/rango no puede cancelarse por ser en menos de 24hs.", "Aviso", MessageBoxButtons.OK);
                        dtpInicio.Enabled = true;
                        cmdRango.Enabled = true;
                        dtpFin.Visible = false;
                        lbl26.Visible = false;
                    }
                }
                catch
                {
                    MessageBox.Show("Error al intentar cancelar.", "Error", MessageBoxButtons.OK);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("No se ha indicado el motivo de la cancelacion, por favor ingreselo y vuelva a intentarlo", "Error", MessageBoxButtons.OK);
            }
            
        }        
    }
    
}
