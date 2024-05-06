namespace Public
{
    partial class Server
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tIP = new System.Windows.Forms.TextBox();
            this.tPort = new System.Windows.Forms.TextBox();
            this.run = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.windows = new System.Windows.Forms.TextBox();
            this.tMsg = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(47, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(33, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port";
            // 
            // tIP
            // 
            this.tIP.Location = new System.Drawing.Point(111, 57);
            this.tIP.Multiline = true;
            this.tIP.Name = "tIP";
            this.tIP.Size = new System.Drawing.Size(219, 49);
            this.tIP.TabIndex = 2;
            this.tIP.TextChanged += new System.EventHandler(this.tIP_TextChanged);
            // 
            // tPort
            // 
            this.tPort.Location = new System.Drawing.Point(111, 144);
            this.tPort.Multiline = true;
            this.tPort.Name = "tPort";
            this.tPort.Size = new System.Drawing.Size(219, 49);
            this.tPort.TabIndex = 3;
            // 
            // run
            // 
            this.run.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.run.Location = new System.Drawing.Point(111, 304);
            this.run.Name = "run";
            this.run.Size = new System.Drawing.Size(83, 48);
            this.run.TabIndex = 4;
            this.run.Text = "Run";
            this.run.UseVisualStyleBackColor = true;
            this.run.Click += new System.EventHandler(this.button1_Click);
            // 
            // close
            // 
            this.close.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.close.Location = new System.Drawing.Point(246, 304);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(84, 48);
            this.close.TabIndex = 5;
            this.close.Text = "Close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // windows
            // 
            this.windows.Location = new System.Drawing.Point(438, 23);
            this.windows.Multiline = true;
            this.windows.Name = "windows";
            this.windows.Size = new System.Drawing.Size(641, 396);
            this.windows.TabIndex = 6;
            this.windows.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // tMsg
            // 
            this.tMsg.Location = new System.Drawing.Point(111, 450);
            this.tMsg.Multiline = true;
            this.tMsg.Name = "tMsg";
            this.tMsg.Size = new System.Drawing.Size(648, 172);
            this.tMsg.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(833, 508);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 53);
            this.button2.TabIndex = 8;
            this.button2.Text = "Send";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 659);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tMsg);
            this.Controls.Add(this.windows);
            this.Controls.Add(this.close);
            this.Controls.Add(this.run);
            this.Controls.Add(this.tPort);
            this.Controls.Add(this.tIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Server";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Server_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tIP;
        private System.Windows.Forms.TextBox tPort;
        private System.Windows.Forms.Button run;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.TextBox windows;
        private System.Windows.Forms.TextBox tMsg;
        private System.Windows.Forms.Button button2;
    }
}