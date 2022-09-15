package com.caysn.autoreplyprint;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.lang.reflect.Method;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;

import javax.swing.BorderFactory;
import javax.swing.ButtonGroup;
import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JList;
import javax.swing.JPanel;
import javax.swing.JRadioButton;
import javax.swing.JScrollPane;
import javax.swing.JTextField;
import javax.swing.ListSelectionModel;
import javax.swing.SwingUtilities;

import com.sun.jna.Pointer;
import com.sun.jna.ptr.IntByReference;

public class samplepage {

	@SuppressWarnings("serial")
	class GroupBoxPort extends JPanel implements ActionListener {

		public JRadioButton rbCom = new JRadioButton();
		public JRadioButton rbTcp = new JRadioButton();
		public JRadioButton rbUsb = new JRadioButton();
		public ButtonGroup rbGroup = new ButtonGroup();

		public JComboBox cbxComName = new JComboBox();
		public JComboBox cbxComBaudrate = new JComboBox();
		public JComboBox cbxComFlowControl = new JComboBox();
		public JTextField editIPAddress = new JTextField();
		public JTextField editTcpPort = new JTextField();
		public JComboBox cbxUsbName = new JComboBox();

		public GroupBoxPort() {
			this.setLayout(null);
			this.setSize(760, 120);
			this.setBorder(BorderFactory.createTitledBorder("Select Port"));

			rbGroup.add(rbCom);
			rbGroup.add(rbTcp);
			rbGroup.add(rbUsb);

			rbCom.setText("COM");
			rbCom.setBounds(10, 20, 60, 30);
			this.add(rbCom);

			rbTcp.setText("TCP");
			rbTcp.setBounds(10, 50, 60, 30);
			this.add(rbTcp);

			rbUsb.setText("USB");
			rbUsb.setBounds(10, 80, 60, 30);
			this.add(rbUsb);

			cbxComName.setBounds(70, 20, 480, 30);
			this.add(cbxComName);
			cbxComBaudrate.setBounds(550, 20, 80, 30);
			this.add(cbxComBaudrate);
			cbxComFlowControl.setBounds(630, 20, 120, 30);
			this.add(cbxComFlowControl);
			editIPAddress.setBounds(70, 50, 600, 31);
			this.add(editIPAddress);
			editTcpPort.setBounds(670, 50, 81, 31);
			this.add(editTcpPort);
			cbxUsbName.setBounds(70, 80, 680, 30);
			this.add(cbxUsbName);

			rbUsb.setSelected(true);
			editIPAddress.setText("192.168.1.87");
			editTcpPort.setText("9100");
			String[] ComBaudrateStringList = { "1200", "2400", "4800", "9600", "19200", "38400", "57600", "115200",
					"230400", "256000", "500000", "750000", "1125000", "1500000" };
			for (String baudrate : ComBaudrateStringList)
				cbxComBaudrate.addItem(baudrate);
			cbxComBaudrate.setSelectedIndex(7);
			cbxComFlowControl.addItem("No FlowControl");
			cbxComFlowControl.addItem("Xon/Xoff FlowControl");
			cbxComFlowControl.addItem("Hardware FlowControl");
			cbxComFlowControl.setSelectedIndex(0);
		}

		@Override
		public void actionPerformed(ActionEvent arg0) {

		}
	}
	
	@SuppressWarnings("serial")
	class TestForm extends JFrame implements ActionListener {

		String[] testFunctionOrderedList = new String[]{
				
	            "Test_Page_SampleTicket_58MM_1",
	            "Test_Page_SampleTicket_80MM_1",

	            "Test_Printer_GetPrinterInfo",
	            "Test_Printer_ClearPrinterBuffer",
	            "Test_Printer_ClearPrinterError",

	            "Test_Pos_QueryPrintResult",

	            "Test_Pos_KickOutDrawer",
	            "Test_Pos_Beep",
	            "Test_Pos_FeedAndHalfCutPaper",
	            "Test_Pos_FullCutPaper",
	            "Test_Pos_HalfCutPaper",
	            "Test_Pos_Feed",

	            "Test_Pos_PrintSelfTestPage",

	            "Test_Page_SetPageDrawDirection",
	            "Test_Page_DrawRect",
	            "Test_Page_DrawText",
	            "Test_Page_DrawTextInUTF8",
	            "Test_Page_DrawTextInGBK",
	            "Test_Page_DrawTextInBIG5",
	            "Test_Page_DrawTextInShiftJIS",
	            "Test_Page_DrawTextInEUCKR",
	            "Test_Page_DrawBarcode",
	            "Test_Page_DrawBarcode_CODE128",
	            "Test_Page_DrawQRCode",
	            "Test_Page_DrawRasterImageFromBufferedImage",
	            
	    };
		
		GroupBoxPort groupBoxPort = new GroupBoxPort();
		JButton btnEnumPort = new JButton();
		JButton btnOpenPort = new JButton();
		JButton btnClosePort = new JButton();
		JList listFunction = new JList(testFunctionOrderedList);
		JScrollPane scrollFunction = new JScrollPane(listFunction);
		JLabel labelFirmwareVersion = new JLabel();
		JLabel labelResolution = new JLabel();
		JLabel labelErrorStatus = new JLabel();
		JLabel labelInfoStatus = new JLabel();
		JLabel labelPrinterReceivedByteCount = new JLabel();
		JLabel labelPrinterPrintedPageID = new JLabel();
		Pointer h = Pointer.NULL;
		AutoReplyPrint.CP_OnPortClosedEvent_Callback closed_callback = new AutoReplyPrint.CP_OnPortClosedEvent_Callback() {
			@Override
			public void CP_OnPortClosedEvent(Pointer handle, Pointer private_data) {
				SwingUtilities.invokeLater(new Runnable() {
					@Override
					public void run() {
						btnClosePort.doClick();
					}
				});
			}
		};
		AutoReplyPrint.CP_OnPrinterStatusEvent_Callback status_callback = new AutoReplyPrint.CP_OnPrinterStatusEvent_Callback() {
			@Override
			public void CP_OnPrinterStatusEvent(Pointer h, final long printer_error_status,
					final long printer_info_status, Pointer private_data) {
				SwingUtilities.invokeLater(new Runnable() {
					@Override
					public void run() {
						Calendar calendar = Calendar.getInstance();
						Date calendarDate = calendar.getTime();
						String time = new SimpleDateFormat("yyyy-MM-dd kk:mm:ss").format(calendarDate);
						AutoReplyPrint.CP_PrinterStatus status = new AutoReplyPrint.CP_PrinterStatus(
								printer_error_status, printer_info_status);
						String error_status_string = String.format(" Printer Error Status: 0x%04X",
								printer_error_status & 0xffff);
						if (status.ERROR_OCCURED()) {
							if (status.ERROR_CUTTER())
								error_status_string += "[ERROR_CUTTER]";
							if (status.ERROR_FLASH())
								error_status_string += "[ERROR_FLASH]";
							if (status.ERROR_NOPAPER())
								error_status_string += "[ERROR_NOPAPER]";
							if (status.ERROR_VOLTAGE())
								error_status_string += "[ERROR_VOLTAGE]";
							if (status.ERROR_MARKER())
								error_status_string += "[ERROR_MARKER]";
							if (status.ERROR_ENGINE())
								error_status_string += "[ERROR_ENGINE]";
							if (status.ERROR_OVERHEAT())
								error_status_string += "[ERROR_OVERHEAT]";
							if (status.ERROR_COVERUP())
								error_status_string += "[ERROR_COVERUP]";
							if (status.ERROR_MOTOR())
								error_status_string += "[ERROR_MOTOR]";
						}
						String info_status_string = String.format(" Printer Info Status: 0x%04X",
								printer_info_status & 0xffff);
						if (status.INFO_LABELMODE())
							info_status_string += "[Label Mode]";
						if (status.INFO_LABELPAPER())
							info_status_string += "[Label Paper]";
						if (status.INFO_PAPERNOFETCH())
							info_status_string += "[Paper Not Fetch]";
						labelErrorStatus.setText(time + error_status_string);
						labelInfoStatus.setText(time + info_status_string);
					}
				});
			}
		};
		AutoReplyPrint.CP_OnPrinterReceivedEvent_Callback received_callback = new AutoReplyPrint.CP_OnPrinterReceivedEvent_Callback() {
			@Override
			public void CP_OnPrinterReceivedEvent(Pointer h, final int printer_received_byte_count,
					Pointer private_data) {
				SwingUtilities.invokeLater(new Runnable() {
					@Override
					public void run() {
						Calendar calendar = Calendar.getInstance();
						Date calendarDate = calendar.getTime();
						String time = new SimpleDateFormat("yyyy-MM-dd kk:mm:ss").format(calendarDate);
						labelPrinterReceivedByteCount
								.setText(time + " PrinterReceived: " + printer_received_byte_count);
					}
				});
			}
		};
		AutoReplyPrint.CP_OnPrinterPrintedEvent_Callback printed_callback = new AutoReplyPrint.CP_OnPrinterPrintedEvent_Callback() {
			@Override
			public void CP_OnPrinterPrintedEvent(Pointer h, final int printer_printed_page_id, Pointer private_data) {
				SwingUtilities.invokeLater(new Runnable() {
					@Override
					public void run() {
						Calendar calendar = Calendar.getInstance();
						Date calendarDate = calendar.getTime();
						String time = new SimpleDateFormat("yyyy-MM-dd kk:mm:ss").format(calendarDate);
						labelPrinterPrintedPageID.setText(time + " PrinterPrinted: " + printer_printed_page_id);
					}
				});
			}
		};

		private void AddCallback() {
			AutoReplyPrint.INSTANCE.CP_Port_AddOnPortClosedEvent(closed_callback, Pointer.NULL);
			AutoReplyPrint.INSTANCE.CP_Printer_AddOnPrinterStatusEvent(status_callback, Pointer.NULL);
			AutoReplyPrint.INSTANCE.CP_Printer_AddOnPrinterReceivedEvent(received_callback, Pointer.NULL);
			AutoReplyPrint.INSTANCE.CP_Printer_AddOnPrinterPrintedEvent(printed_callback, Pointer.NULL);
		}

		private void RemoveCallback() {
			AutoReplyPrint.INSTANCE.CP_Port_RemoveOnPortClosedEvent(closed_callback);
			AutoReplyPrint.INSTANCE.CP_Printer_RemoveOnPrinterStatusEvent(status_callback);
			AutoReplyPrint.INSTANCE.CP_Printer_RemoveOnPrinterReceivedEvent(received_callback);
			AutoReplyPrint.INSTANCE.CP_Printer_RemoveOnPrinterPrintedEvent(printed_callback);
		}

		public TestForm() {
			this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
			this.setLayout(null);
			this.setVisible(true);
			this.setSize(800, 700);
			this.setTitle(AutoReplyPrint.INSTANCE.CP_Library_Version());

			groupBoxPort.setLocation(10, 10);
			this.add(groupBoxPort);

			btnEnumPort.setBounds(20, 140, 240, 30);
			btnEnumPort.setText("EnumPort");
			btnEnumPort.addActionListener(this);
			this.add(btnEnumPort);
			btnOpenPort.setBounds(270, 140, 240, 30);
			btnOpenPort.setText("OpenPort");
			btnOpenPort.addActionListener(this);
			this.add(btnOpenPort);
			btnClosePort.setBounds(520, 140, 240, 30);
			btnClosePort.setText("ClosePort");
			btnClosePort.addActionListener(this);
			this.add(btnClosePort);

			labelFirmwareVersion.setBounds(20, 460, 740, 30);
			labelFirmwareVersion.setText("Firmware Version:");
			this.add(labelFirmwareVersion);
			labelResolution.setBounds(20, 490, 740, 30);
			labelResolution.setText("Resolution:");
			this.add(labelResolution);
			labelErrorStatus.setBounds(20, 520, 740, 30);
			labelErrorStatus.setText("Error Status:");
			this.add(labelErrorStatus);
			labelInfoStatus.setBounds(20, 550, 740, 30);
			labelInfoStatus.setText("Info Status:");
			this.add(labelInfoStatus);
			labelPrinterReceivedByteCount.setBounds(20, 580, 740, 30);
			labelPrinterReceivedByteCount.setText("Printer Received Byte Count:");
			this.add(labelPrinterReceivedByteCount);
			labelPrinterPrintedPageID.setBounds(20, 610, 740, 30);
			labelPrinterPrintedPageID.setText("Printer Printed Page ID:");
			this.add(labelPrinterPrintedPageID);

			scrollFunction.setBounds(20, 180, 740, 270);
			this.add(scrollFunction);
			listFunction.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
			// listFunction.addListSelectionListener(this);
			listFunction.addMouseListener(new MouseListener() {

				@Override
				public void mouseClicked(MouseEvent e) {
					// TODO Auto-generated method stub
					if (e.getSource() == listFunction) {
						String functionName = listFunction.getSelectedValue().toString();
						if ((functionName == null) || (functionName.isEmpty()))
							return;
						try {
							TestFunction fun = new TestFunction();
							Method m = TestFunction.class.getDeclaredMethod(functionName, Pointer.class);
							m.invoke(fun, h);
						} catch (Throwable tr) {
							tr.printStackTrace();
						}
					}
				}

				@Override
				public void mouseEntered(MouseEvent e) {
					// TODO Auto-generated method stub

				}

				@Override
				public void mouseExited(MouseEvent e) {
					// TODO Auto-generated method stub

				}

				@Override
				public void mousePressed(MouseEvent e) {
					// TODO Auto-generated method stub

				}

				@Override
				public void mouseReleased(MouseEvent e) {
					// TODO Auto-generated method stub

				}

			});

			btnEnumPort.doClick();
			refreshUI();

			AddCallback();
		}

		protected void finalize() throws Throwable {
			RemoveCallback();
			super.finalize();
		}

		@Override
		public void actionPerformed(ActionEvent e) {
			if (e.getSource() == btnEnumPort) {
				String[] port_list = null;

				groupBoxPort.cbxComName.removeAllItems();
				port_list = AutoReplyPrint.CP_Port_EnumCom_Helper.EnumCom();
				if (port_list != null) {
					for (String port : port_list)
						groupBoxPort.cbxComName.addItem(port);
				}

				groupBoxPort.cbxUsbName.removeAllItems();
				port_list = AutoReplyPrint.CP_Port_EnumUsb_Helper.EnumUsb();
				if (port_list != null) {
					for (String port : port_list)
						groupBoxPort.cbxUsbName.addItem(port);
				}

			} else if (e.getSource() == btnOpenPort) {
				if (groupBoxPort.rbCom.isSelected()) {
					if (groupBoxPort.cbxComName.getSelectedItem() == null)
						return;
					String name = groupBoxPort.cbxComName.getSelectedItem().toString();
					int baudrate = Integer.parseInt(groupBoxPort.cbxComBaudrate.getSelectedItem().toString());
					int flowcontrol = groupBoxPort.cbxComFlowControl.getSelectedIndex();
					h = AutoReplyPrint.INSTANCE.CP_Port_OpenCom(name, baudrate, AutoReplyPrint.CP_ComDataBits_8,
							AutoReplyPrint.CP_ComParity_NoParity, AutoReplyPrint.CP_ComStopBits_One, flowcontrol,
							1);
				} else if (groupBoxPort.rbUsb.isSelected()) {
					if (groupBoxPort.cbxUsbName.getSelectedItem() == null)
						return;
					String name = groupBoxPort.cbxUsbName.getSelectedItem().toString();
					h = AutoReplyPrint.INSTANCE.CP_Port_OpenUsb(name, 1);
				} else if (groupBoxPort.rbTcp.isSelected()) {
					String ip = groupBoxPort.editIPAddress.getText();
					int port = Integer.parseInt(groupBoxPort.editTcpPort.getText());
					h = AutoReplyPrint.INSTANCE.CP_Port_OpenTcp(null, ip, (short) port, 5000, 1);
				}
				refreshUI();
			} else if (e.getSource() == btnClosePort) {
				if (h != Pointer.NULL) {
					AutoReplyPrint.INSTANCE.CP_Port_Close(h);
					h = Pointer.NULL;
				}
				refreshUI();
			}
		}

		private void refreshUI() {
			groupBoxPort.setEnabled(h == Pointer.NULL);
			btnEnumPort.setEnabled(h == Pointer.NULL);
			btnOpenPort.setEnabled(h == Pointer.NULL);
			btnClosePort.setEnabled(h != Pointer.NULL);
			listFunction.setEnabled(h != Pointer.NULL);
			if (h != Pointer.NULL) {
				labelFirmwareVersion.setText("Firmware Version: "
						+ AutoReplyPrint.CP_Printer_GetPrinterFirmwareVersion_Helper.GetPrinterFirmwareVersion(h));
				IntByReference width_mm = new IntByReference();
				IntByReference height_mm = new IntByReference();
				IntByReference dots_per_mm = new IntByReference();
				if (AutoReplyPrint.INSTANCE.CP_Printer_GetPrinterResolutionInfo(h, width_mm, height_mm, dots_per_mm)) {
					labelResolution.setText("Resolution: " + "width:" + width_mm.getValue() + "mm " + "height:"
							+ height_mm.getValue() + "mm " + "dots_per_mm:" + dots_per_mm.getValue());
				}
			}
		}

	}

	static TestForm testform;
	public static void main(String[] args) {
		SwingUtilities.invokeLater(new Runnable() {
			@Override
			public void run() {
				testform = new samplepage().new TestForm();
			}
		});
	}
}
