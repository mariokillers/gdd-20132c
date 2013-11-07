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
using Clinica_Frba.NewFolder10;
using Clinica_Frba.Registrar_Agenda;
using Clinica_Frba.Abm_de_Profesional;

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
            //this.Hide();
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
            //this.Hide();
        }

        private void cmdRolAlta_Click(object sender, EventArgs e)
        {
            frmRol formRol = new frmRol();
            formRol.Show();
            //this.Hide();
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
                cmdIngresar.Visible = true;

                cmbRoles.DataSource = listaDeRoles;
                cmbRoles.DisplayMember = "Nombre";
                cmbRoles.ValueMember = "Id";    
            }

            // OBTENER FUNCIONALIDADES POR ESTE ROL Y VER ESTE TEMA
            cmdAfiliado.Visible = true; // listaDeFuncionalidades.Contains("ABM afiliado");
            /*cmdProfesional.Visible =
            cmdRol.Visible=*/
        }

        private void cmdAfiliadoModificacion_Click(object sender, EventArgs e)
        {
            lstSeleccionAfiliado formAfil = new lstSeleccionAfiliado();
            formAfil.Operacion = "Modificacion";
            formAfil.Show();
            //this.Hide();
        }

        private void cmdAfiliadoBaja_Click(object sender, EventArgs e)
        {
            lstSeleccionAfiliado formAfil = new lstSeleccionAfiliado();
            formAfil.Operacion = "Baja";
            formAfil.Show();
            //this.Hide();
        }

        private void cmdRolModificacion_Click_1(object sender, EventArgs e)
        {
            lstSeleccionRol formRol = new lstSeleccionRol();
            formRol.Operacion = "Modificacion";
            formRol.Show();
            //this.Hide();
        }

        private void cmdRolBaja_Click_1(object sender, EventArgs e)
        {
            lstSeleccionRol formRol = new lstSeleccionRol();
            formRol.Operacion = "Baja";
            formRol.Show();
            //this.Hide();
        }

        public void ocultar()
        {
            cmbRoles.Dispose();
            cmdIngresar.Visible = false;
            label1.Visible = false;
        }

        private void cmdIngresar_Click(object sender, EventArgs e)
        {
            Rol unRol = new Rol(((Rol)cmbRoles.SelectedItem).Id);
            List<String> listaDeFunc = Funcionalidades.ObtenerFuncionalidadesPorRol(unRol.Id);

            ocultar();
            menu.Visible = true;
            

            //VEO QUE MOSTRAR EN BASE A SUS FUNCIONALIDADES
            cmdLogOut.Visible = true;
            cmdAfiliado.Visible = listaDeFunc.Contains("ABM de afiliados");
            cmbRoles.Visible = listaDeFunc.Contains("ABM de roles");
            cmdAgenda.Visible = listaDeFunc.Contains("Registrar agenda profesional");
            cmdProfesional.Visible = listaDeFunc.Contains("ABM de profesionales");
            cmdEstadisticas.Visible = listaDeFunc.Contains("Consultar listado estadístico");
            cmdTurnos.Visible = listaDeFunc.Contains("Pedido de turno");

            /*
	       ('Registro de resultado para atención médica'),
	       ('Registro de llegada para atención médica'),
	       ('Registrar diagnóstico'),
	       ('Cancelar atención médica'),
	       ('Confeccionar receta médica'),
	       ('Compra de bonos'),
             * */
        }

        private void cmdLogOut_Click(object sender, EventArgs e)
        {
            frmLogin formLogin = new frmLogin();
            this.Close();
            formLogin.Show();
        }

        private void cmdAfiliadoAlta_Click_1(object sender, EventArgs e)
        {
            frmAfiliadoAlta formAfiliado = new frmAfiliadoAlta();
            formAfiliado.Show();
            //this.Hide();
        }

        private void registrarAgendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegistrarAgenda formAgenda = new frmRegistrarAgenda();
            formAgenda.unProfesional = new Profesional(User.Codigo_Persona);
            formAgenda.Show();
        }

        private void consultarAgendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lstSeleccionAgenda formAgenda = new lstSeleccionAgenda();
            formAgenda.unProfesional = new Profesional(User.Codigo_Persona);
            formAgenda.Show();
        }
    }
}
