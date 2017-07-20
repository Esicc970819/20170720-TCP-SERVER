namespace ServerAP
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.Listbox1 = new System.Windows.Forms.ListBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 51);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(79, 15);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(91, 22);
            this.TextBox1.TabIndex = 73;
            this.TextBox1.Text = "192.168.100.19";
            // 
            // Listbox1
            // 
            this.Listbox1.FormattingEnabled = true;
            this.Listbox1.ItemHeight = 12;
            this.Listbox1.Location = new System.Drawing.Point(213, 43);
            this.Listbox1.Name = "Listbox1";
            this.Listbox1.Size = new System.Drawing.Size(114, 88);
            this.Listbox1.TabIndex = 72;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(211, 15);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(65, 12);
            this.Label3.TabIndex = 71;
            this.Label3.Text = "線上使用者";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(14, 46);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(57, 12);
            this.Label2.TabIndex = 70;
            this.Label2.Text = "Server Port";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(23, 18);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(48, 12);
            this.Label1.TabIndex = 69;
            this.Label1.Text = "Server IP";
            // 
            // TextBox2
            // 
            this.TextBox2.Location = new System.Drawing.Point(79, 43);
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Size = new System.Drawing.Size(91, 22);
            this.TextBox2.TabIndex = 68;
            this.TextBox2.Text = "2013";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(16, 170);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(311, 100);
            this.listBox2.TabIndex = 74;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 75;
            this.label4.Text = "聊天室";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 282);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.Listbox1);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.TextBox2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        internal System.Windows.Forms.TextBox TextBox1;
        internal System.Windows.Forms.ListBox Listbox1;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox TextBox2;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label4;
    }
}

