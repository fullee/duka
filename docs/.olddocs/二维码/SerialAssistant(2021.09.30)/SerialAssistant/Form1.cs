using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SerialAssistant
{
    public partial class Form1 : Form
    {
        private long RxCount = 0;
        private long TxCount = 0;

        private String m_strVID = "";
        private String m_strPID = "";

        public Form1()
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            button4_Click(null, null);
        }

        #region 初始化Form
        private void Form1_Load(object sender, EventArgs e)
        {
            //pictureBox1.Image = Properties.Resources.off;//xhn

            ////查询当前有用的串口号
            //SerialPort.GetPortNames();
            //string[] ports = SerialPort.GetPortNames();
            //foreach (string port in ports)
            //{
            //    cb_com.Items.Add(port);
            //}

            //查询指定VID和PID的串口号
            //String strCurPortName = PublicFun.GetPortNameFormVidPid(m_strVID, m_strPID);
            //cb_com.Items.Add(strCurPortName);
            //if (strCurPortName == null)
            //{
            //    MessageBox.Show("无指定VID、PID的COM存在!");
            //    return;
            //}
            
           

            serialPort1.BaudRate = 9600;
            serialPort1.DataBits = 8;
            serialPort1.StopBits = (StopBits)1;

            //迭代所有的波特率
            string[] tab_Baud = new string[] { "110", "300", "600", "1200", "2400", "4800", "9600", "14400", "19200", "38400", "56000", "57600", "115200", "128000", "256000" };
            foreach (string str in tab_Baud)
            {
                cb_Baud.Items.Add(str);
            }

            //迭代所有的数据位
            string[] tab_data = new string[] { "5", "6", "7", "8" };
            foreach (string str in tab_data)
            {
                cb_DataBits.Items.Add(str);
            }

            //迭代所有的停止位
            string[] tab_stop = new string[] { "1", "2" };
            foreach (string str in tab_stop)
            {
                cb_StopBits.Items.Add(str);
            }

            cb_Baud.Text = "115200";
            cb_DataBits.Text = "8";
            cb_StopBits.Text = "1";

            serialPort1.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);//添加事件

        }
        #endregion

        #region 返回系统当前时间
        //nType:0收，1发
        private string GetSysNowTime(int nType)
        {
            string strTime = "";
            if (nType == 0)
            {
                strTime = "[" + DateTime.Now.ToLocalTime().ToString(@"HH:mm:ss.fff") + "]收<--◆";
            }
            else if (nType == 1)
            {
                strTime = "[" + DateTime.Now.ToLocalTime().ToString(@"HH:mm:ss.fff") + "]发-->◇";
            }
            return strTime;
        }
        #endregion

        public String format1(int hex)
        {
            String hexa = hex.ToString("X");
            int len = hexa.Length;
            if (len < 2)
            {
                hexa = "0" + hexa;
            }
            return hexa;
        }


        #region 接收数据
        private void port_DataReceived(object sender,SerialDataReceivedEventArgs e) {
            if (!checkBox_receiveMode.Checked)//没有勾选hex时候，按照字符串方式读取
            {
                int DataLength = serialPort1.BytesToRead;
                int i = 0;
                StringBuilder sb = new StringBuilder();
                while (i < DataLength)
                {
                    byte[] ds = new byte[1024];
                    int len = 0;
                    serialPort1.Encoding = System.Text.Encoding.ASCII;
                    len = serialPort1.Read(ds, 0, 1024);
                    sb.Append(Encoding.ASCII.GetString(ds, 0, len));
                    i += len;
                }
                String str = sb.ToString();
                textBox_receive.AppendText(GetSysNowTime(0));
                textBox_receive.AppendText(str);    //添加内容
                textBox_receive.AppendText("\r\n");
                RxCount += DataLength;
                
            }
            else
            {
                int DataLength = serialPort1.BytesToRead;
                int i = 0;
                StringBuilder sb = new StringBuilder();
                while (i < DataLength)
                {
                    byte[] ds = new byte[1024];
                    int len = serialPort1.Read(ds, 0, 1024);
                    sb.Append(Encoding.ASCII.GetString(ds, 0, len));
                    i += len;
                }
                String str = sb.ToString();

                String str_HEX = "";
                byte[] decBytes = System.Text.Encoding.ASCII.GetBytes(str);
                for (int j = 0; j < decBytes.Length; j++)
                {
                    str_HEX += format1(decBytes[j]);
                    str_HEX += " ";
                }
                textBox_receive.AppendText(GetSysNowTime(0));
                textBox_receive.AppendText(str_HEX);
                textBox_receive.AppendText("\r\n");
                RxCount += DataLength;
            }


            label_ReceiveCount.Text = "RX:" + RxCount.ToString();
        }

        public String format(int hex)
        {
            String hexa = hex.ToString("X");
            int len = hexa.Length;
            if (len < 2)
            {
                hexa = "0" + hexa;
            }
            return hexa;
        }
        #endregion

        #region 清空接收计数器和接收显示区域
        private void button4_Click(object sender, EventArgs e)
        {
            textBox_receive.Text = "";
            RxCount = 0;
            label_ReceiveCount.Text = "RX:" + RxCount.ToString();
            TxCount = 0;
            label_SendCount.Text = "TX:" + TxCount.ToString();
        }
        #endregion

        #region 打开/关闭串口
        private void button1_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.PortName = cb_com.Text;
                    serialPort1.BaudRate = Convert.ToInt32(cb_Baud.Text);
                    serialPort1.DataBits = Convert.ToInt32(cb_DataBits.Text);
                    serialPort1.StopBits = (StopBits)Convert.ToInt32(cb_StopBits.Text);
                    serialPort1.Open();
                }
                catch
                {
                    MessageBox.Show("端口打开失败", "错误");

                }
            }
            else {
                try
                {
                    serialPort1.Close();
                }
                catch
                {
                    MessageBox.Show("端口关闭失败", "错误");

                }
            }

            changeButtonTextAndPicture();

        }
        #endregion

        #region 根据串口状态切换按键名称和指示灯图片
        private void changeButtonTextAndPicture()
        {
            if (serialPort1.IsOpen)
            {
                //pictureBox1.Image = Properties.Resources.on;
                button1.Text = "关闭串口";
                button4.Enabled = false;
            }
            else
            {
                //pictureBox1.Image = Properties.Resources.off;
                button1.Text = "打开串口";
                button4.Enabled = true;
            }
        }
        #endregion

        #region 多行发送
        private void button2_Click(object sender, EventArgs e)
        {
            byte[] Data = new byte[1];
            if (serialPort1.IsOpen)
            {
                if (textBox_send1.Text != "")
                {
                    if (!checkBox_sendMode.Checked)//发送模式是字符模式
                    {
                        try
                        {
                            serialPort1.Write(textBox_send1.Text);
                            textBox_receive.AppendText(GetSysNowTime(1));
                            textBox_receive.AppendText(textBox_send1.Text);
                            textBox_receive.AppendText("\r\n");
                            TxCount += textBox_send1.Text.Length;
                        }
                        catch
                        {
                            MessageBox.Show("端口发送失败，系统将关闭当前串口", "错误");
                            serialPort1.Close();//关闭串口
                        }
                    }
                    else
                    {
                        String strSend1 = textBox_send1.Text.Replace(" ", "");
                        if (strSend1.Length % 2 == 0)//偶数个数字
                        {
                            textBox_receive.AppendText(GetSysNowTime(1));

                            for (int i = 0; i < strSend1.Length / 2; i++)
                            {
                                try
                                {
                                    Data[0] = Convert.ToByte(strSend1.Substring(i * 2, 2), 16);
                                }
                                catch
                                {
                                    MessageBox.Show("请核对输入的十六进制数据格式", "错误");

                                }

                                try
                                {
                                    serialPort1.Write(Data, 0, 1);
                                }
                                catch
                                {
                                    MessageBox.Show("端口发送失败，系统将关闭当前串口", "错误");
                                    serialPort1.Close();//关闭串口
                                }
                            }
                            textBox_receive.AppendText(textBox_send1.Text);
                            textBox_receive.AppendText("\r\n");
                            TxCount += strSend1.Length / 2;
                        }
                        else
                        {
                            MessageBox.Show("请输入偶数个16进制数字", "错误");
                        }
                    }
                    label_SendCount.Text = "TX:" + TxCount.ToString();
                }
            }
            
        }
        #endregion

        #region 切换选项时候修改串口属性
        private void cb_com_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cb_Baud_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.BaudRate = int.Parse(cb_Baud.Text);
        }

        private void cb_DataBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.DataBits = int.Parse(cb_DataBits.Text);
        }

        private void cb_StopBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.StopBits = (StopBits)int.Parse(cb_StopBits.Text);
        }
        #endregion

        #region com的下拉菜单展开时候自动搜索当前设备管理器的指定VID、PID
        private void cb_com_DropDown(object sender, EventArgs e)
        {
            cb_com.Items.Clear();       //清空

            if (PublicFun.g_strVIDPID == "")
            {
                MessageBox.Show("请先进入“设置”选定VID、PID");
                return;
            }

            if (PublicFun.g_strVIDPID == "ALL")
            {
                //查询当前有用的串口号
                SerialPort.GetPortNames();

                string[] ports = SerialPort.GetPortNames();
                foreach (string port in ports)
                {
                    cb_com.Items.Add(port);
                }
                if (cb_com.Items.Count == 0)
                {
                    MessageBox.Show("无COM存在!");
                    return;
                }
            }
            else
            {
                string[] tmpArray = PublicFun.g_strVIDPID.Split(new char[] { '-' });

                String strCurPortName = PublicFun.GetPortNameFormVidPid(tmpArray[0], tmpArray[1]);
                if (strCurPortName == null)
                {
                    MessageBox.Show("无指定VID、PID的COM存在!");
                    return;
                }

                cb_com.Items.Add(strCurPortName);
            }

        }
        #endregion

        #region VID、PID设置
        private void button4_Click_1(object sender, EventArgs e)
        {
            cb_com.SelectedIndex = -1;
            cb_com.Items.Clear();       //清空
            Form2 p = new Form2();
            p.ShowDialog();

        }
        #endregion
    }
}