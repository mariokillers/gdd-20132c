using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Clases;

namespace Clinica_Frba.NewFolder12
{
    public partial class frmAfiliadoAlta : Form
    {
        public frmAfiliadoAlta()
        {
            InitializeComponent();
        }

        public string Operacion { get; set; }
        public Afiliado Afiliado { get; set; }

        private void rdSi_CheckedChanged(object sender, EventArgs e)
        {
            //Si apreta, pertenece al mismo grupo: tenerlo en cuenta para el ABM
            frmAfiliadoAlta a = new frmAfiliadoAlta();
            //this.Hide();
            a.ShowDialog();
            rdSi.Enabled = false;
            rdNo.Enabled = false;
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Operacion == "Modificacion")
                {
                    Afiliado nuevoAfil = new Afiliado();
                    nuevoAfil.Estado_Civil = (decimal)cmbEstadoCivil.SelectedValue;
                    nuevoAfil.Direccion = (String)txtDir.Text;
                    nuevoAfil.Cantidad_Hijos = (decimal)decimal.Parse(txtHijos.Text);
                    nuevoAfil.Mail = (String)txtMail.Text;
                    nuevoAfil.Plan_Medico = (decimal)cmbPlanes.SelectedValue;
                    nuevoAfil.Sexo = (String)cmbSexo.SelectedValue;
                    nuevoAfil.Telefono = (decimal)decimal.Parse(txtTel.Text);


                }
                this.Hide();
            }
            catch { MessageBox.Show("Campos no válidos", "Error!", MessageBoxButtons.OK); }
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
            rdNo.Enabled = true;
            rdSi.Enabled = true;
            rdNo.Checked = false;
            rdSi.Checked = false;
        }

        private void cmbVolver_Click(object sender, EventArgs e)
        {
            frmPrincipal principal = new frmPrincipal();
            this.Hide();
            principal.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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

            cmbSexo.Items.Add("M");
            cmbSexo.Items.Add("F");

            // Set the Format type and the CustomFormat string.
            /*dtpFechaNacimiento.Format = DateTimePickerFormat.Custom;
            dtpFechaNacimiento.CustomFormat = "MMMM dd, yyyy";*/
     
            cargarCampos();
        }

        private void cargarCampos()
        {
            if (Operacion == "Modificacion")
            {
                txtNombre.Text = Afiliado.Nombre;
                txtNombre.Enabled = false;
                txtApellido.Text = Afiliado.Apellido;
                txtApellido.Enabled = false;
                txtDni.Text = Afiliado.NumeroDocumento.ToString();
                txtDni.Enabled = false;

                label25.Hide();
                rdNo.Hide();
                rdSi.Hide();
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

                cmbTipoDoc.Enabled = false;
                //dtpFechaNacimiento.Value.Date =     VER TEMA DE TIPOS, SINO YA FUE
                dtpFechaNacimiento.Enabled = false;

                //cmbSexo.Text = ""+Afiliado.Sexo;
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
        }
    }
}
