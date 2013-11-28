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
using Clinica_Frba.NewFolder5;

namespace Clinica_Frba.NewFolder6
{
    public partial class frmAtencion : Form
    {
        public frmAtencion()
        {
            InitializeComponent();
        }
        //A QUE AFILIADO CORRESPONDE LA ATENCION
        public Afiliado afiliado { get; set; }
        private DateTime fecha { get; set; }
        private TimeSpan hora { get; set; }
        public Profesional profesional { get; set; }
        private int turno { get; set; }
        public Turno unTurno = new Turno();

        private void frmAtencion_Load(object sender, EventArgs e)
        {
            cmbEspecialidades.DataSource = Especialidades.ObtenerEspecialidadesProfesional(profesional.Id);
            cmbEspecialidades.ValueMember = "Codigo";
            cmbEspecialidades.DisplayMember = "Descripcion";
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                fecha = dtpFechaAtencion.Value.Date;
                hora = (TimeSpan)cmbHora.SelectedValue;
                fecha = fecha.Add(hora);

                gpHistoriaClinica.Visible = true;
            }
            catch { MessageBox.Show("Complete correctamente todos los campos", "Error!", MessageBoxButtons.OK); }
        }

        private void cmdConfirmarSintomas_Click(object sender, EventArgs e)
        {
            if (txtDiagnostico.Text != "" && txtSintomas.Text != "")
            {
                try 
                {
                    //pase la validacion mas arriba ---> turno = afiliado.ProximoTurno(DateTime.Parse(System.Configuration.ConfigurationSettings.AppSettings["Fecha"]).Date, (int)(decimal)cmbEspecialidades.SelectedValue, profesional.Id);
                    afiliado.ActualizarAtencion(fecha, txtSintomas.Text, txtDiagnostico.Text, turno);
                    Utiles.ObtenerTurno(turno).Usar();
                    gpRecetas.Visible = true;
                    Limpiar();
                    MessageBox.Show("Se ha actualizado correctamente la atención del paciente", "EnHoraBuena!", MessageBoxButtons.OK);
                }
                catch { MessageBox.Show("El paciente no tiene turno con la especialidad seleccionada o no ha dado aviso de llegada", "Error!", MessageBoxButtons.OK); }
            }
            else { MessageBox.Show("Complete correctamente todos los campos", "Error!", MessageBoxButtons.OK); }
        }

        private void Limpiar()
        {
            txtDiagnostico.Text = "";
            txtSintomas.Text = "";
            txtDiagnostico.Enabled = false;
            txtSintomas.Enabled = false;
            cmbHora.Enabled = false;
            dtpFechaAtencion.Enabled = false;
            cmdAceptar.Enabled = false;
            cmdConfirmarSintomas.Enabled = false;
        }

        private void cmdFinalizar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdGeneraReceta_Click(object sender, EventArgs e)
        {
            frmReceta formReceta = new frmReceta();
            formReceta.afiliado = afiliado;
            formReceta.idAtencion = turno;
            formReceta.Show();
            this.Close();
        }

        private void btnConfEsp_Click(object sender, EventArgs e)
        {
            try
            {

                turno = afiliado.ProximoTurno(DateTime.Parse(System.Configuration.ConfigurationSettings.AppSettings["Fecha"]).Date, (int)(decimal)cmbEspecialidades.SelectedValue, profesional.Id);

                if(Utiles.ExisteRegistroLlegada(turno))
                {
                    dtpFechaAtencion.Text = Utiles.ObtenerFechaTurno(turno).ToString();
                    dtpFechaAtencion.Enabled = false;

                    cmbHora.DataSource = Utiles.ObtenerHorasAceptables(Utiles.ObtenerTurno(turno));
                    cmbHora.ValueMember = "LaHora";
                    cmbHora.DisplayMember = "HoraAMostrar";

                    label1.Visible = true;
                    label2.Visible = true;
                    dtpFechaAtencion.Visible = true;
                    cmdAceptar.Visible = true;
                    cmbHora.Visible = true;
                }
                else { MessageBox.Show("El paciente no no ha dado aviso de llegada", "Error!", MessageBoxButtons.OK); }
            }
            catch { MessageBox.Show("El paciente no tiene turno con la especialidad seleccionada", "Error!", MessageBoxButtons.OK); }

        }
    }
}
