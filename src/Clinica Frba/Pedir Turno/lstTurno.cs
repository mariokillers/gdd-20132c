using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Abm_de_Profesional;
using System.Data.SqlClient;
using Clinica_Frba.Clases;
using Clinica_Frba.Pedir_Turno;

namespace Clinica_Frba.NewFolder4
{
    public partial class lstTurno : Form
    {
        public lstTurno()
        {
            InitializeComponent();
        }

        private List<Profesional> listaDeProfesionales = new List<Profesional>();
        private List<SqlParameter> ListaDeParametros = new List<SqlParameter>();
        public Profesional unaProfesional = new Profesional();
        public Usuario unUser = new Usuario();

        private void lstTurno_Load(object sender, EventArgs e)
        {
            grillaProfesionales.AutoGenerateColumns = false;
            List<Especialidad> listaDeEspecialidades = Especialidades.ObtenerEspecialidades();
            cmbEspecialidades.DataSource = listaDeEspecialidades;
            cmbEspecialidades.ValueMember = "Codigo";
            cmbEspecialidades.DisplayMember = "Descripcion";

            DataGridViewTextBoxColumn ColPersona = new DataGridViewTextBoxColumn();
            ColPersona.DataPropertyName = "Id";
            ColPersona.HeaderText = "Persona";
            ColPersona.Width = 120;
            grillaProfesionales.Columns.Add(ColPersona);

            DataGridViewTextBoxColumn ColApellido = new DataGridViewTextBoxColumn();
            ColApellido.DataPropertyName = "Apellido";
            ColApellido.HeaderText = "Apellido";
            ColApellido.Width = 120;
            grillaProfesionales.Columns.Add(ColApellido);

            DataGridViewTextBoxColumn ColNombre = new DataGridViewTextBoxColumn();
            ColNombre.DataPropertyName = "Nombre";
            ColNombre.HeaderText = "Nombre";
            ColNombre.Width = 120;
            grillaProfesionales.Columns.Add(ColNombre);

            DataGridViewTextBoxColumn ColMatr = new DataGridViewTextBoxColumn();
            ColMatr.DataPropertyName = "Matricula";
            ColMatr.HeaderText = "Matricula";
            ColMatr.Width = 120;
            grillaProfesionales.Columns.Add(ColMatr);

            DataGridViewTextBoxColumn ColDoc = new DataGridViewTextBoxColumn();
            ColDoc.DataPropertyName = "NumeroDocumento";
            ColDoc.HeaderText = "Documento";
            ColDoc.Width = 120;
            grillaProfesionales.Columns.Add(ColDoc);
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            decimal unaEspecialidad = (decimal)cmbEspecialidades.SelectedValue;

            listaDeProfesionales = Profesionales.ObtenerProfesionales("", "", "", "", unaEspecialidad);

            grillaProfesionales.DataSource = listaDeProfesionales;

        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            try
            {
                frmTurno frmTurno = new frmTurno();
                frmTurno.unProfesional = (Profesional)grillaProfesionales.CurrentRow.DataBoundItem;
                frmTurno.unUsuario = this.unUser;
                frmTurno.Show();
                this.Close();
            }
            catch
            {
                MessageBox.Show("No se selecciono ningun profesional", "Error!", MessageBoxButtons.OK);
            }
        }
    }
}
