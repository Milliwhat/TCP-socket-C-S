﻿namespace ChatServer
{
    partial class FServer
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.txtSendMsg = new System.Windows.Forms.TextBox();
            this.btnSendMsg = new System.Windows.Forms.Button();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.btnStartService = new System.Windows.Forms.Button();
            this.lstClients = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblIP = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClearSelectedState = new System.Windows.Forms.Button();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(224, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "聊天内容:";
            // 
            // txtSendMsg
            // 
            this.txtSendMsg.Location = new System.Drawing.Point(133, 298);
            this.txtSendMsg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSendMsg.Name = "txtSendMsg";
            this.txtSendMsg.Size = new System.Drawing.Size(305, 21);
            this.txtSendMsg.TabIndex = 22;
            this.txtSendMsg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSendMsg_KeyDown);
            // 
            // btnSendMsg
            // 
            this.btnSendMsg.Location = new System.Drawing.Point(454, 293);
            this.btnSendMsg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSendMsg.Name = "btnSendMsg";
            this.btnSendMsg.Size = new System.Drawing.Size(75, 23);
            this.btnSendMsg.TabIndex = 21;
            this.btnSendMsg.Text = "发送信息";
            this.btnSendMsg.UseVisualStyleBackColor = true;
            this.btnSendMsg.Click += new System.EventHandler(this.btnSendMsg_Click);
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(227, 60);
            this.txtMsg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMsg.Size = new System.Drawing.Size(302, 219);
            this.txtMsg.TabIndex = 19;
            this.txtMsg.TextChanged += new System.EventHandler(this.txtMsg_TextChanged);
            // 
            // btnStartService
            // 
            this.btnStartService.Location = new System.Drawing.Point(59, 256);
            this.btnStartService.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStartService.Name = "btnStartService";
            this.btnStartService.Size = new System.Drawing.Size(68, 23);
            this.btnStartService.TabIndex = 15;
            this.btnStartService.Text = "启动服务";
            this.btnStartService.UseVisualStyleBackColor = true;
            this.btnStartService.Click += new System.EventHandler(this.btnStartService_Click);
            // 
            // lstClients
            // 
            this.lstClients.FormattingEnabled = true;
            this.lstClients.ItemHeight = 12;
            this.lstClients.Location = new System.Drawing.Point(4, 29);
            this.lstClients.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstClients.Name = "lstClients";
            this.lstClients.Size = new System.Drawing.Size(142, 112);
            this.lstClients.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 300);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 26;
            this.label4.Text = "服务端:";
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.ForeColor = System.Drawing.Color.Red;
            this.lblIP.Location = new System.Drawing.Point(35, 14);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(0, 12);
            this.lblIP.TabIndex = 27;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(139, 256);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(69, 22);
            this.btnExit.TabIndex = 29;
            this.btnExit.Text = "退出服务";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "Port:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "IP:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPort);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblIP);
            this.groupBox1.Location = new System.Drawing.Point(56, 35);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(152, 60);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "服务端";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblPort.Location = new System.Drawing.Point(41, 36);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(0, 12);
            this.lblPort.TabIndex = 28;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClearSelectedState);
            this.groupBox2.Controls.Add(this.lstClients);
            this.groupBox2.Location = new System.Drawing.Point(56, 101);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(152, 150);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "客户端列表";
            // 
            // btnClearSelectedState
            // 
            this.btnClearSelectedState.Location = new System.Drawing.Point(77, -1);
            this.btnClearSelectedState.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClearSelectedState.Name = "btnClearSelectedState";
            this.btnClearSelectedState.Size = new System.Drawing.Size(69, 19);
            this.btnClearSelectedState.TabIndex = 25;
            this.btnClearSelectedState.Text = "取消选择";
            this.btnClearSelectedState.UseVisualStyleBackColor = true;
            this.btnClearSelectedState.Click += new System.EventHandler(this.btnClearSelectedState_Click);
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(366, 328);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFile.TabIndex = 48;
            this.btnSelectFile.Text = "选择文件";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(59, 328);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(268, 21);
            this.txtFileName.TabIndex = 47;
            // 
            // btnSendFile
            // 
            this.btnSendFile.Location = new System.Drawing.Point(454, 328);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(75, 23);
            this.btnSendFile.TabIndex = 46;
            this.btnSendFile.Text = "发送文件";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // FServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 372);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.btnSendFile);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSendMsg);
            this.Controls.Add(this.btnSendMsg);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.btnStartService);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FServer";
            this.Text = "服务端";
            this.Load += new System.EventHandler(this.FServer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSendMsg;
        private System.Windows.Forms.Button btnSendMsg;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Button btnStartService;
        private System.Windows.Forms.ListBox lstClients;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnClearSelectedState;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnSendFile;
    }
}

