namespace PipesX.Child
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.TbMsg = new System.Windows.Forms.TextBox();
            this.BtSend = new System.Windows.Forms.Button();
            this.TbTxt = new System.Windows.Forms.TextBox();
            this.TbPipeName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtGo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TbMsg
            // 
            this.TbMsg.Location = new System.Drawing.Point(16, 285);
            this.TbMsg.Name = "TbMsg";
            this.TbMsg.Size = new System.Drawing.Size(186, 21);
            this.TbMsg.TabIndex = 11;
            // 
            // BtSend
            // 
            this.BtSend.Location = new System.Drawing.Point(218, 284);
            this.BtSend.Name = "BtSend";
            this.BtSend.Size = new System.Drawing.Size(75, 23);
            this.BtSend.TabIndex = 10;
            this.BtSend.Text = "Send";
            this.BtSend.UseVisualStyleBackColor = true;
            this.BtSend.Click += new System.EventHandler(this.BtSend_Click);
            // 
            // TbTxt
            // 
            this.TbTxt.Location = new System.Drawing.Point(16, 51);
            this.TbTxt.Multiline = true;
            this.TbTxt.Name = "TbTxt";
            this.TbTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TbTxt.Size = new System.Drawing.Size(277, 209);
            this.TbTxt.TabIndex = 9;
            // 
            // TbPipeName
            // 
            this.TbPipeName.Location = new System.Drawing.Point(87, 16);
            this.TbPipeName.Name = "TbPipeName";
            this.TbPipeName.Size = new System.Drawing.Size(115, 21);
            this.TbPipeName.TabIndex = 8;
            this.TbPipeName.Text = "PipeTest";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "管道名称：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtGo
            // 
            this.BtGo.Location = new System.Drawing.Point(218, 15);
            this.BtGo.Name = "BtGo";
            this.BtGo.Size = new System.Drawing.Size(75, 23);
            this.BtGo.TabIndex = 6;
            this.BtGo.Text = "Go";
            this.BtGo.UseVisualStyleBackColor = true;
            this.BtGo.Click += new System.EventHandler(this.BtGo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 322);
            this.Controls.Add(this.TbMsg);
            this.Controls.Add(this.BtSend);
            this.Controls.Add(this.TbTxt);
            this.Controls.Add(this.TbPipeName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtGo);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Child";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbMsg;
        private System.Windows.Forms.Button BtSend;
        private System.Windows.Forms.TextBox TbTxt;
        private System.Windows.Forms.TextBox TbPipeName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtGo;
    }
}

