using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.NewFolder12;
using Clinica_Frba.Abm_de_Rol;

namespace Clinica_Frba
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAfiliadoAlta formAf = new frmAfiliadoAlta();
            formAf.Show();
            this.Hide();
        }

        private void modificacionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            lstSeleccionRol formRol = new lstSeleccionRol();
            formRol.Show();
            this.Hide();
        }
    }
}
