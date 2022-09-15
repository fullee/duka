namespace SerialAssistant
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.checkBox_receiveMode = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox_sendMode = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cb_StopBits = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_DataBits = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_Baud = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_com = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label_ReceiveCount = new System.Windows.Forms.Label();
            this.textBox_receive = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox_send1 = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label_SendCount = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.checkBox_receiveMode);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.checkBox_sendMode);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cb_StopBits);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cb_DataBits);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cb_Baud);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cb_com);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(169, 231);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "端口设置";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(89, 134);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 13;
            this.button4.Text = "设置";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // checkBox_receiveMode
            // 
            this.checkBox_receiveMode.AutoSize = true;
            this.checkBox_receiveMode.Location = new System.Drawing.Point(83, 171);
            this.checkBox_receiveMode.Name = "checkBox_receiveMode";
            this.checkBox_receiveMode.Size = new System.Drawing.Size(42, 16);
            this.checkBox_receiveMode.TabIndex = 12;
            this.checkBox_receiveMode.Text = "HEX";
            this.checkBox_receiveMode.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "接收模式：";
            // 
            // checkBox_sendMode
            // 
            this.checkBox_sendMode.AutoSize = true;
            this.checkBox_sendMode.Location = new System.Drawing.Point(83, 197);
            this.checkBox_sendMode.Name = "checkBox_sendMode";
            this.checkBox_sendMode.Size = new System.Drawing.Size(42, 16);
            this.checkBox_sendMode.TabIndex = 10;
            this.checkBox_sendMode.Text = "HEX";
            this.checkBox_sendMode.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 134);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "打开串口";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cb_StopBits
            // 
            this.cb_StopBits.FormattingEnabled = true;
            this.cb_StopBits.Location = new System.Drawing.Point(71, 98);
            this.cb_StopBits.Name = "cb_StopBits";
            this.cb_StopBits.Size = new System.Drawing.Size(92, 20);
            this.cb_StopBits.TabIndex = 7;
            this.cb_StopBits.SelectedIndexChanged += new System.EventHandler(this.cb_StopBits_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "发送模式：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "停止位：";
            // 
            // cb_DataBits
            // 
            this.cb_DataBits.FormattingEnabled = true;
            this.cb_DataBits.Location = new System.Drawing.Point(71, 72);
            this.cb_DataBits.Name = "cb_DataBits";
            this.cb_DataBits.Size = new System.Drawing.Size(92, 20);
            this.cb_DataBits.TabIndex = 5;
            this.cb_DataBits.SelectedIndexChanged += new System.EventHandler(this.cb_DataBits_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "数据位：";
            // 
            // cb_Baud
            // 
            this.cb_Baud.FormattingEnabled = true;
            this.cb_Baud.Location = new System.Drawing.Point(71, 46);
            this.cb_Baud.Name = "cb_Baud";
            this.cb_Baud.Size = new System.Drawing.Size(92, 20);
            this.cb_Baud.TabIndex = 3;
            this.cb_Baud.SelectedIndexChanged += new System.EventHandler(this.cb_Baud_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "波特率：";
            // 
            // cb_com
            // 
            this.cb_com.FormattingEnabled = true;
            this.cb_com.Location = new System.Drawing.Point(71, 20);
            this.cb_com.Name = "cb_com";
            this.cb_com.Size = new System.Drawing.Size(92, 20);
            this.cb_com.TabIndex = 1;
            this.cb_com.SelectedIndexChanged += new System.EventHandler(this.cb_com_SelectedIndexChanged);
            this.cb_com.DropDown += new System.EventHandler(this.cb_com_DropDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口号：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label_SendCount);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.label_ReceiveCount);
            this.groupBox2.Controls.Add(this.textBox_receive);
            this.groupBox2.Location = new System.Drawing.Point(187, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(380, 231);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "接收区域";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(299, 197);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "清空屏幕";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button4_Click);
            // 
            // label_ReceiveCount
            // 
            this.label_ReceiveCount.AutoSize = true;
            this.label_ReceiveCount.Location = new System.Drawing.Point(6, 205);
            this.label_ReceiveCount.Name = "label_ReceiveCount";
            this.label_ReceiveCount.Size = new System.Drawing.Size(0, 12);
            this.label_ReceiveCount.TabIndex = 1;
            // 
            // textBox_receive
            // 
            this.textBox_receive.Location = new System.Drawing.Point(6, 17);
            this.textBox_receive.Multiline = true;
            this.textBox_receive.Name = "textBox_receive";
            this.textBox_receive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_receive.Size = new System.Drawing.Size(368, 172);
            this.textBox_receive.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.textBox_send1);
            this.groupBox3.Location = new System.Drawing.Point(12, 249);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(555, 174);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "发送区域";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(474, 20);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 104);
            this.button3.TabIndex = 9;
            this.button3.Text = "发送";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox_send1
            // 
            this.textBox_send1.Location = new System.Drawing.Point(6, 20);
            this.textBox_send1.Multiline = true;
            this.textBox_send1.Name = "textBox_send1";
            this.textBox_send1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_send1.Size = new System.Drawing.Size(459, 104);
            this.textBox_send1.TabIndex = 1;
            // 
            // label_SendCount
            // 
            this.label_SendCount.AutoSize = true;
            this.label_SendCount.Location = new System.Drawing.Point(91, 205);
            this.label_SendCount.Name = "label_SendCount";
            this.label_SendCount.Size = new System.Drawing.Size(0, 12);
            this.label_SendCount.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 389);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SerialAssistant V1.3";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox_receiveMode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox_sendMode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cb_StopBits;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_DataBits;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_Baud;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_com;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label_ReceiveCount;
        private System.Windows.Forms.TextBox textBox_receive;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox_send1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label_SendCount;
    }
}

