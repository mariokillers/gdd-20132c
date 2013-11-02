using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Clases;
using Clinica_Frba.Clase_Persona;

namespace Clinica_Frba.NewFolder2
{
    public partial class frmAgenda : Form
    {
        public frmAgenda()
        {
            InitializeComponent();
        }
        //PARA SABER A QUIEN CORRESPONDE LA AGENDA
        public Usuario User { get; set; }

        private void frmAgenda_Load(object sender, EventArgs e)
        {
            Persona unaPersona = new Persona(User.Codigo_Persona);
            lblNombre.Text =unaPersona.Apellido+ "," + "" + unaPersona.Nombre;
        }
    }
}
