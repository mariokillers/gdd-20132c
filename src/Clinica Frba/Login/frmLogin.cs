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

                    //comienza el hasheo de la pass
                    UTF8Encoding encoderHash = new UTF8Encoding();
                    SHA256Managed hasher = new SHA256Managed();
                    byte[] bytesDeHasheo = hasher.ComputeHash(encoderHash.GetBytes(txtPassword.Text));
                    user.Password = bytesDeHasheoToString(bytesDeHasheo);

                    //VALIDAR EL USER

                    /*
                     * buscar en la db ese user y esa pass. if true pasa
                     * 
                     * //cambia de form*/
                    frmAfiliado a = new frmAfiliado();
                    this.Hide();
                    a.ShowDialog();
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

        //funcion para transformar lo hasheado a string
        private string bytesDeHasheoToString(byte[] array)
        {
            StringBuilder salida = new StringBuilder("");
            for (int i = 0; i < array.Length; i++)
            {
                salida.Append(array[i].ToString("X2"));
            }
            return salida.ToString();
        }
    }
}
