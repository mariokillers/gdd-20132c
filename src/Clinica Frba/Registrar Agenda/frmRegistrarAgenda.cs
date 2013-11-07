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
            ActualizarGrilla();

            //OBTENGO LOS DIAS
            cmbDias.DataSource = Utiles.ObtenerTodosLosDias();
            cmbDias.ValueMember = "Id";
            cmbDias.DisplayMember = "Detalle";

            //OBTENGO LAS HORAS
            cmbHoraDesde.DataSource = Utiles.ObtenerHorasDiasHabilesDesde();
            cmbHoraDesde.ValueMember = "LaHora";
            cmbHoraDesde.DisplayMember = "HoraAMostrar";

            cmbHoraHasta.DataSource = Utiles.ObtenerHorasDiasHabilesHasta();
            cmbHoraHasta.ValueMember = "LaHora";
            cmbHoraHasta.DisplayMember = "HoraAMostrar";

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
            //AGARRO EL DIA
            string dia = Dias.ObtenerDia((int)cmbDias.SelectedValue);
            //FALTA AGARRAR LAS HORAS
            Rango unRango = new Rango(dia, new TimeSpan(7, 0, 0), new TimeSpan(8, 30, 0));
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
            //CHEQUEA SUMA DE HORAS <48
            if (!Utiles.SePasaDeHoras(listaDeRangos))
            {
                groRango.Visible = true;
            }
            else { }    
        }

        private void cmdConfirmarRango_Click(object sender, EventArgs e)
        {
            DateTime fechaDesde = dtpDesde.Value;
            DateTime fechaHasta = dtpHasta.Value;

            if (Utiles.SonFechasValidas(fechaDesde, fechaHasta))
            {
                try
                {
                    //unProfesional.RegistrarAgenda(fechaDesde,fechaHasta);
                    //VER SI YA ESTA LA VALIDACION EN LA DB -> TIRA EXCEPTION
                }
                catch { MessageBox.Show("El rango de fechas supera los 120 dias", "Error!", MessageBoxButtons.OK); }
            }
            else { MessageBox.Show("La fecha desde es superior a la fecha hasta", "Error!", MessageBoxButtons.OK); }
        }

        private void cmbDias_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SI SELECCIONO EL SABADO
            if ((int)cmbDias.SelectedIndex ==6)
            {
                //SETEO LOS HORARIOS DE SABADO
                cmbHoraDesde.DataSource = Utiles.ObtenerHorasDiasSabadosDesde();
                cmbHoraDesde.ValueMember = "LaHora";
                cmbHoraDesde.DisplayMember = "HoraAMostrar";

                cmbHoraHasta.DataSource = Utiles.ObtenerHorasDiasSabadosHasta();
                cmbHoraHasta.ValueMember = "LaHora";
                cmbHoraHasta.DisplayMember = "HoraAMostrar";
            }
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            Rango unRango = (Rango)grillaHorarios.CurrentRow.DataBoundItem;
            listaDeRangos.Remove(unRango);
            ActualizarGrilla();
        }
    }
}
