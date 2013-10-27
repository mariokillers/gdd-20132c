using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.NewFolder12;
using Clinica_Frba.Abm_de_Rol;
using Clinica_Frba.Clases;

namespace Clinica_Frba
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        //para el tema de las funcionalidades
        public string UserName { get; set; }
        private List<Funcionalidad> listaDeFuncionalidades = new List<Funcionalidad>();

        //SOLO FALTA COMPLETAR LO DE ABAJO
        private void cmdAfiliadoAlta_Click(object sender, EventArgs e)
        {
            frmAfiliadoAlta formAf = new frmAfiliadoAlta();
            formAf.Show();
            this.Hide();
        }
        private void cmdRolModificacion_Click(object sender, EventArgs e)
        {
           /* lstSeleccionRol formRol = new lstSeleccionRol(Utiles.Operacion.Modificacion);
            formRol.Show();
            this.Hide();*/
        }

        private void cmdRolBaja_Click(object sender, EventArgs e)
        {
            lstSeleccionRol formRol = new lstSeleccionRol("Baja");
            formRol.Show();
            this.Hide();
        }

        private void cmdRolAlta_Click(object sender, EventArgs e)
        {
            frmAfiliadoAlta formAfil = new frmAfiliadoAlta();
            formAfil.Show();
            this.Hide();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            Usuario user = new Usuario(UserName);
            listaDeFuncionalidades = user.ObtenerFuncionalidadesPorUsuario();

            // VER ESTE TEMA
           /* cmdAfiliado.Visible = listaDeFuncionalidades.Contains("ABM afiliado");
            cmdProfesional.Visible =
            cmdRol.Visible=*/
        }

    }
}
