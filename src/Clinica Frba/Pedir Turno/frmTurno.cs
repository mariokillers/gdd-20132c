using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Abm_de_Profesional;
using System.Data.SqlClient;
using Clinica_Frba.Clases;

namespace Clinica_Frba.NewFolder4
{
    public partial class frmTurno : Form
    {
        public frmTurno()
        {
            InitializeComponent();
        }

        private List<Profesional> listaDeProfesionales = new List<Profesional>();
        private List<SqlParameter> ListaDeParametros = new List<SqlParameter>();
        public Profesional unaProfesional = new Profesional();
        public Usuario unUser = new Usuario();

        private void frmTurno_Load(object sender, EventArgs e)
        {
            grillaProfesionales.AutoGenerateColumns = false;
            List<Especialidad> listaDeEspecialidades = Especialidades.ObtenerEspecialidades();
            cmbEspecialidades.DataSource = listaDeEspecialidades;
            cmbEspecialidades.ValueMember = "Codigo";
            cmbEspecialidades.DisplayMember = "Descripcion";
        }
    }
}
