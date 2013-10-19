using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.NewFolder12;

namespace Clinica_Frba.NewFolder10
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Ingresar_Click_1(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            //buscar en la db ese user y esa pass. if true pasa

            //cambia de form
            frmAfiliado a = new frmAfiliado();
            this.Hide();
            a.ShowDialog();
        }
    }
}
