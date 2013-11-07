namespace Clinica_Frba.Abm_de_Afiliado
{
    partial class frmAfiliadoModificacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAfiliadoModificacion));
            Clinica_Frba.Clases.Sexo sexo250 = new Clinica_Frba.Clases.Sexo();
            Clinica_Frba.Clases.Sexo sexo251 = new Clinica_Frba.Clases.Sexo();
            Clinica_Frba.Clases.Sexo sexo252 = new Clinica_Frba.Clases.Sexo();
            Clinica_Frba.Clases.Estado estado499 = new Clinica_Frba.Clases.Estado();
            Clinica_Frba.Clases.Estado estado500 = new Clinica_Frba.Clases.Estado();
            Clinica_Frba.Clases.Estado estado501 = new Clinica_Frba.Clases.Estado();
            Clinica_Frba.Clases.Estado estado502 = new Clinica_Frba.Clases.Estado();
            Clinica_Frba.Clases.Estado estado503 = new Clinica_Frba.Clases.Estado();
            Clinica_Frba.Clases.Estado estado504 = new Clinica_Frba.Clases.Estado();
            Clinica_Frba.Clases.TipoDoc tipoDoc416 = new Clinica_Frba.Clases.TipoDoc();
            Clinica_Frba.Clases.TipoDoc tipoDoc417 = new Clinica_Frba.Clases.TipoDoc();
            Clinica_Frba.Clases.TipoDoc tipoDoc418 = new Clinica_Frba.Clases.TipoDoc();
            Clinica_Frba.Clases.TipoDoc tipoDoc419 = new Clinica_Frba.Clases.TipoDoc();
            Clinica_Frba.Clases.TipoDoc tipoDoc420 = new Clinica_Frba.Clases.TipoDoc();
            Clinica_Frba.Clases.Plan plan416 = new Clinica_Frba.Clases.Plan();
            Clinica_Frba.Clases.Plan plan417 = new Clinica_Frba.Clases.Plan();
            Clinica_Frba.Clases.Plan plan418 = new Clinica_Frba.Clases.Plan();
            Clinica_Frba.Clases.Plan plan419 = new Clinica_Frba.Clases.Plan();
            Clinica_Frba.Clases.Plan plan420 = new Clinica_Frba.Clases.Plan();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbSexo
            // 
            this.cmbSexo.DisplayMember = "Id";
            sexo250.Id = "X";
            sexo251.Id = "M";
            sexo252.Id = "F";
            this.cmbSexo.Items.AddRange(new object[] {
            sexo250,
            sexo251,
            sexo252});
            this.cmbSexo.ValueMember = "Id";
            // 
            // cmbEstadoCivil
            // 
            this.cmbEstadoCivil.DisplayMember = "Estado_Civil";
            estado499.Estado_Civil = "Soltero/a";
            estado499.Id = new decimal(new int[] {
            1,
            0,
            0,
            0});
            estado500.Estado_Civil = "Casado/a";
            estado500.Id = new decimal(new int[] {
            2,
            0,
            0,
            0});
            estado501.Estado_Civil = "Viudo/a";
            estado501.Id = new decimal(new int[] {
            3,
            0,
            0,
            0});
            estado502.Estado_Civil = "Concubinato";
            estado502.Id = new decimal(new int[] {
            4,
            0,
            0,
            0});
            estado503.Estado_Civil = "Divorciado/a";
            estado503.Id = new decimal(new int[] {
            5,
            0,
            0,
            0});
            estado504.Estado_Civil = "X";
            estado504.Id = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.cmbEstadoCivil.Items.AddRange(new object[] {
            estado499,
            estado500,
            estado501,
            estado502,
            estado503,
            estado504});
            this.cmbEstadoCivil.ValueMember = "Id";
            // 
            // cmbTipoDoc
            // 
            this.cmbTipoDoc.DisplayMember = "Descripcion";
            tipoDoc416.Descripcion = "DNI";
            tipoDoc416.Id = new decimal(new int[] {
            1,
            0,
            0,
            0});
            tipoDoc417.Descripcion = "CI";
            tipoDoc417.Id = new decimal(new int[] {
            2,
            0,
            0,
            0});
            tipoDoc418.Descripcion = "LC";
            tipoDoc418.Id = new decimal(new int[] {
            3,
            0,
            0,
            0});
            tipoDoc419.Descripcion = "LE";
            tipoDoc419.Id = new decimal(new int[] {
            4,
            0,
            0,
            0});
            tipoDoc420.Descripcion = "X";
            tipoDoc420.Id = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.cmbTipoDoc.Items.AddRange(new object[] {
            tipoDoc416,
            tipoDoc417,
            tipoDoc418,
            tipoDoc419,
            tipoDoc420});
            this.cmbTipoDoc.ValueMember = "Id";
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click_1);
            // 
            // cmbPlanes
            // 
            this.cmbPlanes.DisplayMember = "Descripcion";
            plan416.Codigo = new decimal(new int[] {
            555555,
            0,
            0,
            0});
            plan416.Descripcion = "Plan Medico 110";
            plan416.Precio_Bono_Consulta = new decimal(new int[] {
            96,
            0,
            0,
            0});
            plan416.Precio_Bono_Farmacia = new decimal(new int[] {
            92,
            0,
            0,
            0});
            plan417.Codigo = new decimal(new int[] {
            555556,
            0,
            0,
            0});
            plan417.Descripcion = "Plan Medico 120";
            plan417.Precio_Bono_Consulta = new decimal(new int[] {
            66,
            0,
            0,
            0});
            plan417.Precio_Bono_Farmacia = new decimal(new int[] {
            74,
            0,
            0,
            0});
            plan418.Codigo = new decimal(new int[] {
            555557,
            0,
            0,
            0});
            plan418.Descripcion = "Plan Medico 130";
            plan418.Precio_Bono_Consulta = new decimal(new int[] {
            42,
            0,
            0,
            0});
            plan418.Precio_Bono_Farmacia = new decimal(new int[] {
            45,
            0,
            0,
            0});
            plan419.Codigo = new decimal(new int[] {
            555558,
            0,
            0,
            0});
            plan419.Descripcion = "Plan Medico 140";
            plan419.Precio_Bono_Consulta = new decimal(new int[] {
            28,
            0,
            0,
            0});
            plan419.Precio_Bono_Farmacia = new decimal(new int[] {
            39,
            0,
            0,
            0});
            plan420.Codigo = new decimal(new int[] {
            555559,
            0,
            0,
            0});
            plan420.Descripcion = "Plan Medico 150";
            plan420.Precio_Bono_Consulta = new decimal(new int[] {
            0,
            0,
            0,
            0});
            plan420.Precio_Bono_Farmacia = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cmbPlanes.Items.AddRange(new object[] {
            plan416,
            plan417,
            plan418,
            plan419,
            plan420});
            this.cmbPlanes.ValueMember = "Codigo";
            // 
            // frmAfiliadoModificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 482);
            this.Name = "frmAfiliadoModificacion";
            this.Text = "frmAfiliadoModificacion";
            this.Load += new System.EventHandler(this.frmAfiliadoModificacion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}