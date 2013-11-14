using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Clases;

namespace Clinica_Frba.NewFolder7
{
    public partial class frmCancelarAtencion : Form
    {
        public frmCancelarAtencion()
        {
            InitializeComponent();
        }
        public Usuario unUsuario = new Usuario();
        public String Operacion { get; set; }

        private void frmCancelarAtencion_Load(object sender, EventArgs e)
        {
            grillaTurnos.AutoGenerateColumns = true;
            List<TipoCancelacion> listaDeTipos = Utiles.ObtenerTiposCancelacion();
            cmbCancelacion.DataSource = listaDeTipos;
            cmbCancelacion.ValueMember = "id";
            cmbCancelacion.DisplayMember = "descripcion";

            --cargarGrilla();
        }
    }
}
