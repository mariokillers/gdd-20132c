namespace Clinica_Frba.Abm_de_Afiliado
{
    partial class frmGrupo
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
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.t = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPlanes = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.cmbVolver = new System.Windows.Forms.Button();
            this.btnGrupoExistente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtApellido
            // 
            this.txtApellido.Enabled = false;
            this.txtApellido.Location = new System.Drawing.Point(129, 63);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(200, 20);
            this.txtApellido.TabIndex = 60;
            // 
            // t
            // 
            this.t.AutoSize = true;
            this.t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t.Location = new System.Drawing.Point(17, 63);
            this.t.Name = "t";
            this.t.Size = new System.Drawing.Size(47, 13);
            this.t.TabIndex = 59;
            this.t.Text = "Apellido:";
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(129, 31);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 20);
            this.txtNombre.TabIndex = 58;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 57;
            this.label1.Text = "Nombre:";
            // 
            // cmbPlanes
            // 
            this.cmbPlanes.FormattingEnabled = true;
            this.cmbPlanes.Location = new System.Drawing.Point(129, 99);
            this.cmbPlanes.Name = "cmbPlanes";
            this.cmbPlanes.Size = new System.Drawing.Size(121, 21);
            this.cmbPlanes.TabIndex = 67;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(17, 99);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(104, 13);
            this.label26.TabIndex = 66;
            this.label26.Text = "Plan Medico Nuevo:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(20, 136);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 68;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cmbVolver
            // 
            this.cmbVolver.Location = new System.Drawing.Point(129, 136);
            this.cmbVolver.Name = "cmbVolver";
            this.cmbVolver.Size = new System.Drawing.Size(75, 23);
            this.cmbVolver.TabIndex = 70;
            this.cmbVolver.Text = "Volver";
            this.cmbVolver.UseVisualStyleBackColor = true;
            this.cmbVolver.Click += new System.EventHandler(this.cmbVolver_Click);
            // 
            // btnGrupoExistente
            // 
            this.btnGrupoExistente.Location = new System.Drawing.Point(20, 177);
            this.btnGrupoExistente.Name = "btnGrupoExistente";
            this.btnGrupoExistente.Size = new System.Drawing.Size(184, 23);
            this.btnGrupoExistente.TabIndex = 69;
            this.btnGrupoExistente.Text = "Unirse a Grupo Existente";
            this.btnGrupoExistente.UseVisualStyleBackColor = true;
            this.btnGrupoExistente.Click += new System.EventHandler(this.btnGrupoExistente_Click);
            // 
            // frmGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 350);
            this.Controls.Add(this.cmbVolver);
            this.Controls.Add(this.btnGrupoExistente);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cmbPlanes);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.t);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label1);
            this.Name = "frmGrupo";
            this.Text = "CLINICA - FRBA - Modificacion de Grupo Familiar";
            this.Load += new System.EventHandler(this.frmGrupo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label t;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPlanes;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button cmbVolver;
        private System.Windows.Forms.Button btnGrupoExistente;
    }
}