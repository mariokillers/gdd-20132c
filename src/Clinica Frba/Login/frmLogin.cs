using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.NewFolder12;
using Clinica_Frba.Clases;
using System.Security.Cryptography;

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
            try
            {
                if (txtUserName.Text != "" && txtPassword.Text != "")
                {
                    Usuario user = new Usuario();
                    user.Name = txtUserName.Text;
                    /*
                     * buscar en la db ese user y esa pass. if true pasa
                     * 
                     * //cambia de form
                    frmAfiliado a = new frmAfiliado();
                    this.Hide();
                    a.ShowDialog();*/
                }
                else
                {
                    MessageBox.Show("Complete todos los campos", "Error!", MessageBoxButtons.OK);
                }
                
            }
            catch
            {
                MessageBox.Show("Usuario y contraseña no validos", "Error!", MessageBoxButtons.OK);
            }


        }
    }
}
