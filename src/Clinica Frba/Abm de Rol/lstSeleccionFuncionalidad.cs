using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Clases;

namespace Clinica_Frba.Abm_de_Rol
{
    public partial class lstSeleccionFuncionalidad : Form
    {
        public lstSeleccionFuncionalidad()
        {
            InitializeComponent();
        }

        //lista de roles que voy a tener para mostrar
        private List<Funcionalidad> listaDeFuncionalidades = new List<Funcionalidad>();
        public Rol unRol { get; set; }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                //me traigo todas las funcionalidades que cumplen con el filtro
                listaDeFuncionalidades = Funcionalidades.ObtenerFuncionalidades(txtNombreFunc.Text);
                foreach (Funcionalidad unaFuncionalidad in listaDeFuncionalidades)
                {
                    grillaFuncionalidades.ValueMember = "Id";
                    grillaFuncionalidades.DisplayMember = "Nombre";
                }
            }
            catch { MessageBox.Show("", "Error!", MessageBoxButtons.OK); }
        }

        private void lstSeleccionFuncionalidad_Load(object sender, EventArgs e)
        {
            if (unRol == null)
            {
                //ME CARGO TODAS LAS FUNCIONALIDADES PARA PODER AGREGARLAS A LO ROLES
                List<Funcionalidad> listaDeFuncionalidades = Funcionalidades.ObtenerFuncionalidades();
                grillaFuncionalidades.DataSource = listaDeFuncionalidades;
                grillaFuncionalidades.ValueMember = "Id";
                grillaFuncionalidades.DisplayMember = "Nombre";
            }
            else
            {
                //ME TRAIGO TODAS PARA MOSTRARLAS DESCHEACKEADAS
                List<Funcionalidad> listaDeTodas = Funcionalidades.ObtenerFuncionalidades();

                //ME MANDARON UN ROL ESPECIFICO -> MUESTRO SOLO LAS FUNC DE ESTE ROL
                List<Funcionalidad> listaDeFuncionalidades = Funcionalidades.ObtenerFuncionalidades(unRol.Id);

                //FILTRO LAS QUE YA TIENE
                foreach (Funcionalidad unaFunc in listaDeFuncionalidades)
                {
                    if (listaDeTodas.Contains(unaFunc))
                    {
                        listaDeTodas.Remove(unaFunc);
                    }
                }
                //LISTA A MOSTRAR
                List<Funcionalidad> listaAMostrar = listaDeTodas.Concat(listaDeFuncionalidades).ToList();

                grillaFuncionalidades.DataSource = listaAMostrar;
                grillaFuncionalidades.ValueMember = "Id";
                grillaFuncionalidades.DisplayMember = "Nombre";

                //CHEKEO LAS QUE TIENE
                for (int i = 0; i < listaDeFuncionalidades.Count; i++)
                {
                    grillaFuncionalidades.SetItemChecked(i, true);
                }

                //cmdAgregar.Text = "Eliminar";
            }
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            //TOMA DE LO QUE CHEKEO, ARMA UNA LISTA Y SE LO DEVUELVE AL FORM
            List<Funcionalidad> listaDeFunc = new List<Funcionalidad>();
            foreach (Funcionalidad unaFunc in grillaFuncionalidades.CheckedItems)
            {
                listaDeFunc.Add(unaFunc);
            }

            if (unRol != null)
            {
                //DOY DE BAJA LAS FUNC SELECCIONADAS
                foreach (Funcionalidad unaFunc in listaDeFunc)
                {
                    Funcionalidades.EliminarFuncionalidadPorRol(unRol.Id, unaFunc);
                }
            }
            else 
            { 
                //QUE SE HACE?
            }
        }

    }
}
