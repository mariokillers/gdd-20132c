using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Clases;

namespace Clinica_Frba.NewFolder1
{
    public partial class frmRol : Form
    {
        public frmRol()
        {
            InitializeComponent();
        }

        private void frmRol_Load(object sender, EventArgs e)
        {
            List<Funcionalidad> listaDeFuncionalidades = Funcionalidades.ObtenerFuncionalidades();
            foreach (Funcionalidad unaFuncionalidad in listaDeFuncionalidades)
            {
                cmbFuncionalidades.ValueMember = "Id";
                cmbFuncionalidades.DisplayMember = "Nombre";
            }
        }

        private void cmdLimpiar_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
