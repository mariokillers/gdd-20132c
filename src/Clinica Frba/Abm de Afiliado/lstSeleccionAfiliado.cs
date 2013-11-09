using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Clases;
using System.Data.OleDb;
using System.Data.SqlClient;
using Clinica_Frba.NewFolder12;

namespace Clinica_Frba.Abm_de_Afiliado
{
    public partial class lstSeleccionAfiliado : Form
    {
        public lstSeleccionAfiliado()
        {
            InitializeComponent();
        }

        private List<Afiliado> listaDeAfiliados = new List<Afiliado>();

        //PARA CARGAR EN LA LISTA LOS PARAMETROS DE BUSQUEDA
        private List<SqlParameter> ListaDeParametros = new List<SqlParameter>();
        //PARA SABER SI ES MODIFICACION O BAJA
        public string Operacion { get; set; }

        public Afiliado unAfiliado = new Afiliado();

        //CARGO EL COMBO CON TODOS LOS PLANES
        private void lstSeleccionAfiliado_Load(object sender, EventArgs e)
        {
            grillaPacientes.AutoGenerateColumns = false;
            List<Plan> listaDePlanes = Planes.ObtenerPlanes();
            cmbPlanes.DataSource = listaDePlanes;
            cmbPlanes.ValueMember = "Codigo";
            cmbPlanes.DisplayMember = "Descripcion";

            cargarGrilla();           
            
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            try 
            {
                ActualizarGrilla();
            }
            catch { MessageBox.Show("no actualiza grilla", "Error!", MessageBoxButtons.OK); }
        }

        private void cmdLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        public void Limpiar()
        {
            txtApellido.Text = "";
            txtDni.Text = "";
            txtNombre.Text = "";
            txtNumAfiliado.Text = "";
            ActualizarGrilla();
        }

        public void ActualizarGrilla()
        {
            decimal unPlan = (decimal)cmbPlanes.SelectedValue;

            if (txtNombre.Text != "" || txtApellido.Text != "" || txtDni.Text != "" || txtNumAfiliado.Text != "" || unPlan != 0)
            {   
                listaDeAfiliados = Afiliados.ObtenerAfiliados(txtNombre.Text, txtApellido.Text, txtDni.Text, txtNumAfiliado.Text, unPlan);
            }
            else
            {
                listaDeAfiliados = Afiliados.ObtenerTodos();
            }

            //meto el resultado en la grilla
            grillaPacientes.DataSource = listaDeAfiliados;
        }

        private void cargarGrilla(){

            DataGridViewTextBoxColumn ColPersona = new DataGridViewTextBoxColumn();
            ColPersona.DataPropertyName = "Id";
            ColPersona.HeaderText = "Persona";
            ColPersona.Width = 120;
            grillaPacientes.Columns.Add(ColPersona);

            DataGridViewTextBoxColumn ColApellido = new DataGridViewTextBoxColumn();
            ColApellido.DataPropertyName = "Apellido";
            ColApellido.HeaderText = "Apellido";
            ColApellido.Width = 120;
            grillaPacientes.Columns.Add(ColApellido);

            DataGridViewTextBoxColumn ColNombre = new DataGridViewTextBoxColumn();
            ColNombre.DataPropertyName = "Nombre";
            ColNombre.HeaderText = "Nombre";
            ColNombre.Width = 120;
            grillaPacientes.Columns.Add(ColNombre);

            DataGridViewTextBoxColumn ColGrupo = new DataGridViewTextBoxColumn();
            ColGrupo.DataPropertyName = "Numero_Grupo";
            ColGrupo.HeaderText = "NroGrupo";
            ColGrupo.Width = 120;
            grillaPacientes.Columns.Add(ColGrupo);

            DataGridViewTextBoxColumn  ColFlia = new DataGridViewTextBoxColumn();
            ColFlia.DataPropertyName = "Numero_Familiar";
            ColFlia.HeaderText = "NroFamiliar";
            ColFlia.Width = 120;
            grillaPacientes.Columns.Add(ColFlia);

            DataGridViewTextBoxColumn ColDoc = new DataGridViewTextBoxColumn();
            ColDoc.DataPropertyName = "NumeroDocumento";
            ColDoc.HeaderText = "Documento";
            ColDoc.Width = 120;
            grillaPacientes.Columns.Add(ColDoc);

            DataGridViewTextBoxColumn ColPlan = new DataGridViewTextBoxColumn();
            ColPlan.DataPropertyName = "Plan_Medico";
            ColPlan.HeaderText = "PlanMedico";
            ColPlan.Width = 120;
            grillaPacientes.Columns.Add(ColPlan);


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
                unAfiliado = (Afiliado)grillaPacientes.CurrentRow.DataBoundItem;

                if (Operacion == "Baja")
                {
                    Afiliados.Eliminar(unAfiliado.Id);
                    Limpiar();
                }
                else
                {
                    if (Operacion == "Modificacion")
                    {
                        frmAfiliadoAlta formAfil = new frmAfiliadoAlta();
                        formAfil.Operacion = this.Operacion;
                        formAfil.Afiliado = unAfiliado;
                        formAfil.Show();
                    }
                }
            }
            catch
            {
                MessageBox.Show("No se selecciono ningun afiliado", "Error!", MessageBoxButtons.OK);
            }
        }

        private void btnGrupoFlia_Click(object sender, EventArgs e)
        {
            try
            {
                unAfiliado = (Afiliado)grillaPacientes.CurrentRow.DataBoundItem;

                frmGrupo formGrupo = new frmGrupo();
                formGrupo.unAfiliado = unAfiliado;
                formGrupo.Show();
            }
            catch
            {
                MessageBox.Show("No se selecciono ningun afiliado", "Error!", MessageBoxButtons.OK);
            }

        }
    }
}
