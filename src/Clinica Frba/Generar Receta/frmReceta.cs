using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Clases;
using Clinica_Frba.Generar_Receta;

namespace Clinica_Frba.NewFolder5
{
    public partial class frmReceta : Form
    {
        public frmReceta()
        {
            InitializeComponent();
        }
        private Receta receta { get; set; }
        public int idHistoriaClinica { get; set; }
        public Afiliado afiliado { get; set; }
        private List<Receta> listaDeRecetas { get; set; }
        private List<BonoFarmacia> listaDeBonos { get; set; }
        private List<Medicamento> listaAMostrar { get; set; }
        private bool NecesitaBono { get; set; }
        public Medicamento medicamento { get; set; }

        private void frmRegistroLlegada_Load(object sender, EventArgs e)
        {
            /*NecesitaBono = true;

            cmdCant.Enabled = false;
            cmdSeleccionarMed.Enabled = false;
            cmdAgregarMedicamento.Enabled = false;

            listaAMostrar = new List<Medicamento>();
            listaDeBonos = new List<BonoFarmacia>();
            listaDeRecetas = new List<Receta>();*/
            Limpiar();

            grillaRecetas.AutoGenerateColumns = false;
            grillaBonos.AutoGenerateColumns = false;

            generarGrillaBonos();
            generarGrillaRecetas();
        }

        private void generarGrillaRecetas()
        {
            DataGridViewTextBoxColumn ColMedicamento = new DataGridViewTextBoxColumn();
            ColMedicamento.DataPropertyName = "Detalle";
            ColMedicamento.HeaderText = "Medicamento";
            ColMedicamento.Width = 120;
            grillaRecetas.Columns.Add(ColMedicamento);

            DataGridViewTextBoxColumn ColCantidad = new DataGridViewTextBoxColumn();
            ColCantidad.DataPropertyName = "Cantidad";
            ColCantidad.HeaderText = "Cantidad";
            ColCantidad.Width = 120;
            grillaRecetas.Columns.Add(ColCantidad);

            DataGridViewTextBoxColumn ColCantLetras = new DataGridViewTextBoxColumn();
            ColCantLetras.DataPropertyName = "CantidadEnLetras";
            ColCantLetras.HeaderText = "Cantidad";
            ColCantLetras.Width = 120;
            grillaRecetas.Columns.Add(ColCantLetras);

            DataGridViewTextBoxColumn ColBonoFarmacia = new DataGridViewTextBoxColumn();
            ColBonoFarmacia.DataPropertyName = "BonoFarmacia";
            ColBonoFarmacia.HeaderText = "Bono Farmacia";
            ColBonoFarmacia.Width = 120;
            grillaRecetas.Columns.Add(ColBonoFarmacia);
        }

        private void generarGrillaBonos()
        {
            DataGridViewTextBoxColumn ColTipo = new DataGridViewTextBoxColumn();
            ColTipo.DataPropertyName = "Detalle";
            ColTipo.HeaderText = "Tipo de Bono";
            ColTipo.Width = 120;
            grillaBonos.Columns.Add(ColTipo);

            DataGridViewTextBoxColumn ColPrecio = new DataGridViewTextBoxColumn();
            ColPrecio.DataPropertyName = "Precio";
            ColPrecio.HeaderText = "Precio";
            ColPrecio.Width = 120;
            grillaBonos.Columns.Add(ColPrecio);

            DataGridViewTextBoxColumn ColFechaVencimiento = new DataGridViewTextBoxColumn();
            ColFechaVencimiento.DataPropertyName = "FechaVencimiento";
            ColFechaVencimiento.HeaderText = "Fecha de Vencimiento";
            ColFechaVencimiento.Width = 120;
            grillaBonos.Columns.Add(ColFechaVencimiento);
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (NecesitaBono)
                {
                    BonoFarmacia unBono = new BonoFarmacia(Int32.Parse(txtNumeroBono.Text));
                    if(unBono.Usado)
                    {
                        if (!unBono.EstasVencido((DateTime.Parse(System.Configuration.ConfigurationSettings.AppSettings["Fecha"]))))
                        {
                            if (unBono.PuedeUsarlo((int)afiliado.Numero_Grupo))
                            {
                                if (!listaDeBonos.Any(p => p.Id == unBono.Id))
                            {
                                listaDeBonos.Add(unBono);
                                ActualizarGrillaBonos();
                                receta = new Receta(Int32.Parse(txtNumeroBono.Text));
                                receta.Codigo_Bono_Farmacia = unBono.Id;

                                cmdCant.Enabled = true;
                                cmdSeleccionarMed.Enabled = true;
                                cmdAgregarMedicamento.Enabled = true;
                                cmdAceptar.Enabled = false;
                                NecesitaBono = false;
                                txtNumeroBono.Enabled = false;
                            }
                            else { MessageBox.Show("Ya esta ingresado ese bono", "Error!", MessageBoxButtons.OK); }
                            }
                            else { MessageBox.Show("El bono no puede ser usado por el afiliado", "Error!", MessageBoxButtons.OK); }
                        }
                        else { MessageBox.Show("El bono esta vencido", "Error!", MessageBoxButtons.OK); }
                    }else { MessageBox.Show("El bono ya ha sido usado", "Error!", MessageBoxButtons.OK); }
                }else { MessageBox.Show("No es necesario que agrege mas bonos farmacia hasta el momento", "Error!", MessageBoxButtons.OK); }            }
            catch { MessageBox.Show("No existe un Bono Farmacia con ese codigo", "Error!", MessageBoxButtons.OK); }
        }

        private void ActualizarGrillaBonos()
        {
            grillaBonos.DataSource = null;
            grillaBonos.DataSource = listaDeBonos;
        }

        private void ActualizarGrillaRecetas()
        {
            grillaRecetas.DataSource = null;
            grillaRecetas.DataSource = listaAMostrar;
        }

        private void cmdSeleccionarMed_Click(object sender, EventArgs e)
        {
            frmBusquedaMedicamento formMedicamento = new frmBusquedaMedicamento();
            formMedicamento.Show();
            formMedicamento.formReceta = this;
            cmdSeleccionarMed.Enabled = false;
            cmdCant.Enabled = true;
            this.Hide();
        }

        private void cmdAgregarMedicamento_Click(object sender, EventArgs e)
        {
            try
            {
                if (!NecesitaBono)
                {
                    if (receta.ListaMedicamentos.Count >= 5)
                    {
                        NecesitaBono = true;
                        MessageBox.Show("Necesita adquirir mas bonos para poder agregar el medicamento", "Error!", MessageBoxButtons.OK);
                        cmdAceptar.Enabled = true;
                        txtNumeroBono.Text = "";
                        txtNumeroBono.Enabled = true;
                    }
                    else
                    {
                        if (!receta.ListaMedicamentos.Any(p => p.Detalle == medicamento.Detalle))
                        {
                            medicamento.Cantidad = (int)cmdCant.Value;
                            medicamento.CantidadEnLetras = Utiles.DameEnLetras(medicamento.Cantidad);
                            medicamento.BonoFarmacia = Int32.Parse(txtNumeroBono.Text);
                            receta.ListaMedicamentos = AgregarAListaMedicamentos(medicamento);
                            listaAMostrar.Add(medicamento);

                            ActualizarGrillaRecetas();

                            if (receta.ListaMedicamentos.Count >= 5)
                            {
                                NecesitaBono = true;
                                txtNumeroBono.Text = "";
                                txtNumeroBono.Enabled = true;
                                cmdAceptar.Enabled = true;

                                listaDeRecetas.Add(receta);
                                receta = null;
                            }
                            cmdSeleccionarMed.Enabled = true;
                        }
                        else 
                        {
                            MessageBox.Show("Ya se ha ingresado ese medicamento", "Error!", MessageBoxButtons.OK);
                            cmdSeleccionarMed.Enabled = true;
                        }
                    }
                }
                else {MessageBox.Show("Necesita adquirir mas bonos para poder agregar el medicamento", "Error!", MessageBoxButtons.OK);}
            }
            catch { MessageBox.Show("Seleccione un medicamento", "Error!", MessageBoxButtons.OK); }
        }

        private List<Medicamento> AgregarAListaMedicamentos(Medicamento unMedicamento)
        {
            List<Medicamento> aux = receta.ListaMedicamentos;
            aux.Add(medicamento);
            return aux;
        }

        private void cmdRecetar_Click(object sender, EventArgs e)
        {
            try
            {
                int bonoAnterior = -1;
                receta = new Receta(Int32.Parse(txtNumeroBono.Text));
                receta.ListaMedicamentos = listaAMostrar;
                foreach (Medicamento unMedicamento in receta.ListaMedicamentos)
                {
                    if (unMedicamento.BonoFarmacia != bonoAnterior)
                    {
                        BonoFarmacia bono = new BonoFarmacia(unMedicamento.BonoFarmacia);
                        bono.Usar();
                    }
                    unMedicamento.AgregarAReceta(idHistoriaClinica);
                }
                MessageBox.Show("Se ha recetado correctamete", "EnHoraBuena!", MessageBoxButtons.OK);
                Limpiar();
            }
            catch { MessageBox.Show("Se ha producido un error", "Error!", MessageBoxButtons.OK); }
        }

        private void Limpiar()
        {
            listaDeBonos = null;
            ActualizarGrillaBonos();
            listaAMostrar = null;
            ActualizarGrillaRecetas();
            cmdSeleccionarMed.Enabled = false;
            txtNumeroBono.Enabled = true;
            cmdAceptar.Enabled = true;
            NecesitaBono = true;
            listaAMostrar = new List<Medicamento>();
            listaDeBonos = new List<BonoFarmacia>();
            listaDeRecetas = new List<Receta>();
        }
    }
}
