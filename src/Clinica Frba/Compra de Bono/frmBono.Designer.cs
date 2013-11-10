namespace Clinica_Frba.NewFolder3
{
    partial class frmBono
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
            this.cmdAgregar = new System.Windows.Forms.Button();
            this.cmdConfirmar = new System.Windows.Forms.Button();
            this.txtNumAfil = new System.Windows.Forms.TextBox();
            this.lblNumeroAfiliado = new System.Windows.Forms.Label();
            this.cmdComprar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdCantBonos = new System.Windows.Forms.NumericUpDown();
            this.rbFarmacia = new System.Windows.Forms.RadioButton();
            this.rbConsulta = new System.Windows.Forms.RadioButton();
            this.grillaBonos = new System.Windows.Forms.DataGridView();
            this.tlpDatos = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFechaVencimiento = new System.Windows.Forms.Label();
            this.lblGrupoFamiliar = new System.Windows.Forms.Label();
            this.lblPlanMedico = new System.Windows.Forms.Label();
            this.lblPrecioPorBono = new System.Windows.Forms.Label();
            this.lblMontoAPagar = new System.Windows.Forms.Label();
            this.lblFechaCompra = new System.Windows.Forms.Label();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCantBonos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaBonos)).BeginInit();
            this.tlpDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cmdAgregar);
            this.splitContainer1.Panel1.Controls.Add(this.cmdConfirmar);
            this.splitContainer1.Panel1.Controls.Add(this.txtNumAfil);
            this.splitContainer1.Panel1.Controls.Add(this.lblNumeroAfiliado);
            this.splitContainer1.Panel1.Controls.Add(this.cmdComprar);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.cmdCantBonos);
            this.splitContainer1.Panel1.Controls.Add(this.rbFarmacia);
            this.splitContainer1.Panel1.Controls.Add(this.rbConsulta);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grillaBonos);
            this.splitContainer1.Panel2.Controls.Add(this.tlpDatos);
            this.splitContainer1.Size = new System.Drawing.Size(885, 526);
            this.splitContainer1.SplitterDistance = 296;
            this.splitContainer1.TabIndex = 0;
            // 
            // cmdAgregar
            // 
            this.cmdAgregar.Location = new System.Drawing.Point(47, 300);
            this.cmdAgregar.Name = "cmdAgregar";
            this.cmdAgregar.Size = new System.Drawing.Size(75, 23);
            this.cmdAgregar.TabIndex = 10;
            this.cmdAgregar.Text = "Agregar";
            this.cmdAgregar.UseVisualStyleBackColor = true;
            this.cmdAgregar.Click += new System.EventHandler(this.cmdAgregar_Click);
            // 
            // cmdConfirmar
            // 
            this.cmdConfirmar.Location = new System.Drawing.Point(47, 69);
            this.cmdConfirmar.Name = "cmdConfirmar";
            this.cmdConfirmar.Size = new System.Drawing.Size(75, 23);
            this.cmdConfirmar.TabIndex = 9;
            this.cmdConfirmar.Text = "Aceptar";
            this.cmdConfirmar.UseVisualStyleBackColor = true;
            this.cmdConfirmar.Visible = false;
            this.cmdConfirmar.Click += new System.EventHandler(this.cmdConfirmar_Click);
            // 
            // txtNumAfil
            // 
            this.txtNumAfil.Location = new System.Drawing.Point(29, 43);
            this.txtNumAfil.Name = "txtNumAfil";
            this.txtNumAfil.Size = new System.Drawing.Size(100, 20);
            this.txtNumAfil.TabIndex = 8;
            this.txtNumAfil.Visible = false;
            // 
            // lblNumeroAfiliado
            // 
            this.lblNumeroAfiliado.AutoSize = true;
            this.lblNumeroAfiliado.Location = new System.Drawing.Point(10, 27);
            this.lblNumeroAfiliado.Name = "lblNumeroAfiliado";
            this.lblNumeroAfiliado.Size = new System.Drawing.Size(148, 13);
            this.lblNumeroAfiliado.TabIndex = 7;
            this.lblNumeroAfiliado.Text = "Ingrese el Numero de Afiliado:";
            this.lblNumeroAfiliado.Visible = false;
            // 
            // cmdComprar
            // 
            this.cmdComprar.Location = new System.Drawing.Point(39, 339);
            this.cmdComprar.Name = "cmdComprar";
            this.cmdComprar.Size = new System.Drawing.Size(93, 54);
            this.cmdComprar.TabIndex = 6;
            this.cmdComprar.Text = "Comprar";
            this.cmdComprar.UseVisualStyleBackColor = true;
            this.cmdComprar.Click += new System.EventHandler(this.cmdComprar_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 249);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Cantidad";
            // 
            // cmdCantBonos
            // 
            this.cmdCantBonos.Location = new System.Drawing.Point(22, 265);
            this.cmdCantBonos.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cmdCantBonos.Name = "cmdCantBonos";
            this.cmdCantBonos.Size = new System.Drawing.Size(120, 20);
            this.cmdCantBonos.TabIndex = 4;
            this.cmdCantBonos.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cmdCantBonos.ValueChanged += new System.EventHandler(this.cmdCantBonos_ValueChanged);
            // 
            // rbFarmacia
            // 
            this.rbFarmacia.AutoSize = true;
            this.rbFarmacia.Location = new System.Drawing.Point(36, 185);
            this.rbFarmacia.Name = "rbFarmacia";
            this.rbFarmacia.Size = new System.Drawing.Size(93, 17);
            this.rbFarmacia.TabIndex = 3;
            this.rbFarmacia.Text = "Bono farmacia";
            this.rbFarmacia.UseVisualStyleBackColor = true;
            this.rbFarmacia.CheckedChanged += new System.EventHandler(this.rbFarmacia_CheckedChanged);
            // 
            // rbConsulta
            // 
            this.rbConsulta.AutoSize = true;
            this.rbConsulta.Checked = true;
            this.rbConsulta.Location = new System.Drawing.Point(36, 139);
            this.rbConsulta.Name = "rbConsulta";
            this.rbConsulta.Size = new System.Drawing.Size(93, 17);
            this.rbConsulta.TabIndex = 2;
            this.rbConsulta.TabStop = true;
            this.rbConsulta.Text = "Bono consulta";
            this.rbConsulta.UseVisualStyleBackColor = true;
            this.rbConsulta.CheckedChanged += new System.EventHandler(this.rbConsulta_CheckedChanged);
            // 
            // grillaBonos
            // 
            this.grillaBonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaBonos.Location = new System.Drawing.Point(3, 4);
            this.grillaBonos.Name = "grillaBonos";
            this.grillaBonos.Size = new System.Drawing.Size(579, 335);
            this.grillaBonos.TabIndex = 8;
            // 
            // tlpDatos
            // 
            this.tlpDatos.ColumnCount = 2;
            this.tlpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDatos.Controls.Add(this.label6, 0, 0);
            this.tlpDatos.Controls.Add(this.label7, 0, 5);
            this.tlpDatos.Controls.Add(this.label2, 0, 1);
            this.tlpDatos.Controls.Add(this.label4, 0, 4);
            this.tlpDatos.Controls.Add(this.label5, 0, 3);
            this.tlpDatos.Controls.Add(this.label3, 0, 2);
            this.tlpDatos.Controls.Add(this.lblFechaVencimiento, 1, 1);
            this.tlpDatos.Controls.Add(this.lblGrupoFamiliar, 1, 2);
            this.tlpDatos.Controls.Add(this.lblPlanMedico, 1, 3);
            this.tlpDatos.Controls.Add(this.lblPrecioPorBono, 1, 4);
            this.tlpDatos.Controls.Add(this.lblMontoAPagar, 1, 5);
            this.tlpDatos.Controls.Add(this.lblFechaCompra, 1, 0);
            this.tlpDatos.Location = new System.Drawing.Point(3, 345);
            this.tlpDatos.Name = "tlpDatos";
            this.tlpDatos.RowCount = 6;
            this.tlpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpDatos.Size = new System.Drawing.Size(302, 169);
            this.tlpDatos.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 28);
            this.label6.TabIndex = 5;
            this.label6.Text = "Fecha de compra";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 29);
            this.label7.TabIndex = 6;
            this.label7.Text = "Monto a pagar";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fecha de vencimiento";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 28);
            this.label4.TabIndex = 2;
            this.label4.Text = "Precio por bono";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 28);
            this.label5.TabIndex = 3;
            this.label5.Text = "Plan médico";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 28);
            this.label3.TabIndex = 1;
            this.label3.Text = "Grupo familiar";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFechaVencimiento
            // 
            this.lblFechaVencimiento.AutoSize = true;
            this.lblFechaVencimiento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFechaVencimiento.Location = new System.Drawing.Point(154, 28);
            this.lblFechaVencimiento.Name = "lblFechaVencimiento";
            this.lblFechaVencimiento.Size = new System.Drawing.Size(145, 28);
            this.lblFechaVencimiento.TabIndex = 8;
            this.lblFechaVencimiento.Text = "label9";
            this.lblFechaVencimiento.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblGrupoFamiliar
            // 
            this.lblGrupoFamiliar.AutoSize = true;
            this.lblGrupoFamiliar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGrupoFamiliar.Location = new System.Drawing.Point(154, 56);
            this.lblGrupoFamiliar.Name = "lblGrupoFamiliar";
            this.lblGrupoFamiliar.Size = new System.Drawing.Size(145, 28);
            this.lblGrupoFamiliar.TabIndex = 9;
            this.lblGrupoFamiliar.Text = "label10";
            this.lblGrupoFamiliar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblPlanMedico
            // 
            this.lblPlanMedico.AutoSize = true;
            this.lblPlanMedico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPlanMedico.Location = new System.Drawing.Point(154, 84);
            this.lblPlanMedico.Name = "lblPlanMedico";
            this.lblPlanMedico.Size = new System.Drawing.Size(145, 28);
            this.lblPlanMedico.TabIndex = 10;
            this.lblPlanMedico.Text = "label11";
            this.lblPlanMedico.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblPrecioPorBono
            // 
            this.lblPrecioPorBono.AutoSize = true;
            this.lblPrecioPorBono.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPrecioPorBono.Location = new System.Drawing.Point(154, 112);
            this.lblPrecioPorBono.Name = "lblPrecioPorBono";
            this.lblPrecioPorBono.Size = new System.Drawing.Size(145, 28);
            this.lblPrecioPorBono.TabIndex = 11;
            this.lblPrecioPorBono.Text = "label12";
            this.lblPrecioPorBono.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblMontoAPagar
            // 
            this.lblMontoAPagar.AutoSize = true;
            this.lblMontoAPagar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMontoAPagar.Location = new System.Drawing.Point(154, 140);
            this.lblMontoAPagar.Name = "lblMontoAPagar";
            this.lblMontoAPagar.Size = new System.Drawing.Size(145, 29);
            this.lblMontoAPagar.TabIndex = 12;
            this.lblMontoAPagar.Text = "label13";
            this.lblMontoAPagar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblFechaCompra
            // 
            this.lblFechaCompra.AutoSize = true;
            this.lblFechaCompra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFechaCompra.Location = new System.Drawing.Point(154, 0);
            this.lblFechaCompra.Name = "lblFechaCompra";
            this.lblFechaCompra.Size = new System.Drawing.Size(145, 28);
            this.lblFechaCompra.TabIndex = 7;
            this.lblFechaCompra.Text = "label8";
            this.lblFechaCompra.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // frmBono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(885, 526);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmBono";
            this.Text = "Compra de bonos";
            this.Load += new System.EventHandler(this.frmBono_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmdCantBonos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaBonos)).EndInit();
            this.tlpDatos.ResumeLayout(false);
            this.tlpDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown cmdCantBonos;
        private System.Windows.Forms.RadioButton rbFarmacia;
        private System.Windows.Forms.RadioButton rbConsulta;
        private System.Windows.Forms.Button cmdComprar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tlpDatos;
        private System.Windows.Forms.TextBox txtNumAfil;
        private System.Windows.Forms.Label lblNumeroAfiliado;
        private System.Windows.Forms.Label lblFechaCompra;
        private System.Windows.Forms.Label lblFechaVencimiento;
        private System.Windows.Forms.Label lblGrupoFamiliar;
        private System.Windows.Forms.Label lblPlanMedico;
        private System.Windows.Forms.Label lblPrecioPorBono;
        private System.Windows.Forms.Label lblMontoAPagar;
        private System.Windows.Forms.Button cmdConfirmar;
        private System.Windows.Forms.DataGridView grillaBonos;
        private System.Windows.Forms.Button cmdAgregar;


    }
}