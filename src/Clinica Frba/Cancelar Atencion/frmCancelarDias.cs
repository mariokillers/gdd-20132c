using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Clases;

namespace Clinica_Frba.Cancelar_Atencion
{
    public partial class frmCancelarDias : Form
    {
        public frmCancelarDias()
        {
            InitializeComponent();
        }
        public Usuario unUsuario = new Usuario();
        public Agenda unaAgenda = new Agenda();

        private void cmdRango_Click(object sender, EventArgs e)
        {
            lbl26.Visible = true;
            dtpFin.Visible = true;
        }

        private void frmCancelarDias_Load(object sender, EventArgs e)
        {
            List<TipoCancelacion> listaDeTipos = Utiles.ObtenerTiposCancelacion();
            cmbCancelacion.DataSource = listaDeTipos;
            cmbCancelacion.ValueMember = "id";
            cmbCancelacion.DisplayMember = "descripcion";

            
        }
    }
}
