namespace Clinica_Frba.NewFolder9
{
    partial class frmListadosEstadisticos
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grillaTopEspecialidades = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grillaTopBonosAfiliado = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.grillaTopBonosEspecialidad = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.grillaTopBonosTerceros = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAno = new System.Windows.Forms.NumericUpDown();
            this.rdSegundoTrimestre = new System.Windows.Forms.RadioButton();
            this.rdPrimerSemestre = new System.Windows.Forms.RadioButton();
            this.cmdConsultar = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaTopEspecialidades)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaTopBonosAfiliado)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaTopBonosEspecialidad)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaTopBonosTerceros)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAno)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(624, 335);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grillaTopEspecialidades);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(616, 309);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cancelaciones por especialidad";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grillaTopEspecialidades
            // 
            this.grillaTopEspecialidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaTopEspecialidades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grillaTopEspecialidades.Location = new System.Drawing.Point(3, 3);
            this.grillaTopEspecialidades.Name = "grillaTopEspecialidades";
            this.grillaTopEspecialidades.Size = new System.Drawing.Size(610, 303);
            this.grillaTopEspecialidades.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grillaTopBonosAfiliado);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(616, 309);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Bonos farmacia por afiliado";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // grillaTopBonosAfiliado
            // 
            this.grillaTopBonosAfiliado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaTopBonosAfiliado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grillaTopBonosAfiliado.Location = new System.Drawing.Point(3, 3);
            this.grillaTopBonosAfiliado.Name = "grillaTopBonosAfiliado";
            this.grillaTopBonosAfiliado.Size = new System.Drawing.Size(610, 303);
            this.grillaTopBonosAfiliado.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.grillaTopBonosEspecialidad);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(616, 309);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Bonos farmacia por especialidad";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // grillaTopBonosEspecialidad
            // 
            this.grillaTopBonosEspecialidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaTopBonosEspecialidad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grillaTopBonosEspecialidad.Location = new System.Drawing.Point(3, 3);
            this.grillaTopBonosEspecialidad.Name = "grillaTopBonosEspecialidad";
            this.grillaTopBonosEspecialidad.Size = new System.Drawing.Size(610, 303);
            this.grillaTopBonosEspecialidad.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.grillaTopBonosTerceros);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(616, 309);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Bonos usados por terceros";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // grillaTopBonosTerceros
            // 
            this.grillaTopBonosTerceros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaTopBonosTerceros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grillaTopBonosTerceros.Location = new System.Drawing.Point(3, 3);
            this.grillaTopBonosTerceros.Name = "grillaTopBonosTerceros";
            this.grillaTopBonosTerceros.Size = new System.Drawing.Size(610, 303);
            this.grillaTopBonosTerceros.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cmdConsultar);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.cmbAno);
            this.splitContainer1.Panel1.Controls.Add(this.rdSegundoTrimestre);
            this.splitContainer1.Panel1.Controls.Add(this.rdPrimerSemestre);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(624, 473);
            this.splitContainer1.SplitterDistance = 134;
            this.splitContainer1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Año a consultar";
            // 
            // cmbAno
            // 
            this.cmbAno.Location = new System.Drawing.Point(118, 55);
            this.cmbAno.Maximum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.cmbAno.Minimum = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            this.cmbAno.Name = "cmbAno";
            this.cmbAno.Size = new System.Drawing.Size(120, 20);
            this.cmbAno.TabIndex = 2;
            this.cmbAno.Value = new decimal(new int[] {
            2013,
            0,
            0,
            0});
            // 
            // rdSegundoTrimestre
            // 
            this.rdSegundoTrimestre.AutoSize = true;
            this.rdSegundoTrimestre.Location = new System.Drawing.Point(302, 76);
            this.rdSegundoTrimestre.Name = "rdSegundoTrimestre";
            this.rdSegundoTrimestre.Size = new System.Drawing.Size(113, 17);
            this.rdSegundoTrimestre.TabIndex = 1;
            this.rdSegundoTrimestre.TabStop = true;
            this.rdSegundoTrimestre.Text = "Segundo semestre";
            this.rdSegundoTrimestre.UseVisualStyleBackColor = true;
            // 
            // rdPrimerSemestre
            // 
            this.rdPrimerSemestre.AutoSize = true;
            this.rdPrimerSemestre.Location = new System.Drawing.Point(302, 53);
            this.rdPrimerSemestre.Name = "rdPrimerSemestre";
            this.rdPrimerSemestre.Size = new System.Drawing.Size(99, 17);
            this.rdPrimerSemestre.TabIndex = 0;
            this.rdPrimerSemestre.TabStop = true;
            this.rdPrimerSemestre.Text = "Primer semestre";
            this.rdPrimerSemestre.UseVisualStyleBackColor = true;
            // 
            // cmdConsultar
            // 
            this.cmdConsultar.Location = new System.Drawing.Point(494, 70);
            this.cmdConsultar.Name = "cmdConsultar";
            this.cmdConsultar.Size = new System.Drawing.Size(75, 23);
            this.cmdConsultar.TabIndex = 4;
            this.cmdConsultar.Text = "Consultar";
            this.cmdConsultar.UseVisualStyleBackColor = true;
            // 
            // frmListadosEstadisticos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 473);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmListadosEstadisticos";
            this.Text = "Listados estadísticos";
            this.Load += new System.EventHandler(this.frmListadosEstadisticos_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grillaTopEspecialidades)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grillaTopBonosAfiliado)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grillaTopBonosEspecialidad)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grillaTopBonosTerceros)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbAno)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown cmbAno;
        private System.Windows.Forms.RadioButton rdSegundoTrimestre;
        private System.Windows.Forms.RadioButton rdPrimerSemestre;
        private System.Windows.Forms.DataGridView grillaTopEspecialidades;
        private System.Windows.Forms.DataGridView grillaTopBonosAfiliado;
        private System.Windows.Forms.DataGridView grillaTopBonosEspecialidad;
        private System.Windows.Forms.DataGridView grillaTopBonosTerceros;
        private System.Windows.Forms.Button cmdConsultar;
    }
}