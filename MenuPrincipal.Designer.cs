namespace OLC1_Proyecto1
{
    partial class MenuPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.automataPictureBox = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.anteriorBtn = new System.Windows.Forms.Button();
            this.siguienteBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.abrirBtn = new System.Windows.Forms.Button();
            this.guardarBtn = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ErroresTxt = new System.Windows.Forms.RichTextBox();
            this.TokensTxt = new System.Windows.Forms.RichTextBox();
            this.Automata = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.guardarTokens = new System.Windows.Forms.Button();
            this.guardarErrores = new System.Windows.Forms.Button();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.textEditorTabPage1 = new Practica1LF_AnalizadorLexico.TextEditorTabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.automataPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1494, 807);
            this.label2.Margin = new System.Windows.Forms.Padding(1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(291, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cristian Meoño - 201801397 - COMPILADORES 1S2020";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button1.Location = new System.Drawing.Point(50, 726);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(205, 58);
            this.button1.TabIndex = 3;
            this.button1.Text = "Analizar Expresiones Regulares";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button2.Location = new System.Drawing.Point(451, 726);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(205, 58);
            this.button2.TabIndex = 4;
            this.button2.Text = "Analizar Lexemas";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(50, 94);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(606, 604);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textEditorTabPage1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(598, 574);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Pestaña1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.YellowGreen;
            this.button3.Location = new System.Drawing.Point(468, 24);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(188, 38);
            this.button3.TabIndex = 6;
            this.button3.Text = "Nueva Pestaña";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // automataPictureBox
            // 
            this.automataPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.automataPictureBox.Location = new System.Drawing.Point(693, 120);
            this.automataPictureBox.Name = "automataPictureBox";
            this.automataPictureBox.Size = new System.Drawing.Size(593, 288);
            this.automataPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.automataPictureBox.TabIndex = 7;
            this.automataPictureBox.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(693, 457);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(593, 288);
            this.dataGridView1.TabIndex = 8;
            // 
            // anteriorBtn
            // 
            this.anteriorBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.anteriorBtn.ForeColor = System.Drawing.SystemColors.Highlight;
            this.anteriorBtn.Location = new System.Drawing.Point(815, 23);
            this.anteriorBtn.Name = "anteriorBtn";
            this.anteriorBtn.Size = new System.Drawing.Size(171, 40);
            this.anteriorBtn.TabIndex = 9;
            this.anteriorBtn.Text = "AF Anterior";
            this.anteriorBtn.UseVisualStyleBackColor = true;
            this.anteriorBtn.Click += new System.EventHandler(this.AnteriorBtn_Click);
            // 
            // siguienteBtn
            // 
            this.siguienteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.siguienteBtn.ForeColor = System.Drawing.SystemColors.Highlight;
            this.siguienteBtn.Location = new System.Drawing.Point(1017, 24);
            this.siguienteBtn.Name = "siguienteBtn";
            this.siguienteBtn.Size = new System.Drawing.Size(171, 40);
            this.siguienteBtn.TabIndex = 10;
            this.siguienteBtn.Text = "AF Siguiente";
            this.siguienteBtn.UseVisualStyleBackColor = true;
            this.siguienteBtn.Click += new System.EventHandler(this.SiguienteBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Archivo ER|*.er";
            // 
            // abrirBtn
            // 
            this.abrirBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.abrirBtn.ForeColor = System.Drawing.Color.YellowGreen;
            this.abrirBtn.Location = new System.Drawing.Point(50, 24);
            this.abrirBtn.Name = "abrirBtn";
            this.abrirBtn.Size = new System.Drawing.Size(188, 38);
            this.abrirBtn.TabIndex = 11;
            this.abrirBtn.Text = "Abrir Archivo";
            this.abrirBtn.UseVisualStyleBackColor = true;
            this.abrirBtn.Click += new System.EventHandler(this.AbrirBtn_Click);
            // 
            // guardarBtn
            // 
            this.guardarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.guardarBtn.ForeColor = System.Drawing.Color.YellowGreen;
            this.guardarBtn.Location = new System.Drawing.Point(256, 24);
            this.guardarBtn.Name = "guardarBtn";
            this.guardarBtn.Size = new System.Drawing.Size(188, 38);
            this.guardarBtn.TabIndex = 12;
            this.guardarBtn.Text = "Guardar Archivo";
            this.guardarBtn.UseVisualStyleBackColor = true;
            this.guardarBtn.Click += new System.EventHandler(this.GuardarBtn_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Archivo ER|*.er";
            // 
            // ErroresTxt
            // 
            this.ErroresTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.ErroresTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ErroresTxt.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErroresTxt.Location = new System.Drawing.Point(1320, 120);
            this.ErroresTxt.Name = "ErroresTxt";
            this.ErroresTxt.ReadOnly = true;
            this.ErroresTxt.Size = new System.Drawing.Size(452, 288);
            this.ErroresTxt.TabIndex = 13;
            this.ErroresTxt.Text = "";
            // 
            // TokensTxt
            // 
            this.TokensTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.TokensTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TokensTxt.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.TokensTxt.Location = new System.Drawing.Point(1320, 457);
            this.TokensTxt.Name = "TokensTxt";
            this.TokensTxt.ReadOnly = true;
            this.TokensTxt.Size = new System.Drawing.Size(452, 288);
            this.TokensTxt.TabIndex = 14;
            this.TokensTxt.Text = "";
            // 
            // Automata
            // 
            this.Automata.AutoSize = true;
            this.Automata.Location = new System.Drawing.Point(689, 96);
            this.Automata.Name = "Automata";
            this.Automata.Size = new System.Drawing.Size(94, 21);
            this.Automata.TabIndex = 15;
            this.Automata.Text = "Automata";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(689, 433);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 21);
            this.label1.TabIndex = 16;
            this.label1.Text = "Tabla de Transiciones";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1316, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 21);
            this.label3.TabIndex = 17;
            this.label3.Text = "Errores";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1319, 433);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 21);
            this.label4.TabIndex = 18;
            this.label4.Text = "Tokens";
            // 
            // guardarTokens
            // 
            this.guardarTokens.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.guardarTokens.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guardarTokens.ForeColor = System.Drawing.Color.Goldenrod;
            this.guardarTokens.Location = new System.Drawing.Point(1653, 426);
            this.guardarTokens.Name = "guardarTokens";
            this.guardarTokens.Size = new System.Drawing.Size(119, 25);
            this.guardarTokens.TabIndex = 19;
            this.guardarTokens.Text = "Guardar XML";
            this.guardarTokens.UseVisualStyleBackColor = true;
            this.guardarTokens.Click += new System.EventHandler(this.GuardarTokens_Click);
            // 
            // guardarErrores
            // 
            this.guardarErrores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.guardarErrores.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guardarErrores.ForeColor = System.Drawing.Color.Goldenrod;
            this.guardarErrores.Location = new System.Drawing.Point(1653, 89);
            this.guardarErrores.Name = "guardarErrores";
            this.guardarErrores.Size = new System.Drawing.Size(119, 25);
            this.guardarErrores.TabIndex = 20;
            this.guardarErrores.Text = "Guardar XML";
            this.guardarErrores.UseVisualStyleBackColor = true;
            this.guardarErrores.Click += new System.EventHandler(this.GuardarErrores_Click);
            // 
            // saveFileDialog2
            // 
            this.saveFileDialog2.Filter = "Archivo XML | .xml";
            // 
            // textEditorTabPage1
            // 
            this.textEditorTabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textEditorTabPage1.Location = new System.Drawing.Point(0, 0);
            this.textEditorTabPage1.Margin = new System.Windows.Forms.Padding(5);
            this.textEditorTabPage1.Name = "textEditorTabPage1";
            this.textEditorTabPage1.Size = new System.Drawing.Size(605, 575);
            this.textEditorTabPage1.TabIndex = 0;
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(1784, 821);
            this.Controls.Add(this.guardarErrores);
            this.Controls.Add(this.guardarTokens);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Automata);
            this.Controls.Add(this.TokensTxt);
            this.Controls.Add(this.ErroresTxt);
            this.Controls.Add(this.guardarBtn);
            this.Controls.Add(this.abrirBtn);
            this.Controls.Add(this.siguienteBtn);
            this.Controls.Add(this.anteriorBtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.automataPictureBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Principal";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.automataPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabPage tabPage1;
        private Practica1LF_AnalizadorLexico.TextEditorTabPage textEditorTabPage1;
        private System.Windows.Forms.PictureBox automataPictureBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button anteriorBtn;
        private System.Windows.Forms.Button siguienteBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button abrirBtn;
        private System.Windows.Forms.Button guardarBtn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.RichTextBox ErroresTxt;
        private System.Windows.Forms.RichTextBox TokensTxt;
        private System.Windows.Forms.Label Automata;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button guardarTokens;
        private System.Windows.Forms.Button guardarErrores;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
    }
}

