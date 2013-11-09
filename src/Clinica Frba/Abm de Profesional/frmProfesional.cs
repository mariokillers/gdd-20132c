using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Clases;

namespace Clinica_Frba.NewFolder13
{
    public partial class frmProfesional : Form
    {
        public frmProfesional()
        {
            InitializeComponent();
        }

        private List<Especialidad> listaDeEspecialidades = new List<Especialidad>();

        private void frmProfesional_Load(object sender, EventArgs e)
        {
            listaDeEspecialidades = Especialidades.ObtenerEspecialidades();
            grillaEspecialidades.DataSource = listaDeEspecialidades;
            grillaEspecialidades.ValueMember = "Codigo";
            grillaEspecialidades.DisplayMember = "Descripcion";
        }
    }
}
