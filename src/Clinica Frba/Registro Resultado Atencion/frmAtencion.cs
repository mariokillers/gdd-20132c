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
                fecha = dtpFechaAtencion.Value;
                hora = (TimeSpan)cmbHora.SelectedValue;

                gpHistoriaClinica.Visible = true;
            }
            catch { MessageBox.Show("Complete correctamente todos los campos", "Error!", MessageBoxButtons.OK); }
        }

        private void cmdConfirmarSintomas_Click(object sender, EventArgs e)
        {
            if (txtDiagnostico.Text != "" && txtSintomas.Text != "")
            {
                if(afiliado.ActualizarHistoriaClinica(profesional,hora,txtSintomas.Text,txtDiagnostico.Text))
                {
                    gpRecetas.Visible = true;
                    MessageBox.Show("Se ha actualizado correctamente la historia clinica del paciente", "EnHoraBuena!", MessageBoxButtons.OK);
                }
            }
            else { MessageBox.Show("Complete correctamente todos los campos", "Error!", MessageBoxButtons.OK); }
        }
    }
}
