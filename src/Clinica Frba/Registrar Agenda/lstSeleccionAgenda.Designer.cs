namespace Clinica_Frba.Registrar_Agenda
{
    partial class lstSeleccionAgenda
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
            this.lblNombreProfesional = new System.Windows.Forms.Label();
            this.grillaAgenda = new System.Windows.Forms.DataGridView();
            this.cmdEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grillaAgenda)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dr: ";
            // 
            // lblNombreProfesional
            // 
            this.lblNombreProfesional.AutoSize = true;
            this.lblNombreProfesional.Location = new System.Drawing.Point(44, 13);
            this.lblNombreProfesional.Name = "lblNombreProfesional";
            this.lblNombreProfesional.Size = new System.Drawing.Size(35, 13);
            this.lblNombreProfesional.TabIndex = 1;
            this.lblNombreProfesional.Text = "label2";
            // 
            // grillaAgenda
            // 
            this.grillaAgenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaAgenda.Location = new System.Drawing.Point(16, 62);
            this.grillaAgenda.Name = "grillaAgenda";
            this.grillaAgenda.Size = new System.Drawing.Size(240, 150);
            this.grillaAgenda.TabIndex = 2;
            // 
            // cmdEliminar
            // 
            this.cmdEliminar.Location = new System.Drawing.Point(80, 218);
            this.cmdEliminar.Name = "cmdEliminar";
            this.cmdEliminar.Size = new System.Drawing.Size(109, 23);
            this.cmdEliminar.TabIndex = 3;
            this.cmdEliminar.Text = "Eliminar Agenda";
            this.cmdEliminar.UseVisualStyleBackColor = true;
            this.cmdEliminar.Click += new System.EventHandler(this.cmdEliminar_Click);
            // 
            // lstSeleccionAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.cmdEliminar);
            this.Controls.Add(this.grillaAgenda);
            this.Controls.Add(this.lblNombreProfesional);
            this.Controls.Add(this.label1);
            this.Name = "lstSeleccionAgenda";
            this.Text = "Agenda";
            this.Load += new System.EventHandler(this.lstSeleccionAgenda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaAgenda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNombreProfesional;
        private System.Windows.Forms.DataGridView grillaAgenda;
        private System.Windows.Forms.Button cmdEliminar;

    }
}