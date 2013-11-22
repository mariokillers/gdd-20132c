using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Abm_de_Profesional;
using Clinica_Frba.Clases;

namespace Clinica_Frba.Registrar_Llegada
{
    public partial class frmRegistrarLlegada : Form
    {
        public frmRegistrarLlegada()
        {
            InitializeComponent();
        }
        public Afiliado afiliado { get; set; }
        public Profesional profesional { get; set; }
        
       /* private void cmdSeleccionar_Click(object sender, EventArgs e)
        {
            lstSeleccionProfesionales formProfesional = new lstSeleccionProfesionales();
            formProfesional.Operacion = "Seleccion";
            formProfesional.formLlegada = this;
        }*/
    }
}
