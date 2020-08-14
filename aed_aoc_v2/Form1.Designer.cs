namespace aed_aoc_v2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Ram = new System.Windows.Forms.DataGridView();
            this.Cache = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.BotaoGO = new System.Windows.Forms.Button();
            this.BotaoAcessar = new System.Windows.Forms.Button();
            this.hit_miss = new System.Windows.Forms.Label();
            this.Botao_Sair = new System.Windows.Forms.Button();
            this.Botao_Limpar = new System.Windows.Forms.Button();
            this.labelSequencia = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Botao_Eficiencia = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Ram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cache)).BeginInit();
            this.SuspendLayout();
            // 
            // Ram
            // 
            this.Ram.BackgroundColor = System.Drawing.Color.White;
            this.Ram.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Ram.Location = new System.Drawing.Point(68, 181);
            this.Ram.Name = "Ram";
            this.Ram.Size = new System.Drawing.Size(338, 416);
            this.Ram.TabIndex = 31;
            // 
            // Cache
            // 
            this.Cache.AllowUserToDeleteRows = false;
            this.Cache.AllowUserToResizeColumns = false;
            this.Cache.AllowUserToResizeRows = false;
            this.Cache.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Cache.BackgroundColor = System.Drawing.Color.White;
            this.Cache.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Cache.Location = new System.Drawing.Point(621, 181);
            this.Cache.MultiSelect = false;
            this.Cache.Name = "Cache";
            this.Cache.ReadOnly = true;
            this.Cache.ShowCellErrors = false;
            this.Cache.ShowCellToolTips = false;
            this.Cache.ShowEditingIcon = false;
            this.Cache.ShowRowErrors = false;
            this.Cache.Size = new System.Drawing.Size(588, 416);
            this.Cache.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(70, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 37);
            this.label1.TabIndex = 34;
            this.label1.Text = "RAM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(636, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 37);
            this.label2.TabIndex = 35;
            this.label2.Text = "CACHE";
            // 
            // label4
            // 
            this.label4.AllowDrop = true;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(73, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 24);
            this.label4.TabIndex = 37;
            this.label4.Text = "Ram:";
            // 
            // label5
            // 
            this.label5.AllowDrop = true;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label5.Location = new System.Drawing.Point(64, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 24);
            this.label5.TabIndex = 38;
            this.label5.Text = "Bloco:";
            // 
            // label6
            // 
            this.label6.AllowDrop = true;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label6.Location = new System.Drawing.Point(270, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 24);
            this.label6.TabIndex = 39;
            this.label6.Text = "Algorítmo:";
            // 
            // label7
            // 
            this.label7.AllowDrop = true;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label7.Location = new System.Drawing.Point(325, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 24);
            this.label7.TabIndex = 40;
            this.label7.Text = "N:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(133, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 41;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(133, 48);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 42;
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteCustomSource.AddRange(new string[] {
            "FIFO",
            "LFU",
            "LRU"});
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "FIFO",
            "LRU",
            "LFU"});
            this.comboBox1.Location = new System.Drawing.Point(371, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 21);
            this.comboBox1.TabIndex = 43;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(371, 48);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 44;
            // 
            // label8
            // 
            this.label8.AllowDrop = true;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label8.Location = new System.Drawing.Point(617, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 24);
            this.label8.TabIndex = 45;
            this.label8.Text = "Cache: ";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(685, 12);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 46;
            // 
            // BotaoGO
            // 
            this.BotaoGO.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BotaoGO.Location = new System.Drawing.Point(864, 34);
            this.BotaoGO.Name = "BotaoGO";
            this.BotaoGO.Size = new System.Drawing.Size(75, 23);
            this.BotaoGO.TabIndex = 47;
            this.BotaoGO.Text = "Go";
            this.BotaoGO.UseVisualStyleBackColor = true;
            this.BotaoGO.Click += new System.EventHandler(this.BotaoGO_Click);
            // 
            // BotaoAcessar
            // 
            this.BotaoAcessar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BotaoAcessar.Location = new System.Drawing.Point(481, 361);
            this.BotaoAcessar.Name = "BotaoAcessar";
            this.BotaoAcessar.Size = new System.Drawing.Size(75, 23);
            this.BotaoAcessar.TabIndex = 48;
            this.BotaoAcessar.Text = "Acessar";
            this.BotaoAcessar.UseVisualStyleBackColor = true;
            this.BotaoAcessar.Click += new System.EventHandler(this.BotaoAcessar_Click);
            // 
            // hit_miss
            // 
            this.hit_miss.AutoSize = true;
            this.hit_miss.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hit_miss.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.hit_miss.Location = new System.Drawing.Point(1134, 24);
            this.hit_miss.Name = "hit_miss";
            this.hit_miss.Size = new System.Drawing.Size(0, 31);
            this.hit_miss.TabIndex = 50;
            // 
            // Botao_Sair
            // 
            this.Botao_Sair.Cursor = System.Windows.Forms.Cursors.Default;
            this.Botao_Sair.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Botao_Sair.Location = new System.Drawing.Point(68, 618);
            this.Botao_Sair.Name = "Botao_Sair";
            this.Botao_Sair.Size = new System.Drawing.Size(75, 23);
            this.Botao_Sair.TabIndex = 52;
            this.Botao_Sair.Text = "Sair";
            this.Botao_Sair.UseVisualStyleBackColor = true;
            this.Botao_Sair.Click += new System.EventHandler(this.Botao_Sair_Click_1);
            // 
            // Botao_Limpar
            // 
            this.Botao_Limpar.Cursor = System.Windows.Forms.Cursors.Default;
            this.Botao_Limpar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Botao_Limpar.Location = new System.Drawing.Point(1134, 618);
            this.Botao_Limpar.Name = "Botao_Limpar";
            this.Botao_Limpar.Size = new System.Drawing.Size(75, 23);
            this.Botao_Limpar.TabIndex = 53;
            this.Botao_Limpar.Text = "Limpar";
            this.Botao_Limpar.UseVisualStyleBackColor = true;
            this.Botao_Limpar.Click += new System.EventHandler(this.Botao_Limpar_Click);
            // 
            // labelSequencia
            // 
            this.labelSequencia.AutoEllipsis = true;
            this.labelSequencia.AutoSize = true;
            this.labelSequencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSequencia.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelSequencia.Location = new System.Drawing.Point(618, 84);
            this.labelSequencia.Name = "labelSequencia";
            this.labelSequencia.Size = new System.Drawing.Size(0, 13);
            this.labelSequencia.TabIndex = 54;
            // 
            // Botao_Eficiencia
            // 
            this.Botao_Eficiencia.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Botao_Eficiencia.Location = new System.Drawing.Point(481, 618);
            this.Botao_Eficiencia.Name = "Botao_Eficiencia";
            this.Botao_Eficiencia.Size = new System.Drawing.Size(75, 23);
            this.Botao_Eficiencia.TabIndex = 55;
            this.Botao_Eficiencia.Text = "Eficiencia";
            this.Botao_Eficiencia.UseVisualStyleBackColor = true;
            this.Botao_Eficiencia.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 653);
            this.Controls.Add(this.Botao_Eficiencia);
            this.Controls.Add(this.labelSequencia);
            this.Controls.Add(this.Botao_Limpar);
            this.Controls.Add(this.Botao_Sair);
            this.Controls.Add(this.hit_miss);
            this.Controls.Add(this.BotaoAcessar);
            this.Controls.Add(this.BotaoGO);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cache);
            this.Controls.Add(this.Ram);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Simulador - Desenvolvido por Arthur Luiz e Grabrielle Rosane";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Ram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cache)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView Ram;
        private System.Windows.Forms.DataGridView Cache;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button BotaoGO;
        private System.Windows.Forms.Button BotaoAcessar;
        private System.Windows.Forms.Label hit_miss;
        private System.Windows.Forms.Button Botao_Sair;
        private System.Windows.Forms.Button Botao_Limpar;
        private System.Windows.Forms.Label labelSequencia;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Botao_Eficiencia;
    }
}

