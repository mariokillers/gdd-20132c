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
                grillaFuncionalidades.DataSource = listaDeFuncionalidades;
                grillaFuncionalidades.ValueMember = "Id";
                grillaFuncionalidades.DisplayMember = "Nombre";
            }
            catch { MessageBox.Show("Se ha producido un error", "Error!", MessageBoxButtons.OK); }
        }

        private void lstSeleccionFuncionalidad_Load(object sender, EventArgs e)
        {
            try
            {
                if (unRol != null)
                {
                    //ME TRAIGO TODAS PARA MOSTRARLAS DESCHEACKEADAS
                    List<Funcionalidad> listaDeTodas = Funcionalidades.ObtenerFuncionalidades();

                    grillaFuncionalidades.DataSource = listaDeTodas;
                    grillaFuncionalidades.ValueMember = "Id";
                    grillaFuncionalidades.DisplayMember = "Nombre";

                    //ME MANDARON UN ROL ESPECIFICO -> MUESTRO SOLO LAS FUNC DE ESTE ROL
                    List<Funcionalidad> listaDeFuncionalidades = Funcionalidades.ObtenerFuncionalidades(unRol.Id);

                    //CHECKEO LAS QUE TIENE
                    foreach (Funcionalidad unaFunc in listaDeTodas)
                    {
                        var probar = listaDeFuncionalidades.SingleOrDefault(fun => fun.Id == unaFunc.Id);
                        if (probar != null)
                        {
                            grillaFuncionalidades.SetItemChecked(listaDeTodas.IndexOf(unaFunc), true);
                        }
                    }
                }
            }
            catch
            {MessageBox.Show("Se ha producido un error,vuelva a intentarlo", "Error!", MessageBoxButtons.OK);}
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            //LISTA DE FUNCIONALIDADES QUE TIENE ESE ROL
            List<Funcionalidad> listaQueTiene = Funcionalidades.ObtenerFuncionalidades(unRol.Id);

            //LISTA DE FUNCIONALIDADES CHEKEADAS
            List<Funcionalidad> listaDeFunc = new List<Funcionalidad>();
            foreach (Funcionalidad unaFunc in grillaFuncionalidades.CheckedItems)
            {
                listaDeFunc.Add(unaFunc);
            }

            //DOY DE BAJA LAS FUNC QUE YA NO ESTAN
            foreach (Funcionalidad unaFunc in listaQueTiene)
            {
                Funcionalidades.EliminarFuncionalidadPorRol(unRol.Id, unaFunc);
            }

            //DOY DE ALTA LAS NUEVAS
            foreach (Funcionalidad unaFunc in listaDeFunc)
            {
                Funcionalidades.AgregarFuncionalidadEnRol(unRol.Id, unaFunc);
            }

            MessageBox.Show("Se ha modificado el rol con éxito", "Enhorabuena!", MessageBoxButtons.OK);
        }
    }
}
