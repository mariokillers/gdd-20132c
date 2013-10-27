namespace Clinica_Frba
{
    partial class frmPrincipal
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
            this.ToolStrip = new System.Windows.Forms.MenuStrip();
            this.cmdAfiliado = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdAfiliadoAlta = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdAfiliadoModificacion = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdAfiliadoBaja = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdProfesional = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdRol = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdRolAlta = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdRolModificacion = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdRolBaja = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStrip
            // 
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdAfiliado,
            this.cmdProfesional,
            this.cmdRol});
            this.ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(284, 24);
            this.ToolStrip.TabIndex = 0;
            this.ToolStrip.Text = "menuStrip1";
            // 
            // cmdAfiliado
            // 
            this.cmdAfiliado.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdAfiliadoAlta,
            this.cmdAfiliadoModificacion,
            this.cmdAfiliadoBaja});
            this.cmdAfiliado.Name = "cmdAfiliado";
            this.cmdAfiliado.Size = new System.Drawing.Size(60, 20);
            this.cmdAfiliado.Text = "Afiliado";
            // 
            // cmdAfiliadoAlta
            // 
            this.cmdAfiliadoAlta.Name = "cmdAfiliadoAlta";
            this.cmdAfiliadoAlta.Size = new System.Drawing.Size(144, 22);
            this.cmdAfiliadoAlta.Text = "Alta";
            this.cmdAfiliadoAlta.Click += new System.EventHandler(this.altaToolStripMenuItem_Click);
            // 
            // cmdAfiliadoModificacion
            // 
            this.cmdAfiliadoModificacion.Name = "cmdAfiliadoModificacion";
            this.cmdAfiliadoModificacion.Size = new System.Drawing.Size(144, 22);
            this.cmdAfiliadoModificacion.Text = "Modificacion";
            // 
            // cmdAfiliadoBaja
            // 
            this.cmdAfiliadoBaja.Name = "cmdAfiliadoBaja";
            this.cmdAfiliadoBaja.Size = new System.Drawing.Size(144, 22);
            this.cmdAfiliadoBaja.Text = "Baja";
            // 
            // cmdProfesional
            // 
            this.cmdProfesional.Name = "cmdProfesional";
            this.cmdProfesional.Size = new System.Drawing.Size(78, 20);
            this.cmdProfesional.Text = "Profesional";
            // 
            // cmdRol
            // 
            this.cmdRol.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdRolAlta,
            this.cmdRolModificacion,
            this.cmdRolBaja});
            this.cmdRol.Name = "cmdRol";
            this.cmdRol.Size = new System.Drawing.Size(36, 20);
            this.cmdRol.Text = "Rol";
            // 
            // cmdRolAlta
            // 
            this.cmdRolAlta.Name = "cmdRolAlta";
            this.cmdRolAlta.Size = new System.Drawing.Size(144, 22);
            this.cmdRolAlta.Text = "Alta";
            this.cmdRolAlta.Click += new System.EventHandler(this.cmdRolAlta_Click);
            // 
            // cmdRolModificacion
            // 
            this.cmdRolModificacion.Name = "cmdRolModificacion";
            this.cmdRolModificacion.Size = new System.Drawing.Size(144, 22);
            this.cmdRolModificacion.Text = "Modificacion";
            this.cmdRolModificacion.Click += new System.EventHandler(this.modificacionToolStripMenuItem1_Click);
            // 
            // cmdRolBaja
            // 
            this.cmdRolBaja.Name = "cmdRolBaja";
            this.cmdRolBaja.Size = new System.Drawing.Size(144, 22);
            this.cmdRolBaja.Text = "Baja";
            this.cmdRolBaja.Click += new System.EventHandler(this.bajaToolStripMenuItem1_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.ToolStrip);
            this.MainMenuStrip = this.ToolStrip;
            this.Name = "frmPrincipal";
            this.Text = "Bienvenido!";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip ToolStrip;
        private System.Windows.Forms.ToolStripMenuItem cmdAfiliado;
        private System.Windows.Forms.ToolStripMenuItem cmdProfesional;
        private System.Windows.Forms.ToolStripMenuItem cmdRol;
        private System.Windows.Forms.ToolStripMenuItem cmdAfiliadoAlta;
        private System.Windows.Forms.ToolStripMenuItem cmdAfiliadoModificacion;
        private System.Windows.Forms.ToolStripMenuItem cmdAfiliadoBaja;
        private System.Windows.Forms.ToolStripMenuItem cmdRolAlta;
        private System.Windows.Forms.ToolStripMenuItem cmdRolModificacion;
        private System.Windows.Forms.ToolStripMenuItem cmdRolBaja;


    }
}

