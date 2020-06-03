namespace SocketBase
{
    partial class server
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
            this.ip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.port = new System.Windows.Forms.TextBox();
            this.bnt_listen = new System.Windows.Forms.Button();
            this.bnt_send = new System.Windows.Forms.Button();
            this.receive = new System.Windows.Forms.TextBox();
            this.send = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ip
            // 
            this.ip.Location = new System.Drawing.Point(94, 63);
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(128, 25);
            this.ip.TabIndex = 0;
            this.ip.Text = "192.168.1.104";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "ip：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "port:";
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(294, 63);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(100, 25);
            this.port.TabIndex = 3;
            this.port.Text = "50000";
            // 
            // bnt_listen
            // 
            this.bnt_listen.Location = new System.Drawing.Point(436, 63);
            this.bnt_listen.Name = "bnt_listen";
            this.bnt_listen.Size = new System.Drawing.Size(96, 26);
            this.bnt_listen.TabIndex = 4;
            this.bnt_listen.Text = "开始监听";
            this.bnt_listen.UseVisualStyleBackColor = true;
            this.bnt_listen.Click += new System.EventHandler(this.bnt_listen_Click);
            // 
            // bnt_send
            // 
            this.bnt_send.Location = new System.Drawing.Point(560, 393);
            this.bnt_send.Name = "bnt_send";
            this.bnt_send.Size = new System.Drawing.Size(96, 36);
            this.bnt_send.TabIndex = 7;
            this.bnt_send.Text = "发送消息";
            this.bnt_send.UseVisualStyleBackColor = true;
            this.bnt_send.Click += new System.EventHandler(this.bnt_send_Click);
            // 
            // receive
            // 
            this.receive.Location = new System.Drawing.Point(107, 149);
            this.receive.Multiline = true;
            this.receive.Name = "receive";
            this.receive.Size = new System.Drawing.Size(338, 105);
            this.receive.TabIndex = 8;
            // 
            // send
            // 
            this.send.Location = new System.Drawing.Point(107, 302);
            this.send.Multiline = true;
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(338, 102);
            this.send.TabIndex = 9;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "All"});
            this.comboBox1.Location = new System.Drawing.Point(591, 64);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 10;
            // 
            // server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 462);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.send);
            this.Controls.Add(this.receive);
            this.Controls.Add(this.bnt_send);
            this.Controls.Add(this.bnt_listen);
            this.Controls.Add(this.port);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ip);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "server";
            this.Text = "server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.Button bnt_listen;
        private System.Windows.Forms.Button bnt_send;
        private System.Windows.Forms.TextBox receive;
        private System.Windows.Forms.TextBox send;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

