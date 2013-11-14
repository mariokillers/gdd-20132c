namespace Clinica_Frba.NewFolder5
{
    partial class frmReceta
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grillaBonos = new System.Windows.Forms.DataGridView();
            this.txtNumeroBono = new System.Windows.Forms.TextBox();
            this.lblNumeroAfiliado = new System.Windows.Forms.Label();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdAgregarMedicamento = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdCantBonos = new System.Windows.Forms.NumericUpDown();
            this.grillaRecetas = new System.Windows.Forms.DataGridView();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaBonos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCantBonos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaRecetas)).BeginInit();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.grillaBonos);
            this.splitContainer1.Panel1.Controls.Add(this.txtNumeroBono);
            this.splitContainer1.Panel1.Controls.Add(this.lblNumeroAfiliado);
            this.splitContainer1.Panel1.Controls.Add(this.cmdAceptar);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.cmdAgregarMedicamento);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.cmdCantBonos);
            this.splitContainer1.Panel2.Controls.Add(this.grillaRecetas);
            this.splitContainer1.Size = new System.Drawing.Size(712, 531);
            this.splitContainer1.SplitterDistance = 185;
            this.splitContainer1.TabIndex = 0;
            // 
            // grillaBonos
            // 
            this.grillaBonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaBonos.Location = new System.Drawing.Point(13, 48);
            this.grillaBonos.Name = "grillaBonos";
            this.grillaBonos.Size = new System.Drawing.Size(541, 108);
            this.grillaBonos.TabIndex = 10;
            // 
            // txtNumeroBono
            // 
            this.txtNumeroBono.Location = new System.Drawing.Point(200, 9);
            this.txtNumeroBono.Name = "txtNumeroBono";
            this.txtNumeroBono.Size = new System.Drawing.Size(100, 20);
            this.txtNumeroBono.TabIndex = 9;
            // 
            // lblNumeroAfiliado
            // 
            this.lblNumeroAfiliado.AutoSize = true;
            this.lblNumeroAfiliado.Location = new System.Drawing.Point(31, 9);
            this.lblNumeroAfiliado.Name = "lblNumeroAfiliado";
            this.lblNumeroAfiliado.Size = new System.Drawing.Size(131, 13);
            this.lblNumeroAfiliado.TabIndex = 8;
            this.lblNumeroAfiliado.Text = "Ingrese  Numero de Bono:";
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.Location = new System.Drawing.Point(339, 7);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(75, 23);
            this.cmdAceptar.TabIndex = 0;
            this.cmdAceptar.Text = "Agregar";
            this.cmdAceptar.UseVisualStyleBackColor = true;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(13, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(520, 100);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Medicamento";
            // 
            // cmdAgregarMedicamento
            // 
            this.cmdAgregarMedicamento.Location = new System.Drawing.Point(519, 188);
            this.cmdAgregarMedicamento.Name = "cmdAgregarMedicamento";
            this.cmdAgregarMedicamento.Size = new System.Drawing.Size(190, 23);
            this.cmdAgregarMedicamento.TabIndex = 10;
            this.cmdAgregarMedicamento.Text = "Agregar Medicamento a Receta";
            this.cmdAgregarMedicamento.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(585, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Cantidad";
            // 
            // cmdCantBonos
            // 
            this.cmdCantBonos.Location = new System.Drawing.Point(553, 162);
            this.cmdCantBonos.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.cmdCantBonos.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cmdCantBonos.Name = "cmdCantBonos";
            this.cmdCantBonos.Size = new System.Drawing.Size(120, 20);
            this.cmdCantBonos.TabIndex = 6;
            this.cmdCantBonos.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // grillaRecetas
            // 
            this.grillaRecetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaRecetas.Location = new System.Drawing.Point(13, 143);
            this.grillaRecetas.Name = "grillaRecetas";
            this.grillaRecetas.Size = new System.Drawing.Size(541, 150);
            this.grillaRecetas.TabIndex = 0;
            // 
            // frmReceta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 531);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmReceta";
            this.Text = "Receta médica";
            this.Load += new System.EventHandler(this.frmRegistroLlegada_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grillaBonos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCantBonos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaRecetas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button cmdAceptar;
        private System.Windows.Forms.TextBox txtNumeroBono;
        private System.Windows.Forms.Label lblNumeroAfiliado;
        private System.Windows.Forms.DataGridView grillaBonos;
        private System.Windows.Forms.DataGridView grillaRecetas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown cmdCantBonos;
        private System.Windows.Forms.Button cmdAgregarMedicamento;
        private System.Windows.Forms.GroupBox groupBox1;


    }
}