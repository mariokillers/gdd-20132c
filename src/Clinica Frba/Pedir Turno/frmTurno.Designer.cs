namespace Clinica_Frba.Pedir_Turno
{
    partial class frmTurno
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
            this.label5 = new System.Windows.Forms.Label();
            this.btnAction = new System.Windows.Forms.Button();
            this.grillaHorarios = new System.Windows.Forms.DataGridView();
            this.cmdBuscar = new System.Windows.Forms.Button();
            this.dtpFechas = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grillaHorarios)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Seleccione Fecha de Turno:";
            // 
            // btnAction
            // 
            this.btnAction.Location = new System.Drawing.Point(27, 357);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(100, 34);
            this.btnAction.TabIndex = 18;
            this.btnAction.Text = "Confirmar";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // grillaHorarios
            // 
            this.grillaHorarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grillaHorarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaHorarios.Location = new System.Drawing.Point(27, 144);
            this.grillaHorarios.Name = "grillaHorarios";
            this.grillaHorarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grillaHorarios.Size = new System.Drawing.Size(427, 196);
            this.grillaHorarios.TabIndex = 17;
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.Location = new System.Drawing.Point(27, 87);
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(100, 23);
            this.cmdBuscar.TabIndex = 16;
            this.cmdBuscar.Text = "Buscar Horarios";
            this.cmdBuscar.UseVisualStyleBackColor = true;
            this.cmdBuscar.Click += new System.EventHandler(this.cmdBuscar_Click);
            // 
            // dtpFechas
            // 
            this.dtpFechas.Location = new System.Drawing.Point(27, 44);
            this.dtpFechas.Name = "dtpFechas";
            this.dtpFechas.Size = new System.Drawing.Size(215, 20);
            this.dtpFechas.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Seleccione Horario de Turno:";
            // 
            // frmTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 401);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFechas);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.grillaHorarios);
            this.Controls.Add(this.cmdBuscar);
            this.Controls.Add(this.label5);
            this.Name = "frmTurno";
            this.Text = "frmTurno";
            this.Load += new System.EventHandler(this.frmTurno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaHorarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.DataGridView grillaHorarios;
        private System.Windows.Forms.Button cmdBuscar;
        private System.Windows.Forms.DateTimePicker dtpFechas;
        private System.Windows.Forms.Label label1;
    }
}