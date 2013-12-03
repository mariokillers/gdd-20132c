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
using Clinica_Frba.Registrar_Llegada;
using Clinica_Frba.Registrar_Agenda;
using Clinica_Frba.Cancelar_Atencion;
using Clinica_Frba.Abm_de_Afiliado;

namespace Clinica_Frba.Abm_de_Profesional
{
    public partial class lstSeleccionProfesionales : Form
    {
        public lstSeleccionProfesionales()
        {
            InitializeComponent();
        }
        public frmRegistrarLlegada formLlegada { get; set; }
        private List<Profesional> listaDeProfesionales = new List<Profesional>();
        private List<SqlParameter> ListaDeParametros = new List<SqlParameter>();
        public string Operacion { get; set; }
        public decimal especialidad { get; set; }

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
            especialidad = (decimal)cmbEspecialidades.SelectedValue;

            if (txtNombre.Text != "" || txtApellido.Text != "" || txtDni.Text != "" || txtNumMatricula.Text != "" || especialidad != 0)
            {
                listaDeProfesionales = Profesionales.ObtenerProfesionales(txtNombre.Text, txtApellido.Text, txtDni.Text, txtNumMatricula.Text, especialidad);
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
            else if (Operacion == "Modificacion")
            {
                btnAction.Text = "Modificar";
            }
            else
            {
                btnAction.Text = "Seleccionar";
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            try
            {
                unProfesional = (Profesional)grillaProfesionales.CurrentRow.DataBoundItem;

                if (Operacion == "Baja")
                {
                    Profesionales.EliminarProfesional(unProfesional.Id);
                    Limpiar();
                    MessageBox.Show("El profesional ha sido dado de baja correctamente", "Aviso", MessageBoxButtons.OK);
                }
                else
                {
                    if (Operacion == "Modificacion")
                    {
                        frmProfesional formProf = new frmProfesional();
                        formProf.Operacion = this.Operacion;
                        formProf.unProfesional = unProfesional;
                        formProf.listaVieja = unProfesional.Especialidades;
                        formProf.Show();
                    }
                    if (Operacion == "Seleccion")
                    {
                        try
                        {
                            Profesional profesional = (Profesional)grillaProfesionales.CurrentRow.DataBoundItem;
                            formLlegada.profesional = profesional;
                            formLlegada.especialidad = especialidad;
                            if (formLlegada.cargarGrilla())
                            {
                                formLlegada.Show();
                                this.Close();
                            }
                        }
                        catch { MessageBox.Show("Debe seleccionar algun profesional", "Error!", MessageBoxButtons.OK); }
                    }
                    if (Operacion == "Registrar Agenda")
                    {
                        frmRegistrarAgenda formAgenda = new frmRegistrarAgenda();
                        formAgenda.unProfesional = unProfesional;
                        formAgenda.Show();
                        this.Close();
                    }
                    if (Operacion == "Consultar Agenda")
                    {
                        lstSeleccionAgenda formAgenda = new lstSeleccionAgenda();
                        formAgenda.unProfesional = unProfesional;
                        formAgenda.Show();
                        this.Close();
                    }
                    if (Operacion == "Cancelar Dias")
                    {
                        frmCancelarDias frmCancel = new frmCancelarDias();
                        frmCancel.unProfesional = unProfesional;
                        frmCancel.Show();
                        this.Close();
                    }
                    if (Operacion == "Registrar Atencion")
                    {
                        lstSeleccionAfiliado formAfil = new lstSeleccionAfiliado();
                        formAfil.Operacion = "Seleccion";
                        formAfil.profesional = unProfesional;
                        formAfil.Show();
                        this.Close();
                    }
                }
            }
            catch
            {
                MessageBox.Show("No se selecciono ningun profesional", "Error!", MessageBoxButtons.OK);
            }
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ActualizarGrilla();
            }
            catch
            {
                MessageBox.Show("no actualiza grilla", "Error!", MessageBoxButtons.OK);
            }
        }
    }
}