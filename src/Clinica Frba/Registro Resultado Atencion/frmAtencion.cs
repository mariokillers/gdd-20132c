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

        private void frmAtencion_Load(object sender, EventArgs e)
        {
            cmbHora.DataSource = Utiles.ObtenerHorasDiasHabiles();
            cmbHora.ValueMember = "LaHora";
            cmbHora.DisplayMember = "HoraAMostrar";
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
                if(afiliado.ActualizarHistoriaClinica(profesional,fecha,txtSintomas.Text,txtDiagnostico.Text))
                {
                    gpRecetas.Visible = true;
                    Limpiar();
                    MessageBox.Show("Se ha actualizado correctamente la historia clinica del paciente", "EnHoraBuena!", MessageBoxButtons.OK);
                }
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
            formReceta.Show();
            this.Close();
        }
    }
}
