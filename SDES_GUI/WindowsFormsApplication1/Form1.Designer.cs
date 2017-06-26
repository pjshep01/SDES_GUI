namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.encryptButton = new System.Windows.Forms.Button();
            this.decryptButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.encryptThisString = new System.Windows.Forms.TextBox();
            this.decryptThisString = new System.Windows.Forms.TextBox();
            this.keyText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.decryptedString = new System.Windows.Forms.TextBox();
            this.encryptedString = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // encryptButton
            // 
            this.encryptButton.Location = new System.Drawing.Point(392, 110);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(75, 23);
            this.encryptButton.TabIndex = 0;
            this.encryptButton.Text = "Encrypt";
            this.encryptButton.UseVisualStyleBackColor = true;
            this.encryptButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // decryptButton
            // 
            this.decryptButton.Location = new System.Drawing.Point(392, 276);
            this.decryptButton.Name = "decryptButton";
            this.decryptButton.Size = new System.Drawing.Size(75, 23);
            this.decryptButton.TabIndex = 1;
            this.decryptButton.Text = "Decrypt";
            this.decryptButton.UseVisualStyleBackColor = true;
            this.decryptButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Encrypt String";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Decrypt String";
            // 
            // encryptThisString
            // 
            this.encryptThisString.Location = new System.Drawing.Point(71, 113);
            this.encryptThisString.Name = "encryptThisString";
            this.encryptThisString.Size = new System.Drawing.Size(151, 20);
            this.encryptThisString.TabIndex = 4;
            this.encryptThisString.TextChanged += new System.EventHandler(this.encryptThisString_TextChanged);
            this.encryptThisString.Leave += new System.EventHandler(this.encryptThisString_Leave);
            // 
            // decryptThisString
            // 
            this.decryptThisString.Location = new System.Drawing.Point(71, 279);
            this.decryptThisString.Name = "decryptThisString";
            this.decryptThisString.Size = new System.Drawing.Size(151, 20);
            this.decryptThisString.TabIndex = 5;
            this.decryptThisString.TextChanged += new System.EventHandler(this.decryptThisString_TextChanged);
            this.decryptThisString.Leave += new System.EventHandler(this.decryptThisString_Leave);
            // 
            // keyText
            // 
            this.keyText.Location = new System.Drawing.Point(71, 28);
            this.keyText.Name = "keyText";
            this.keyText.Size = new System.Drawing.Size(151, 20);
            this.keyText.TabIndex = 6;
            this.keyText.TextChanged += new System.EventHandler(this.keyText_TextChanged);
            this.keyText.Leave += new System.EventHandler(this.keyText_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Key";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Here is the encrypted string.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(68, 327);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Here is the decrypted string.";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // decryptedString
            // 
            this.decryptedString.Location = new System.Drawing.Point(71, 343);
            this.decryptedString.Name = "decryptedString";
            this.decryptedString.Size = new System.Drawing.Size(151, 20);
            this.decryptedString.TabIndex = 10;
            this.decryptedString.TextChanged += new System.EventHandler(this.decryptedString_TextChanged);
            // 
            // encryptedString
            // 
            this.encryptedString.Location = new System.Drawing.Point(70, 168);
            this.encryptedString.Name = "encryptedString";
            this.encryptedString.Size = new System.Drawing.Size(151, 20);
            this.encryptedString.TabIndex = 11;
            this.encryptedString.TextChanged += new System.EventHandler(this.encryptedString_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(229, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "[]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(227, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "[]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(227, 281);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "[]";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(227, 346);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "[]";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 430);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.encryptedString);
            this.Controls.Add(this.decryptedString);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.keyText);
            this.Controls.Add(this.decryptThisString);
            this.Controls.Add(this.encryptThisString);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.decryptButton);
            this.Controls.Add(this.encryptButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button encryptButton;
        private System.Windows.Forms.Button decryptButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox encryptThisString;
        private System.Windows.Forms.TextBox decryptThisString;
        private System.Windows.Forms.TextBox keyText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox decryptedString;
        private System.Windows.Forms.TextBox encryptedString;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}

