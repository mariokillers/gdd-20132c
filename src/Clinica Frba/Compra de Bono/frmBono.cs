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
        private List<TipoCompraParaMostrar> ListaAMostrar { get; set; }

        private void frmBono_Load(object sender, EventArgs e)
        {
            ListaAMostrar = new List<TipoCompraParaMostrar>();
            grillaBonos.AutoGenerateColumns = false;
            cmdComprar.Enabled = false;
            cargarGrilla();

            lblFechaCompra.Text = DateTime.Parse(System.Configuration.ConfigurationSettings.AppSettings["Fecha"]).ToShortDateString();
            lblMontoAPagar.Text = "0";
            lblFechaVencimiento.Text = "";
            if (RolElegido.Nombre == "Afiliado")
            {
                afiliado = new Afiliado(User.Codigo_Persona);
                lblGrupoFamiliar.Text = afiliado.Numero_Familiar.ToString();
                lblPrecioPorBono.Text = (new BonoConsulta(afiliado)).Precio.ToString();
                lblNumeroAfiliado.Text = afiliado.Numero_Familiar.ToString() + afiliado.Numero_Grupo.ToString();
                lblPlanMedico.Text = afiliado.Plan_Medico.ToString(); 
            }
            //COMO ES ADMINISTRADOR ->TIENE QUE INGRESAR EL NUM DE AFIL DE LA PERSONA
            else 
            {
                lblNumeroAfiliado.Visible = true;
                txtNumAfil.Visible = true;
                cmdConfirmar.Visible = true;
                grillaBonos.Visible = false;
                tlpDatos.Visible = false;
                cmdCantBonos.Visible = false;
                cmdAgregar.Visible = false;
                cmdComprar.Visible = false;
                rbConsulta.Visible = false;
                rbFarmacia.Visible = false;
                label1.Visible = false;
            }
        }

        private void cargarGrilla()
        {
            DataGridViewTextBoxColumn ColTipo = new DataGridViewTextBoxColumn();
            ColTipo.DataPropertyName = "TipoBono";
            ColTipo.HeaderText = "Tipo de Bono";
            ColTipo.Width = 120;
            grillaBonos.Columns.Add(ColTipo);

            DataGridViewTextBoxColumn ColCantidad = new DataGridViewTextBoxColumn();
            ColCantidad.DataPropertyName = "Cantidad";
            ColCantidad.HeaderText = "Cantidad";
            ColCantidad.Width = 120;
            grillaBonos.Columns.Add(ColCantidad);

            DataGridViewTextBoxColumn ColMonto = new DataGridViewTextBoxColumn();
            ColMonto.DataPropertyName = "MontoBono";
            ColMonto.HeaderText = "Monto por Bono";
            ColMonto.Width = 120;
            grillaBonos.Columns.Add(ColMonto);

            DataGridViewTextBoxColumn ColMontoTotal = new DataGridViewTextBoxColumn();
            ColMontoTotal.DataPropertyName = "MontoTotal";
            ColMontoTotal.HeaderText = "Monto Total";
            ColMontoTotal.Width = 120;
            grillaBonos.Columns.Add(ColMontoTotal);

            DataGridViewTextBoxColumn ColFechaVencimiento = new DataGridViewTextBoxColumn();
            ColFechaVencimiento.DataPropertyName = "FechaVencimiento";
            ColFechaVencimiento.HeaderText = "Fecha de Vencimiento";
            ColFechaVencimiento.Width = 120;
            grillaBonos.Columns.Add(ColFechaVencimiento);

        }

        private void ActualizarGrilla()
        {
            grillaBonos.DataSource = null;
            grillaBonos.DataSource = ListaAMostrar;
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
                    RealizarCompra();
                }
            }
            catch { MessageBox.Show("Inserte correctamente todos los campos", "Error!", MessageBoxButtons.OK); }
        }

        private void RealizarCompra()
        {
            Compra unaCompra = new Compra(afiliado);
            List<BonoConsulta> bonosConsulta = new List<BonoConsulta>();
            List<BonoFarmacia> bonosFarmacia = new List<BonoFarmacia>();
            if (PuedeRealizarCompra())
            {
                foreach (TipoCompraParaMostrar unRegistro in ListaAMostrar)
                {
                    if (unRegistro.TipoBono == "Bono Farmacia")
                    {
                        for (int i = 0; i < unRegistro.Cantidad; i++)
                        {
                            BonoFarmacia unBono = new BonoFarmacia(afiliado);
                            bonosFarmacia.Add(unBono);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < unRegistro.Cantidad; i++)
                        {
                            BonoConsulta unBono = new BonoConsulta(afiliado);
                            bonosConsulta.Add(unBono);
                        }
                    }
                }
                unaCompra.BonosFarmacia = bonosFarmacia;
                unaCompra.BonosConsulta = bonosConsulta;

                if (afiliado.ComprarBonos(unaCompra))
                {
                    MessageBox.Show("La compra se ha realizado con éxito", "EnhoraBuena!", MessageBoxButtons.OK);
                }
                else { MessageBox.Show("No se pudo realizar la compra", "Error!", MessageBoxButtons.OK); }
            }
            else { MessageBox.Show("El usuario no puede realizar la compra, se encuentra inhabilitado", "Error!", MessageBoxButtons.OK); }
            LimpiarGrilla();
        }

        private void LimpiarGrilla()
        {
            grillaBonos.DataSource = null;
        }

        private bool PuedeRealizarCompra()
        {
            return afiliado.Activo;
        }

        private void cmdConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                afiliado = new Afiliado(txtNumAfil.Text);

                lblNumeroAfiliado.Visible = false;
                txtNumAfil.Visible = false;
                cmdConfirmar.Visible = false;
                grillaBonos.Visible = true;
                tlpDatos.Visible = true;
                cmdCantBonos.Visible = true;
                cmdAgregar.Visible = true;
                cmdComprar.Visible = true;
                rbConsulta.Visible = true;
                rbFarmacia.Visible = true;
                label1.Visible = true;

                lblGrupoFamiliar.Text = afiliado.Numero_Familiar.ToString();
                lblPrecioPorBono.Text = (new BonoConsulta(afiliado)).Precio.ToString();
                lblNumeroAfiliado.Text = afiliado.Numero_Familiar.ToString() + afiliado.Numero_Grupo.ToString();
                lblPlanMedico.Text = afiliado.Plan_Medico.ToString(); //ES UN NOMBRE?
            }
            catch { MessageBox.Show("El afiliado no existe", "Error!", MessageBoxButtons.OK); }
        }

        private void rbConsulta_CheckedChanged(object sender, EventArgs e)
        {
            lblPrecioPorBono.Text = (new BonoConsulta(afiliado)).Precio.ToString();
            lblFechaVencimiento.Text = "";
        }

        private void rbFarmacia_CheckedChanged(object sender, EventArgs e)
        {
            lblPrecioPorBono.Text = (new BonoFarmacia(afiliado)).Precio.ToString();
            lblFechaVencimiento.Text = (DateTime.Parse(System.Configuration.ConfigurationSettings.AppSettings["Fecha"]).AddDays(60)).ToShortDateString();
        }

        private void cmdCantBonos_ValueChanged(object sender, EventArgs e)
        {
            lblMontoAPagar.Text = (cmdCantBonos.Value * Int32.Parse(lblPrecioPorBono.Text)).ToString();
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtNumAfil.Visible)
                {
                    TipoCompraParaMostrar unaCompra = new TipoCompraParaMostrar();
                    unaCompra.FechaVencimiento = lblFechaVencimiento.Text;
                    unaCompra.Cantidad = (int)cmdCantBonos.Value;
                    unaCompra.MontoBono = Int32.Parse(lblPrecioPorBono.Text);
                    unaCompra.MontoTotal = (unaCompra.MontoBono * unaCompra.Cantidad);
                    if (rbFarmacia.Checked) { unaCompra.TipoBono = "Bono Farmacia"; }
                    else { unaCompra.TipoBono = "Bono Consulta"; }
                    ListaAMostrar.Add(unaCompra);
                    ActualizarGrilla();
                    cmdComprar.Enabled = true;
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
    }
}
