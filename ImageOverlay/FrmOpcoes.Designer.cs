namespace ImageOverlay
{
    partial class FrmOpcoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOpcoes));
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtLocalImagem = new System.Windows.Forms.TextBox();
            this.BtnProcurar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ChkSkype = new System.Windows.Forms.CheckBox();
            this.linkLblSobre = new System.Windows.Forms.LinkLabel();
            this.ChkStartupWindows = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(91, 184);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(75, 23);
            this.BtnGuardar.TabIndex = 9;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(284, 184);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(75, 23);
            this.BtnCancelar.TabIndex = 10;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Localização:";
            // 
            // TxtLocalImagem
            // 
            this.TxtLocalImagem.Location = new System.Drawing.Point(79, 23);
            this.TxtLocalImagem.Name = "TxtLocalImagem";
            this.TxtLocalImagem.ReadOnly = true;
            this.TxtLocalImagem.Size = new System.Drawing.Size(268, 20);
            this.TxtLocalImagem.TabIndex = 3;
            // 
            // BtnProcurar
            // 
            this.BtnProcurar.Location = new System.Drawing.Point(360, 21);
            this.BtnProcurar.Name = "BtnProcurar";
            this.BtnProcurar.Size = new System.Drawing.Size(75, 23);
            this.BtnProcurar.TabIndex = 4;
            this.BtnProcurar.Text = "Procurar...";
            this.BtnProcurar.UseVisualStyleBackColor = true;
            this.BtnProcurar.Click += new System.EventHandler(this.BtnProcurar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BtnProcurar);
            this.groupBox1.Controls.Add(this.TxtLocalImagem);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(441, 59);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Imagem";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ChkSkype);
            this.groupBox2.Controls.Add(this.linkLblSobre);
            this.groupBox2.Controls.Add(this.ChkStartupWindows);
            this.groupBox2.Location = new System.Drawing.Point(12, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(441, 78);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Outras Opções";
            // 
            // ChkSkype
            // 
            this.ChkSkype.AutoSize = true;
            this.ChkSkype.Location = new System.Drawing.Point(9, 43);
            this.ChkSkype.Name = "ChkSkype";
            this.ChkSkype.Size = new System.Drawing.Size(152, 17);
            this.ChkSkype.TabIndex = 7;
            this.ChkSkype.Text = "Mostrar somente no Skype";
            this.ChkSkype.UseVisualStyleBackColor = true;
            // 
            // linkLblSobre
            // 
            this.linkLblSobre.AutoSize = true;
            this.linkLblSobre.Location = new System.Drawing.Point(332, 47);
            this.linkLblSobre.Name = "linkLblSobre";
            this.linkLblSobre.Size = new System.Drawing.Size(103, 13);
            this.linkLblSobre.TabIndex = 8;
            this.linkLblSobre.TabStop = true;
            this.linkLblSobre.Text = "Sobre a Aplicação...";
            this.linkLblSobre.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblSobre_LinkClicked);
            // 
            // ChkStartupWindows
            // 
            this.ChkStartupWindows.AutoSize = true;
            this.ChkStartupWindows.Location = new System.Drawing.Point(9, 20);
            this.ChkStartupWindows.Name = "ChkStartupWindows";
            this.ChkStartupWindows.Size = new System.Drawing.Size(229, 17);
            this.ChkStartupWindows.TabIndex = 6;
            this.ChkStartupWindows.Text = "Arrancar automaticamente com o Windows";
            this.ChkStartupWindows.UseVisualStyleBackColor = true;
            // 
            // FrmOpcoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 224);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnGuardar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOpcoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Opções";
            this.Load += new System.EventHandler(this.FrmOpcoes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtLocalImagem;
        private System.Windows.Forms.Button BtnProcurar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox ChkStartupWindows;
        private System.Windows.Forms.LinkLabel linkLblSobre;
        private System.Windows.Forms.CheckBox ChkSkype;
    }
}