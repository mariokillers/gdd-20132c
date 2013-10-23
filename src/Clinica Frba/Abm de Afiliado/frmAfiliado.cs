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
    public partial class frmAfiliado : Form
    {
        public frmAfiliado()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //ESTO NO ES ASI,PERO ES UNA IDEA
            frmAfiliado a = new frmAfiliado();
            //this.Hide();
            a.ShowDialog();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch { MessageBox.Show("Campos no válidos", "Error!", MessageBoxButtons.OK); }
        }
    }
}
