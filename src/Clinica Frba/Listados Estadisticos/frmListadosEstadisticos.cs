using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Clases;

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
            grillaListado2.AutoGenerateColumns = false;
            grillaListado3.AutoGenerateColumns = false;
            grillaListado4.AutoGenerateColumns = false;
            grillaListado1.AutoGenerateColumns = false;

            generarGrillaListado1();
            generarGrillaListado2();
            generarGrillaListado3();
            generarGrillaListado4();
        }

        private void generarGrillaListado4()
        {

            DataGridViewTextBoxColumn ColCant = new DataGridViewTextBoxColumn();
            ColCant.DataPropertyName = "CantBonos";
            ColCant.HeaderText = "Bonos Farmacia Vencidos";
            ColCant.Width = 120;
            grillaListado4.Columns.Add(ColCant);
        }

        private void generarGrillaListado2()
        {
            DataGridViewTextBoxColumn ColNombre = new DataGridViewTextBoxColumn();
            ColNombre.DataPropertyName = "Nombre";
            ColNombre.HeaderText = "Nombre";
            ColNombre.Width = 120;
            grillaListado2.Columns.Add(ColNombre);

            DataGridViewTextBoxColumn ColApellido= new DataGridViewTextBoxColumn();
            ColApellido.DataPropertyName = "Apellido";
            ColApellido.HeaderText = "Apellido";
            ColApellido.Width = 120;
            grillaListado2.Columns.Add(ColApellido);

            DataGridViewTextBoxColumn ColCant = new DataGridViewTextBoxColumn();
            ColCant.DataPropertyName = "CantBonos";
            ColCant.HeaderText = "Bonos Farmacia Vencidos";
            ColCant.Width = 120;
            grillaListado2.Columns.Add(ColCant);
        }

        private void generarGrillaListado3()
        {
            DataGridViewTextBoxColumn ColNombre = new DataGridViewTextBoxColumn();
            ColNombre.DataPropertyName = "EspecialidadMedica";
            ColNombre.HeaderText = "Especialidad Médica";
            ColNombre.Width = 120;
            grillaListado3.Columns.Add(ColNombre);

            DataGridViewTextBoxColumn ColCant = new DataGridViewTextBoxColumn();
            ColCant.DataPropertyName = "CantBonos";
            ColCant.HeaderText = "Bonos Farmacia Recetados";
            ColCant.Width = 120;
            grillaListado3.Columns.Add(ColCant);
        }

        private void generarGrillaListado1()
        {
            DataGridViewTextBoxColumn ColNombre = new DataGridViewTextBoxColumn();
            ColNombre.DataPropertyName = "EspecialidadMedica";
            ColNombre.HeaderText = "Especialidad Médica";
            ColNombre.Width = 120;
            grillaListado1.Columns.Add(ColNombre);

            DataGridViewTextBoxColumn ColCant = new DataGridViewTextBoxColumn();
            ColCant.DataPropertyName = "CantBonos";
            ColCant.HeaderText = "Bonos Farmacia Recetados";
            ColCant.Width = 120;
            grillaListado1.Columns.Add(ColCant);
        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime desde = new DateTime();
                DateTime hasta = new DateTime();

                if (rdPrimerSemestre.Checked)
                {
                    desde = new DateTime(dtpAño.Value.Year, 1, 1);
                    hasta = desde.AddMonths(6).AddMilliseconds(-1);
                    hasta = hasta.AddMilliseconds(-1);
                }
                if (rdSegundoSemestre.Checked)
                {
                    desde = new DateTime(dtpAño.Value.Year, 7, 1);
                    hasta = desde.AddMonths(6).AddMilliseconds(-1);
                    hasta = hasta.AddMilliseconds(-1);
                }

                grillaListado1.DataSource = Listados.ObtenerEspecialidadesMasCancelaciones(desde, hasta);
                grillaListado2.DataSource = Listados.ObtenerCantBonosVencidosPorAfiliado(desde, hasta);
                grillaListado3.DataSource = Listados.ObtenerEspecialidadesConMasBonosRecetados(desde, hasta);
                grillaListado4.DataSource = Listados.ObtenerAfiliadosQueUsaronBonosQueNoCompraron(desde, hasta);
            }
            catch { MessageBox.Show("No se ha podido realizar las estadisticas. Vuelva a intentarlo", "Error!", MessageBoxButtons.OK); }
        }
    }
}
