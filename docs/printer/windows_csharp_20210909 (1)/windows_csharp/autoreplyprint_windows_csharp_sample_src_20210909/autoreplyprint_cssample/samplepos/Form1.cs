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

namespace samplepos
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
                        1);
            }
            else if (rbUsb.Checked)
            {
                String name = cbxUsbName.Text;
                h = AutoReplyPrint.CP_Port_OpenUsb(name, 1);
            }
            else if (rbTcp.Checked)
            {
                String ip = cbxIPAddress.Text;
                ushort port = (ushort)int.Parse(tbTcpPort.Text);
                h = AutoReplyPrint.CP_Port_OpenTcp(null, ip, port, 5000, 1);
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
            if (h != UIntPtr.Zero)
            {
                labelFirmwareVersion.Text = AutoReplyPrint.CP_Printer_GetPrinterFirmwareVersion(h);
                uint width_mm = 0;
                uint height_mm = 0;
                uint dots_per_mm = 0;
                AutoReplyPrint.CP_Printer_GetPrinterResolutionInfo(h, ref width_mm, ref height_mm, ref dots_per_mm);
                labelResolution.Text = "Resolution: width_mm:" + width_mm + " height_mm:" + height_mm + " dots_per_mm:" + dots_per_mm;
            }
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

        private static void OnPrinterStatusEventUpdateAction(long printer_status)
        {
            long printer_error_status = printer_status & 0xffff;
            long printer_info_status = (printer_status >> 16) & 0xffff;

            // printer_error_status
            {
                String status_str = "";
                if (AutoReplyPrint.CP_PRINTERSTATUS_ERROR_CUTTER(printer_error_status))
                    status_str += "[Cutter Error]";
                if (AutoReplyPrint.CP_PRINTERSTATUS_ERROR_FLASH(printer_error_status))
                    status_str += "[Flash Error]";
                if (AutoReplyPrint.CP_PRINTERSTATUS_ERROR_NOPAPER(printer_error_status))
                    status_str += "[No Paper]";
                if (AutoReplyPrint.CP_PRINTERSTATUS_ERROR_VOLTAGE(printer_error_status))
                    status_str += "[Voltage Error]";
                if (AutoReplyPrint.CP_PRINTERSTATUS_ERROR_MARKER(printer_error_status))
                    status_str += "[Marker Error]";
                if (AutoReplyPrint.CP_PRINTERSTATUS_ERROR_ENGINE(printer_error_status))
                    status_str += "[Engine Error]";
                if (AutoReplyPrint.CP_PRINTERSTATUS_ERROR_OVERHEAT(printer_error_status))
                    status_str += "[Overheat]";
                if (AutoReplyPrint.CP_PRINTERSTATUS_ERROR_COVERUP(printer_error_status))
                    status_str += "[Coverup]";
                if (AutoReplyPrint.CP_PRINTERSTATUS_ERROR_MOTOR(printer_error_status))
                    status_str += "[Motor Error]";

                window.labelPrinterErrorStatus.Text = DateTime.Now.ToString("F") + " Printer Error Status: " + String.Format("0x{0:X}", printer_error_status) + status_str;
            }

            // printer_info_status
            {
                String status_str = "";
                if (AutoReplyPrint.CP_PRINTERSTATUS_INFO_LABELMODE(printer_info_status))
                    status_str += "[Label Mode]";
                if (AutoReplyPrint.CP_PRINTERSTATUS_INFO_LABELPAPER(printer_info_status))
                    status_str += "[Label Paper]";
                if (AutoReplyPrint.CP_PRINTERSTATUS_INFO_PAPERNOFETCH(printer_info_status))
                    status_str += "[Paper Not Fetch]";

                window.labelPrinterInfoStatus.Text = DateTime.Now.ToString("F") + " Printer Info Status: " + String.Format("0x{0:X}", printer_info_status) + status_str;
            }
        }
        private static void OnPrinterStatusEvent(UIntPtr handle, long printer_error_status, long printer_info_status, UIntPtr private_data)
        {
            Action<long> action = new Action<long>(OnPrinterStatusEventUpdateAction);
            window.BeginInvoke(action, printer_error_status | (printer_info_status << 16) );
        }

        private static void OnPrinterReceivedEventUpdateAction(uint printer_received_byte_count)
        {
            window.labelPrinterReceived.Text = DateTime.Now.ToString("F") + " Printer Received: " + String.Format("{0:D}", printer_received_byte_count);
        }
        private static void OnPrinterReceivedEvent(UIntPtr handle, uint printer_received_byte_count, UIntPtr private_data)
        {
            Action<uint> action = new Action<uint>(OnPrinterReceivedEventUpdateAction);
            window.BeginInvoke(action, printer_received_byte_count);
        }

        private static void OnPrinterPrintedEventUpdateAction(uint printer_printed_page_id)
        {
            window.labelPrinterPrinted.Text = DateTime.Now.ToString("F") + " Printer Printed: " + String.Format("{0:4}", printer_printed_page_id);
        }
        private static void OnPrinterPrintedEvent(UIntPtr handle, uint printer_printed_page_id, UIntPtr private_data)
        {
            Action<uint> action = new Action<uint>(OnPrinterPrintedEventUpdateAction);
            window.BeginInvoke(action, printer_printed_page_id);
        }

        AutoReplyPrint.CP_OnPortClosedEvent OnPortClosedDelegate = new AutoReplyPrint.CP_OnPortClosedEvent(OnPortClosedEvent);
        AutoReplyPrint.CP_OnPrinterStatusEvent OnPrinterStatusDelegate = new AutoReplyPrint.CP_OnPrinterStatusEvent(OnPrinterStatusEvent);
        AutoReplyPrint.CP_OnPrinterReceivedEvent OnPrinterReceivedDelegate = new AutoReplyPrint.CP_OnPrinterReceivedEvent(OnPrinterReceivedEvent);
        AutoReplyPrint.CP_OnPrinterPrintedEvent OnPrinterPrintedDelegate = new AutoReplyPrint.CP_OnPrinterPrintedEvent(OnPrinterPrintedEvent);

        void AddPrinterEvent()
        {
            AutoReplyPrint.CP_Port_AddOnPortClosedEvent(OnPortClosedDelegate, UIntPtr.Zero);
            AutoReplyPrint.CP_Printer_AddOnPrinterStatusEvent(OnPrinterStatusDelegate, UIntPtr.Zero);
            AutoReplyPrint.CP_Printer_AddOnPrinterReceivedEvent(OnPrinterReceivedDelegate, UIntPtr.Zero);
            AutoReplyPrint.CP_Printer_AddOnPrinterPrintedEvent(OnPrinterPrintedDelegate, UIntPtr.Zero);
        }
        void RemovePrinterEvent()
        {
            AutoReplyPrint.CP_Port_RemoveOnPortClosedEvent(OnPortClosedDelegate);
            AutoReplyPrint.CP_Printer_RemoveOnPrinterStatusEvent(OnPrinterStatusDelegate);
            AutoReplyPrint.CP_Printer_RemoveOnPrinterReceivedEvent(OnPrinterReceivedDelegate);
            AutoReplyPrint.CP_Printer_RemoveOnPrinterPrintedEvent(OnPrinterPrintedDelegate);
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