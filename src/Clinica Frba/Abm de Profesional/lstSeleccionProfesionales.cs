using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Clinica_Frba.Clases;
using Clinica_Frba.NewFolder13;

namespace Clinica_Frba.Abm_de_Profesional
{
    public partial class lstSeleccionProfesionales : Form
    {
        public lstSeleccionProfesionales()
        {
            InitializeComponent();
        }

        private List<Profesional> listaDeProfesionales = new List<Profesional>();

        private List<SqlParameter> ListaDeParametros = new List<SqlParameter>();

        public string Operacion { get; set; }

        public Profesional unProfesional = new Profesional();

        private void lstSeleccionProfesionales_Load(object sender, EventArgs e)
        {
            grillaProfesionales.AutoGenerateColumns = false;
            List<Especialidad> listaDeEspecialidades = Especialidades.ObtenerEspecialidades();
            cmbEspecialidades.DataSource = listaDeEspecialidades;
            cmbEspecialidades.ValueMember = "Codigo";
            cmbEspecialidades.DisplayMember = "Descripcion";

            cargarGrilla();
        }

        private void cmdLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        public void Limpiar()
        {
            txtApellido.Text = "";
            txtDni.Text = "";
            txtNombre.Text = "";
            txtNumMatricula.Text = "";
            ActualizarGrilla();
        }

        public void ActualizarGrilla()
        {
            decimal unaEspecialidad = (decimal)cmbEspecialidades.SelectedValue;

            if (txtNombre.Text != "" || txtApellido.Text != "" || txtDni.Text != "" || txtNumMatricula.Text != "" || unaEspecialidad != 0)
            {
                listaDeProfesionales = Profesionales.ObtenerProfesionales(txtNombre.Text, txtApellido.Text, txtDni.Text, txtNumMatricula.Text, unaEspecialidad);
            }
            else
            {
                listaDeProfesionales = Profesionales.ObtenerTodos();
            }

            //meto el resultado en la grilla
            grillaProfesionales.DataSource = listaDeProfesionales;
        }

        private void cargarGrilla()
        {

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

            if (Operacion == "Baja")
            {
                btnAction.Text = "Eliminar";
            }
            else
            {
                btnAction.Text = "Modificar";
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            try
            {
                unProfesional = (Profesional)grillaProfesionales.CurrentRow.DataBoundItem;

                if (Operacion == "Baja")
                {
                 //   Profesionales.Eliminar(unProfesional.Id);   ---->TODO
                    Limpiar();
                }
                else
                {
                    if (Operacion == "Modificacion")
                    {
                        frmProfesional formProf = new frmProfesional();
                        formProf.Operacion = this.Operacion;
                        formProf.unProfesional = unProfesional;
                        formProf.Show();
                    }
                }
            }
            catch
            {
                MessageBox.Show("No se selecciono ningun profesional", "Error!", MessageBoxButtons.OK);
            }
        }
    }
}
