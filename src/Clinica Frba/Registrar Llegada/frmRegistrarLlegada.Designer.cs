namespace Clinica_Frba.Registrar_Llegada
{
    partial class frmRegistrarLlegada
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Medico = new System.Windows.Forms.GroupBox();
            this.cmdSeleccionar = new System.Windows.Forms.Button();
            this.SeleccionTurno = new System.Windows.Forms.GroupBox();
            this.btnTurno = new System.Windows.Forms.Button();
            this.grillaHorarios = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBono = new System.Windows.Forms.TextBox();
            this.cmdConfirmarBono = new System.Windows.Forms.Button();
            this.lblNumeroAfiliado = new System.Windows.Forms.Label();
            this.Medico.SuspendLayout();
            this.SeleccionTurno.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaHorarios)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Medico
            // 
            this.Medico.Controls.Add(this.cmdSeleccionar);
            this.Medico.Location = new System.Drawing.Point(27, 36);
            this.Medico.Name = "Medico";
            this.Medico.Size = new System.Drawing.Size(508, 77);
            this.Medico.TabIndex = 1;
            this.Medico.TabStop = false;
            this.Medico.Text = "Seleccionar Profesional";
            // 
            // cmdSeleccionar
            // 
            this.cmdSeleccionar.Location = new System.Drawing.Point(144, 32);
            this.cmdSeleccionar.Name = "cmdSeleccionar";
            this.cmdSeleccionar.Size = new System.Drawing.Size(148, 23);
            this.cmdSeleccionar.TabIndex = 0;
            this.cmdSeleccionar.Text = "Seleccionar Profesional";
            this.cmdSeleccionar.UseVisualStyleBackColor = true;
            this.cmdSeleccionar.Click += new System.EventHandler(this.cmdSeleccionar_Click);
            // 
            // SeleccionTurno
            // 
            this.SeleccionTurno.Controls.Add(this.btnTurno);
            this.SeleccionTurno.Controls.Add(this.grillaHorarios);
            this.SeleccionTurno.Location = new System.Drawing.Point(27, 126);
            this.SeleccionTurno.Name = "SeleccionTurno";
            this.SeleccionTurno.Size = new System.Drawing.Size(508, 203);
            this.SeleccionTurno.TabIndex = 2;
            this.SeleccionTurno.TabStop = false;
            this.SeleccionTurno.Text = "Seleccion Turno";
            // 
            // btnTurno
            // 
            this.btnTurno.Location = new System.Drawing.Point(162, 174);
            this.btnTurno.Name = "btnTurno";
            this.btnTurno.Size = new System.Drawing.Size(75, 23);
            this.btnTurno.TabIndex = 1;
            this.btnTurno.Text = "Seleccionar";
            this.btnTurno.UseVisualStyleBackColor = true;
            this.btnTurno.Click += new System.EventHandler(this.btnTurno_Click);
            // 
            // grillaHorarios
            // 
            this.grillaHorarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaHorarios.Location = new System.Drawing.Point(6, 19);
            this.grillaHorarios.Name = "grillaHorarios";
            this.grillaHorarios.Size = new System.Drawing.Size(496, 150);
            this.grillaHorarios.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblNumeroAfiliado);
            this.groupBox2.Controls.Add(this.cmdConfirmarBono);
            this.groupBox2.Controls.Add(this.txtBono);
            this.groupBox2.Location = new System.Drawing.Point(29, 345);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(502, 100);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bono Consulta";
            // 
            // txtBono
            // 
            this.txtBono.Enabled = false;
            this.txtBono.Location = new System.Drawing.Point(156, 35);
            this.txtBono.Name = "txtBono";
            this.txtBono.Size = new System.Drawing.Size(130, 20);
            this.txtBono.TabIndex = 0;
            // 
            // cmdConfirmarBono
            // 
            this.cmdConfirmarBono.Enabled = false;
            this.cmdConfirmarBono.Location = new System.Drawing.Point(330, 59);
            this.cmdConfirmarBono.Name = "cmdConfirmarBono";
            this.cmdConfirmarBono.Size = new System.Drawing.Size(141, 23);
            this.cmdConfirmarBono.TabIndex = 7;
            this.cmdConfirmarBono.Text = "Confirmar Bono";
            this.cmdConfirmarBono.UseVisualStyleBackColor = true;
            this.cmdConfirmarBono.Click += new System.EventHandler(this.cmdConfirmarBono_Click);
            // 
            // lblNumeroAfiliado
            // 
            this.lblNumeroAfiliado.AutoSize = true;
            this.lblNumeroAfiliado.Location = new System.Drawing.Point(6, 38);
            this.lblNumeroAfiliado.Name = "lblNumeroAfiliado";
            this.lblNumeroAfiliado.Size = new System.Drawing.Size(131, 13);
            this.lblNumeroAfiliado.TabIndex = 9;
            this.lblNumeroAfiliado.Text = "Ingrese  Numero de Bono:";
            // 
            // frmRegistrarLlegada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 464);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.SeleccionTurno);
            this.Controls.Add(this.Medico);
            this.Name = "frmRegistrarLlegada";
            this.Text = "s";
            this.Load += new System.EventHandler(this.frmRegistrarLlegada_Load);
            this.Medico.ResumeLayout(false);
            this.SeleccionTurno.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grillaHorarios)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Medico;
        private System.Windows.Forms.Button cmdSeleccionar;
        private System.Windows.Forms.GroupBox SeleccionTurno;
        private System.Windows.Forms.DataGridView grillaHorarios;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtBono;
        private System.Windows.Forms.Button cmdConfirmarBono;
        private System.Windows.Forms.Button btnTurno;
        private System.Windows.Forms.Label lblNumeroAfiliado;
    }
}