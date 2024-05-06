namespace Public
{
    partial class Clients
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
            this.Close = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tMsg = new System.Windows.Forms.TextBox();
            this.windows = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // run
            // 
            this.run.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.run.Location = new System.Drawing.Point(120, 110);
            this.run.Name = "run";
            this.run.Size = new System.Drawing.Size(159, 54);
            this.run.TabIndex = 0;
            this.run.Text = "Connect";
            this.run.UseVisualStyleBackColor = true;
            this.run.Click += new System.EventHandler(this.run_Click);
            // 
            // Close
            // 
            this.Close.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Close.Location = new System.Drawing.Point(120, 289);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(159, 54);
            this.Close.TabIndex = 1;
            this.Close.Text = "Quit";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(1008, 605);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 48);
            this.button2.TabIndex = 2;
            this.button2.Text = "Send";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tMsg
            // 
            this.tMsg.Location = new System.Drawing.Point(163, 556);
            this.tMsg.Multiline = true;
            this.tMsg.Name = "tMsg";
            this.tMsg.Size = new System.Drawing.Size(744, 154);
            this.tMsg.TabIndex = 3;
            // 
            // windows
            // 
            this.windows.Location = new System.Drawing.Point(332, 39);
            this.windows.Multiline = true;
            this.windows.Name = "windows";
            this.windows.Size = new System.Drawing.Size(795, 451);
            this.windows.TabIndex = 4;
            // 
            // Clients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 763);
            this.Controls.Add(this.windows);
            this.Controls.Add(this.tMsg);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.run);
            this.Name = "Clients";
            this.Text = "Clients";
            this.Load += new System.EventHandler(this.Clients_Load);
            this.Click += new System.EventHandler(this.run_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button run;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tMsg;
        private System.Windows.Forms.TextBox windows;
    }
}