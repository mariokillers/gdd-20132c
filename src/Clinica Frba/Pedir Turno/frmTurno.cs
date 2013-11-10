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

namespace Clinica_Frba.Pedir_Turno
{
    public partial class frmTurno : Form
    {
        public frmTurno()
        {
            InitializeComponent();
        }

        public Usuario unUsuario = new Usuario();
        public Profesional unProfesional = new Profesional();
        public Agenda unaAgenda = new Agenda();

        private void frmTurno_Load(object sender, EventArgs e)
        {
            unaAgenda.armarAgenda(unProfesional.Id);

            MessageBox.Show("Desde: " + unaAgenda.FechaDesde + ", Hasta: " + unaAgenda.FechaHasta, "test", MessageBoxButtons.OK);

            dtpFecha.MinDate = unaAgenda.FechaDesde;
            dtpFecha.MaxDate = unaAgenda.FechaHasta;
        }
    }
}
