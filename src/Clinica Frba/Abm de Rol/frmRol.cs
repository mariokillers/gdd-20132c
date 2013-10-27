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
            foreach (Funcionalidad unaFuncionalidad in listaDeFuncionalidades)
            {
                cmbFuncionalidades.ValueMember = "Id";
                cmbFuncionalidades.DisplayMember = "Nombre";
            }
        }

        private void cmdLimpiar_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombre.Text != "" && cmbFuncionalidades.CheckedItems!= null) //VER SI CON NULL FUNCA
                {
                    //TOMO LAS FUNCIONALIDADES QUE SELECCIONO
                    List<Funcionalidad> listaDeFunc = new List<Funcionalidad>();
                    foreach (Funcionalidad unaFunc in cmbFuncionalidades.CheckedItems)
                    {
                        listaDeFunc.Add(unaFunc);
                    }
                    //DOY DE ALTA EL ROL
                    Roles.Agregar(txtNombre.Text, listaDeFunc);
                }
            }
            catch 
            {
                MessageBox.Show("Se ha producido un error,vuelva a intentarlo", "Error!", MessageBoxButtons.OK);
            }
        }
    }
}
