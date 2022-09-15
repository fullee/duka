package com.caysn.autoreplyprint;

import java.io.FileInputStream;
import java.io.InputStream;

import javax.swing.JFileChooser;
import javax.swing.JOptionPane;
import javax.swing.SwingUtilities;
import javax.swing.filechooser.FileNameExtensionFilter;

public class TestUtils {
	public static byte[] ReadFromFile(String fileName) {
		byte[] data = null;
		try {
			InputStream in = new FileInputStream(fileName);
			data = new byte[in.available()];
			in.read(data);
			in.close();
		} catch (Throwable tr) {
			tr.printStackTrace();
		}

		return data;
	}

	public static void showMessageOnUiThread(final String msg) {
		SwingUtilities.invokeLater(new Runnable() {
			@Override
			public void run() {
				JOptionPane.showMessageDialog(null, msg);
			}
		});
	}

	public static String SelectImage() {
		JFileChooser fcDlg = new JFileChooser();
		fcDlg.setDialogTitle("Select Image...");
		FileNameExtensionFilter filter = new FileNameExtensionFilter("Images(*.bmp;*.png;*.jpg)", "bmp", "png", "jpg");
		fcDlg.setFileFilter(filter);
		int returnVal = fcDlg.showOpenDialog(null);
		if (returnVal == JFileChooser.APPROVE_OPTION) {
			String filepath = fcDlg.getSelectedFile().getPath();
			return filepath;
		}
		return null;
	}
}
