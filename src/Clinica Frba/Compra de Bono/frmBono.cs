using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Clases;
using Clinica_Frba.Clase_Persona;

namespace Clinica_Frba.NewFolder3
{
    public partial class frmBono : Form
    {
        public frmBono()
        {
            InitializeComponent();
        }
        public Usuario User { get; set; }
        public Rol RolElegido { get; set; }
        private Afiliado afiliado { get; set; }

        private void frmBono_Load(object sender, EventArgs e)
        {
            lblFechaCompra.Text = DateTime.Today.ToShortDateString();
            lblPrecioPorBono.Text = "0";
            lblMontoAPagar.Text = "0";
            lblFechaVencimiento.Text = "";
            if (RolElegido.Nombre == "Afiliado")
            {
                afiliado = new Afiliado(User.Codigo_Persona);
                lblGrupoFamiliar.Text = afiliado.Numero_Familiar.ToString();
                lblNumeroAfiliado.Text = afiliado.Numero_Familiar.ToString() + afiliado.Numero_Grupo.ToString();
                lblPlanMedico.Text = afiliado.Plan_Medico.ToString(); //ES UN NOMBRE?
            }
            //COMO ES ADMINISTRADOR ->TIENE QUE INGRESAR EL NUM DE AFIL DE LA PERSONA
            else 
            {
                lblNumeroAfiliado.Visible = true;
                txtNumAfil.Visible = true;
            }
        }

        private void ActualizarGrilla()
        {
            //grillaBonos.DataSource = listaBonos;
        }

        private void cmdComprar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!txtNumAfil.Visible)
                {
                    RealizarCompra();
                }
                else
                {
                    //SI ES ADMINISTRATIVO -> LE HAGO UNA COMPRA PARA EL AFILIADO
                    afiliado = new Afiliado(Int32.Parse(txtNumAfil.Text));
                    RealizarCompra();
                }
            }
            catch { MessageBox.Show("Inserte correctamente todos los campos", "Error!", MessageBoxButtons.OK); }
        }

        private void RealizarCompra()
        {
            Compra unaCompra = new Compra(afiliado);
            int cantBonos = (int)cmdCantBonos.Value;
            if (rbConsulta.Checked)
            {
                List<BonoConsulta> bonos = new List<BonoConsulta>();
                for (int i = 0; i < cantBonos; i++)
                {
                    BonoConsulta unBono = new BonoConsulta(afiliado);
                    lblPrecioPorBono.Text = unBono.Precio.ToString();
                    bonos.Add(unBono);
                }
                unaCompra.BonosConsulta = bonos;
                unaCompra.BonosFarmacia = new List<BonoFarmacia>();
                if (afiliado.ComprarBonos(unaCompra))
                {
                    MessageBox.Show("La compra se ha realizado con éxito", "EnhoraBuena!", MessageBoxButtons.OK);
                }
                else { MessageBox.Show("No se pudo realizar la compra", "Error!", MessageBoxButtons.OK); }
            }
            else if (rbFarmacia.Checked)
            {
                List<BonoFarmacia> bonos = new List<BonoFarmacia>();
                for (int i = 0; i < cantBonos; i++)
                {
                    BonoFarmacia unBono = new BonoFarmacia(afiliado);
                    lblPrecioPorBono.Text = unBono.Precio.ToString();
                    bonos.Add(unBono);
                }
                unaCompra.BonosFarmacia = bonos;
                unaCompra.BonosConsulta = new List<BonoConsulta>();
                if (afiliado.ComprarBonos(unaCompra)) 
                {
                    MessageBox.Show("La compra se ha realizado con éxito", "EnhoraBuena!", MessageBoxButtons.OK);
                }
                else { MessageBox.Show("No se pudo realizar la compra", "Error!", MessageBoxButtons.OK); }
            }
            //ActualizarGrilla();
        }
    }
}
