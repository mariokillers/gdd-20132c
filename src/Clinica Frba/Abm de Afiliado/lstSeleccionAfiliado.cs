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
                string test = "1";
                MessageBox.Show("" + Convert.ToInt32(test), "test", MessageBoxButtons.OK);
                ActualizarGrilla();
            }
            catch { MessageBox.Show("no actualiza grilla papa", "Error!", MessageBoxButtons.OK); }
        }

        private void cmdLimpiar_Click(object sender, EventArgs e)
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
                //me traigo los roles que cumplen con el filtro
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

         }
    }
}
