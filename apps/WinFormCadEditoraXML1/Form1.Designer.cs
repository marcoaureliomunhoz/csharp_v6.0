namespace WinFormCadEditoraXML1
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxEditoras = new System.Windows.Forms.ListBox();
            this.btnNova = new System.Windows.Forms.Button();
            this.btnRecarregar = new System.Windows.Forms.Button();
            this.panelCadastro = new System.Windows.Forms.Panel();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.panelCadastro.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Editoras";
            // 
            // listBoxEditoras
            // 
            this.listBoxEditoras.FormattingEnabled = true;
            this.listBoxEditoras.ItemHeight = 18;
            this.listBoxEditoras.Location = new System.Drawing.Point(27, 40);
            this.listBoxEditoras.Name = "listBoxEditoras";
            this.listBoxEditoras.Size = new System.Drawing.Size(400, 346);
            this.listBoxEditoras.TabIndex = 9;
            this.listBoxEditoras.DoubleClick += new System.EventHandler(this.listBoxEditoras_DoubleClick);
            this.listBoxEditoras.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listBoxEditoras_KeyUp);
            // 
            // btnNova
            // 
            this.btnNova.Location = new System.Drawing.Point(131, 403);
            this.btnNova.Name = "btnNova";
            this.btnNova.Size = new System.Drawing.Size(98, 33);
            this.btnNova.TabIndex = 12;
            this.btnNova.Text = "Nova";
            this.btnNova.UseVisualStyleBackColor = true;
            this.btnNova.Click += new System.EventHandler(this.btnNova_Click);
            // 
            // btnRecarregar
            // 
            this.btnRecarregar.Location = new System.Drawing.Point(27, 403);
            this.btnRecarregar.Name = "btnRecarregar";
            this.btnRecarregar.Size = new System.Drawing.Size(98, 33);
            this.btnRecarregar.TabIndex = 13;
            this.btnRecarregar.Text = "Recarregar";
            this.btnRecarregar.UseVisualStyleBackColor = true;
            this.btnRecarregar.Click += new System.EventHandler(this.btnRecarregar_Click);
            // 
            // panelCadastro
            // 
            this.panelCadastro.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelCadastro.Controls.Add(this.txtNome);
            this.panelCadastro.Controls.Add(this.label3);
            this.panelCadastro.Controls.Add(this.txtCodigo);
            this.panelCadastro.Controls.Add(this.label2);
            this.panelCadastro.Enabled = false;
            this.panelCadastro.Location = new System.Drawing.Point(450, 40);
            this.panelCadastro.Name = "panelCadastro";
            this.panelCadastro.Size = new System.Drawing.Size(398, 346);
            this.panelCadastro.TabIndex = 14;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(21, 102);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(356, 24);
            this.txtNome.TabIndex = 3;
            this.txtNome.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nome";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(21, 43);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(137, 24);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Código";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Enabled = false;
            this.btnSalvar.Location = new System.Drawing.Point(450, 403);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(98, 33);
            this.btnSalvar.TabIndex = 15;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 460);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.panelCadastro);
            this.Controls.Add(this.btnNova);
            this.Controls.Add(this.btnRecarregar);
            this.Controls.Add(this.listBoxEditoras);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CadEditoraXML1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelCadastro.ResumeLayout(false);
            this.panelCadastro.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxEditoras;
        private System.Windows.Forms.Button btnNova;
        private System.Windows.Forms.Button btnRecarregar;
        private System.Windows.Forms.Panel panelCadastro;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSalvar;
    }
}

