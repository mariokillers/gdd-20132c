namespace Clinica_Frba.Abm_de_Rol
{
    partial class lstSeleccionFuncionalidad
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
            this.grillaFuncionalidades = new System.Windows.Forms.CheckedListBox();
            this.cmdAgregar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtRol = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbHabilitado = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grillaFuncionalidades
            // 
            this.grillaFuncionalidades.FormattingEnabled = true;
            this.grillaFuncionalidades.Location = new System.Drawing.Point(81, 113);
            this.grillaFuncionalidades.Name = "grillaFuncionalidades";
            this.grillaFuncionalidades.Size = new System.Drawing.Size(214, 184);
            this.grillaFuncionalidades.TabIndex = 3;
            // 
            // cmdAgregar
            // 
            this.cmdAgregar.Location = new System.Drawing.Point(136, 302);
            this.cmdAgregar.Name = "cmdAgregar";
            this.cmdAgregar.Size = new System.Drawing.Size(75, 23);
            this.cmdAgregar.TabIndex = 4;
            this.cmdAgregar.Text = "Guardar";
            this.cmdAgregar.UseVisualStyleBackColor = true;
            this.cmdAgregar.Click += new System.EventHandler(this.cmdAgregar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbHabilitado);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtRol);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(22, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(342, 81);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // txtRol
            // 
            this.txtRol.Location = new System.Drawing.Point(153, 26);
            this.txtRol.Name = "txtRol";
            this.txtRol.Size = new System.Drawing.Size(100, 20);
            this.txtRol.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nombre del Rol:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Estado:";
            // 
            // cbHabilitado
            // 
            this.cbHabilitado.AutoSize = true;
            this.cbHabilitado.Location = new System.Drawing.Point(153, 55);
            this.cbHabilitado.Name = "cbHabilitado";
            this.cbHabilitado.Size = new System.Drawing.Size(73, 17);
            this.cbHabilitado.TabIndex = 10;
            this.cbHabilitado.Text = "Habilitado";
            this.cbHabilitado.UseVisualStyleBackColor = true;
            // 
            // lstSeleccionFuncionalidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 331);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cmdAgregar);
            this.Controls.Add(this.grillaFuncionalidades);
            this.Name = "lstSeleccionFuncionalidad";
            this.Text = "lstSeleccionFuncionalidad";
            this.Load += new System.EventHandler(this.lstSeleccionFuncionalidad_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox grillaFuncionalidades;
        private System.Windows.Forms.Button cmdAgregar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtRol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbHabilitado;
        private System.Windows.Forms.Label label1;
    }
}