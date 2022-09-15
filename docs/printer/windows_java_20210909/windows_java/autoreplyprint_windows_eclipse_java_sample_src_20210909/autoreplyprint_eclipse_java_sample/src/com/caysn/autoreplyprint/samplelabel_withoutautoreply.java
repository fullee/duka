package com.caysn.autoreplyprint;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.lang.reflect.Method;

import javax.swing.BorderFactory;
import javax.swing.ButtonGroup;
import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JFrame;
import javax.swing.JList;
import javax.swing.JPanel;
import javax.swing.JRadioButton;
import javax.swing.JScrollPane;
import javax.swing.JTextField;
import javax.swing.ListSelectionModel;
import javax.swing.SwingUtilities;

import com.sun.jna.Pointer;

public class samplelabel_withoutautoreply {

	@SuppressWarnings("serial")
	class GroupBoxPort extends JPanel implements ActionListener {

		public JRadioButton rbCom = new JRadioButton();
		public JRadioButton rbTcp = new JRadioButton();
		public JRadioButton rbUsb = new JRadioButton();
		public JRadioButton rbLpt = new JRadioButton();
		public ButtonGroup rbGroup = new ButtonGroup();

		public JComboBox cbxComName = new JComboBox();
		public JComboBox cbxComBaudrate = new JComboBox();
		public JComboBox cbxComFlowControl = new JComboBox();
		public JTextField editIPAddress = new JTextField();
		public JTextField editTcpPort = new JTextField();
		public JComboBox cbxUsbName = new JComboBox();
		public JComboBox cbxLptName = new JComboBox();

		public GroupBoxPort() {
			this.setLayout(null);
			this.setSize(760, 150);
			this.setBorder(BorderFactory.createTitledBorder("Select Port"));

			rbGroup.add(rbCom);
			rbGroup.add(rbTcp);
			rbGroup.add(rbUsb);
			rbGroup.add(rbLpt);

			rbCom.setText("COM");
			rbCom.setBounds(10, 20, 60, 30);
			this.add(rbCom);

			rbTcp.setText("TCP");
			rbTcp.setBounds(10, 50, 60, 30);
			this.add(rbTcp);

			rbUsb.setText("USB");
			rbUsb.setBounds(10, 80, 60, 30);
			this.add(rbUsb);
			
			rbLpt.setText("LPT");
			rbLpt.setBounds(10, 110, 60, 30);
			this.add(rbLpt);

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
			cbxLptName.setBounds(70, 110, 680, 30);
			this.add(cbxLptName);

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
				
	            "Test_Label_SampleTicket_58MM_1",
	            "Test_Label_SampleTicket_80MM_1",
	            "Test_Label_SampleTicket_HeadImageTail_CompressionLevel0",
	            "Test_Label_SampleTicket_HeadImageTail_CompressionLevel1",
	            "Test_Label_SampleTicket_HeadImageTail_CompressionLevel2",

	            "Test_Port_Write",
	            "Test_Port_Read",
	            "Test_Port_Available",
	            "Test_Port_SkipAvailable",
	            "Test_Port_IsConnectionValid",

	            "Test_Printer_ClearPrinterBuffer",
	            "Test_Printer_ClearPrinterError",

	            "Test_Pos_QueryRTStatus",
	            "Test_Pos_QueryPrintResult",

	            "Test_Pos_KickOutDrawer",
	            "Test_Pos_Beep",

	            "Test_Pos_PrintSelfTestPage",
	            
	            "Test_Label_EnableLabelMode",
	            "Test_Label_DisableLabelMode",
	            "Test_Label_CalibrateLabel",
	            "Test_Label_FeedLabel",
	            "Test_Label_SetLabelPositionAdjustment",
	            "Test_Label_PageBegin_PagePrint",
	            "Test_Label_DrawText",
	            "Test_Label_DrawBarcode_UPCA",
	            "Test_Label_DrawBarcode_UPCE",
	            "Test_Label_DrawBarcode_EAN13",
	            "Test_Label_DrawBarcode_EAN8",
	            "Test_Label_DrawBarcode_CODE39",
	            "Test_Label_DrawBarcode_ITF",
	            "Test_Label_DrawBarcode_CODEBAR",
	            "Test_Label_DrawBarcode_CODE93",
	            "Test_Label_DrawBarcode_CODE128",
	            "Test_Label_DrawQRCode",
	            "Test_Label_DrawPDF417Code",
	            "Test_Label_DrawLine",
	            "Test_Label_DrawRect",
	            "Test_Label_DrawBox",
	            "Test_Label_DrawImageFromBufferedImage",

	    };
		
		GroupBoxPort groupBoxPort = new GroupBoxPort();
		JButton btnEnumPort = new JButton();
		JButton btnOpenPort = new JButton();
		JButton btnClosePort = new JButton();
		JList listFunction = new JList(testFunctionOrderedList);
		JScrollPane scrollFunction = new JScrollPane(listFunction);
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

		private void AddCallback() {
			AutoReplyPrint.INSTANCE.CP_Port_AddOnPortClosedEvent(closed_callback, Pointer.NULL);
		}

		private void RemoveCallback() {
			AutoReplyPrint.INSTANCE.CP_Port_RemoveOnPortClosedEvent(closed_callback);
		}

		public TestForm() {
			this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
			this.setLayout(null);
			this.setVisible(true);
			this.setSize(800, 700);
			this.setTitle(AutoReplyPrint.INSTANCE.CP_Library_Version());

			groupBoxPort.setLocation(10, 10);
			this.add(groupBoxPort);

			btnEnumPort.setBounds(20, 170, 240, 30);
			btnEnumPort.setText("EnumPort");
			btnEnumPort.addActionListener(this);
			this.add(btnEnumPort);
			btnOpenPort.setBounds(270, 170, 240, 30);
			btnOpenPort.setText("OpenPort");
			btnOpenPort.addActionListener(this);
			this.add(btnOpenPort);
			btnClosePort.setBounds(520, 170, 240, 30);
			btnClosePort.setText("ClosePort");
			btnClosePort.addActionListener(this);
			this.add(btnClosePort);

			scrollFunction.setBounds(20, 210, 740, 440);
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
				
				groupBoxPort.cbxLptName.removeAllItems();
				port_list = AutoReplyPrint.CP_Port_EnumLpt_Helper.EnumLpt();
				if (port_list != null) {
					for (String port : port_list)
						groupBoxPort.cbxLptName.addItem(port);
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
							0);
				} else if (groupBoxPort.rbUsb.isSelected()) {
					if (groupBoxPort.cbxUsbName.getSelectedItem() == null)
						return;
					String name = groupBoxPort.cbxUsbName.getSelectedItem().toString();
					h = AutoReplyPrint.INSTANCE.CP_Port_OpenUsb(name, 0);
				} else if (groupBoxPort.rbLpt.isSelected()) {
					if (groupBoxPort.cbxLptName.getSelectedItem() == null)
						return;
					String name = groupBoxPort.cbxLptName.getSelectedItem().toString();
					h = AutoReplyPrint.INSTANCE.CP_Port_OpenLpt(name);
				} else if (groupBoxPort.rbTcp.isSelected()) {
					String ip = groupBoxPort.editIPAddress.getText();
					int port = Integer.parseInt(groupBoxPort.editTcpPort.getText());
					h = AutoReplyPrint.INSTANCE.CP_Port_OpenTcp(null, ip, (short) port, 5000, 0);
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
		}

	}

	static TestForm testform;
	public static void main(String[] args) {
		SwingUtilities.invokeLater(new Runnable() {
			@Override
			public void run() {
				testform = new samplelabel_withoutautoreply().new TestForm();
			}
		});
	}
}
