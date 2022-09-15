using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;
using autoreplyprint.cs;
using System.Threading;

namespace samplepage_withoutautoreply
{
    public partial class Form1 : Form
    {
        UIntPtr h = UIntPtr.Zero;
        static Form1 window;


        public Form1()
        {
            InitializeComponent();
            window = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            refreshUI();
            this.Text = AutoReplyPrint.CP_Library_Version();
            cbxComFlowControl.SelectedIndex = 0;
            buttonEnumPort_Click(null, null);
            listBoxFunction.DataSource = TestFunction.testFunctionOrderedList;
            rbUsb.Checked = true;
            AddPrinterEvent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            RemovePrinterEvent();
            StopEnumNetPrinter();
            buttonClosePort_Click(null, null);
        }

        private void buttonEnumPort_Click(object sender, EventArgs e)
        {
            cbxComName.DataSource = AutoReplyPrint.CP_Port_EnumCom();
            cbxUsbName.DataSource = AutoReplyPrint.CP_Port_EnumUsb();
            cbxLptName.DataSource = AutoReplyPrint.CP_Port_EnumLpt();
            StartEnumNetPrinterInThread();
        }

        private void StopEnumNetPrinter()
        {
            cancelEnumNetPrinter = 1;
        }
        private void StartEnumNetPrinterInThread()
        {
            window.cbxIPAddress.Items.Clear();
            window.cbxIPAddress.Text = "";
            Thread thread = new Thread(EnumNetPrinter);
            thread.Start();
        }
        private int cancelEnumNetPrinter = 0;
        private void EnumNetPrinter()
        {
            cancelEnumNetPrinter = 0;
            AutoReplyPrint.CP_Port_EnumNetPrinter(3000, ref cancelEnumNetPrinter, OnNetPrinterDiscovered, UIntPtr.Zero);
        }
        private delegate void OnNetPrinterDiscoveredDelegate(String discovered_ip, String discovered_name);
        private static void OnNetPrinterDiscoveredUpdateAction(String discovered_ip, String discovered_name)
        {
            if (!window.cbxIPAddress.Items.Contains(discovered_name))
                window.cbxIPAddress.Items.Add(discovered_name);
            if (!window.cbxIPAddress.Items.Contains(discovered_ip))
                window.cbxIPAddress.Items.Add(discovered_ip);
            if ((window.cbxIPAddress.SelectedIndex < 0) || (window.cbxIPAddress.SelectedIndex > window.cbxIPAddress.Items.Count))
                window.cbxIPAddress.SelectedIndex = 0;
        }
        private static void OnNetPrinterDiscovered(String local_ip, String discovered_mac, String discovered_ip, String discovered_name, UIntPtr private_data)
        {
            OnNetPrinterDiscoveredDelegate action = new OnNetPrinterDiscoveredDelegate(OnNetPrinterDiscoveredUpdateAction);
            window.BeginInvoke(action, new String[] { discovered_ip, discovered_name });
        }

        private void buttonOpenPort_Click(object sender, EventArgs e)
        {
            if (rbCom.Checked)
            {
                String name = cbxComName.Text;
                int baudrate = int.Parse(cbxComBaudrate.Text);
                int flowcontrol = cbxComFlowControl.SelectedIndex;
                h = AutoReplyPrint.CP_Port_OpenCom(
                        name, baudrate,
                        AutoReplyPrint.CP_ComDataBits_8,
                        AutoReplyPrint.CP_ComParity_NoParity,
                        AutoReplyPrint.CP_ComStopBits_One,
                        flowcontrol,
                        0);
            }
            else if (rbUsb.Checked)
            {
                String name = cbxUsbName.Text;
                h = AutoReplyPrint.CP_Port_OpenUsb(name, 0);
            }
            else if (rbLpt.Checked)
            {
                String name = cbxLptName.Text;
                h = AutoReplyPrint.CP_Port_OpenLpt(name);
            }
            else if (rbTcp.Checked)
            {
                String ip = cbxIPAddress.Text;
                ushort port = (ushort)int.Parse(tbTcpPort.Text);
                h = AutoReplyPrint.CP_Port_OpenTcp(null, ip, port, 5000, 0);
            }
            refreshUI();
        }

        private void buttonClosePort_Click(object sender, EventArgs e)
        {
            AutoReplyPrint.CP_Port_Close(h);
            h = UIntPtr.Zero;
            refreshUI();
        }

        private void refreshUI()
        {
            groupBoxSelectPort.Enabled = (h == UIntPtr.Zero);
            buttonEnumPort.Enabled = (h == UIntPtr.Zero);
            buttonOpenPort.Enabled = (h == UIntPtr.Zero);
            buttonClosePort.Enabled = (h != UIntPtr.Zero);
            listBoxFunction.Enabled = (h != UIntPtr.Zero);
        }

        private static void OnPortClosedEventUpdateAction(uint val)
        {
            window.buttonClosePort_Click(null, null);
        }
        private static void OnPortClosedEvent(UIntPtr handle, UIntPtr private_data)
        {
            Action<uint> action = new Action<uint>(OnPortClosedEventUpdateAction);
            window.BeginInvoke(action, 0U);
        }

        AutoReplyPrint.CP_OnPortClosedEvent OnPortClosedDelegate = new AutoReplyPrint.CP_OnPortClosedEvent(OnPortClosedEvent);

        void AddPrinterEvent()
        {
            AutoReplyPrint.CP_Port_AddOnPortClosedEvent(OnPortClosedDelegate, UIntPtr.Zero);
        }
        void RemovePrinterEvent()
        {
            AutoReplyPrint.CP_Port_RemoveOnPortClosedEvent(OnPortClosedDelegate);
        }

        private void listBoxFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (h == UIntPtr.Zero)
                return;

            String functionName = (String)listBoxFunction.SelectedItem;
            if (String.IsNullOrEmpty(functionName))
                return;

            TestFunction testFunction = new TestFunction();
            Type testFunctionType = testFunction.GetType();
            MethodInfo mi = testFunctionType.GetMethod(functionName);
            mi.Invoke(testFunction, new object[] { h });
        }
    }
}