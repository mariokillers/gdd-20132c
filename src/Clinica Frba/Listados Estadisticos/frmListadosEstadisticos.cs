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

            DataGridViewTextBoxColumn ColMes = new DataGridViewTextBoxColumn();
            ColMes.DataPropertyName = "Mes";
            ColMes.HeaderText = "Mes";
            ColMes.Width = 120;
            grillaListado4.Columns.Add(ColMes);

            DataGridViewTextBoxColumn ColAno = new DataGridViewTextBoxColumn();
            ColAno.DataPropertyName = "Ano";
            ColAno.HeaderText = "Año";
            ColAno.Width = 120;
            grillaListado4.Columns.Add(ColAno);
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
          
             DataGridViewTextBoxColumn ColMes = new DataGridViewTextBoxColumn();
             ColMes.DataPropertyName = "Mes";
             ColMes.HeaderText = "Mes";
             ColMes.Width = 120;
             grillaListado2.Columns.Add(ColMes);

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
          
            DataGridViewTextBoxColumn ColMes = new DataGridViewTextBoxColumn();
            ColMes.DataPropertyName = "Mes";
            ColMes.HeaderText = "Mes";
            ColMes.Width = 120;
            grillaListado3.Columns.Add(ColMes);

            DataGridViewTextBoxColumn ColAno = new DataGridViewTextBoxColumn();
            ColAno.DataPropertyName = "Ano";
            ColAno.HeaderText = "Año";
            ColAno.Width = 120;
            grillaListado3.Columns.Add(ColAno);

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
            ColCant.DataPropertyName = "CantCancelaciones";
            ColCant.HeaderText = "Bonos Farmacia Recetados";
            ColCant.Width = 120;
            grillaListado1.Columns.Add(ColCant);

            DataGridViewTextBoxColumn ColMes = new DataGridViewTextBoxColumn();
            ColMes.DataPropertyName = "Mes";
            ColMes.HeaderText = "Mes";
            ColMes.Width = 120;
            grillaListado1.Columns.Add(ColMes);

            DataGridViewTextBoxColumn ColHorario = new DataGridViewTextBoxColumn();
            ColHorario.DataPropertyName = "Horario";
            ColHorario.HeaderText = "Horario";
            ColHorario.Width = 120;
            grillaListado1.Columns.Add(ColHorario);

            DataGridViewTextBoxColumn ColAno = new DataGridViewTextBoxColumn();
            ColAno.DataPropertyName = "Ano";
            ColAno.HeaderText = "Año";
            ColAno.Width = 120;
            grillaListado1.Columns.Add(ColAno);
        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                int ano = (int)dtpAño.Value.Year;
                int desde = 0;
                int hasta = 0;

                if (rdPrimerSemestre.Checked)
                {
                    desde = 1;
                    hasta = 6;
                }
                if (rdSegundoSemestre.Checked)
                {
                    desde = 7;
                    hasta = 12;
                }

                grillaListado1.DataSource = Listados.Listado1(desde, hasta, ano);
                grillaListado2.DataSource = Listados.Listado2(desde, hasta, ano);
                grillaListado3.DataSource = Listados.Listado3(desde, hasta, ano);
                grillaListado4.DataSource = Listados.Listado4(desde, hasta, ano);
            }
            catch { MessageBox.Show("No se ha podido realizar las estadisticas. Vuelva a intentarlo", "Error!", MessageBoxButtons.OK); }
        }
    }
}
