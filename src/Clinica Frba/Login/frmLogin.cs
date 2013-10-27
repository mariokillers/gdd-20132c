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

        frmPrincipal formPrincipal;

        private void Ingresar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtUserName.Text != "" && txtPassword.Text != "")
                {
                    Usuario user = new Usuario(txtUserName.Text);

                    //comienza el hasheo de la pass
                    UTF8Encoding encoderHash = new UTF8Encoding();
                    SHA256Managed hasher = new SHA256Managed();
                    byte[] bytesDeHasheo = hasher.ComputeHash(encoderHash.GetBytes(txtPassword.Text));
                    string pass = bytesDeHasheoToString(bytesDeHasheo);

                    //VALIDAR EL USER
                    if (!user.Activo)
                    {
                    }
                    if (!user.Password.Equals(pass))
                    {
                        //ACTUALIZAR CANT FALLIDOS
                        user.ActualizarFallidos();
                        MessageBox.Show("Usuario y contraseña no validos", "Error!", MessageBoxButtons.OK);
                    }
                    //SETEO LOS FALLIDOS EN 0 PORQUE ENTRO
                    user.ReiniciarFallidos();

                    //INGRESO AL FORM PRINCIPAL,LE PASO EL USER ID ASI SABE QUE FUNCIONALIDADES MOSTRAR
                    formPrincipal.UserName = user.Name;
                    //this.Hide();
                    //formPrincipal.Show();
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
