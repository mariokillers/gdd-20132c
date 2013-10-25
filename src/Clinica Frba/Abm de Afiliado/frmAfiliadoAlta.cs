using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Clinica_Frba.NewFolder12
{
    public partial class frmAfiliadoAlta : Form
    {
        public frmAfiliadoAlta()
        {
            InitializeComponent();
        }

        private void rdSi_CheckedChanged(object sender, EventArgs e)
        {
            //Si apreta, pertenece al mismo grupo: tenerlo en cuenta para el ABM
            frmAfiliadoAlta a = new frmAfiliadoAlta();
            //this.Hide();
            a.ShowDialog();
            rdSi.Enabled = false;
            rdNo.Enabled = false;
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
            }
            catch { MessageBox.Show("Campos no válidos", "Error!", MessageBoxButtons.OK); }
        }

        private void cmdLimpiar_Click(object sender, EventArgs e)
        {
            txtApellido.Text = "";
            txtDir.Text = "";
            txtDni.Text = "";
            txtMail.Text = "";
            txtNombre.Text = "";
            txtTel.Text = "";
            cmbEstadoCivil.Text = "";
            cmbSexo.Text = "";
            cmbTipoDoc.Text = "";
            rdNo.Enabled = true;
            rdSi.Enabled = true;
            rdNo.Checked = false;
            rdSi.Checked = false;
        }

        private void cmbVolver_Click(object sender, EventArgs e)
        {
            frmPrincipal principal = new frmPrincipal();
            this.Hide();
            principal.ShowDialog();
        }
    }
}
