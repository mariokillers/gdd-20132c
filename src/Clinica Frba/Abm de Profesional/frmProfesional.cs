using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Clases;
using Clinica_Frba.Abm_de_Profesional;

namespace Clinica_Frba.NewFolder13
{
    public partial class frmProfesional : Form
    {
        public frmProfesional()
        {
            InitializeComponent();
        }

        public List<Especialidad> listaDeEspecialidades = new List<Especialidad>();
        public Profesional unProfesional = new Profesional();
        public String Operacion { get; set; }
        public List<Especialidad> listaVieja = new List<Especialidad>();

        private void frmProfesional_Load(object sender, EventArgs e)
        {
            listaDeEspecialidades = Especialidades.ObtenerEspecialidades();
            grillaEspecialidades.DataSource = listaDeEspecialidades;
            grillaEspecialidades.ValueMember = "Codigo";
            grillaEspecialidades.DisplayMember = "Descripcion";

            List<TipoDoc> listaDeTipos = TiposDoc.ObtenerTiposDoc();
            cmbTipoDoc.DataSource = listaDeTipos;
            cmbTipoDoc.ValueMember = "Id";
            cmbTipoDoc.DisplayMember = "Descripcion";

            List<Sexo> listaDeSexos = Sexo.ObtenerSexos();
            cmbSexo.DataSource = listaDeSexos;
            cmbSexo.ValueMember = "Id";
            cmbSexo.DisplayMember = "Id";

            if (Operacion == "Modificacion")
            {
                label14.Hide();
                label24.Hide();
                label3.Hide();
                label17.Hide();
                label20.Hide();
                label11.Hide();
                label15.Hide();
                label16.Hide();
                label19.Hide();
                label22.Hide();
                label13.Hide();
                label12.Hide();

                txtNombre.Text = unProfesional.Nombre;
                txtNombre.Enabled = false;
                txtApellido.Text = unProfesional.Apellido;
                txtApellido.Enabled = false;
                txtDni.Text = unProfesional.NumeroDocumento.ToString();
                txtDni.Enabled = false;
                txtMatricula.Text = unProfesional.Matricula.ToString();
                txtMatricula.Enabled = false;

                cmbTipoDoc.Enabled = false;
                //dtpFechaNacimiento.Value.Date =     VER TEMA DE TIPOS, SINO YA FUE
                dtpFechaNacimiento.Enabled = false;

                cmbTipoDoc.Text = "" + Utiles.ObtenerTipoDoc(unProfesional.TipoDocumento);
                txtDir.Text = unProfesional.Direccion;
                txtMail.Text = unProfesional.Mail;
                txtTel.Text = unProfesional.Telefono.ToString();
                cmbSexo.Text = unProfesional.Sexo;

                List<Especialidad> listaTiene = unProfesional.Especialidades;

                foreach (Especialidad unaEsp in listaDeEspecialidades)
                {
                    var probar = listaTiene.SingleOrDefault(esp => esp.Codigo == unaEsp.Codigo);
                    if (probar != null)
                    {
                        grillaEspecialidades.SetItemChecked(listaDeEspecialidades.IndexOf(unaEsp), true);
                    }
                }

            }
        }

        private void cmdLimpiar_Click(object sender, EventArgs e)
        {
            deschequearElCheckBox();
            if (Operacion == "Alta")
            {
                txtApellido.Text = "";
                txtDir.Text = "";
                txtDni.Text = "";
                txtMail.Text = "";
                txtNombre.Text = "";
                txtTel.Text = "";
                cmbSexo.Text = "";
                cmbTipoDoc.Text = "";
                txtMatricula.Text = "";
            }
 
            
        }

        public void deschequearElCheckBox()
        {
            bool state = false;
            for (int i = 0; i < grillaEspecialidades.Items.Count; i++)
                grillaEspecialidades.SetItemCheckState(i, (state ? CheckState.Checked : CheckState.Unchecked));
        }

        private void cmbVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSeleccionarTodo_Click(object sender, EventArgs e)
        {
            bool state = true;
            for (int i = 0; i < grillaEspecialidades.Items.Count; i++)
                grillaEspecialidades.SetItemCheckState(i, (state ? CheckState.Checked : CheckState.Unchecked));
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            try
            {

                unProfesional.Direccion = txtDir.Text;
                
                unProfesional.Telefono = (decimal)decimal.Parse(txtTel.Text);
                unProfesional.Mail = txtMail.Text;
                unProfesional.Sexo = (String)cmbSexo.SelectedValue;
                unProfesional.Matricula = (int)int.Parse(txtMatricula.Text);
                unProfesional.Especialidades = new List<Especialidad>();

                listaVieja = Especialidades.ObtenerEspecialidadesProfesional(unProfesional.Id);

                foreach (Especialidad unaEsp in grillaEspecialidades.CheckedItems)
                {
                    unProfesional.Especialidades.Add(unaEsp);
                }

                if (Operacion == "Alta")
                {
                    unProfesional.Nombre = txtNombre.Text;
                    unProfesional.Apellido = txtApellido.Text;
                    unProfesional.TipoDocumento = (decimal)cmbTipoDoc.SelectedValue;
                    unProfesional.NumeroDocumento = (decimal)decimal.Parse(txtDni.Text);
                    unProfesional.FechaNacimiento = (DateTime)dtpFechaNacimiento.Value;
                    if (Profesionales.AgregarProfesional(unProfesional) == 0)
                    {
                        MessageBox.Show("Hay campos incorrectos o el profesional ya esta registrado. Por favor verifique sus datos.", "Error", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("El Profesional ha sido modificado exitosamente", "Aviso", MessageBoxButtons.OK);
                        this.Close();
                    }
                }
                else if (Operacion == "Modificacion")
                {
                    Profesionales.EliminarEspecialidades(unProfesional, listaVieja);
                    Profesionales.ModificarProfesional(unProfesional);
                    MessageBox.Show("El Profesional ha sido modificado exitosamente", "Aviso", MessageBoxButtons.OK);
                    this.Close();
                }  
            }
            catch
            {
                MessageBox.Show("Hay campos sin completar o incorrectos. Por favor verifique sus datos.", "Error", MessageBoxButtons.OK);
            }
        }

        private Boolean analizarCampos()
        {
            if (txtApellido.Text == "" || txtDir.Text == "" || txtDni.Text == "" || txtMail.Text == "" || txtNombre.Text == "" || txtTel.Text == "" || txtMatricula.Text == "" || grillaEspecialidades.CheckedItems.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
