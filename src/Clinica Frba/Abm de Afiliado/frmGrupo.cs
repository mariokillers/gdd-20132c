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


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Afiliado nuevoAfil = new Afiliado();
            nuevoAfil.Id = unAfiliado.Id;
            nuevoAfil.Plan_Medico = (decimal)cmbPlanes.SelectedValue;

            decimal nuevoNum = Afiliados.AgregarGrupo(nuevoAfil);

            MessageBox.Show("Su nuevo numero de afiliado es: " + nuevoNum, "Aviso", MessageBoxButtons.OK);

            this.Hide();
        }

        private void cmbVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
