using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Clases;

namespace Clinica_Frba.NewFolder6
{
    public partial class frmAtencion : Form
    {
        public frmAtencion()
        {
            InitializeComponent();
        }
        //A QUE AFILIADO CORRESPONDE LA ATENCION
        private Afiliado afiliado { get; set; }

        private void frmAtencion_Load(object sender, EventArgs e)
        {
            cmbHoraDesde.DataSource = Utiles.ObtenerHorasDiasHabiles();
            cmbHoraDesde.ValueMember = "LaHora";
            cmbHoraDesde.DisplayMember = "HoraAMostrar";
        }
    }
}
