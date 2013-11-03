using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Clases;

namespace Clinica_Frba.Abm_de_Afiliado
{
    public partial class frmGrupo : Form
    {
        public frmGrupo()
        {
            InitializeComponent();
        }

        public Afiliado unAfiliado = new Afiliado();

        private void frmGrupo_Load(object sender, EventArgs e)
        {
            txtNombre.Text = unAfiliado.Nombre;
            txtApellido.Text = unAfiliado.Apellido;

            List<Plan> listaDePlanes = Planes.ObtenerPlanes();
            cmbPlanes.DataSource = listaDePlanes;
            cmbPlanes.ValueMember = "Codigo";
            cmbPlanes.DisplayMember = "Descripcion";
        }
    }
}
