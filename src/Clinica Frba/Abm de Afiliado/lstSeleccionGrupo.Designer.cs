namespace Clinica_Frba.Abm_de_Afiliado
{
    partial class lstSeleccionGrupo
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
            this.txtNumGrupo = new System.Windows.Forms.TextBox();
            this.btnAction = new System.Windows.Forms.Button();
            this.grillaGrupos = new System.Windows.Forms.DataGridView();
            this.cmdBuscar = new System.Windows.Forms.Button();
            this.cmdLimpiar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.grillaGrupos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNumGrupo
            // 
            this.txtNumGrupo.Location = new System.Drawing.Point(112, 25);
            this.txtNumGrupo.Name = "txtNumGrupo";
            this.txtNumGrupo.Size = new System.Drawing.Size(100, 20);
            this.txtNumGrupo.TabIndex = 5;
            // 
            // btnAction
            // 
            this.btnAction.Location = new System.Drawing.Point(221, 276);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(75, 34);
            this.btnAction.TabIndex = 9;
            this.btnAction.Text = "Aceptar";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // grillaGrupos
            // 
            this.grillaGrupos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grillaGrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaGrupos.Location = new System.Drawing.Point(12, 109);
            this.grillaGrupos.Name = "grillaGrupos";
            this.grillaGrupos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grillaGrupos.Size = new System.Drawing.Size(284, 161);
            this.grillaGrupos.TabIndex = 8;
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.Location = new System.Drawing.Point(221, 80);
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(75, 23);
            this.cmdBuscar.TabIndex = 7;
            this.cmdBuscar.Text = "Buscar";
            this.cmdBuscar.UseVisualStyleBackColor = true;
            this.cmdBuscar.Click += new System.EventHandler(this.cmdBuscar_Click_1);
            // 
            // cmdLimpiar
            // 
            this.cmdLimpiar.Location = new System.Drawing.Point(12, 80);
            this.cmdLimpiar.Name = "cmdLimpiar";
            this.cmdLimpiar.Size = new System.Drawing.Size(75, 23);
            this.cmdLimpiar.TabIndex = 6;
            this.cmdLimpiar.Text = "Limpiar";
            this.cmdLimpiar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Numero de Grupo:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNumGrupo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 65);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Búsqueda";
            // 
            // lstSeleccionGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 317);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.grillaGrupos);
            this.Controls.Add(this.cmdBuscar);
            this.Controls.Add(this.cmdLimpiar);
            this.Controls.Add(this.groupBox1);
            this.Name = "lstSeleccionGrupo";
            this.Text = "lstSeleccionGrupo";
            this.Load += new System.EventHandler(this.lstSeleccionGrupo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaGrupos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumGrupo;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.DataGridView grillaGrupos;
        private System.Windows.Forms.Button cmdBuscar;
        private System.Windows.Forms.Button cmdLimpiar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}