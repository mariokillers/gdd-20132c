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
            this.menu = new System.Windows.Forms.MenuStrip();
            this.cmdAfiliado = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdAfiliadoAlta = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdAfiliadoModificacion = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdAfiliadoBaja = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdProfesional = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdProfAlta = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdProfMod = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdProfBaja = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdRol = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdRolAlta = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdRolModificacion = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdRolBaja = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdAgenda = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarAgendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarAgendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdEstadisticas = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdTurnos = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdCompraDeBonos = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdLogOut = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbRoles = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdIngresar = new System.Windows.Forms.Button();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdAfiliado,
            this.cmdProfesional,
            this.cmdRol,
            this.cmdAgenda,
            this.cmdEstadisticas,
            this.cmdTurnos,
            this.cmdCompraDeBonos,
            this.cmdLogOut});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(743, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menu";
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
            this.cmdAfiliadoAlta.Click += new System.EventHandler(this.cmdAfiliadoAlta_Click_1);
            // 
            // cmdAfiliadoModificacion
            // 
            this.cmdAfiliadoModificacion.Name = "cmdAfiliadoModificacion";
            this.cmdAfiliadoModificacion.Size = new System.Drawing.Size(144, 22);
            this.cmdAfiliadoModificacion.Text = "Modificacion";
            this.cmdAfiliadoModificacion.Click += new System.EventHandler(this.cmdAfiliadoModificacion_Click);
            // 
            // cmdAfiliadoBaja
            // 
            this.cmdAfiliadoBaja.Name = "cmdAfiliadoBaja";
            this.cmdAfiliadoBaja.Size = new System.Drawing.Size(144, 22);
            this.cmdAfiliadoBaja.Text = "Baja";
            this.cmdAfiliadoBaja.Click += new System.EventHandler(this.cmdAfiliadoBaja_Click);
            // 
            // cmdProfesional
            // 
            this.cmdProfesional.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdProfAlta,
            this.cmdProfMod,
            this.cmdProfBaja});
            this.cmdProfesional.Name = "cmdProfesional";
            this.cmdProfesional.Size = new System.Drawing.Size(78, 20);
            this.cmdProfesional.Text = "Profesional";
            // 
            // cmdProfAlta
            // 
            this.cmdProfAlta.Name = "cmdProfAlta";
            this.cmdProfAlta.Size = new System.Drawing.Size(152, 22);
            this.cmdProfAlta.Text = "Alta";
            this.cmdProfAlta.Click += new System.EventHandler(this.cmdProfAlta_Click);
            // 
            // cmdProfMod
            // 
            this.cmdProfMod.Name = "cmdProfMod";
            this.cmdProfMod.Size = new System.Drawing.Size(152, 22);
            this.cmdProfMod.Text = "Modificacion";
            this.cmdProfMod.Click += new System.EventHandler(this.cmdProfMod_Click);
            // 
            // cmdProfBaja
            // 
            this.cmdProfBaja.Name = "cmdProfBaja";
            this.cmdProfBaja.Size = new System.Drawing.Size(152, 22);
            this.cmdProfBaja.Text = "Baja";
            this.cmdProfBaja.Click += new System.EventHandler(this.cmdProfBaja_Click);
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
            this.cmdRolAlta.Size = new System.Drawing.Size(196, 22);
            this.cmdRolAlta.Text = "Alta";
            this.cmdRolAlta.Click += new System.EventHandler(this.cmdRolAlta_Click);
            // 
            // cmdRolModificacion
            // 
            this.cmdRolModificacion.Name = "cmdRolModificacion";
            this.cmdRolModificacion.Size = new System.Drawing.Size(196, 22);
            this.cmdRolModificacion.Text = "Consulta/Modificacion";
            this.cmdRolModificacion.Click += new System.EventHandler(this.cmdRolModificacion_Click_1);
            // 
            // cmdRolBaja
            // 
            this.cmdRolBaja.Name = "cmdRolBaja";
            this.cmdRolBaja.Size = new System.Drawing.Size(196, 22);
            this.cmdRolBaja.Text = "Baja";
            this.cmdRolBaja.Click += new System.EventHandler(this.cmdRolBaja_Click_1);
            // 
            // cmdAgenda
            // 
            this.cmdAgenda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarAgendaToolStripMenuItem,
            this.consultarAgendaToolStripMenuItem});
            this.cmdAgenda.Name = "cmdAgenda";
            this.cmdAgenda.Size = new System.Drawing.Size(122, 20);
            this.cmdAgenda.Text = "Agenda Profesional";
            // 
            // registrarAgendaToolStripMenuItem
            // 
            this.registrarAgendaToolStripMenuItem.Name = "registrarAgendaToolStripMenuItem";
            this.registrarAgendaToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.registrarAgendaToolStripMenuItem.Text = "Registrar Agenda";
            this.registrarAgendaToolStripMenuItem.Click += new System.EventHandler(this.registrarAgendaToolStripMenuItem_Click);
            // 
            // consultarAgendaToolStripMenuItem
            // 
            this.consultarAgendaToolStripMenuItem.Name = "consultarAgendaToolStripMenuItem";
            this.consultarAgendaToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.consultarAgendaToolStripMenuItem.Text = "Consultar Agenda";
            this.consultarAgendaToolStripMenuItem.Click += new System.EventHandler(this.consultarAgendaToolStripMenuItem_Click);
            // 
            // cmdEstadisticas
            // 
            this.cmdEstadisticas.Name = "cmdEstadisticas";
            this.cmdEstadisticas.Size = new System.Drawing.Size(79, 20);
            this.cmdEstadisticas.Text = "Estadisticas";
            // 
            // cmdTurnos
            // 
            this.cmdTurnos.Name = "cmdTurnos";
            this.cmdTurnos.Size = new System.Drawing.Size(56, 20);
            this.cmdTurnos.Text = "Turnos";
            // 
            // cmdCompraDeBonos
            // 
            this.cmdCompraDeBonos.Name = "cmdCompraDeBonos";
            this.cmdCompraDeBonos.Size = new System.Drawing.Size(114, 20);
            this.cmdCompraDeBonos.Text = "Compra de Bonos";
            this.cmdCompraDeBonos.Click += new System.EventHandler(this.cmdCompraDeBonos_Click);
            // 
            // cmdLogOut
            // 
            this.cmdLogOut.Name = "cmdLogOut";
            this.cmdLogOut.Size = new System.Drawing.Size(87, 20);
            this.cmdLogOut.Text = "Cerrar sesion";
            this.cmdLogOut.Click += new System.EventHandler(this.cmdLogOut_Click);
            // 
            // cmbRoles
            // 
            this.cmbRoles.FormattingEnabled = true;
            this.cmbRoles.Location = new System.Drawing.Point(195, 102);
            this.cmbRoles.Name = "cmbRoles";
            this.cmbRoles.Size = new System.Drawing.Size(119, 21);
            this.cmbRoles.TabIndex = 1;
            this.cmbRoles.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(208, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seleccione un rol:";
            this.label1.Visible = false;
            // 
            // cmdIngresar
            // 
            this.cmdIngresar.Location = new System.Drawing.Point(214, 129);
            this.cmdIngresar.Name = "cmdIngresar";
            this.cmdIngresar.Size = new System.Drawing.Size(75, 23);
            this.cmdIngresar.TabIndex = 3;
            this.cmdIngresar.Text = "Ingresar";
            this.cmdIngresar.UseVisualStyleBackColor = true;
            this.cmdIngresar.Visible = false;
            this.cmdIngresar.Click += new System.EventHandler(this.cmdIngresar_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 270);
            this.Controls.Add(this.cmdIngresar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbRoles);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "frmPrincipal";
            this.Text = "Bienvenido!";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem cmdAfiliado;
        private System.Windows.Forms.ToolStripMenuItem cmdProfesional;
        private System.Windows.Forms.ToolStripMenuItem cmdRol;
        private System.Windows.Forms.ToolStripMenuItem cmdAfiliadoAlta;
        private System.Windows.Forms.ToolStripMenuItem cmdAfiliadoModificacion;
        private System.Windows.Forms.ToolStripMenuItem cmdAfiliadoBaja;
        private System.Windows.Forms.ToolStripMenuItem cmdRolAlta;
        private System.Windows.Forms.ToolStripMenuItem cmdRolModificacion;
        private System.Windows.Forms.ToolStripMenuItem cmdRolBaja;
        private System.Windows.Forms.ToolStripMenuItem cmdAgenda;
        private System.Windows.Forms.ToolStripMenuItem cmdProfAlta;
        private System.Windows.Forms.ToolStripMenuItem cmdProfMod;
        private System.Windows.Forms.ToolStripMenuItem cmdProfBaja;
        private System.Windows.Forms.ComboBox cmbRoles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdIngresar;
        private System.Windows.Forms.ToolStripMenuItem cmdEstadisticas;
        private System.Windows.Forms.ToolStripMenuItem cmdLogOut;
        private System.Windows.Forms.ToolStripMenuItem registrarAgendaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmdTurnos;
        private System.Windows.Forms.ToolStripMenuItem consultarAgendaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmdCompraDeBonos;


    }
}

