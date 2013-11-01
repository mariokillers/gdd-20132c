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
            List<Plan> listaDePlanes = Planes.ObtenerPlanes();
            cmbPlanes.DataSource = listaDePlanes;
            cmbPlanes.ValueMember = "Codigo";
            cmbPlanes.DisplayMember = "Descripcion";
            
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            try 
            {
                ActualizarGrilla();
            }
            catch { MessageBox.Show("'no actualiza grilla papa", "Error!", MessageBoxButtons.OK); }
        }

        private void cmdLimpiar_Click(object sender, EventArgs e)
        {
            txtApellido.Text = "";
            txtDni.Text = "";
            txtNombre.Text = "";
            txtNumAfiliado.Text = "";
        }

        public void ActualizarGrilla()
        {
            if (txtNombre.Text != "")
            {
                //me traigo los roles que cumplen con el filtro
                decimal unPlan = (decimal)cmbPlanes.SelectedValue;
                listaDeAfiliados = Afiliados.ObtenerAfiliados(txtNombre.Text, txtApellido.Text, txtDni.Text, txtNumAfiliado.Text, unPlan);
            }
            else
            {
                listaDeAfiliados = Afiliados.ObtenerTodos();
            }

            //meto el resultado en la grilla
            grillaPacientes.DataSource = listaDeAfiliados;
        }
    }
}
