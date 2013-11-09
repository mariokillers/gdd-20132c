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
    public partial class lstSeleccionGrupo : Form
    {
        public lstSeleccionGrupo()
        {
            InitializeComponent();
        }

        public List<Grupo> listaDeGrupos = new List<Grupo>();
        public Grupo unGrupo = new Grupo();
        public Afiliado unAfiliado = new Afiliado();

        private void lstSeleccionGrupo_Load(object sender, EventArgs e)
        {
            grillaGrupos.AutoGenerateColumns = false;
            cargarGrilla();
        }

        private void cmdLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        public void Limpiar()
        {
            txtNumGrupo.Text = "";
            ActualizarGrilla();
        }

        public void ActualizarGrilla()
        {
            listaDeGrupos = Grupos.ObtenerGrupos(txtNumGrupo.Text);
            
            //meto el resultado en la grilla
            grillaGrupos.DataSource = listaDeGrupos;
        }

        public void cargarGrilla()
        {
            DataGridViewTextBoxColumn ColNum = new DataGridViewTextBoxColumn();
            ColNum.DataPropertyName = "nroGrupo";
            ColNum.HeaderText = "Numero Grupo";
            ColNum.Width = 120;
            grillaGrupos.Columns.Add(ColNum);

            DataGridViewTextBoxColumn ColPlan = new DataGridViewTextBoxColumn();
            ColPlan.DataPropertyName = "planMedico";
            ColPlan.HeaderText = "Plan Medico";
            ColPlan.Width = 120;
            grillaGrupos.Columns.Add(ColPlan);
        }

        private void cmdBuscar_Click_1(object sender, EventArgs e)
        {
            try
            {
                ActualizarGrilla();
            }
            catch { MessageBox.Show("no actualiza grilla", "Error!", MessageBoxButtons.OK); }

        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            unGrupo = (Grupo)grillaGrupos.CurrentRow.DataBoundItem;

            try
            {
                Afiliados.ModificarGrupo(unAfiliado, unGrupo);
                this.Close();
            }
            catch
            {
                MessageBox.Show("No se pudo actualizar el grupo", "Error!", MessageBoxButtons.OK);
            }
        }
    }
}
