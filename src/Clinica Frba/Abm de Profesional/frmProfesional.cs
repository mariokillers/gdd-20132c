﻿using System;
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

            List<Estado> listaDeEstados = Estados.ObtenerEstados();
            cmbEstadoCivil.DataSource = listaDeEstados;
            cmbEstadoCivil.ValueMember = "Id";
            cmbEstadoCivil.DisplayMember = "Estado_Civil";

            List<Sexo> listaDeSexos = Sexo.ObtenerSexos();
            cmbSexo.DataSource = listaDeSexos;
            cmbSexo.ValueMember = "Id";
            cmbSexo.DisplayMember = "Id";
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
            txtMatricula.Text = "";
            deschequearElCheckBox();
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

                unProfesional.Nombre = txtNombre.Text;
                unProfesional.Apellido = txtApellido.Text;
                unProfesional.TipoDocumento = (decimal)cmbTipoDoc.SelectedValue;
                unProfesional.NumeroDocumento = (decimal)decimal.Parse(txtDni.Text);
                unProfesional.Direccion = txtDir.Text;
                unProfesional.FechaNacimiento = (DateTime)dtpFechaNacimiento.Value;
                unProfesional.Telefono = (decimal)decimal.Parse(txtTel.Text);
                unProfesional.Mail = txtMail.Text;
                unProfesional.Sexo = (String)cmbSexo.SelectedValue;
                unProfesional.Matricula = (int)int.Parse(txtMatricula.Text);

                unProfesional.Especialidades = new List<Especialidad>();

                foreach (Especialidad unaEsp in grillaEspecialidades.CheckedItems)
                {
                    unProfesional.Especialidades.Add(unaEsp);
                }

                Profesionales.AgregarProfesional(unProfesional);

                MessageBox.Show("El Profesional ha sido modificado exitosamente", "Aviso", MessageBoxButtons.OK);

                this.Close();
            }
            catch
            {
                MessageBox.Show("Hay campos sin completar o incorrectos. Por favor verifique sus datos.", "Error", MessageBoxButtons.OK);
            }
        }
    }
}
