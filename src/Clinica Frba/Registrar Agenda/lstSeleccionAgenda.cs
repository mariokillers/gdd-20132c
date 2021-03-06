﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Clases;
using Clinica_Frba.Abm_de_Profesional;

namespace Clinica_Frba.Registrar_Agenda
{
    public partial class lstSeleccionAgenda : Form
    {
        public lstSeleccionAgenda()
        {
            InitializeComponent();
        }

        //PARA SABER QUE PROFESIONAL ESTOY ACTUALIZANDO
        public Profesional unProfesional { get; set; }

        private void lstSeleccionAgenda_Load(object sender, EventArgs e)
        {
            try
            {
                lblNombre.Text = unProfesional.Apellido + ", " + unProfesional.Nombre;
                lblDesde.Text = unProfesional.ObtenerAgendaDesde().ToShortDateString();
                lblHasta.Text = unProfesional.ObtenerAgendaHasta().ToShortDateString();

                grillaAgenda.AutoGenerateColumns = false;
                generarGrilla();
                ActualizarGrilla();       
            }
            catch 
            {
                this.Close();
                MessageBox.Show("No hay una agenda cargada", "Error!", MessageBoxButtons.OK); 
            }
        }

        private void ActualizarGrilla()
        {
            grillaAgenda.DataSource = unProfesional.ObtenerAgenda();
        }

        private void generarGrilla()
        {
            DataGridViewTextBoxColumn ColDia = new DataGridViewTextBoxColumn();
            ColDia.DataPropertyName = "StringDia";
            ColDia.HeaderText = "Día";
            ColDia.Width = 120;
            grillaAgenda.Columns.Add(ColDia);

            DataGridViewTextBoxColumn ColHoraDesde = new DataGridViewTextBoxColumn();
            ColHoraDesde.DataPropertyName = "HoraDesde";
            ColHoraDesde.HeaderText = "Hora Desde";
            ColHoraDesde.Width = 120;
            grillaAgenda.Columns.Add(ColHoraDesde);

            DataGridViewTextBoxColumn ColHoraHasta = new DataGridViewTextBoxColumn();
            ColHoraHasta.DataPropertyName = "HoraHasta";
            ColHoraHasta.HeaderText = "Hora Hasta";
            ColHoraHasta.Width = 120;
            grillaAgenda.Columns.Add(ColHoraHasta);

            DataGridViewTextBoxColumn ColEspecialidad = new DataGridViewTextBoxColumn();
            ColEspecialidad.DataPropertyName = "EspString";
            ColEspecialidad.HeaderText = "Especialidad";
            ColEspecialidad.Width = 120;
            grillaAgenda.Columns.Add(ColEspecialidad);
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            if (unProfesional.EliminarAgenda() && unProfesional.EliminarRango()) 
            {
                ActualizarGrilla();
                MessageBox.Show("La agenda ha sido eliminada correctamente", "EnhoraBuena!", MessageBoxButtons.OK);         
            }
            else { MessageBox.Show("La agenda no se ha pidido eliminar", "Error!", MessageBoxButtons.OK); }
            this.Close();
        }
    }
}
