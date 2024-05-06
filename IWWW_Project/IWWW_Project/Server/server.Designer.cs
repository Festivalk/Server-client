namespace Server
{
    partial class server
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
            this.run = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.windows = new System.Windows.Forms.TextBox();
            this.tIP = new System.Windows.Forms.TextBox();
            this.tPort = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // run
            // 
            this.run.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.run.Location = new System.Drawing.Point(124, 367);
            this.run.Name = "run";
            this.run.Size = new System.Drawing.Size(91, 51);
            this.run.TabIndex = 0;
            this.run.Text = "Run";
            this.run.UseVisualStyleBackColor = true;
            this.run.Click += new System.EventHandler(this.run_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(40, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 33);
            this.label3.TabIndex = 1;
            this.label3.Text = "IP";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(40, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 33);
            this.label4.TabIndex = 2;
            this.label4.Text = "Port";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // windows
            // 
            this.windows.Location = new System.Drawing.Point(320, 53);
            this.windows.Multiline = true;
            this.windows.Name = "windows";
            this.windows.Size = new System.Drawing.Size(499, 462);
            this.windows.TabIndex = 3;
            this.windows.TextChanged += new System.EventHandler(this.windows_TextChanged);
            // 
            // tIP
            // 
            this.tIP.Location = new System.Drawing.Point(124, 110);
            this.tIP.Multiline = true;
            this.tIP.Name = "tIP";
            this.tIP.Size = new System.Drawing.Size(155, 36);
            this.tIP.TabIndex = 4;
            this.tIP.TextChanged += new System.EventHandler(this.tIP_TextChanged);
            // 
            // tPort
            // 
            this.tPort.Location = new System.Drawing.Point(124, 207);
            this.tPort.Multiline = true;
            this.tPort.Name = "tPort";
            this.tPort.Size = new System.Drawing.Size(150, 36);
            this.tPort.TabIndex = 5;
            this.tPort.TextChanged += new System.EventHandler(this.tPort_TextChanged);
            // 
            // server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 580);
            this.Controls.Add(this.tPort);
            this.Controls.Add(this.tIP);
            this.Controls.Add(this.windows);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.run);
            this.Name = "server";
            this.Text = "server";
            this.Load += new System.EventHandler(this.server_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button run;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox windows;
        private System.Windows.Forms.TextBox tIP;
        private System.Windows.Forms.TextBox tPort;
    }
}