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
            txtNombre.Text = "";
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                //me traigo los roles que cumplen con el filtro
                listaDeRoles = Roles.ObtenerRoles(txtNombre.Text);
                //meto el resultado en la grilla
                grillaRoles.DataSource = listaDeRoles;
            }
            catch{ MessageBox.Show("", "Error!", MessageBoxButtons.OK);}
        }

        private void lstSeleccionRol_Load(object sender, EventArgs e)
        {
            //genero las columnas de la grilla
            grillaRoles.AutoGenerateColumns = false;
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

            DataGridViewButtonColumn ColBoton = new DataGridViewButtonColumn();
            ColBoton.Name = "Boton";
            ColBoton.HeaderText = "";
            ColBoton.Width = 80;
            ColBoton.UseColumnTextForButtonValue = true;

            grillaRoles.Columns.Add(ColBoton);

            if (Operacion == "Baja")
            {
                ColBoton.Text = "Eliminar";
            }
            else
            {
                //ColHabilitado.ReadOnly = true; // si eligio modificar, no puede inhabilitarlo
                ColBoton.Text = "Modificar";
            }

            /*SELECCIONAR UN ROL Y APRETAR UN BOTON DE MODIFICAR FUNC. Y ME APAREZCA UNA GRILLA
             * CON TODAS LAS FUNCIONALIDADES DE ESE ROL
             */
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            //selecciona un rol
            Rol unRol = new Rol();
            unRol = (Rol)grillaRoles.CurrentRow.DataBoundItem;
            if (!unRol.Habilitado)
            {
                //SI "INHABILITA" EL ROL, DARLO DE BAJA
                Roles.Eliminar(unRol.Id);
                cargarGrilla();
            } 
        }

        private void cmdVolver_Click(object sender, EventArgs e)
        {
            frmPrincipal principal = new frmPrincipal();
            this.Hide();
            principal.ShowDialog();
        }

        private void grillaRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //IGNORA LOS CLICKS DE OTROS BOTONES 
            if (e.RowIndex < 0 || e.ColumnIndex !=
                grillaRoles.Columns["Boton"].Index) return;

            Rol unRol = (Rol)grillaRoles.CurrentRow.DataBoundItem;
            if (Operacion == "Baja")
            {
                Roles.Eliminar(unRol.Id);
                cargarGrilla();
            }
            else
            {
                if (Operacion == "Modificacion")
                {

                }
                //ME TENGO QUE ABRIR UNA NUEVA VISTA CON LAS FUNC DE ESE ROL
            }
        }
    }
}
