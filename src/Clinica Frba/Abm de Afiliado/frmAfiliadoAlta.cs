using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Clases;
using System.Data.SqlClient;
using Clinica_Frba.Abm_de_Afiliado;

namespace Clinica_Frba.NewFolder12
{
    public partial class frmAfiliadoAlta : Form
    {
        public frmAfiliadoAlta()
        {
            InitializeComponent();
        }

        public String Operacion { get; set; }
        public Afiliado Afiliado { get; set; }
        public String Miembro { get; set; }
        public Afiliado nuevoAfil { get; set; }

        private void rdSi_CheckedChanged(object sender, EventArgs e)
        {
            //Si apreta, pertenece al mismo grupo: tenerlo en cuenta para el ABM
            frmAfiliadoAlta a = new frmAfiliadoAlta();
            //this.Hide();
            a.ShowDialog();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                almacenarDatos();

                MessageBox.Show("El Afiliado ha sido modificado exitosamente", "Aviso", MessageBoxButtons.OK);
                   
                this.Hide();
            }
            catch { MessageBox.Show("Hay campos sin completar o incorrectos. Por favor verifique sus datos.", "Error", MessageBoxButtons.OK); }
        }

        private void cmdLimpiar_Click(object sender, EventArgs e)
        {
            txtApellido.Text = "";
            txtDir.Text = "";
            txtDni.Text = "";
            txtMail.Text = "";
            txtNombre.Text = "";
            txtTel.Text = "";
            cmbEstadoCivil.Text = "";
            cmbSexo.Text = "";
            cmbTipoDoc.Text = "";
        }

        private void cmbVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmAfiliadoAlta_Load(object sender, EventArgs e)
        {
            List<Plan> listaDePlanes = Planes.ObtenerPlanes();
            cmbPlanes.DataSource = listaDePlanes;
            cmbPlanes.ValueMember = "Codigo";
            cmbPlanes.DisplayMember = "Descripcion";

            List<TipoDoc> listaDeTipos = TiposDoc.ObtenerTiposDoc();
            cmbTipoDoc.DataSource = listaDeTipos;
            cmbTipoDoc.ValueMember = "Id";
            cmbTipoDoc.DisplayMember = "Descripcion";

            List<Estado> listaDeEstados = Estados.ObtenerEstados();
            cmbEstadoCivil.DataSource = listaDeEstados;
            cmbEstadoCivil.ValueMember = "Id";
            cmbEstadoCivil.DisplayMember = "Estado_Civil";

            List<Sexo> listaDeSexos = Sexo.ObtenerSexos();
            cmbSexo.DataSource = listaDeSexos;
            cmbSexo.ValueMember = "Id";
            cmbSexo.DisplayMember = "Id";

            // Set the Format type and the CustomFormat string.
            /*dtpFechaNacimiento.Format = DateTimePickerFormat.Custom;
            dtpFechaNacimiento.CustomFormat = "MMMM dd, yyyy";*/
     
            cargarCampos();
        }

        private void cargarCampos()
        {
            nuevoAfil = new Afiliado();
            if (Operacion == "Modificacion")
            {
                txtNombre.Text = Afiliado.Nombre;
                txtNombre.Enabled = false;
                txtApellido.Text = Afiliado.Apellido;
                txtApellido.Enabled = false;
                txtDni.Text = Afiliado.NumeroDocumento.ToString();
                txtDni.Enabled = false;

                label25.Hide();
                btnConyuge.Hide();
                btnHijo.Hide();
                label14.Hide();
                label24.Hide();
                label3.Hide();
                label17.Hide();
                label20.Hide();
                label11.Hide();
                label15.Hide();
                label16.Hide();
                label19.Hide();
                label18.Hide();
                label22.Hide();
                label13.Hide();

                cmdLimpiar.Hide();

                cmbTipoDoc.Enabled = false;
                //dtpFechaNacimiento.Value.Date =     VER TEMA DE TIPOS, SINO YA FUE
                dtpFechaNacimiento.Enabled = false;

                cmbTipoDoc.Text = "" + Utiles.ObtenerTipoDoc(Afiliado.TipoDocumento);

                txtDir.Text = Afiliado.Direccion;
                txtMail.Text = Afiliado.Mail;
                txtHijos.Text = Afiliado.Cantidad_Hijos.ToString();
                txtTel.Text = Afiliado.Telefono.ToString();
                cmbSexo.Text = Afiliado.Sexo;
                cmbPlanes.Text = "" + Utiles.ObtenerPlan(Afiliado.Plan_Medico);
                cmbEstadoCivil.Text = "" + Utiles.ObtenerEstado(Afiliado.Estado_Civil);

                if (Afiliado.Numero_Familiar != 1)
                {
                    cmbPlanes.Enabled = false;
                }
            }
            if (Miembro == "Hijo")
            {
                btnConyuge.Hide();
                btnHijo.Text = "Hermano";
                txtDir.Text = Afiliado.Direccion;
                txtTel.Text = (String)Afiliado.Telefono.ToString();
                cmbPlanes.Text = "" + Utiles.ObtenerPlan(Afiliado.Plan_Medico);
                cmbPlanes.Enabled = false;
                label12.Visible = true;
                lblGrupo.Visible = true;
                lblGrupo.Text = Afiliado.Numero_Grupo.ToString();
                nuevoAfil.Numero_Grupo = Afiliado.Numero_Grupo;
                nuevoAfil.Numero_Familiar = 0;
            }
            else if (Miembro == "Conyuge")
            {
                btnConyuge.Hide();
                txtDir.Text = Afiliado.Direccion;
                txtTel.Text = (String)Afiliado.Telefono.ToString();
                cmbPlanes.Text = "" + Utiles.ObtenerPlan(Afiliado.Plan_Medico);
                cmbPlanes.Enabled = false;
                label12.Visible = true;
                lblGrupo.Visible = true;
                lblGrupo.Text = Afiliado.Numero_Grupo.ToString();
                nuevoAfil.Numero_Grupo = Afiliado.Numero_Grupo;
                nuevoAfil.Numero_Familiar = 02;
            }
            else
            {
                nuevoAfil.Numero_Grupo = 0;
                nuevoAfil.Numero_Familiar = 01;
            }
        }

        public void almacenarDatos()
        {
            nuevoAfil.Estado_Civil = (decimal)cmbEstadoCivil.SelectedValue;
            nuevoAfil.Direccion = (String)txtDir.Text;
            nuevoAfil.Cantidad_Hijos = (decimal)decimal.Parse(txtHijos.Text);
            nuevoAfil.Mail = (String)txtMail.Text;
            nuevoAfil.Plan_Medico = (decimal)cmbPlanes.SelectedValue;
            nuevoAfil.Sexo = (String)cmbSexo.SelectedValue;
            nuevoAfil.Telefono = (decimal)decimal.Parse(txtTel.Text);

            if (Operacion == "Modificacion")
            {
                nuevoAfil.Id = Afiliado.Id;
                nuevoAfil.Numero_Grupo = Afiliado.Numero_Grupo;
                Afiliados.Modificar(nuevoAfil);
            }
            else if (Operacion == "Alta")
            {
                nuevoAfil.Nombre = (String)txtNombre.Text;
                nuevoAfil.Apellido = (String)txtApellido.Text;
                nuevoAfil.TipoDocumento = (decimal)cmbTipoDoc.SelectedValue;
                nuevoAfil.NumeroDocumento = (decimal)decimal.Parse(txtDni.Text);
                nuevoAfil.FechaNacimiento = (DateTime)dtpFechaNacimiento.Value;
                decimal GrupoNuevo = Afiliados.AgregarAfiliado(nuevoAfil);
                nuevoAfil.Numero_Grupo = GrupoNuevo;
            }
        }

        private void btnHijo_Click(object sender, EventArgs e)
        {
            try
            {
                Operacion = "Alta";
                almacenarDatos();
                frmAfiliadoAlta formHijo = new frmAfiliadoAlta();
                formHijo.Operacion = this.Operacion;
                formHijo.Afiliado = this.nuevoAfil;
                formHijo.Afiliado.Numero_Grupo = nuevoAfil.Numero_Grupo;
                formHijo.Miembro = "Hijo";
                formHijo.Show();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Hay campos sin completar o incorrectos. Por favor verifique sus datos.", "Error", MessageBoxButtons.OK);
            }
        }

        private void btnConyuge_Click(object sender, EventArgs e)
        {
            try
            {
                Operacion = "Alta";
                almacenarDatos();
                frmAfiliadoAlta formConyuge = new frmAfiliadoAlta();
                formConyuge.Operacion = this.Operacion;
                formConyuge.Afiliado = this.nuevoAfil;
                formConyuge.Afiliado.Numero_Grupo = nuevoAfil.Numero_Grupo;
                formConyuge.Miembro = "Conyuge";
                formConyuge.Show();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Hay campos sin completar o incorrectos. Por favor verifique sus datos.", "Error", MessageBoxButtons.OK);
            }

        }
    }
}
