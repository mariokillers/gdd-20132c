using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Clases;

namespace Clinica_Frba.NewFolder5
{
    public partial class frmReceta : Form
    {
        public frmReceta()
        {
            InitializeComponent();
        }

        public Afiliado afiliado { get; set; }
        private List<BonoFarmacia> listaDeBonos { get; set; }
        private bool EsNecesarioMas { get; set; }
        public Medicamento medicamento { get; set; }

        private void frmRegistroLlegada_Load(object sender, EventArgs e)
        {

            /*List<Medicamento> listaDeMedicamentos = Medicamentos.ObtenerMedicamentos();
            cmbMedicamentos.DataSource = listaDeMedicamentos;
            cmbMedicamentos.ValueMember = "Detalle";
            cmbMedicamentos.DisplayMember = "Detalle";*/

            listaDeBonos = new List<BonoFarmacia>();

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
            ColBonoFarmacia.DataPropertyName = "Codigo_Bono_Farmacia";
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
                if (EsNecesarioMas)
                {
                    BonoFarmacia unBono = new BonoFarmacia(Int32.Parse(txtNumeroBono.Text));
                    if (!unBono.EstasVencido(DateTime.Today))
                    {
                        if (!listaDeBonos.Any(p => p.Id == unBono.Id))
                        {
                            listaDeBonos.Add(unBono);
                            ActualizarGrilla();
                        }
                        else { MessageBox.Show("Ya esta ingresado ese bono", "Error!", MessageBoxButtons.OK); }
                    }
                    else { MessageBox.Show("El bono esta vencido", "Error!", MessageBoxButtons.OK); }
                }else { MessageBox.Show("No es necesario que agrege mas bonos farmacia hasta el momento", "Error!", MessageBoxButtons.OK); }            }
            catch { MessageBox.Show("No existe un Bono Farmacia con ese codigo", "Error!", MessageBoxButtons.OK); }
        }

        private void ActualizarGrilla()
        {
            grillaBonos.DataSource = null;
            grillaBonos.DataSource = listaDeBonos;
        }
    }
}
