using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SerialAssistant
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            //迭代所有的VID、PID
            //常用VID、PID
            //deviceVID == 0x27DD && devicePID == 0x0002
            //deviceVID == 0x0103 && devicePID == 0x6061
            //deviceVID == 0x26F1 && devicePID == 0x5650 
            string[] tab_data = new string[] { "ALL", "27DD-0002", "0103-6061", "26F1-5650", "26F1-D001" };
            foreach (string str in tab_data)
            {
                cb_VidPid.Items.Add(str);
            }

            cb_VidPid.SelectedIndex = PublicFun.g_icbVidPid_SelectedIndex;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (cb_VidPid.SelectedIndex == -1)
            {
                PublicFun.g_strVIDPID = "";
            } 
            else
            {
                PublicFun.g_strVIDPID = cb_VidPid.Text;
                PublicFun.g_icbVidPid_SelectedIndex = cb_VidPid.SelectedIndex;
            }

            this.Close();
        }
    }
}
