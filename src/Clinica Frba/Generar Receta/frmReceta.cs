using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Clinica_Frba.NewFolder5
{
    public partial class frmRegistroLlegada : Form
    {
        public frmRegistroLlegada()
        {
            InitializeComponent();
        }

        private void frmRegistroLlegada_Load(object sender, EventArgs e)
        {
            grillaRecetas.AutoGenerateColumns = false;
        }

        private void generarGrilla()
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
        }
    }
}
