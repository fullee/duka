namespace samplepage_withoutautoreply
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxEnumOpenClosePort = new System.Windows.Forms.GroupBox();
            this.buttonClosePort = new System.Windows.Forms.Button();
            this.buttonOpenPort = new System.Windows.Forms.Button();
            this.buttonEnumPort = new System.Windows.Forms.Button();
            this.groupBoxFunctionList = new System.Windows.Forms.GroupBox();
            this.listBoxFunction = new System.Windows.Forms.ListBox();
            this.cbxComBaudrate = new System.Windows.Forms.ComboBox();
            this.tbTcpPort = new System.Windows.Forms.TextBox();
            this.groupBoxSelectPort = new System.Windows.Forms.GroupBox();
            this.cbxIPAddress = new System.Windows.Forms.ComboBox();
            this.cbxLptName = new System.Windows.Forms.ComboBox();
            this.rbLpt = new System.Windows.Forms.RadioButton();
            this.cbxUsbName = new System.Windows.Forms.ComboBox();
            this.cbxComName = new System.Windows.Forms.ComboBox();
            this.rbUsb = new System.Windows.Forms.RadioButton();
            this.rbTcp = new System.Windows.Forms.RadioButton();
            this.rbCom = new System.Windows.Forms.RadioButton();
            this.cbxComFlowControl = new System.Windows.Forms.ComboBox();
            this.groupBoxEnumOpenClosePort.SuspendLayout();
            this.groupBoxFunctionList.SuspendLayout();
            this.groupBoxSelectPort.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxEnumOpenClosePort
            // 
            this.groupBoxEnumOpenClosePort.Controls.Add(this.buttonClosePort);
            this.groupBoxEnumOpenClosePort.Controls.Add(this.buttonOpenPort);
            this.groupBoxEnumOpenClosePort.Controls.Add(this.buttonEnumPort);
            this.groupBoxEnumOpenClosePort.Location = new System.Drawing.Point(12, 144);
            this.groupBoxEnumOpenClosePort.Name = "groupBoxEnumOpenClosePort";
            this.groupBoxEnumOpenClosePort.Size = new System.Drawing.Size(468, 56);
            this.groupBoxEnumOpenClosePort.TabIndex = 6;
            this.groupBoxEnumOpenClosePort.TabStop = false;
            this.groupBoxEnumOpenClosePort.Text = "Enum/Open/Close Port";
            // 
            // buttonClosePort
            // 
            this.buttonClosePort.Location = new System.Drawing.Point(220, 21);
            this.buttonClosePort.Name = "buttonClosePort";
            this.buttonClosePort.Size = new System.Drawing.Size(100, 23);
            this.buttonClosePort.TabIndex = 2;
            this.buttonClosePort.Text = "ClosePort";
            this.buttonClosePort.UseVisualStyleBackColor = true;
            this.buttonClosePort.Click += new System.EventHandler(this.buttonClosePort_Click);
            // 
            // buttonOpenPort
            // 
            this.buttonOpenPort.Location = new System.Drawing.Point(114, 21);
            this.buttonOpenPort.Name = "buttonOpenPort";
            this.buttonOpenPort.Size = new System.Drawing.Size(100, 23);
            this.buttonOpenPort.TabIndex = 1;
            this.buttonOpenPort.Text = "OpenPort";
            this.buttonOpenPort.UseVisualStyleBackColor = true;
            this.buttonOpenPort.Click += new System.EventHandler(this.buttonOpenPort_Click);
            // 
            // buttonEnumPort
            // 
            this.buttonEnumPort.Location = new System.Drawing.Point(8, 21);
            this.buttonEnumPort.Name = "buttonEnumPort";
            this.buttonEnumPort.Size = new System.Drawing.Size(100, 23);
            this.buttonEnumPort.TabIndex = 0;
            this.buttonEnumPort.Text = "EnumPort";
            this.buttonEnumPort.UseVisualStyleBackColor = true;
            this.buttonEnumPort.Click += new System.EventHandler(this.buttonEnumPort_Click);
            // 
            // groupBoxFunctionList
            // 
            this.groupBoxFunctionList.Controls.Add(this.listBoxFunction);
            this.groupBoxFunctionList.Location = new System.Drawing.Point(12, 207);
            this.groupBoxFunctionList.Name = "groupBoxFunctionList";
            this.groupBoxFunctionList.Size = new System.Drawing.Size(468, 314);
            this.groupBoxFunctionList.TabIndex = 7;
            this.groupBoxFunctionList.TabStop = false;
            this.groupBoxFunctionList.Text = "Function List";
            // 
            // listBoxFunction
            // 
            this.listBoxFunction.FormattingEnabled = true;
            this.listBoxFunction.ItemHeight = 12;
            this.listBoxFunction.Location = new System.Drawing.Point(8, 21);
            this.listBoxFunction.Name = "listBoxFunction";
            this.listBoxFunction.Size = new System.Drawing.Size(454, 280);
            this.listBoxFunction.TabIndex = 0;
            this.listBoxFunction.SelectedIndexChanged += new System.EventHandler(this.listBoxFunction_SelectedIndexChanged);
            // 
            // cbxComBaudrate
            // 
            this.cbxComBaudrate.FormattingEnabled = true;
            this.cbxComBaudrate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cbxComBaudrate.Location = new System.Drawing.Point(182, 21);
            this.cbxComBaudrate.Name = "cbxComBaudrate";
            this.cbxComBaudrate.Size = new System.Drawing.Size(121, 20);
            this.cbxComBaudrate.TabIndex = 4;
            this.cbxComBaudrate.Text = "115200";
            // 
            // tbTcpPort
            // 
            this.tbTcpPort.Location = new System.Drawing.Point(182, 47);
            this.tbTcpPort.Name = "tbTcpPort";
            this.tbTcpPort.Size = new System.Drawing.Size(121, 21);
            this.tbTcpPort.TabIndex = 6;
            this.tbTcpPort.Text = "9100";
            // 
            // groupBoxSelectPort
            // 
            this.groupBoxSelectPort.Controls.Add(this.cbxComFlowControl);
            this.groupBoxSelectPort.Controls.Add(this.cbxIPAddress);
            this.groupBoxSelectPort.Controls.Add(this.cbxLptName);
            this.groupBoxSelectPort.Controls.Add(this.rbLpt);
            this.groupBoxSelectPort.Controls.Add(this.cbxUsbName);
            this.groupBoxSelectPort.Controls.Add(this.tbTcpPort);
            this.groupBoxSelectPort.Controls.Add(this.cbxComBaudrate);
            this.groupBoxSelectPort.Controls.Add(this.cbxComName);
            this.groupBoxSelectPort.Controls.Add(this.rbUsb);
            this.groupBoxSelectPort.Controls.Add(this.rbTcp);
            this.groupBoxSelectPort.Controls.Add(this.rbCom);
            this.groupBoxSelectPort.Location = new System.Drawing.Point(12, 12);
            this.groupBoxSelectPort.Name = "groupBoxSelectPort";
            this.groupBoxSelectPort.Size = new System.Drawing.Size(468, 124);
            this.groupBoxSelectPort.TabIndex = 5;
            this.groupBoxSelectPort.TabStop = false;
            this.groupBoxSelectPort.Text = "Select Port";
            // 
            // cbxIPAddress
            // 
            this.cbxIPAddress.FormattingEnabled = true;
            this.cbxIPAddress.Location = new System.Drawing.Point(55, 48);
            this.cbxIPAddress.Name = "cbxIPAddress";
            this.cbxIPAddress.Size = new System.Drawing.Size(121, 20);
            this.cbxIPAddress.TabIndex = 11;
            // 
            // cbxLptName
            // 
            this.cbxLptName.FormattingEnabled = true;
            this.cbxLptName.Location = new System.Drawing.Point(55, 98);
            this.cbxLptName.Name = "cbxLptName";
            this.cbxLptName.Size = new System.Drawing.Size(248, 20);
            this.cbxLptName.TabIndex = 9;
            // 
            // rbLpt
            // 
            this.rbLpt.AutoSize = true;
            this.rbLpt.Location = new System.Drawing.Point(8, 98);
            this.rbLpt.Name = "rbLpt";
            this.rbLpt.Size = new System.Drawing.Size(41, 16);
            this.rbLpt.TabIndex = 8;
            this.rbLpt.TabStop = true;
            this.rbLpt.Text = "Lpt";
            this.rbLpt.UseVisualStyleBackColor = true;
            // 
            // cbxUsbName
            // 
            this.cbxUsbName.FormattingEnabled = true;
            this.cbxUsbName.Location = new System.Drawing.Point(55, 73);
            this.cbxUsbName.Name = "cbxUsbName";
            this.cbxUsbName.Size = new System.Drawing.Size(248, 20);
            this.cbxUsbName.TabIndex = 7;
            // 
            // cbxComName
            // 
            this.cbxComName.FormattingEnabled = true;
            this.cbxComName.Location = new System.Drawing.Point(55, 21);
            this.cbxComName.Name = "cbxComName";
            this.cbxComName.Size = new System.Drawing.Size(121, 20);
            this.cbxComName.TabIndex = 3;
            // 
            // rbUsb
            // 
            this.rbUsb.AutoSize = true;
            this.rbUsb.Location = new System.Drawing.Point(7, 75);
            this.rbUsb.Name = "rbUsb";
            this.rbUsb.Size = new System.Drawing.Size(41, 16);
            this.rbUsb.TabIndex = 2;
            this.rbUsb.TabStop = true;
            this.rbUsb.Text = "Usb";
            this.rbUsb.UseVisualStyleBackColor = true;
            // 
            // rbTcp
            // 
            this.rbTcp.AutoSize = true;
            this.rbTcp.Location = new System.Drawing.Point(7, 48);
            this.rbTcp.Name = "rbTcp";
            this.rbTcp.Size = new System.Drawing.Size(41, 16);
            this.rbTcp.TabIndex = 1;
            this.rbTcp.TabStop = true;
            this.rbTcp.Text = "Tcp";
            this.rbTcp.UseVisualStyleBackColor = true;
            // 
            // rbCom
            // 
            this.rbCom.AutoSize = true;
            this.rbCom.Location = new System.Drawing.Point(8, 22);
            this.rbCom.Name = "rbCom";
            this.rbCom.Size = new System.Drawing.Size(41, 16);
            this.rbCom.TabIndex = 0;
            this.rbCom.TabStop = true;
            this.rbCom.Text = "Com";
            this.rbCom.UseVisualStyleBackColor = true;
            // 
            // cbxComFlowControl
            // 
            this.cbxComFlowControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxComFlowControl.FormattingEnabled = true;
            this.cbxComFlowControl.Items.AddRange(new object[] {
            "No FlowControl",
            "Xon/Xoff FlowControl",
            "Hardware FlowControl"});
            this.cbxComFlowControl.Location = new System.Drawing.Point(309, 21);
            this.cbxComFlowControl.Name = "cbxComFlowControl";
            this.cbxComFlowControl.Size = new System.Drawing.Size(121, 20);
            this.cbxComFlowControl.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 533);
            this.Controls.Add(this.groupBoxEnumOpenClosePort);
            this.Controls.Add(this.groupBoxFunctionList);
            this.Controls.Add(this.groupBoxSelectPort);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxEnumOpenClosePort.ResumeLayout(false);
            this.groupBoxFunctionList.ResumeLayout(false);
            this.groupBoxSelectPort.ResumeLayout(false);
            this.groupBoxSelectPort.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxEnumOpenClosePort;
        private System.Windows.Forms.Button buttonClosePort;
        private System.Windows.Forms.Button buttonOpenPort;
        private System.Windows.Forms.Button buttonEnumPort;
        private System.Windows.Forms.GroupBox groupBoxFunctionList;
        private System.Windows.Forms.ListBox listBoxFunction;
        private System.Windows.Forms.ComboBox cbxComBaudrate;
        private System.Windows.Forms.TextBox tbTcpPort;
        private System.Windows.Forms.GroupBox groupBoxSelectPort;
        private System.Windows.Forms.ComboBox cbxUsbName;
        private System.Windows.Forms.ComboBox cbxComName;
        private System.Windows.Forms.RadioButton rbUsb;
        private System.Windows.Forms.RadioButton rbTcp;
        private System.Windows.Forms.RadioButton rbCom;
        private System.Windows.Forms.RadioButton rbLpt;
        private System.Windows.Forms.ComboBox cbxLptName;
        private System.Windows.Forms.ComboBox cbxIPAddress;
        private System.Windows.Forms.ComboBox cbxComFlowControl;

    }
}

