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

        //LISTA PARA MOSTRAR LOS RANGOS
        List<Rango> listaDeRangos = new List<Rango>();

        private void frmRegistrarAgenda_Load(object sender, EventArgs e)
        {
            grillaHorarios.AutoGenerateColumns = false;

            generarGrilla();

            //OBTENGO LOS DIAS
            cmbDias.DataSource = Utiles.ObtenerTodosLosDias();
            cmbDias.ValueMember = "Id";
            cmbDias.DisplayMember = "Detalle";

            //SI SELECCIONO EL SABADO
            if ((int)cmbDias.SelectedValue == 7)
            {
                //NO FUNCA
                cmdHoraDesde.DataSource = Utiles.ObtenerHorasDiasSabadosDesde();
                cmdHoraHasta.DataSource = Utiles.ObtenerHorasDiasSabadosHasta();
            }

            //lblNombre.Text = Profesional.Apellido + "," + Profesional.Nombre;
        }

        private void generarGrilla()
        {
            DataGridViewTextBoxColumn ColDia = new DataGridViewTextBoxColumn();
            ColDia.DataPropertyName = "Dia";
            ColDia.HeaderText = "Día";
            ColDia.Width = 120;
            grillaHorarios.Columns.Add(ColDia);

            DataGridViewTextBoxColumn ColHoraDesde = new DataGridViewTextBoxColumn();
            ColHoraDesde.DataPropertyName = "HoraDesde";
            ColHoraDesde.HeaderText = "Hora Desde";
            ColHoraDesde.Width = 120;
            grillaHorarios.Columns.Add(ColHoraDesde);

            DataGridViewTextBoxColumn ColHoraHasta = new DataGridViewTextBoxColumn();
            ColHoraHasta.DataPropertyName = "HoraHasta";
            ColHoraHasta.HeaderText = "Hora Hasta";
            ColHoraHasta.Width = 120;
            grillaHorarios.Columns.Add(ColHoraHasta);
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            //FALTA AGARRAR LAS HORAS
            Rango unRango = new Rango(Dias.ObtenerDia((int)cmbDias.SelectedValue), 1, 1);

            listaDeRangos.Add(unRango);
            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            //meto el resultado en la grilla
            grillaHorarios.DataSource = listaDeRangos;
        }

        private void cmdFinalizar_Click(object sender, EventArgs e)
        {
            groRango.Visible = true;
        }

        private void cmdConfirmarRango_Click(object sender, EventArgs e)
        {
            DateTime fechaDesde = dtpDesde.Value;
            DateTime fechaHasta = dtpHasta.Value;

            if (Utiles.SonFechasValidas(fechaDesde, fechaHasta))
            {
                try
                {
                    //unProfesional.RegistrarAgenda(fechaDesde,fechaHasta;
                    //VER SI YA ESTA LA VALIDACION EN LA DB -> TIRA EXCEPTION
                }
                catch { MessageBox.Show("El rango de fechas supera los 120 dias", "Error!", MessageBoxButtons.OK); }
            }
            else { MessageBox.Show("La fecha desde es superior a la fecha hasta", "Error!", MessageBoxButtons.OK); }
        }
    }
}
