using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Clases;
using Clinica_Frba.Abm_de_Profesional;

namespace Clinica_Frba.Registrar_Agenda
{
    public partial class frmRegistrarAgenda : Form
    {
        public frmRegistrarAgenda()
        {
            InitializeComponent();
        }
        //PARA SABER QUE PROFESIONAL ESTOY ACTUALIZANDO
        public Usuario Profesional { get; set; }

        private void frmRegistrarAgenda_Load(object sender, EventArgs e)
        {
            grillaHorarios.AutoGenerateColumns = false;
            generarGrilla();

            //OBTENGO LOS DIAS
            List<Dias> listaDeDias = Utiles.ObtenerTodosLosDias();

            cmbDias.DataSource = listaDeDias;
            cmbDias.ValueMember = "Id";
            cmbDias.DisplayMember = "Detalle";

            //lblNombre.Text = Profesional.Apellido + "," + Profesional.Nombre;
        }

        private void generarGrilla()
        {
            DataGridViewTextBoxColumn ColDia = new DataGridViewTextBoxColumn();
            ColDia.DataPropertyName = "Detalle";
            ColDia.HeaderText = "Día";
            ColDia.Width = 120;
            grillaHorarios.Columns.Add(ColDia);

            DataGridViewTextBoxColumn ColHoraDesde = new DataGridViewTextBoxColumn();
            //ColHoraDesde.DataPropertyName = "Detalle";
            //ColHoraDesde.HeaderText = "Día";
            ColHoraDesde.Width = 120;
            grillaHorarios.Columns.Add(ColHoraDesde);

            DataGridViewTextBoxColumn ColHoraHasta = new DataGridViewTextBoxColumn();
            //ColHoraHasta.DataPropertyName = "Detalle";
            //ColHoraHasta.HeaderText = "Día";
            ColHoraHasta.Width = 120;
            grillaHorarios.Columns.Add(ColHoraHasta);
        }
    }
}
