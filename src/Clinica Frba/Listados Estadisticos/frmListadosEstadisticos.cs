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
            DataGridViewTextBoxColumn ColNombre = new DataGridViewTextBoxColumn();
            ColNombre.DataPropertyName = "Nombre";
            ColNombre.HeaderText = "Nombre";
            ColNombre.Width = 120;
            grillaListado4.Columns.Add(ColNombre);

            DataGridViewTextBoxColumn ColApellido = new DataGridViewTextBoxColumn();
            ColApellido.DataPropertyName = "Apellido";
            ColApellido.HeaderText = "Apellido";
            ColApellido.Width = 120;
            grillaListado4.Columns.Add(ColApellido);

            DataGridViewTextBoxColumn ColDoc = new DataGridViewTextBoxColumn();
            ColDoc.DataPropertyName = "Documento";
            ColDoc.HeaderText = "Documento";
            ColDoc.Width = 120;
            grillaListado4.Columns.Add(ColDoc);

            DataGridViewTextBoxColumn ColCant = new DataGridViewTextBoxColumn();
            ColCant.DataPropertyName = "CantBonos";
            ColCant.HeaderText = "Bonos Farmacia Vencidos";
            ColCant.Width = 120;
            grillaListado4.Columns.Add(ColCant);

            DataGridViewTextBoxColumn ColAno = new DataGridViewTextBoxColumn();
            ColAno.DataPropertyName = "Ano";
            ColAno.HeaderText = "Año";
            ColAno.Width = 120;
            grillaListado4.Columns.Add(ColAno);

            DataGridViewTextBoxColumn ColMes1 = new DataGridViewTextBoxColumn();
            ColMes1.DataPropertyName = "CantBonos1";
            ColMes1.HeaderText = "1° Mes";
            ColMes1.Width = 120;
            grillaListado4.Columns.Add(ColMes1);

            DataGridViewTextBoxColumn ColMes2 = new DataGridViewTextBoxColumn();
            ColMes2.DataPropertyName = "CantBonos2";
            ColMes2.HeaderText = "2° Mes";
            ColMes2.Width = 120;
            grillaListado4.Columns.Add(ColMes2);

            DataGridViewTextBoxColumn ColMes3 = new DataGridViewTextBoxColumn();
            ColMes3.DataPropertyName = "CantBonos3";
            ColMes3.HeaderText = "3° Mes";
            ColMes3.Width = 120;
            grillaListado4.Columns.Add(ColMes3);

            DataGridViewTextBoxColumn ColMes4 = new DataGridViewTextBoxColumn();
            ColMes4.DataPropertyName = "CantBonos4";
            ColMes4.HeaderText = "4° Mes";
            ColMes4.Width = 120;
            grillaListado4.Columns.Add(ColMes4);

            DataGridViewTextBoxColumn ColMes5 = new DataGridViewTextBoxColumn();
            ColMes5.DataPropertyName = "CantBonos5";
            ColMes5.HeaderText = "5° Mes";
            ColMes5.Width = 120;
            grillaListado4.Columns.Add(ColMes5);

            DataGridViewTextBoxColumn ColMes6 = new DataGridViewTextBoxColumn();
            ColMes6.DataPropertyName = "CantBonos6";
            ColMes6.HeaderText = "6° Mes";
            ColMes6.Width = 120;
            grillaListado4.Columns.Add(ColMes6);
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

             DataGridViewTextBoxColumn ColDoc = new DataGridViewTextBoxColumn();
             ColDoc.DataPropertyName = "Documento";
             ColDoc.HeaderText = "Documento";
             ColDoc.Width = 120;
             grillaListado2.Columns.Add(ColDoc);

             DataGridViewTextBoxColumn ColCant = new DataGridViewTextBoxColumn();
             ColCant.DataPropertyName = "CantBonos";
             ColCant.HeaderText = "Bonos Farmacia Vencidos";
             ColCant.Width = 120;
             grillaListado2.Columns.Add(ColCant);

             DataGridViewTextBoxColumn ColAno = new DataGridViewTextBoxColumn();
             ColAno.DataPropertyName = "Ano";
             ColAno.HeaderText = "Año";
             ColAno.Width = 120;
             grillaListado2.Columns.Add(ColAno);

             DataGridViewTextBoxColumn ColMes1 = new DataGridViewTextBoxColumn();
             ColMes1.DataPropertyName = "CantBonos1";
             ColMes1.HeaderText = "1° Mes";
             ColMes1.Width = 120;
             grillaListado2.Columns.Add(ColMes1);

             DataGridViewTextBoxColumn ColMes2 = new DataGridViewTextBoxColumn();
             ColMes2.DataPropertyName = "CantBonos2";
             ColMes2.HeaderText = "2° Mes";
             ColMes2.Width = 120;
             grillaListado2.Columns.Add(ColMes2);

             DataGridViewTextBoxColumn ColMes3 = new DataGridViewTextBoxColumn();
             ColMes3.DataPropertyName = "CantBonos3";
             ColMes3.HeaderText = "3° Mes";
             ColMes3.Width = 120;
             grillaListado2.Columns.Add(ColMes3);

             DataGridViewTextBoxColumn ColMes4 = new DataGridViewTextBoxColumn();
             ColMes4.DataPropertyName = "CantBonos4";
             ColMes4.HeaderText = "4° Mes";
             ColMes4.Width = 120;
             grillaListado2.Columns.Add(ColMes4);

             DataGridViewTextBoxColumn ColMes5 = new DataGridViewTextBoxColumn();
             ColMes5.DataPropertyName = "CantBonos5";
             ColMes5.HeaderText = "5° Mes";
             ColMes5.Width = 120;
             grillaListado2.Columns.Add(ColMes5);

             DataGridViewTextBoxColumn ColMes6 = new DataGridViewTextBoxColumn();
             ColMes6.DataPropertyName = "CantBonos6";
             ColMes6.HeaderText = "6° Mes";
             ColMes6.Width = 120;
             grillaListado2.Columns.Add(ColMes6);
         }

        private void generarGrillaListado3()
        {
            DataGridViewTextBoxColumn ColNombre = new DataGridViewTextBoxColumn();
            ColNombre.DataPropertyName = "EspecialidadMedica";
            ColNombre.HeaderText = "Especialidad Médica";
            ColNombre.Width = 120;
            grillaListado3.Columns.Add(ColNombre);

            DataGridViewTextBoxColumn ColTipo = new DataGridViewTextBoxColumn();
            ColTipo.DataPropertyName = "TipoEspecialidadMedica";
            ColTipo.HeaderText = "Tipo Especialidad Médica";
            ColTipo.Width = 120;
            grillaListado3.Columns.Add(ColTipo);

            DataGridViewTextBoxColumn ColCant = new DataGridViewTextBoxColumn();
            ColCant.DataPropertyName = "CantCancelaciones";
            ColCant.HeaderText = "Total Semestre";
            ColCant.Width = 120;
            grillaListado3.Columns.Add(ColCant);

            DataGridViewTextBoxColumn ColMes1 = new DataGridViewTextBoxColumn();
            ColMes1.DataPropertyName = "CantCancelaciones1";
            ColMes1.HeaderText = "1° Mes";
            ColMes1.Width = 120;
            grillaListado3.Columns.Add(ColMes1);

            DataGridViewTextBoxColumn ColMes2 = new DataGridViewTextBoxColumn();
            ColMes2.DataPropertyName = "CantCancelaciones2";
            ColMes2.HeaderText = "2° Mes";
            ColMes2.Width = 120;
            grillaListado3.Columns.Add(ColMes2);

            DataGridViewTextBoxColumn ColMes3 = new DataGridViewTextBoxColumn();
            ColMes3.DataPropertyName = "CantCancelaciones3";
            ColMes3.HeaderText = "3° Mes";
            ColMes3.Width = 120;
            grillaListado3.Columns.Add(ColMes3);

            DataGridViewTextBoxColumn ColMes4 = new DataGridViewTextBoxColumn();
            ColMes4.DataPropertyName = "CantCancelaciones4";
            ColMes4.HeaderText = "4° Mes";
            ColMes4.Width = 120;
            grillaListado3.Columns.Add(ColMes4);

            DataGridViewTextBoxColumn ColMes5 = new DataGridViewTextBoxColumn();
            ColMes5.DataPropertyName = "CantCancelaciones5";
            ColMes5.HeaderText = "5° Mes";
            ColMes5.Width = 120;
            grillaListado3.Columns.Add(ColMes5);

            DataGridViewTextBoxColumn ColMes6 = new DataGridViewTextBoxColumn();
            ColMes6.DataPropertyName = "CantCancelaciones6";
            ColMes6.HeaderText = "6° Mes";
            ColMes6.Width = 120;
            grillaListado3.Columns.Add(ColMes6);
        }

        private void generarGrillaListado1()
        {
            DataGridViewTextBoxColumn ColNombre = new DataGridViewTextBoxColumn();
            ColNombre.DataPropertyName = "EspecialidadMedica";
            ColNombre.HeaderText = "Especialidad Médica";
            ColNombre.Width = 120;
            grillaListado1.Columns.Add(ColNombre);

            DataGridViewTextBoxColumn ColTipo = new DataGridViewTextBoxColumn();
            ColTipo.DataPropertyName = "TipoEspecialidadMedica";
            ColTipo.HeaderText = "Tipo Especialidad Médica";
            ColTipo.Width = 120;
            grillaListado3.Columns.Add(ColTipo);

            DataGridViewTextBoxColumn ColCant = new DataGridViewTextBoxColumn();
            ColCant.DataPropertyName = "CantCancelaciones";
            ColCant.HeaderText = "Total Semestre";
            ColCant.Width = 120;
            grillaListado1.Columns.Add(ColCant);

            DataGridViewTextBoxColumn ColMes1 = new DataGridViewTextBoxColumn();
            ColMes1.DataPropertyName = "CantCancelaciones1";
            ColMes1.HeaderText = "1° Mes";
            ColMes1.Width = 120;
            grillaListado1.Columns.Add(ColMes1);

            DataGridViewTextBoxColumn ColMes2 = new DataGridViewTextBoxColumn();
            ColMes2.DataPropertyName = "CantCancelaciones2";
            ColMes2.HeaderText = "2° Mes";
            ColMes2.Width = 120;
            grillaListado1.Columns.Add(ColMes2);

            DataGridViewTextBoxColumn ColMes3 = new DataGridViewTextBoxColumn();
            ColMes3.DataPropertyName = "CantCancelaciones3";
            ColMes3.HeaderText = "3° Mes";
            ColMes3.Width = 120;
            grillaListado1.Columns.Add(ColMes3);

            DataGridViewTextBoxColumn ColMes4 = new DataGridViewTextBoxColumn();
            ColMes4.DataPropertyName = "CantCancelaciones4";
            ColMes4.HeaderText = "4° Mes";
            ColMes4.Width = 120;
            grillaListado1.Columns.Add(ColMes4);

            DataGridViewTextBoxColumn ColMes5 = new DataGridViewTextBoxColumn();
            ColMes5.DataPropertyName = "CantCancelaciones5";
            ColMes5.HeaderText = "5° Mes";
            ColMes5.Width = 120;
            grillaListado1.Columns.Add(ColMes5);

            DataGridViewTextBoxColumn ColMes6 = new DataGridViewTextBoxColumn();
            ColMes6.DataPropertyName = "CantCancelaciones6";
            ColMes6.HeaderText = "6° Mes";
            ColMes6.Width = 120;
            grillaListado1.Columns.Add(ColMes6);
        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                int ano = (int)dtpAño.Value.Year;
                int semestre = 0;

                if (rdPrimerSemestre.Checked)
                {
                    semestre = 1;
                }
                if (rdSegundoSemestre.Checked)
                {
                    semestre = 2;
                }

                grillaListado1.DataSource = Listados.Listado1(semestre, ano);
                grillaListado2.DataSource = Listados.Listado2(semestre, ano);
                grillaListado3.DataSource = Listados.Listado3(semestre, ano);
                grillaListado4.DataSource = Listados.Listado4(semestre, ano);
            }
            catch { MessageBox.Show("No se ha podido realizar las estadisticas. Vuelva a intentarlo", "Error!", MessageBoxButtons.OK); }
        }
    }
}
