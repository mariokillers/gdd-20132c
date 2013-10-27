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
using Clinica_Frba.Abm_de_Afiliado;
using Clinica_Frba.NewFolder1;

namespace Clinica_Frba
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        //para el tema de las funcionalidades
        public Usuario User { get; set; }
        private List<Rol> listaDeRoles = new List<Rol>();

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
            lstSeleccionRol formRol = new lstSeleccionRol();
            formRol.Show();
            this.Hide();
        }

        private void cmdRolAlta_Click(object sender, EventArgs e)
        {
            frmRol formRol = new frmRol();
            formRol.Show();
            this.Hide();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            listaDeRoles = Usuarios.ObtenerRoles(User);
            if (listaDeRoles.Count > 1)
            {
                //DAR LA OPCION DE LOGEARSE CON EL ROL QUE QUIERE
                label1.Visible = true;
                menu.Visible = false;
                cmbRoles.Visible = true;

                cmbRoles.DataSource = listaDeRoles;
                cmbRoles.DisplayMember = "Nombre";
                cmbRoles.ValueMember = "Id";    
            }
            // OBTENER FUNCIONALIDADES POR ESTE ROL Y VER ESTE TEMA
           /* cmdAfiliado.Visible = listaDeFuncionalidades.Contains("ABM afiliado");
            cmdProfesional.Visible =
            cmdRol.Visible=*/
        }

        private void cmdAfiliadoModificacion_Click(object sender, EventArgs e)
        {
            lstSeleccionAfiliado formAfil = new lstSeleccionAfiliado();
            formAfil.Operacion = "Modificacion";
            formAfil.Show();
            this.Hide();
        }

        private void cmdAfiliadoBaja_Click(object sender, EventArgs e)
        {
            lstSeleccionAfiliado formAfil = new lstSeleccionAfiliado();
            formAfil.Operacion = "Baja";
            formAfil.Show();
            this.Hide();
        }

        private void cmdRolModificacion_Click_1(object sender, EventArgs e)
        {
            lstSeleccionRol formRol = new lstSeleccionRol();
            formRol.Operacion = "Modificacion";
            formRol.Show();
            this.Hide();
        }

        private void cmdRolBaja_Click_1(object sender, EventArgs e)
        {
            lstSeleccionRol formRol = new lstSeleccionRol();
            formRol.Operacion = "Baja";
            formRol.Show();
            this.Hide();
        }

        private void cmdIngresar_Click(object sender, EventArgs e)
        {
            Rol unRol = new Rol(((Rol)cmbRoles.SelectedItem).Id);
            List<String> listaDeFunc = Funcionalidades.ObtenerFuncionalidadesPorRol(unRol.Id);

            menu.Visible = true;

            //VEO QUE MOSTRAR EN BASE A SUS FUNCIONALIDADES
            cmdAfiliado.Visible = listaDeFunc.Contains("Administrar afiliados");
            cmbRoles.Visible = listaDeFunc.Contains("Administrar roles");
            cmdAgenda.Visible = listaDeFunc.Contains("Registrar agenda");
            cmdProfesional.Visible = listaDeFunc.Contains("Adminisrar profesionales");
            cmdEstadisticas.Visible = listaDeFunc.Contains("Consultar listado estadístico");

            /*
	       ('Ver afiliados'),
	       ('Ver profesionales'),
	       ('Registrar llegada'),
	       ('Registrar diagnóstico'),
	       ('Cancelar atención médica'),
	       ('Crear receta médica'),
	       ('Comprar bonos'),
	       ('Ver turnos'),
	       ('Pedir turno')*/
        }
    }
}
