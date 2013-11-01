using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Clases;

namespace Clinica_Frba.Abm_de_Rol
{
    public partial class lstSeleccionRol : Form
    {
        public lstSeleccionRol()
        {
            InitializeComponent();
        }

        //lista de roles que voy a tener para mostrar
        private List<Rol> listaDeRoles = new List<Rol>();
        //PARA SABER SI ES MODIFICACION O BAJA
        public string Operacion { get; set; }

        private void cmdLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        public void Limpiar()
        {
            txtNombre.Text = "";
            ActualizarGrilla();
        }
        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ActualizarGrilla();
            }
            catch{ MessageBox.Show("", "Error!", MessageBoxButtons.OK);}
        }

        private void lstSeleccionRol_Load(object sender, EventArgs e)
        {
            //genero las columnas de la grilla
            grillaRoles.AutoGenerateColumns = false;

            cargarGrilla();
            ActualizarGrilla();
        }

        public void ActualizarGrilla()
        {
            if (txtNombre.Text != "")
            {
                //me traigo los roles que cumplen con el filtro
                listaDeRoles = Roles.ObtenerRoles(txtNombre.Text);
            }
            else
            {
                listaDeRoles = Roles.ObtenerTodos();
            }
            
            //meto el resultado en la grilla
            grillaRoles.DataSource = listaDeRoles;
        }
        
        private void cargarGrilla()
        {
            DataGridViewTextBoxColumn ColNombre = new DataGridViewTextBoxColumn();
            ColNombre.DataPropertyName = "Nombre";
            ColNombre.HeaderText = "Nombre Rol";
            ColNombre.Width = 120;

            grillaRoles.Columns.Add(ColNombre);

            /*DataGridViewCheckBoxColumn ColHabilitado = new DataGridViewCheckBoxColumn();
            ColHabilitado.DataPropertyName = "Habilitado";
            ColHabilitado.HeaderText = "Habilitado";
            ColHabilitado.Width = 50;

            grillaRoles.Columns.Add(ColHabilitado);*/

            if (Operacion == "Baja")
            {
                cmdOperacion.Text = "Eliminar";
            }
            else
            {
                cmdOperacion.Text = "Modificar";
            }

            /*SELECCIONAR UN ROL Y APRETAR UN BOTON DE MODIFICAR FUNC. Y ME APAREZCA UNA GRILLA
             * CON TODAS LAS FUNCIONALIDADES DE ESE ROL
             */
        }

        private void cmdOperacion_Click(object sender, EventArgs e)
        {
            Rol unRol = (Rol)grillaRoles.CurrentRow.DataBoundItem;
            if (Operacion == "Baja")
            {
                Roles.Eliminar(unRol.Id);
                cargarGrilla();
                Limpiar();

            }
            else
            {
                if (Operacion == "Modificacion")
                {
                    lstSeleccionFuncionalidad formFunc = new lstSeleccionFuncionalidad();
                    formFunc.unRol = unRol;
                    formFunc.Show();
                }
                //ME TENGO QUE ABRIR UNA NUEVA VISTA CON LAS FUNC DE ESE ROL
            }
        }
    }
}
