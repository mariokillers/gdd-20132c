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
        public Profesional unProfesional { get; set; }

        //LISTA PARA MOSTRAR LOS RANGOS
        private List<Rango> listaDeRangos = new List<Rango>();

        private void frmRegistrarAgenda_Load(object sender, EventArgs e)
        {
            grillaHorarios.AutoGenerateColumns = false;

            generarGrilla();

            //OBTENGO LOS DIAS
            cmbDias.DataSource = Utiles.ObtenerTodosLosDias();
            cmbDias.ValueMember = "Id";
            cmbDias.DisplayMember = "Detalle";

            //OBTENGO LAS HORAS
            cmbHoraDesde.DataSource = Utiles.ObtenerHorasDiasHabiles();
            cmbHoraDesde.ValueMember = "LaHora";
            cmbHoraDesde.DisplayMember = "HoraAMostrar";

            cmbHoraHasta.DataSource = Utiles.ObtenerHorasDiasHabiles();
            cmbHoraHasta.ValueMember = "LaHora";
            cmbHoraHasta.DisplayMember = "HoraAMostrar";

            lblNombre.Text = unProfesional.Apellido + ", " + unProfesional.Nombre;
        }

        private void generarGrilla()
        {
            DataGridViewTextBoxColumn ColDia = new DataGridViewTextBoxColumn();
            ColDia.DataPropertyName = "StringDia";
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
            Dias unDia = new Dias((int)cmbDias.SelectedValue);
            //AGARR0 LAS HORAS
            TimeSpan horaDesde = (TimeSpan)cmbHoraDesde.SelectedValue;
            TimeSpan horaHasta = (TimeSpan)cmbHoraHasta.SelectedValue;
            if (Utiles.EsHoraValida(horaDesde, horaHasta))
            {
                Rango unRango = new Rango(unDia, horaDesde, horaHasta);
                //VALIDAR QUE NO SE PISE CON OTRA YA ASIGNADA
                if(Utiles.NoSePisan(unDia, horaDesde,horaHasta,listaDeRangos))
                {
                    listaDeRangos.Add(unRango); 
                    ActualizarGrilla(); 
                }else{MessageBox.Show("Los horarios seleccionados se sobreponen", "Error!", MessageBoxButtons.OK);}
            }
            else { MessageBox.Show("Inserte correctamente las horas", "Error!", MessageBoxButtons.OK); }
        }
        private void ActualizarGrilla()
        {     
            grillaHorarios.DataSource = null;
            grillaHorarios.DataSource = listaDeRangos;
            
        }

        private void cmdFinalizar_Click(object sender, EventArgs e)
        {
            if(unProfesional.RegistrarRango(listaDeRangos) )
            {
                MessageBox.Show("La agenda ha sido insertada correctamente", "EnhoraBuena!", MessageBoxButtons.OK);
                groRango.Visible = true;
            }
            else { MessageBox.Show("La carga horaria supera las 48 hs. semanales", "Error!", MessageBoxButtons.OK); }
        }

        private void cmdConfirmarRango_Click(object sender, EventArgs e)
        {
            DateTime fechaDesde = dtpDesde.Value;
            DateTime fechaHasta = dtpHasta.Value;

            if (Utiles.SonFechasValidas(fechaDesde, fechaHasta))
            {
                if (unProfesional.RegistrarAgenda(fechaDesde, fechaHasta)) { MessageBox.Show("El rango de fechas ha sido insertado correctamente", "EnhoraBuena!", MessageBoxButtons.OK); }
                else { MessageBox.Show("El rango de fechas supera los 120 dias", "Error!", MessageBoxButtons.OK); }
            }
            else { MessageBox.Show("La fecha desde es superior a la fecha hasta", "Error!", MessageBoxButtons.OK); }
            this.Close();        
        }

        private void cmbDias_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SI SELECCIONO EL SABADO
            if ((int)cmbDias.SelectedIndex ==5)
            {
                //SETEO LOS HORARIOS DE SABADO
                cmbHoraDesde.DataSource = Utiles.ObtenerHorasDiasSabados();
                cmbHoraDesde.ValueMember = "LaHora";
                cmbHoraDesde.DisplayMember = "HoraAMostrar";

                cmbHoraHasta.DataSource = Utiles.ObtenerHorasDiasSabados();
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
