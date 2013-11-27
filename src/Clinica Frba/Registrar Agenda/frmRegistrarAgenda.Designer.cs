namespace Clinica_Frba.Registrar_Agenda
{
    partial class frmRegistrarAgenda
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbHoraHasta = new System.Windows.Forms.ComboBox();
            this.cmbHoraDesde = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDias = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.grillaHorarios = new System.Windows.Forms.DataGridView();
            this.cmdEliminar = new System.Windows.Forms.Button();
            this.cmdFinalizar = new System.Windows.Forms.Button();
            this.groRango = new System.Windows.Forms.GroupBox();
            this.cmdConfirmarRango = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbEspecialidades = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaHorarios)).BeginInit();
            this.groRango.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre del Profesional:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(143, 9);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(35, 13);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "label2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbEspecialidades);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmbHoraHasta);
            this.groupBox1.Controls.Add(this.cmbHoraDesde);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbDias);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmdAceptar);
            this.groupBox1.Location = new System.Drawing.Point(15, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(558, 82);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registrar Dias y Horarios";
            // 
            // cmbHoraHasta
            // 
            this.cmbHoraHasta.FormattingEnabled = true;
            this.cmbHoraHasta.Location = new System.Drawing.Point(291, 31);
            this.cmbHoraHasta.Name = "cmbHoraHasta";
            this.cmbHoraHasta.Size = new System.Drawing.Size(102, 21);
            this.cmbHoraHasta.TabIndex = 12;
            // 
            // cmbHoraDesde
            // 
            this.cmbHoraDesde.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.cmbHoraDesde.FormattingEnabled = true;
            this.cmbHoraDesde.Location = new System.Drawing.Point(174, 32);
            this.cmbHoraDesde.Name = "cmbHoraDesde";
            this.cmbHoraDesde.Size = new System.Drawing.Size(102, 21);
            this.cmbHoraDesde.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(302, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Hora Hasta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(187, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Hora Desde:";
            // 
            // cmbDias
            // 
            this.cmbDias.FormattingEnabled = true;
            this.cmbDias.Location = new System.Drawing.Point(7, 33);
            this.cmbDias.Name = "cmbDias";
            this.cmbDias.Size = new System.Drawing.Size(121, 21);
            this.cmbDias.TabIndex = 8;
            this.cmbDias.SelectedIndexChanged += new System.EventHandler(this.cmbDias_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Día:";
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.Location = new System.Drawing.Point(471, 55);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(75, 23);
            this.cmdAceptar.TabIndex = 0;
            this.cmdAceptar.Text = "Agregar";
            this.cmdAceptar.UseVisualStyleBackColor = true;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // grillaHorarios
            // 
            this.grillaHorarios.AllowUserToAddRows = false;
            this.grillaHorarios.AllowUserToDeleteRows = false;
            this.grillaHorarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaHorarios.Location = new System.Drawing.Point(12, 114);
            this.grillaHorarios.Name = "grillaHorarios";
            this.grillaHorarios.Size = new System.Drawing.Size(561, 150);
            this.grillaHorarios.TabIndex = 3;
            // 
            // cmdEliminar
            // 
            this.cmdEliminar.Location = new System.Drawing.Point(123, 278);
            this.cmdEliminar.Name = "cmdEliminar";
            this.cmdEliminar.Size = new System.Drawing.Size(75, 23);
            this.cmdEliminar.TabIndex = 4;
            this.cmdEliminar.Text = "Eliminar";
            this.cmdEliminar.UseVisualStyleBackColor = true;
            this.cmdEliminar.Click += new System.EventHandler(this.cmdEliminar_Click);
            // 
            // cmdFinalizar
            // 
            this.cmdFinalizar.Location = new System.Drawing.Point(396, 278);
            this.cmdFinalizar.Name = "cmdFinalizar";
            this.cmdFinalizar.Size = new System.Drawing.Size(75, 23);
            this.cmdFinalizar.TabIndex = 6;
            this.cmdFinalizar.Text = "Confirmar";
            this.cmdFinalizar.UseVisualStyleBackColor = true;
            this.cmdFinalizar.Click += new System.EventHandler(this.cmdFinalizar_Click);
            // 
            // groRango
            // 
            this.groRango.Controls.Add(this.cmdConfirmarRango);
            this.groRango.Controls.Add(this.label6);
            this.groRango.Controls.Add(this.label5);
            this.groRango.Controls.Add(this.dtpHasta);
            this.groRango.Controls.Add(this.dtpDesde);
            this.groRango.Location = new System.Drawing.Point(15, 311);
            this.groRango.Name = "groRango";
            this.groRango.Size = new System.Drawing.Size(558, 144);
            this.groRango.TabIndex = 7;
            this.groRango.TabStop = false;
            this.groRango.Text = "Registrar Rango de Fechas";
            this.groRango.Visible = false;
            // 
            // cmdConfirmarRango
            // 
            this.cmdConfirmarRango.Location = new System.Drawing.Point(255, 108);
            this.cmdConfirmarRango.Name = "cmdConfirmarRango";
            this.cmdConfirmarRango.Size = new System.Drawing.Size(75, 23);
            this.cmdConfirmarRango.TabIndex = 4;
            this.cmdConfirmarRango.Text = "Confirmar";
            this.cmdConfirmarRango.UseVisualStyleBackColor = true;
            this.cmdConfirmarRango.Click += new System.EventHandler(this.cmdConfirmarRango_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(111, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Fecha Hasta:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(111, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Fecha Desde:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(246, 71);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(200, 20);
            this.dtpHasta.TabIndex = 1;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(246, 35);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(200, 20);
            this.dtpDesde.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(448, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Especialidad:";
            // 
            // cmbEspecialidades
            // 
            this.cmbEspecialidades.FormattingEnabled = true;
            this.cmbEspecialidades.Location = new System.Drawing.Point(425, 31);
            this.cmbEspecialidades.Name = "cmbEspecialidades";
            this.cmbEspecialidades.Size = new System.Drawing.Size(121, 21);
            this.cmbEspecialidades.TabIndex = 14;
            // 
            // frmRegistrarAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 467);
            this.Controls.Add(this.groRango);
            this.Controls.Add(this.cmdFinalizar);
            this.Controls.Add(this.cmdEliminar);
            this.Controls.Add(this.grillaHorarios);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.label1);
            this.Name = "frmRegistrarAgenda";
            this.Text = "Registrar Agenda";
            this.Load += new System.EventHandler(this.frmRegistrarAgenda_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaHorarios)).EndInit();
            this.groRango.ResumeLayout(false);
            this.groRango.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbDias;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdAceptar;
        private System.Windows.Forms.DataGridView grillaHorarios;
        private System.Windows.Forms.Button cmdEliminar;
        private System.Windows.Forms.Button cmdFinalizar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbHoraHasta;
        private System.Windows.Forms.ComboBox cmbHoraDesde;
        private System.Windows.Forms.GroupBox groRango;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Button cmdConfirmarRango;
        private System.Windows.Forms.ComboBox cmbEspecialidades;
        private System.Windows.Forms.Label label7;
    }
}