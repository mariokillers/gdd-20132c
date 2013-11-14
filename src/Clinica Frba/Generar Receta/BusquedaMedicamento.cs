using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Clases;

namespace Clinica_Frba.Generar_Receta
{
    public partial class BusquedaMedicamento : Form
    {
        public BusquedaMedicamento()
        {
            InitializeComponent();
        }

        private List<Medicamento> listaDeMedicamentos = new List<Medicamento>();

        private void BusquedaMedicamento_Load(object sender, EventArgs e)
        {
            grillaMedicamentos.AutoGenerateColumns = false;

            generarGrilla();
        }

        private void generarGrilla()
        {
            DataGridViewTextBoxColumn ColNombre = new DataGridViewTextBoxColumn();
            ColNombre.DataPropertyName = "Detalle";
            ColNombre.HeaderText = "Nombre";
            ColNombre.Width = 200;
            grillaMedicamentos.Columns.Add(ColNombre);
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ActualizarGrilla();
            }
            catch { MessageBox.Show("No existe un medicamento con tales caracteristicas", "Error!", MessageBoxButtons.OK); }
        }

        private void ActualizarGrilla()
        {
            if (txtNombreMedicamento.Text != "")
            {
                listaDeMedicamentos = Medicamentos.ObtenerMedicamentos(txtNombreMedicamento.Text);
            }
            else { listaDeMedicamentos = Medicamentos.ObtenerMedicamentos(); }

            grillaMedicamentos.DataSource = listaDeMedicamentos;
        }
    }
}
