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
    public partial class lstSeleccionFuncionalidad : Form
    {
        public lstSeleccionFuncionalidad()
        {
            InitializeComponent();
        }

        //lista de roles que voy a tener para mostrar
        private List<Funcionalidad> listaDeFuncionalidades = new List<Funcionalidad>();

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                //me traigo todas las funcionalidades que cumplen con el filtro
                listaDeFuncionalidades = Funcionalidades.ObtenerFuncionalidades(txtNombreFunc.Text);
                foreach (Funcionalidad unaFuncionalidad in listaDeFuncionalidades)
                {
                    grillaFuncionalidades.ValueMember = "Id";
                    grillaFuncionalidades.DisplayMember = "Nombre";
                }
            }
            catch { MessageBox.Show("", "Error!", MessageBoxButtons.OK); }
        }

        private void lstSeleccionFuncionalidad_Load(object sender, EventArgs e)
        {
            //ME CARGO TODAS LAS FUNCIONALIDADES PARA PODER AGREGARLAS A LO ROLES
            List<Funcionalidad> listaDeFuncionalidades = Funcionalidades.ObtenerFuncionalidades();
            foreach (Funcionalidad unaFuncionalidad in listaDeFuncionalidades)
            {
                grillaFuncionalidades.ValueMember = "Id";
                grillaFuncionalidades.DisplayMember = "Nombre";
            }
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            //TOMA DE LO QUE CHEKEO, ARMA UNA LISTA Y SE LO DEVUELVE AL FORM
        }
    }
}
