using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Clases;

namespace Clinica_Frba.NewFolder1
{
    public partial class frmRol : Form
    {
        public frmRol()
        {
            InitializeComponent();
        }

        private void frmRol_Load(object sender, EventArgs e)
        {
            //ME CARGO TODAS LAS FUNCIONALIDADES PARA PODER AGREGARLAS A LO ROLES
            List<Funcionalidad> listaDeFuncionalidades = Funcionalidades.ObtenerFuncionalidades();
            cmbFuncionalidades.DataSource = listaDeFuncionalidades;
            cmbFuncionalidades.ValueMember = "Id";
            cmbFuncionalidades.DisplayMember = "Nombre";
        }

        private void cmdLimpiar_Click(object sender, EventArgs e)
        {
            deschequearElCheckBox();    //NO ME LO ESTA TOMANDO
            txtNombre.Text = "";
        }

        public void deschequearElCheckBox()
        {
            bool state = false;
            for (int i = 0; i < cmbFuncionalidades.Items.Count; i++)
                cmbFuncionalidades.SetItemCheckState(i, (state ? CheckState.Checked : CheckState.Unchecked));
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombre.Text != "" && cmbFuncionalidades.CheckedItems != null) //VER SI CON NULL FUNCA
                {
                    //TOMO LAS FUNCIONALIDADES QUE SELECCIONO
                    List<Funcionalidad> listaDeFunc = new List<Funcionalidad>();
                    foreach (Funcionalidad unaFunc in cmbFuncionalidades.CheckedItems)
                    {
                        listaDeFunc.Add(unaFunc);
                    }
                    //DOY DE ALTA EL ROL
                    Roles.Agregar(txtNombre.Text, listaDeFunc);
                    MessageBox.Show("El rol fue agregado con éxito", "Enhorabuena!", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Inserte correctamente los campos", "Error!", MessageBoxButtons.OK);
                }
            }
            catch 
            {
                MessageBox.Show("Se ha producido un error,vuelva a intentarlo", "Error!", MessageBoxButtons.OK);
            }
        }

        private void cmdSeleccionarTodo_Click(object sender, EventArgs e)
        {
            bool state = true;
            for (int i = 0; i < cmbFuncionalidades.Items.Count; i++)
                cmbFuncionalidades.SetItemCheckState(i, (state ? CheckState.Checked : CheckState.Unchecked));
        }
    }
}
