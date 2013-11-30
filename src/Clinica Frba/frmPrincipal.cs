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
using Clinica_Frba.NewFolder3;
using Clinica_Frba.NewFolder13;
using Clinica_Frba.NewFolder4;
using Clinica_Frba.NewFolder7;
using Clinica_Frba.NewFolder9;
using Clinica_Frba.Cancelar_Atencion;
using Clinica_Frba.NewFolder6;
using Clinica_Frba.Registrar_Llegada;

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
        private Rol unRol { get; set; }
        private List<Rol> listaDeRoles = new List<Rol>();

        private void cmdAfiliadoAlta_Click(object sender, EventArgs e)
        {
            frmAfiliadoAlta formAf = new frmAfiliadoAlta();
            formAf.Show();
        }

        private void cmdRolBaja_Click(object sender, EventArgs e)
        {
            lstSeleccionRol formRol = new lstSeleccionRol();
            formRol.Show();
        }

        private void cmdRolAlta_Click(object sender, EventArgs e)
        {
            frmRol formRol = new frmRol();
            formRol.Show();
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
            cmdAfiliado.Visible = true;
        }

        private void cmdAfiliadoModificacion_Click(object sender, EventArgs e)
        {
            lstSeleccionAfiliado formAfil = new lstSeleccionAfiliado();
            formAfil.Operacion = "Modificacion";
            formAfil.Show();
        }

        private void cmdAfiliadoBaja_Click(object sender, EventArgs e)
        {
            lstSeleccionAfiliado formAfil = new lstSeleccionAfiliado();
            formAfil.Operacion = "Baja";
            formAfil.Show();
        }

        private void cmdRolModificacion_Click_1(object sender, EventArgs e)
        {
            lstSeleccionRol formRol = new lstSeleccionRol();
            formRol.Operacion = "Modificacion";
            formRol.Show();
        }

        private void cmdRolBaja_Click_1(object sender, EventArgs e)
        {
            lstSeleccionRol formRol = new lstSeleccionRol();
            formRol.Operacion = "Baja";
            formRol.Show();
        }

        public void ocultar()
        {
            cmbRoles.Dispose();
            cmdIngresar.Visible = false;
            label1.Visible = false;
        }

        private void cmdIngresar_Click(object sender, EventArgs e)
        {
            unRol = new Rol(((Rol)cmbRoles.SelectedItem).Id);
            List<String> listaDeFunc = Funcionalidades.ObtenerFuncionalidadesPorRol(unRol.Id);

            ocultar();
            menu.Visible = true;

            //VEO QUE MOSTRAR EN BASE A SUS FUNCIONALIDADES
            cmdLogOut.Visible = true;
            cmdAfiliado.Visible = listaDeFunc.Contains("ABM de afiliados");
            cmdRol.Visible = listaDeFunc.Contains("ABM de roles");
            cmdAgenda.Visible = listaDeFunc.Contains("Registrar agenda profesional");
            cmdProfesional.Visible = listaDeFunc.Contains("ABM de profesionales");
            cmdEstadisticas.Visible = listaDeFunc.Contains("Consultar listado estadistico");
            cmdTurnos.Visible = listaDeFunc.Contains("Pedido de turno");
            cmdCompraDeBonos.Visible = listaDeFunc.Contains("Compra de bonos");
            cmdRegistrarLlegada.Visible = listaDeFunc.Contains("Registro de llegada para atencion medica");
            cmdAtencion.Visible = listaDeFunc.Contains("Registro de resultado para atencion medica");
            cmdCancelar.Visible = listaDeFunc.Contains("Cancelar atencion medica");
            cmdCancelarDias.Visible = listaDeFunc.Contains("Cancelar dia");
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
            formAfiliado.Operacion = "Alta";
            formAfiliado.Show();
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

        private void cmdCompraDeBonos_Click(object sender, EventArgs e)
        {
            frmBono formBono = new frmBono();
            formBono.User = User;
            formBono.RolElegido = unRol;
            formBono.Show();
        }

        private void cmdProfAlta_Click(object sender, EventArgs e)
        {
            frmProfesional frmPro = new frmProfesional();
            frmPro.Operacion = "Alta";
            frmPro.Show();
        }

        private void cmdProfMod_Click(object sender, EventArgs e)
        {
            lstSeleccionProfesionales lstPro = new lstSeleccionProfesionales();
            lstPro.Operacion = "Modificacion";
            lstPro.Show();
        }

        private void cmdProfBaja_Click(object sender, EventArgs e)
        {
            lstSeleccionProfesionales lstPro = new lstSeleccionProfesionales();
            lstPro.Operacion = "Baja";
            lstPro.Show();
        }

        private void cmdAtencion_Click(object sender, EventArgs e)
        {
            lstSeleccionAfiliado formAfil = new lstSeleccionAfiliado();
            formAfil.Operacion = "Seleccion";
            formAfil.profesional = new Profesional(User.Codigo_Persona);
            formAfil.Show();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lstTurno frmTurno = new lstTurno();
            frmTurno.unUser = this.User;
            frmTurno.Show();
        }

        private void cancelarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCancelarAtencion cancel = new frmCancelarAtencion();
            cancel.unUsuario = this.User;
            cancel.Show();
        }

        private void cmdEstadisticas_Click(object sender, EventArgs e)
        {
            frmListadosEstadisticos formEstadisticas = new frmListadosEstadisticos();
            formEstadisticas.Show();
        }

        private void cancelarDiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCancelarDias frmCancel= new frmCancelarDias();
            frmCancel.unUsuario = this.User;
            frmCancel.Show();
        }

        private void cmdRegistrarLlegada_Click(object sender, EventArgs e)
        {
            frmRegistrarLlegada formLlegada = new frmRegistrarLlegada();
            formLlegada.Show();
        }
    }
}
