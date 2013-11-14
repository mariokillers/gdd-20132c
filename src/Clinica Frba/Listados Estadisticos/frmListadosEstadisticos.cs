using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Clinica_Frba.NewFolder9
{
    public partial class frmListadosEstadisticos : Form
    {
        public frmListadosEstadisticos()
        {
            InitializeComponent();
        }

        private void frmListadosEstadisticos_Load(object sender, EventArgs e)
        {
            grillaTopBonosAfiliado.AutoGenerateColumns = false;
            grillaTopBonosEspecialidad.AutoGenerateColumns = false;
            grillaTopBonosTerceros.AutoGenerateColumns = false;
            grillaTopEspecialidades.AutoGenerateColumns = false;
        }

        private void generarGrillaBonosAfiliado()
        {
            DataGridViewTextBoxColumn ColNombre = new DataGridViewTextBoxColumn();
            ColNombre.DataPropertyName = "TipoBono";
            ColNombre.HeaderText = "Nombre";
            ColNombre.Width = 120;
            grillaTopBonosAfiliado.Columns.Add(ColNombre);

            DataGridViewTextBoxColumn ColApellido= new DataGridViewTextBoxColumn();
            ColApellido.DataPropertyName = "Cantidad";
            ColApellido.HeaderText = "Apellido";
            ColApellido.Width = 120;
            grillaTopBonosAfiliado.Columns.Add(ColApellido);

            DataGridViewTextBoxColumn ColCant = new DataGridViewTextBoxColumn();
            ColCant.DataPropertyName = "MontoBono";
            ColCant.HeaderText = "Bonos Farmacia Vencidos";
            ColCant.Width = 120;
            grillaTopBonosAfiliado.Columns.Add(ColCant);
        }

        private void generarGrillaCancelacionesEspecialidad()
        {
            DataGridViewTextBoxColumn ColNombre = new DataGridViewTextBoxColumn();
            ColNombre.DataPropertyName = "EspecialidadMedica";
            ColNombre.HeaderText = "Especialidad Médica";
            ColNombre.Width = 120;
            grillaTopEspecialidades.Columns.Add(ColNombre);

            DataGridViewTextBoxColumn ColCant = new DataGridViewTextBoxColumn();
            ColCant.DataPropertyName = "CantBonos";
            ColCant.HeaderText = "Bonos Farmacia Recetados";
            ColCant.Width = 120;
            grillaTopEspecialidades.Columns.Add(ColCant);
        }
    }
}
