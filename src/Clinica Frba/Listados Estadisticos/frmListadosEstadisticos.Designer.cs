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
            this.grillaListado1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grillaListado2 = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.grillaListado3 = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.grillaListado4 = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dtpAño = new System.Windows.Forms.DateTimePicker();
            this.cmdConsultar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rdSegundoSemestre = new System.Windows.Forms.RadioButton();
            this.rdPrimerSemestre = new System.Windows.Forms.RadioButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaListado1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaListado2)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaListado3)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaListado4)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.tabPage1.Controls.Add(this.grillaListado1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(616, 309);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cancelaciones por especialidad";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grillaListado1
            // 
            this.grillaListado1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaListado1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grillaListado1.Location = new System.Drawing.Point(3, 3);
            this.grillaListado1.Name = "grillaListado1";
            this.grillaListado1.Size = new System.Drawing.Size(610, 303);
            this.grillaListado1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grillaListado2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(616, 309);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Bonos farmacia por afiliado";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // grillaListado2
            // 
            this.grillaListado2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaListado2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grillaListado2.Location = new System.Drawing.Point(3, 3);
            this.grillaListado2.Name = "grillaListado2";
            this.grillaListado2.Size = new System.Drawing.Size(610, 303);
            this.grillaListado2.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.grillaListado3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(616, 309);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Bonos farmacia por especialidad";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // grillaListado3
            // 
            this.grillaListado3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaListado3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grillaListado3.Location = new System.Drawing.Point(3, 3);
            this.grillaListado3.Name = "grillaListado3";
            this.grillaListado3.Size = new System.Drawing.Size(610, 303);
            this.grillaListado3.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.grillaListado4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(616, 309);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Bonos usados por terceros";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // grillaListado4
            // 
            this.grillaListado4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaListado4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grillaListado4.Location = new System.Drawing.Point(3, 3);
            this.grillaListado4.Name = "grillaListado4";
            this.grillaListado4.Size = new System.Drawing.Size(610, 303);
            this.grillaListado4.TabIndex = 1;
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
            this.splitContainer1.Panel1.Controls.Add(this.dtpAño);
            this.splitContainer1.Panel1.Controls.Add(this.cmdConsultar);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.rdSegundoSemestre);
            this.splitContainer1.Panel1.Controls.Add(this.rdPrimerSemestre);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(624, 473);
            this.splitContainer1.SplitterDistance = 134;
            this.splitContainer1.TabIndex = 1;
            // 
            // dtpAño
            // 
            this.dtpAño.CustomFormat = "yyyy";
            this.dtpAño.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAño.Location = new System.Drawing.Point(167, 53);
            this.dtpAño.Margin = new System.Windows.Forms.Padding(2);
            this.dtpAño.Name = "dtpAño";
            this.dtpAño.Size = new System.Drawing.Size(49, 20);
            this.dtpAño.TabIndex = 5;
            // 
            // cmdConsultar
            // 
            this.cmdConsultar.Location = new System.Drawing.Point(476, 61);
            this.cmdConsultar.Name = "cmdConsultar";
            this.cmdConsultar.Size = new System.Drawing.Size(75, 23);
            this.cmdConsultar.TabIndex = 4;
            this.cmdConsultar.Text = "Consultar";
            this.cmdConsultar.UseVisualStyleBackColor = true;
            this.cmdConsultar.Click += new System.EventHandler(this.cmdConsultar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Año a consultar";
            // 
            // rdSegundoSemestre
            // 
            this.rdSegundoSemestre.AutoSize = true;
            this.rdSegundoSemestre.Location = new System.Drawing.Point(302, 76);
            this.rdSegundoSemestre.Name = "rdSegundoSemestre";
            this.rdSegundoSemestre.Size = new System.Drawing.Size(113, 17);
            this.rdSegundoSemestre.TabIndex = 1;
            this.rdSegundoSemestre.TabStop = true;
            this.rdSegundoSemestre.Text = "Segundo semestre";
            this.rdSegundoSemestre.UseVisualStyleBackColor = true;
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
            ((System.ComponentModel.ISupportInitialize)(this.grillaListado1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grillaListado2)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grillaListado3)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grillaListado4)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
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
        private System.Windows.Forms.RadioButton rdSegundoSemestre;
        private System.Windows.Forms.RadioButton rdPrimerSemestre;
        private System.Windows.Forms.DataGridView grillaListado1;
        private System.Windows.Forms.DataGridView grillaListado2;
        private System.Windows.Forms.DataGridView grillaListado3;
        private System.Windows.Forms.DataGridView grillaListado4;
        private System.Windows.Forms.Button cmdConsultar;
        private System.Windows.Forms.DateTimePicker dtpAño;
    }
}