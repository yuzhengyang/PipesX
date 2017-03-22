namespace PipesX.Client
{
    partial class ClientForm
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
            this.BtSend = new System.Windows.Forms.Button();
            this.BtReceive = new System.Windows.Forms.Button();
            this.BtConnect = new System.Windows.Forms.Button();
            this.TbCmd = new System.Windows.Forms.TextBox();
            this.TbReceive = new System.Windows.Forms.TextBox();
            this.TbSend = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtSend
            // 
            this.BtSend.Location = new System.Drawing.Point(420, 257);
            this.BtSend.Name = "BtSend";
            this.BtSend.Size = new System.Drawing.Size(75, 23);
            this.BtSend.TabIndex = 11;
            this.BtSend.Text = "Send";
            this.BtSend.UseVisualStyleBackColor = true;
            this.BtSend.Click += new System.EventHandler(this.BtSend_Click);
            // 
            // BtReceive
            // 
            this.BtReceive.Location = new System.Drawing.Point(338, 257);
            this.BtReceive.Name = "BtReceive";
            this.BtReceive.Size = new System.Drawing.Size(75, 23);
            this.BtReceive.TabIndex = 10;
            this.BtReceive.Text = "Receive";
            this.BtReceive.UseVisualStyleBackColor = true;
            this.BtReceive.Click += new System.EventHandler(this.BtReceive_Click);
            // 
            // BtConnect
            // 
            this.BtConnect.Location = new System.Drawing.Point(257, 257);
            this.BtConnect.Name = "BtConnect";
            this.BtConnect.Size = new System.Drawing.Size(75, 23);
            this.BtConnect.TabIndex = 9;
            this.BtConnect.Text = "Connect";
            this.BtConnect.UseVisualStyleBackColor = true;
            this.BtConnect.Click += new System.EventHandler(this.BtConnect_Click);
            // 
            // TbCmd
            // 
            this.TbCmd.Location = new System.Drawing.Point(338, 12);
            this.TbCmd.Multiline = true;
            this.TbCmd.Name = "TbCmd";
            this.TbCmd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TbCmd.Size = new System.Drawing.Size(157, 234);
            this.TbCmd.TabIndex = 8;
            // 
            // TbReceive
            // 
            this.TbReceive.Location = new System.Drawing.Point(12, 12);
            this.TbReceive.Multiline = true;
            this.TbReceive.Name = "TbReceive";
            this.TbReceive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TbReceive.Size = new System.Drawing.Size(157, 234);
            this.TbReceive.TabIndex = 7;
            // 
            // TbSend
            // 
            this.TbSend.Location = new System.Drawing.Point(175, 12);
            this.TbSend.Multiline = true;
            this.TbSend.Name = "TbSend";
            this.TbSend.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TbSend.Size = new System.Drawing.Size(157, 234);
            this.TbSend.TabIndex = 6;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 293);
            this.Controls.Add(this.BtSend);
            this.Controls.Add(this.BtReceive);
            this.Controls.Add(this.BtConnect);
            this.Controls.Add(this.TbCmd);
            this.Controls.Add(this.TbReceive);
            this.Controls.Add(this.TbSend);
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtSend;
        private System.Windows.Forms.Button BtReceive;
        private System.Windows.Forms.Button BtConnect;
        private System.Windows.Forms.TextBox TbCmd;
        private System.Windows.Forms.TextBox TbReceive;
        private System.Windows.Forms.TextBox TbSend;
    }
}