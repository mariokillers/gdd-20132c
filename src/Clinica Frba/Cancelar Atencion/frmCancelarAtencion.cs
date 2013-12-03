using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Clases;

namespace Clinica_Frba.NewFolder7
{
    public partial class frmCancelarAtencion : Form
    {
        public frmCancelarAtencion()
        {
            InitializeComponent();
        }
        public Afiliado unAfiliado = new Afiliado();
        public String Operacion { get; set; }
        public List<Turno> listaTurnos { get; set; }
        public Turno unTurno { get; set; }

        private void frmCancelarAtencion_Load(object sender, EventArgs e)
        {
            unTurno = new Turno();
            listaTurnos = new List<Turno>();
            grillaTurnos.AutoGenerateColumns = false;
            grillaTurnos.MultiSelect = false;
            List<TipoCancelacion> listaDeTipos = Utiles.ObtenerTiposCancelacion();
            cmbCancelacion.DataSource = listaDeTipos;
            cmbCancelacion.ValueMember = "id";
            cmbCancelacion.DisplayMember = "descripcion";

            lbl1.Text = "Afiliado: " + unAfiliado.Apellido + ", " + unAfiliado.Nombre;

            cargarGrilla();
        }

        public void cargarGrilla()
        {
            DataGridViewTextBoxColumn ColPaciente = new DataGridViewTextBoxColumn();
            ColPaciente.DataPropertyName = "Nombre_Persona";
            ColPaciente.HeaderText = "PacienteNombre";
            ColPaciente.Width = 120;
            grillaTurnos.Columns.Add(ColPaciente);

            DataGridViewTextBoxColumn ColProfesional = new DataGridViewTextBoxColumn();
            ColProfesional.DataPropertyName = "Nombre_Profesional";
            ColProfesional.HeaderText = "Profesional";
            ColProfesional.Width = 120;
            grillaTurnos.Columns.Add(ColProfesional);

            DataGridViewTextBoxColumn ColFecha = new DataGridViewTextBoxColumn();
            ColFecha.DataPropertyName = "Fecha";
            ColFecha.HeaderText = "Fecha Turno";
            ColFecha.Width = 120;
            grillaTurnos.Columns.Add(ColFecha);

            ActualizarGrilla();
        }

        public void ActualizarGrilla()
        {
            listaTurnos = Turnos.ObtenerTurnos(this.unAfiliado.Codigo_Persona);
            
            //meto el resultado en la grilla
            grillaTurnos.DataSource = listaTurnos;
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            if (txtMotivo.Text != "")
            {
                try
                {
                    unTurno = (Turno)grillaTurnos.CurrentRow.DataBoundItem;

                    if ((Utiles.EsFechaValidaPorUnDia(DateTime.Parse(System.Configuration.ConfigurationSettings.AppSettings["Fecha"]).Date, unTurno.Fecha.Date)))
                    {
                        Turnos.Cancelar(unTurno, (decimal)cmbCancelacion.SelectedValue, txtMotivo.Text);
                        MessageBox.Show("El turno se ha cancelado con exito!", "Aviso", MessageBoxButtons.OK);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("El turno no puede cancelarse por ser en menos de 24hs.", "Aviso", MessageBoxButtons.OK);
                    }
                }
                catch
                {
                    MessageBox.Show("No se ha seleccionado ningun turno o tiene campos sin completar!", "Error", MessageBoxButtons.OK);
                }
            }
            else MessageBox.Show("No se ha indicado el motivo de la cancelacion, por favor ingreselo y vuelva a intentarlo", "Error", MessageBoxButtons.OK);
        }
    }
}
