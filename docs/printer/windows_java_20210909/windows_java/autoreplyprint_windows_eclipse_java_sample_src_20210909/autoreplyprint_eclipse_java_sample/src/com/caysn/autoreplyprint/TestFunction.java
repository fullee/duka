package com.caysn.autoreplyprint;

import java.awt.image.BufferedImage;
import java.io.FileInputStream;
import java.text.SimpleDateFormat;
import java.util.Date;

import javax.imageio.ImageIO;

import com.sun.jna.Pointer;
import com.sun.jna.WString;
import com.sun.jna.ptr.IntByReference;
import com.sun.jna.ptr.LongByReference;

public class TestFunction {

	void Test_Pos_SampleTicket_58MM_1(Pointer h) {
		int paperWidth = 384;

		AutoReplyPrint.INSTANCE.CP_Pos_ResetPrinter(h);
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteMode(h);
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_UTF8);

		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "123xxstreet,xxxcity,xxxxstate\r\n");
		AutoReplyPrint.INSTANCE.CP_Pos_SetAlignment(h, AutoReplyPrint.CP_Pos_Alignment_Right);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "TEL 9999-99-9999  C#2\r\n");
		AutoReplyPrint.INSTANCE.CP_Pos_SetAlignment(h, AutoReplyPrint.CP_Pos_Alignment_HCenter);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "2020-12-26 16:41:00");
		AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 1);

		AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 1);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "apples");
		AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, paperWidth - 12 * 6);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "$10.00");
		AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 1);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "grapes");
		AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, paperWidth - 12 * 6);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "$20.00");
		AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 1);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "bananas");
		AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, paperWidth - 12 * 6);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "$30.00");
		AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 1);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "lemons");
		AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, paperWidth - 12 * 6);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "$40.00");
		AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 1);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "oranges");
		AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, paperWidth - 12 * 7);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "$100.00");
		AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 1);
		AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 1);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "Before adding tax");
		AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, paperWidth - 12 * 7);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "$200.00");
		AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 1);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "tax 5.0%");
		AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, paperWidth - 12 * 6);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "$10.00");
		AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 1);
		String line = "";
		for (int i = 0; i < paperWidth / 12; ++i)
			line += " ";
		AutoReplyPrint.INSTANCE.CP_Pos_SetTextUnderline(h, 2);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, line);
		AutoReplyPrint.INSTANCE.CP_Pos_SetTextUnderline(h, 0);
		AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 1);
		AutoReplyPrint.INSTANCE.CP_Pos_SetTextScale(h, 1, 0);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "total");
		AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, paperWidth - 12 * 2 * 7);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "$190.00");
		AutoReplyPrint.INSTANCE.CP_Pos_SetTextScale(h, 0, 0);
		AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 1);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "Customer's payment");
		AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, paperWidth - 12 * 7);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "$200.00");
		AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 1);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "Change");
		AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, paperWidth - 12 * 6);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "$10.00");
		AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 1);

		AutoReplyPrint.INSTANCE.CP_Pos_SetBarcodeHeight(h, 60);
		AutoReplyPrint.INSTANCE.CP_Pos_SetBarcodeUnitWidth(h, 3);
		AutoReplyPrint.INSTANCE.CP_Pos_SetBarcodeReadableTextPosition(h, AutoReplyPrint.CP_Pos_BarcodeTextPrintPosition_BelowBarcode);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintBarcode(h, AutoReplyPrint.CP_Pos_BarcodeType_UPCA, "12345678901");

		AutoReplyPrint.INSTANCE.CP_Pos_Beep(h, 1, 500);

		{
			Test_Pos_QueryPrintResult(h);
		}
	}

	void Test_Pos_SampleTicket_80MM_1(Pointer h) {
		int[] nLineStartPos = { 0, 201, 401 };
		int[] nLineEndPos = { 200, 400, 575 };

		{
			AutoReplyPrint.INSTANCE.CP_Pos_ResetPrinter(h);
			AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteMode(h);
			AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_UTF8);
			AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 2);
		}

		{
			AutoReplyPrint.INSTANCE.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.length, nLineStartPos, nLineEndPos);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.length, nLineStartPos, nLineEndPos);
		}

		{
			AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 2);
			AutoReplyPrint.INSTANCE.CP_Pos_SetAlignment(h, AutoReplyPrint.CP_Pos_Alignment_Right);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("服务台\r\n"));
		}

		{
			AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 2);

			int nStartPos = 0;
			int nEndPos = 120;
			AutoReplyPrint.INSTANCE.CP_Pos_PrintHorizontalLineSpecifyThickness(h, nStartPos, nEndPos, 3);
			AutoReplyPrint.INSTANCE.CP_Pos_FeedDot(h, 10);
			AutoReplyPrint.INSTANCE.CP_Pos_SetAlignment(h, AutoReplyPrint.CP_Pos_Alignment_Left);
			AutoReplyPrint.INSTANCE.CP_Pos_SetTextBold(h, 1);
			AutoReplyPrint.INSTANCE.CP_Pos_SetTextScale(h, 1, 1);
			AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 12);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("圆桌"));
			AutoReplyPrint.INSTANCE.CP_Pos_FeedDot(h, 0);
			AutoReplyPrint.INSTANCE.CP_Pos_SetTextScale(h, 0, 0);
			AutoReplyPrint.INSTANCE.CP_Pos_FeedDot(h, 10);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintHorizontalLineSpecifyThickness(h, nStartPos, nEndPos, 3);
			AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 1);
			AutoReplyPrint.INSTANCE.CP_Pos_SetTextBold(h, 0);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("麻辣香锅（上梅林店）\r\n2020年2月7日15:51:00\r\n\r\n"));
		}

		{
			AutoReplyPrint.INSTANCE.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.length, nLineStartPos, nLineEndPos);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.length, nLineStartPos, nLineEndPos);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.length, nLineStartPos, nLineEndPos);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.length, nLineStartPos, nLineEndPos);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.length, nLineStartPos, nLineEndPos);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.length, nLineStartPos, nLineEndPos);
		}

		{
			AutoReplyPrint.INSTANCE.CP_Pos_SetAlignment(h, AutoReplyPrint.CP_Pos_Alignment_HCenter);
			AutoReplyPrint.INSTANCE.CP_Pos_SetTextScale(h, 1, 1);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("\r\n15-D-一楼-大厅-散座\r\n"));
			AutoReplyPrint.INSTANCE.CP_Pos_SetAlignment(h, AutoReplyPrint.CP_Pos_Alignment_Left);
			AutoReplyPrint.INSTANCE.CP_Pos_SetTextScale(h, 0, 0);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("\r\n扫码点餐订单\r\n店内用餐\r\n7人\r\n"));
		}

		{
			AutoReplyPrint.INSTANCE.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.length, nLineStartPos, nLineEndPos);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.length, nLineStartPos, nLineEndPos);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.length, nLineStartPos, nLineEndPos);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.length, nLineStartPos, nLineEndPos);
		}

		{
			AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 0);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("\r\n热菜类\r\n"));
			AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 80);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("鱼香肉丝"));
			AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 200);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("1"));
			AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 480);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("¥23.50\r\n"));
			AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 80);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("麻辣鸡丝"));
			AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 200);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("1"));
			AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 480);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("¥23.50\r\n"));
			AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 0);

			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("凉菜类\r\n"));
			AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 80);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("凉拌腐竹"));
			AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 200);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("1"));
			AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 480);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("¥23.50\r\n"));
			AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 80);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("糖醋花生"));
			AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 200);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("1"));
			AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 480);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("¥23.50\r\n"));
		}

		{
			AutoReplyPrint.INSTANCE.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.length, nLineStartPos, nLineEndPos);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.length, nLineStartPos, nLineEndPos);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.length, nLineStartPos, nLineEndPos);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.length, nLineStartPos, nLineEndPos);
		}

		{
			AutoReplyPrint.INSTANCE.CP_Pos_FeedDot(h, 30);
			AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 80);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("消毒餐具"));
			AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 200);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("7"));
			AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 480);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("¥14.00\r\n"));
		}

		{
			AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 2);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.length, nLineStartPos, nLineEndPos);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.length, nLineStartPos, nLineEndPos);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.length, nLineStartPos, nLineEndPos);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.length, nLineStartPos, nLineEndPos);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.length, nLineStartPos, nLineEndPos);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.length, nLineStartPos, nLineEndPos);
			AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 1);
		}

		{
			AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 0);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("在线支付"));
			AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 480);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("¥114.00\r\n"));
		}

		{
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("备注\r\n"));
			AutoReplyPrint.INSTANCE.CP_Pos_SetPrintAreaLeftMargin(h, 80);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("所有菜都不要放葱，口味要微辣。百事可乐不要加冰。上菜快点，太慢了！！\r\n\r\n"));
			AutoReplyPrint.INSTANCE.CP_Pos_SetPrintAreaLeftMargin(h, 0);
		}

		{
			AutoReplyPrint.INSTANCE.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.length, nLineStartPos, nLineEndPos);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.length, nLineStartPos, nLineEndPos);
			AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 1);
		}

		{
			AutoReplyPrint.INSTANCE.CP_Pos_SetAlignment(h, AutoReplyPrint.CP_Pos_Alignment_HCenter);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintQRCode(h, 0, AutoReplyPrint.CP_QRCodeECC_L, "麻辣香锅");
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("\r\n用心服务每一天\r\n40008083030\r\n\r\n"));
		}

		{
			AutoReplyPrint.INSTANCE.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.length, nLineStartPos, nLineEndPos);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.length, nLineStartPos, nLineEndPos);
		}

		{
			AutoReplyPrint.INSTANCE.CP_Pos_Beep(h, 3, 300);
			AutoReplyPrint.INSTANCE.CP_Pos_FeedAndHalfCutPaper(h);
		}

		{
			Test_Pos_QueryPrintResult(h);
		}
	}

	void Test_Pos_SampleTicket_80MM_2(Pointer h) {
		{
			AutoReplyPrint.INSTANCE.CP_Printer_ClearPrinterBuffer(h);
			AutoReplyPrint.INSTANCE.CP_Pos_ResetPrinter(h);
			AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteMode(h);
			AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_UTF8);
		}

		{
			AutoReplyPrint.INSTANCE.CP_Pos_PrintHorizontalLine(h, 0, 575);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintHorizontalLine(h, 0, 575);
			AutoReplyPrint.INSTANCE.CP_Pos_SetAlignment(h, AutoReplyPrint.CP_Pos_Alignment_Left);
			AutoReplyPrint.INSTANCE.CP_Pos_SetTextBold(h, 1);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("国药堂大药房(上海)限公司\r\n"));
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("测试自动售药机器\r\n"));
			AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 1);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("订单号:" + 999999999 + "\r\n"));
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("日期:" + "2020-07-31" + "\r\n"));
			AutoReplyPrint.INSTANCE.CP_Pos_PrintHorizontalLine(h, 0, 575);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintHorizontalLine(h, 0, 575);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("商品编码/商品名称/规格/厂家\r\n"));
			AutoReplyPrint.INSTANCE.CP_Pos_PrintHorizontalLine(h, 0, 575);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintHorizontalLine(h, 0, 575);
		}

		{
			AutoReplyPrint.INSTANCE.CP_Pos_QueryPrintResult(h, 3000);
		}

		{
			AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 1);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("FM111111" + "/" + "藿香正气水" + "/" + "1.8g*16片" + "/" + "盒" + "/" + "999感冒灵修正药业" + "★运动员慎用" + "\r\n"));
			AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 0);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("数量" + 666));
			AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 240);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("单价:" + 111));
			AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 380);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("金额:" + "9999.99" + "\r\n"));
			AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 0);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("批号:" + "22222222"));
			AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 340);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("有效期至:" + "2020-22-22" + "\r\n"));
			AutoReplyPrint.INSTANCE.CP_Pos_PrintHorizontalLine(h, 0, 575);
			AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 1);
			AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 0);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("数量合计:" + 999999));
			AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 380);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("金额合计:" + 9999.99 + "\r\n"));
			AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 1);

			AutoReplyPrint.INSTANCE.CP_Pos_SetAlignment(h, AutoReplyPrint.CP_Pos_Alignment_Left);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("客服电话:4001-005-835\r\n"));
			AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 1);
			AutoReplyPrint.INSTANCE.CP_Pos_SetAlignment(h, AutoReplyPrint.CP_Pos_Alignment_HCenter);
			AutoReplyPrint.INSTANCE.CP_Pos_SetPrintAreaLeftMargin(h, 20);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("因药品属于特殊商品，除药品质量原因外，药品一经售出，不得退换\r\n\r\n"));
			AutoReplyPrint.INSTANCE.CP_Pos_SetPrintAreaLeftMargin(h, 20);

			AutoReplyPrint.INSTANCE.CP_Pos_SetAlignment(h, AutoReplyPrint.CP_Pos_Alignment_HCenter);
			AutoReplyPrint.INSTANCE.CP_Pos_SetBarcodeUnitWidth(h, 8);
			AutoReplyPrint.INSTANCE.CP_Pos_PrintQRCode(h, 0, AutoReplyPrint.CP_QRCodeECC_L, "https://m.yao123.com/static/hmkp/invoiceInfo.html");

			AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 1);

			AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("盒马APP-我的-扫码-申请开发票。\r\n请在90天内申请开发票\r\n\r\n\r\n"));
			AutoReplyPrint.INSTANCE.CP_Pos_FeedAndHalfCutPaper(h);

			AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 1);
			AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 1);
		}

		{
			Test_Pos_QueryPrintResult(h);
		}
	}

	void Test_Label_SampleTicket_58MM_1(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteMode(h);
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_UTF8);

		AutoReplyPrint.INSTANCE.CP_Label_PageBegin(h, 0, 0, 384, 240, 0);
		AutoReplyPrint.INSTANCE.CP_Label_DrawBox(h, 0, 0, 384, 240, 1, 1);
		AutoReplyPrint.INSTANCE.CP_Label_DrawTextInUTF8(h, 10, 10, 24, 0, new WString("型号：P58A+"));
		AutoReplyPrint.INSTANCE.CP_Label_DrawTextInUTF8(h, 10, 40, 24, 0, new WString("MFG ：20201226"));
		AutoReplyPrint.INSTANCE.CP_Label_DrawBarcode(h, 10, 70, AutoReplyPrint.CP_Label_BarcodeType_CODE128, AutoReplyPrint.CP_Label_BarcodeTextPrintPosition_BelowBarcode, 60, 2, 0, "No.123456");
		AutoReplyPrint.INSTANCE.CP_Label_PagePrint(h, 1);

		{
			Test_Pos_QueryPrintResult(h);
		}
	}

	void Test_Label_SampleTicket_80MM_1(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteMode(h);
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_UTF8);

		AutoReplyPrint.INSTANCE.CP_Label_PageBegin(h, 0, 0, 576, 240, 0);
		AutoReplyPrint.INSTANCE.CP_Label_DrawBox(h, 0, 0, 576, 240, 1, 1);
		AutoReplyPrint.INSTANCE.CP_Label_DrawTextInUTF8(h, 10, 10, 24, 0, new WString("型号：P58A+"));
		AutoReplyPrint.INSTANCE.CP_Label_DrawTextInUTF8(h, 10, 40, 24, 0, new WString("MFG ：20201226"));
		AutoReplyPrint.INSTANCE.CP_Label_DrawBarcode(h, 10, 70, AutoReplyPrint.CP_Label_BarcodeType_CODE128, AutoReplyPrint.CP_Label_BarcodeTextPrintPosition_BelowBarcode, 60, 2, 0, "No.123456");
		AutoReplyPrint.INSTANCE.CP_Label_PagePrint(h, 1);

		{
			Test_Pos_QueryPrintResult(h);
		}
	}

	void Test_Label_SampleTicket_HeadImageTail_CompressionLevel0(Pointer h) {
		String filePath = TestUtils.SelectImage();
		if (filePath == null)
			return;

		BufferedImage image = null;
		try {
			image = ImageIO.read(new FileInputStream(filePath));
		} catch (Throwable tr) {
			tr.printStackTrace();
		}
		if ((image == null) || (image.getWidth() == 0) || (image.getHeight() == 0))
			return;

		int printwidth = 384;
		int dstw = printwidth;
		int dsth = (int) (dstw * ((double) image.getHeight() / image.getWidth()));

		AutoReplyPrint.INSTANCE.CP_Label_BackPaperToPrintPosition(h);
		AutoReplyPrint.CP_Pos_PrintRasterImageFromData_Helper.PrintRasterImageFromBufferedImage(h, dstw, dsth, image, AutoReplyPrint.CP_ImageBinarizationMethod_ErrorDiffusion, AutoReplyPrint.CP_ImageCompressionMethod_None);
		AutoReplyPrint.INSTANCE.CP_Label_FeedPaperToTearPosition(h);

		Test_Pos_QueryPrintResult(h);
	}

	void Test_Label_SampleTicket_HeadImageTail_CompressionLevel1(Pointer h) {
		String filePath = TestUtils.SelectImage();
		if (filePath == null)
			return;

		BufferedImage image = null;
		try {
			image = ImageIO.read(new FileInputStream(filePath));
		} catch (Throwable tr) {
			tr.printStackTrace();
		}
		if ((image == null) || (image.getWidth() == 0) || (image.getHeight() == 0))
			return;

		int printwidth = 384;
		int dstw = printwidth;
		int dsth = (int) (dstw * ((double) image.getHeight() / image.getWidth()));

		AutoReplyPrint.INSTANCE.CP_Label_BackPaperToPrintPosition(h);
		AutoReplyPrint.CP_Pos_PrintRasterImageFromData_Helper.PrintRasterImageFromBufferedImage(h, dstw, dsth, image, AutoReplyPrint.CP_ImageBinarizationMethod_ErrorDiffusion, AutoReplyPrint.CP_ImageCompressionMethod_Level1);
		AutoReplyPrint.INSTANCE.CP_Label_FeedPaperToTearPosition(h);

		Test_Pos_QueryPrintResult(h);
	}

	void Test_Label_SampleTicket_HeadImageTail_CompressionLevel2(Pointer h) {
		String filePath = TestUtils.SelectImage();
		if (filePath == null)
			return;

		BufferedImage image = null;
		try {
			image = ImageIO.read(new FileInputStream(filePath));
		} catch (Throwable tr) {
			tr.printStackTrace();
		}
		if ((image == null) || (image.getWidth() == 0) || (image.getHeight() == 0))
			return;

		int printwidth = 384;
		int dstw = printwidth;
		int dsth = (int) (dstw * ((double) image.getHeight() / image.getWidth()));

		AutoReplyPrint.INSTANCE.CP_Label_BackPaperToPrintPosition(h);
		AutoReplyPrint.CP_Pos_PrintRasterImageFromData_Helper.PrintRasterImageFromBufferedImage(h, dstw, dsth, image, AutoReplyPrint.CP_ImageBinarizationMethod_ErrorDiffusion, AutoReplyPrint.CP_ImageCompressionMethod_Level2);
		AutoReplyPrint.INSTANCE.CP_Label_FeedPaperToTearPosition(h);

		Test_Pos_QueryPrintResult(h);
	}

	void Test_Page_SampleTicket_58MM_1(Pointer h) {
		int paperWidth = 384;
		int paperHeight = 800;

		AutoReplyPrint.INSTANCE.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, paperWidth, paperHeight);
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteMode(h);
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_UTF8);

		AutoReplyPrint.INSTANCE.CP_Pos_SetTextScale(h, 1, 1);
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, AutoReplyPrint.CP_Page_DrawAlignment_HCenter, 10, new WString("中国福利彩票"));
		AutoReplyPrint.INSTANCE.CP_Pos_SetTextScale(h, 0, 0);
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 0, 60, new WString("销售期2020033"));
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, AutoReplyPrint.CP_Page_DrawAlignment_Right, 60, new WString("兑奖期2020033"));
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 0, 90, new WString("站号230902001"));
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, AutoReplyPrint.CP_Page_DrawAlignment_Right, 90, new WString("7639-A"));
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 0, 120, new WString("注数5"));
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, AutoReplyPrint.CP_Page_DrawAlignment_Right, 120, new WString("金额10.00"));

		AutoReplyPrint.INSTANCE.CP_Pos_SetTextLineHeight(h, 60);
		AutoReplyPrint.INSTANCE.CP_Pos_SetTextScale(h, 0, 1);
		AutoReplyPrint.INSTANCE.CP_Pos_SetTextUnderline(h, 2);
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 0, 160, new WString(" A: 02  07  10  17  20  21  25\r\n A: 02  07  10  17  20  21  25\r\n A: 02  07  10  17  20  21  25\r\n A: 02  07  10  17  20  21  25\r\n A: 02  07  10  17  20  21  25\r\n"));
		AutoReplyPrint.INSTANCE.CP_Pos_SetTextScale(h, 0, 0);
		AutoReplyPrint.INSTANCE.CP_Pos_SetTextUnderline(h, 0);
		AutoReplyPrint.INSTANCE.CP_Pos_SetTextLineHeight(h, 30);

		AutoReplyPrint.INSTANCE.CP_Pos_SetBarcodeHeight(h, 60);
		AutoReplyPrint.INSTANCE.CP_Pos_SetBarcodeUnitWidth(h, 3);
		AutoReplyPrint.INSTANCE.CP_Pos_SetBarcodeReadableTextPosition(h, AutoReplyPrint.CP_Pos_BarcodeTextPrintPosition_BelowBarcode);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBarcode(h, 0, 460, AutoReplyPrint.CP_Pos_BarcodeType_CODE128, "1234567890");
		AutoReplyPrint.INSTANCE.CP_Page_DrawQRCode(h, 284, 460, 0, AutoReplyPrint.CP_QRCodeECC_L, "1234567890");

		AutoReplyPrint.INSTANCE.CP_Page_PrintPage(h);
		AutoReplyPrint.INSTANCE.CP_Page_ExitPageMode(h);

		AutoReplyPrint.INSTANCE.CP_Pos_FeedAndHalfCutPaper(h);
		AutoReplyPrint.INSTANCE.CP_Pos_KickOutDrawer(h, 0, 100, 100);
		AutoReplyPrint.INSTANCE.CP_Pos_KickOutDrawer(h, 1, 100, 100);
		AutoReplyPrint.INSTANCE.CP_Pos_Beep(h, 1, 500);

		{
			Test_Pos_QueryPrintResult(h);
		}
	}

	void Test_Page_SampleTicket_80MM_1(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 576, 200);
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteMode(h);
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_UTF8);

		AutoReplyPrint.INSTANCE.CP_Pos_SetTextScale(h, 1, 1);
		AutoReplyPrint.INSTANCE.CP_Page_DrawText(h, AutoReplyPrint.CP_Page_DrawAlignment_HCenter, 0, "Print Store");
		AutoReplyPrint.INSTANCE.CP_Pos_SetTextScale(h, 7, 1);
		AutoReplyPrint.INSTANCE.CP_Page_DrawText(h, AutoReplyPrint.CP_Page_DrawAlignment_HCenter, 48, "______");
		AutoReplyPrint.INSTANCE.CP_Page_DrawBarcode(h, AutoReplyPrint.CP_Page_DrawAlignment_HCenter, 100, AutoReplyPrint.CP_Pos_BarcodeType_CODE128, "No.201804190001");

		AutoReplyPrint.INSTANCE.CP_Page_SetPageArea(h, 0, 200, 576, 1400);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBox(h, 0, 0, 576, 1400, 1, 1);
		AutoReplyPrint.INSTANCE.CP_Page_SetPageDrawDirection(h, AutoReplyPrint.CP_Page_DrawDirection_TopToBottom);

		int y = 0;
		AutoReplyPrint.INSTANCE.CP_Pos_SetTextScale(h, 1, 1);
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, AutoReplyPrint.CP_Page_DrawAlignment_HCenter, y, new WString("Print物流（测试）托运单"));

		y += 64;
		AutoReplyPrint.INSTANCE.CP_Pos_SetTextScale(h, 0, 0);
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 0, y, new WString("发站：厦门总部"));
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 300, y, new WString("到站：广州 0539-7825336"));
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 600, y, new WString("托运日期：2020-05-24"));
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 900, y, new WString("运单号：601052400032"));

		y += 32;
		AutoReplyPrint.INSTANCE.CP_Page_DrawRect(h, 0, y - 5, 1400, 2, 1);
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 0, y, new WString("收货人"));
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 300, y, new WString("电话：15000353189"));
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 600, y, new WString("运费：提付10"));

		y += 32;
		AutoReplyPrint.INSTANCE.CP_Page_DrawRect(h, 0, y - 5, 1400, 2, 1);
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 0, y, new WString("发货人"));
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 300, y, new WString("电话：15000353189"));
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 600, y, new WString("会员号"));
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 900, y, new WString("代收款：1000"));

		y += 32;
		AutoReplyPrint.INSTANCE.CP_Page_DrawRect(h, 0, y - 5, 1400, 2, 1);
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 0, y, new WString("货物名称"));
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 150, y, new WString("件数"));
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 300, y, new WString("重量"));
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 450, y, new WString("体积"));
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 600, y, new WString("保价额"));
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 750, y, new WString("保价费"));
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 900, y, new WString("交货方式"));
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 1050, y, new WString("自提"));

		y += 32;
		AutoReplyPrint.INSTANCE.CP_Page_DrawRect(h, 0, y - 5, 1400, 2, 1);
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 0, y, new WString("配件"));
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 900, y, new WString("送货费"));

		y += 32;
		AutoReplyPrint.INSTANCE.CP_Page_DrawRect(h, 0, y - 5, 1400, 2, 1);
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 0, y, new WString("托运地址"));
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 150, y, new WString("运河路高架桥南张营中心街东首"));
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 900, y, new WString("预付运费"));

		y += 32;
		AutoReplyPrint.INSTANCE.CP_Page_DrawRect(h, 0, y - 5, 1400, 2, 1);
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 0, y, new WString("到站地址"));
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 150, y, new WString("金兰物流E7区11号"));
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 900, y, new WString("提付合计"));

		y += 32;
		AutoReplyPrint.INSTANCE.CP_Page_DrawRect(h, 0, y - 5, 1400, 2, 1);
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 0, y, new WString("备注"));
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 900, y, new WString("返款"));

		y += 32;
		AutoReplyPrint.INSTANCE.CP_Page_DrawRect(h, 0, y - 5, 1400, 2, 1);
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 0, y, new WString("声明：1、不得虚假报货名 2、不得虚假报货名 3、不得虚假报货名 4、不得虚假报货名 5、不得虚假报货名 6、不得虚假报货名 7、不得虚假报货名 8、不得虚假报货名 1、不得虚假报货名 2、不得虚假报货名 3、不得虚假报货名 4、不得虚假报货名 5、不得虚假报货名 6、不得虚假报货名 7、不得虚假报货名 8、不得虚假报货名 1、不得虚假报货名 2、不得虚假报货名 3、不得虚假报货名 4、不得虚假报货名 5、不得虚假报货名 6、不得虚假报货名 7、不得虚假报货名 8、不得虚假报货名 1、不得虚假报货名 2、不得虚假报货名 3、不得虚假报货名 4、不得虚假报货名 5、不得虚假报货名 6、不得虚假报货名 7、不得虚假报货名 8、不得虚假报货名"));

		y = 530;
		AutoReplyPrint.INSTANCE.CP_Page_DrawRect(h, 0, y - 5, 1400, 2, 1);
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 0, y, new WString("服务查询：2379911"));
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 300, y, new WString("发货人签名"));
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 600, y, new WString("第一联"));
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 900, y, new WString("制单"));

		AutoReplyPrint.INSTANCE.CP_Page_PrintPage(h);
		AutoReplyPrint.INSTANCE.CP_Page_ExitPageMode(h);

		AutoReplyPrint.INSTANCE.CP_Pos_KickOutDrawer(h, 0, 100, 100);
		AutoReplyPrint.INSTANCE.CP_Pos_KickOutDrawer(h, 1, 100, 100);
		AutoReplyPrint.INSTANCE.CP_Pos_Beep(h, 1, 500);
		AutoReplyPrint.INSTANCE.CP_Pos_FeedAndHalfCutPaper(h);

		{
			Test_Pos_QueryPrintResult(h);
		}
	}

	void Test_Port_Write(Pointer h) {
		byte cmd[] = { 0x12, 0x54 };
		if (AutoReplyPrint.INSTANCE.CP_Port_Write(h, cmd, cmd.length, 1000) != cmd.length)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Port_Read(Pointer h) {
		// send this cmd to query printer status
		byte cmd[] = { 0x10, 0x04, 0x01 };
		AutoReplyPrint.INSTANCE.CP_Port_SkipAvailable(h);
		if (AutoReplyPrint.INSTANCE.CP_Port_Write(h, cmd, cmd.length, 1000) == cmd.length) {
			byte status[] = new byte[1];
			if (AutoReplyPrint.INSTANCE.CP_Port_Read(h, status, 1, 2000) == 1) {
				TestUtils.showMessageOnUiThread(String.format("Status 0x%02X", status[0] & 0xff));
			} else {
				TestUtils.showMessageOnUiThread("Read failed");
			}
		} else {
			TestUtils.showMessageOnUiThread("Write failed");
		}
	}

	void Test_Port_ReadUntilByte(Pointer h) {
		// send this cmd to query printer status
		byte cmd[] = { 0x1F, 0x28, 0x4C, 0x02, 0x00, 0x72, 0x41 };
		AutoReplyPrint.INSTANCE.CP_Port_SkipAvailable(h);
		if (AutoReplyPrint.INSTANCE.CP_Port_Write(h, cmd, cmd.length, 1000) == cmd.length) {
			byte buffer[] = new byte[0x100];
			int nBytesReaded = AutoReplyPrint.INSTANCE.CP_Port_ReadUntilByte(h, buffer, buffer.length, 2000, (byte) 0x00);
			if (nBytesReaded > 0) {
				TestUtils.showMessageOnUiThread(new String(buffer));
			} else {
				TestUtils.showMessageOnUiThread("Read failed");
			}
		} else {
			TestUtils.showMessageOnUiThread("Write failed");
		}
	}

	void Test_Port_Available(Pointer h) {
		int available = AutoReplyPrint.INSTANCE.CP_Port_Available(h);
		TestUtils.showMessageOnUiThread("available " + available);
	}

	void Test_Port_SkipAvailable(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Port_SkipAvailable(h);
	}

	void Test_Port_IsConnectionValid(Pointer h) {
		boolean valid = AutoReplyPrint.INSTANCE.CP_Port_IsConnectionValid(h);
		TestUtils.showMessageOnUiThread("valid " + valid);
	}

	void Test_Printer_GetPrinterInfo(Pointer h) {
		String firmware_version = AutoReplyPrint.CP_Printer_GetPrinterFirmwareVersion_Helper.GetPrinterFirmwareVersion(h) + "\r\n";
		IntByReference width_mm = new IntByReference();
		IntByReference height_mm = new IntByReference();
		IntByReference dots_per_mm = new IntByReference();
		LongByReference printer_error_status = new LongByReference();
		LongByReference printer_info_status = new LongByReference();
		IntByReference printer_received_byte_count = new IntByReference();
		IntByReference printer_printed_page_id = new IntByReference();
		LongByReference timestamp_ms_printer_status = new LongByReference();
		LongByReference timestamp_ms_printer_received = new LongByReference();
		LongByReference timestamp_ms_printer_printed = new LongByReference();
		if (AutoReplyPrint.INSTANCE.CP_Printer_GetPrinterResolutionInfo(h, width_mm, height_mm, dots_per_mm) && AutoReplyPrint.INSTANCE.CP_Printer_GetPrinterStatusInfo(h, printer_error_status, printer_info_status, timestamp_ms_printer_status) && AutoReplyPrint.INSTANCE.CP_Printer_GetPrinterReceivedInfo(h, printer_received_byte_count, timestamp_ms_printer_received) && AutoReplyPrint.INSTANCE.CP_Printer_GetPrinterPrintedInfo(h, printer_printed_page_id, timestamp_ms_printer_printed)) {
			Date dt_printer_status = new Date(timestamp_ms_printer_status.getValue());
			Date dt_printer_received = new Date(timestamp_ms_printer_received.getValue());
			Date dt_printer_printed = new Date(timestamp_ms_printer_printed.getValue());
			SimpleDateFormat simpleDateFormat = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
			String str_printer_resolution = "Width: " + width_mm.getValue() + " Height: " + height_mm.getValue() + " DotsPerMM: " + dots_per_mm.getValue() + "\r\n";
			String str_printer_error_status = simpleDateFormat.format(dt_printer_status) + String.format(" Printer Error Status: 0x%04X\r\n", printer_error_status.getValue() & 0xffff);
			String str_printer_info_status = simpleDateFormat.format(dt_printer_status) + String.format(" Printer Info Status: 0x%04X\r\n", printer_info_status.getValue() & 0xffff);
			String str_printer_received = simpleDateFormat.format(dt_printer_received) + String.format(" Printer Received Byte Count: %d\r\n", printer_received_byte_count.getValue());
			String str_printer_printed = simpleDateFormat.format(dt_printer_printed) + String.format(" Printer Printed Page ID: %d\r\n", printer_printed_page_id.getValue());
			TestUtils.showMessageOnUiThread(firmware_version + str_printer_resolution + str_printer_error_status + str_printer_info_status + str_printer_received + str_printer_printed);
		}
	}

	void Test_Printer_ClearPrinterBuffer(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Printer_ClearPrinterBuffer(h);
	}

	void Test_Printer_ClearPrinterError(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Printer_ClearPrinterError(h);
	}

	void Test_Pos_QueryRTStatus(Pointer h) {
		int status = AutoReplyPrint.INSTANCE.CP_Pos_QueryRTStatus(h, 3000);
		if (status != 0) {
			String s = "";
			s += String.format("RTStatus: %02x %02x %02x %02x\r\n", status & 0xff, (status >> 8) & 0xff, (status >> 16) & 0xff, (status >> 24) & 0xff);
			if (AutoReplyPrint.CP_RTSTATUS_Helper.CP_RTSTATUS_COVERUP(status))
				s += "[Cover Up]";
			if (AutoReplyPrint.CP_RTSTATUS_Helper.CP_RTSTATUS_NOPAPER(status))
				s += "[No Paper]";
			if (AutoReplyPrint.CP_RTSTATUS_Helper.CP_RTSTATUS_PAPER_NEAREND(status))
				s += "[Paper Near End]";
			TestUtils.showMessageOnUiThread(s);
		} else {
			TestUtils.showMessageOnUiThread("Query failed");
		}
	}

	void Test_Pos_QueryPrintResult(Pointer h) {
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_QueryPrintResult(h, 30000);
		if (!result)
			TestUtils.showMessageOnUiThread("Print failed");
		else
			TestUtils.showMessageOnUiThread("Print Success");
	}

	void Test_Pos_KickOutDrawer(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Pos_KickOutDrawer(h, 0, 100, 100);
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_KickOutDrawer(h, 1, 100, 100);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_Beep(Pointer h) {
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_Beep(h, 3, 300);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_FeedAndHalfCutPaper(Pointer h) {
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_FeedAndHalfCutPaper(h);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_FullCutPaper(Pointer h) {
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_FullCutPaper(h);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_HalfCutPaper(Pointer h) {
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_HalfCutPaper(h);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_Feed(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "12345678901234567890");
		AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 4);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "12345678901234567890");
		AutoReplyPrint.INSTANCE.CP_Pos_FeedDot(h, 100);
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 3);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_PrintSelfTestPage(Pointer h) {
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_PrintSelfTestPage(h);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_PrintText(Pointer h) {
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "12345678901234567890\r\n");
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_PrintTextInUTF8(Pointer h) {
		WString str = new WString("1234567890\r\n" + "abcdefghijklmnopqrstuvwxyz\r\n" + "ΑΒΓΔΕΖΗΘΙΚ∧ΜΝΞΟ∏Ρ∑ΤΥΦΧΨΩ\r\n" + "αβγδεζηθικλμνξοπρστυφχψω\r\n" + "你好，欢迎使用！\r\n" + "你號，歡迎使用！\r\n" + "梦を见る事が出来なければ\r\n未来を変える事は出来ません\r\n" + "왕관을 쓰려는자\r\n그 무게를 견뎌라\r\n");
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteMode(h);
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_UTF8);
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, str);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_PrintTextInGBK(Pointer h) {
		WString str = new WString("1234567890\r\nabcdefghijklmnopqrstuvwxyz\r\n你好，欢迎使用！\r\n你號，歡迎使用！\r\n");
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteMode(h);
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_GBK);
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInGBK(h, str);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_PrintTextInBIG5(Pointer h) {
		WString str = new WString("1234567890\r\nabcdefghijklmnopqrstuvwxyz\r\n你號，歡迎使用！\r\n");
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteMode(h);
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_BIG5);
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInBIG5(h, str);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_PrintTextInShiftJIS(Pointer h) {
		WString str = new WString("1234567890\r\n" + "abcdefghijklmnopqrstuvwxyz\r\n" + "こんにちは\r\n");
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteMode(h);
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_ShiftJIS);
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInShiftJIS(h, str);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_PrintTextInEUCKR(Pointer h) {
		WString str = new WString("1234567890\r\n" + "abcdefghijklmnopqrstuvwxyz\r\n" + "왕관을 쓰려는자\r\n" + "그 무게를 견뎌라\r\n");
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteMode(h);
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_EUCKR);
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInEUCKR(h, str);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_PrintBarcode(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Pos_SetBarcodeUnitWidth(h, 2);
		AutoReplyPrint.INSTANCE.CP_Pos_SetBarcodeHeight(h, 60);
		AutoReplyPrint.INSTANCE.CP_Pos_SetBarcodeReadableTextFontType(h, 0);
		AutoReplyPrint.INSTANCE.CP_Pos_SetBarcodeReadableTextPosition(h, AutoReplyPrint.CP_Pos_BarcodeTextPrintPosition_BelowBarcode);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintBarcode(h, AutoReplyPrint.CP_Pos_BarcodeType_UPCA, "01234567890");
		AutoReplyPrint.INSTANCE.CP_Pos_PrintBarcode(h, AutoReplyPrint.CP_Pos_BarcodeType_UPCE, "123456");
		AutoReplyPrint.INSTANCE.CP_Pos_PrintBarcode(h, AutoReplyPrint.CP_Pos_BarcodeType_EAN13, "123456789012");
		AutoReplyPrint.INSTANCE.CP_Pos_PrintBarcode(h, AutoReplyPrint.CP_Pos_BarcodeType_EAN8, "1234567");
		AutoReplyPrint.INSTANCE.CP_Pos_PrintBarcode(h, AutoReplyPrint.CP_Pos_BarcodeType_CODE39, "123456");
		AutoReplyPrint.INSTANCE.CP_Pos_PrintBarcode(h, AutoReplyPrint.CP_Pos_BarcodeType_ITF, "123456");
		AutoReplyPrint.INSTANCE.CP_Pos_PrintBarcode(h, AutoReplyPrint.CP_Pos_BarcodeType_CODEBAR, "A123456A");
		AutoReplyPrint.INSTANCE.CP_Pos_PrintBarcode(h, AutoReplyPrint.CP_Pos_BarcodeType_CODE93, "123456");
		AutoReplyPrint.INSTANCE.CP_Pos_PrintBarcode(h, AutoReplyPrint.CP_Pos_BarcodeType_CODE128, "No.123456");

		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 3);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_PrintQRCode(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Pos_SetBarcodeUnitWidth(h, 8);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintQRCode(h, 0, AutoReplyPrint.CP_QRCodeECC_L, "Hello 欢迎使用");

		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 3);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");

	}

	void Test_Pos_PrintQRCodeUseEpsonCmd(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Pos_PrintQRCodeUseEpsonCmd(h, 8, AutoReplyPrint.CP_QRCodeECC_L, "Hello 欢迎使用");

		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 3);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");

	}

	void Test_Pos_PrintDoubleQRCode(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Pos_PrintDoubleQRCode(h, 4, 0, 4, AutoReplyPrint.CP_QRCodeECC_L, "hello", 200, 3, AutoReplyPrint.CP_QRCodeECC_L, "test");

		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 3);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");

	}

	void Test_Pos_PrintPDF417BarcodeUseEpsonCmd(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Pos_PrintPDF417BarcodeUseEpsonCmd(h, 0, 0, 3, 3, 0, 0, "test 测试");

		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 3);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");

	}

	void Test_Pos_PrintRasterImageFromBufferedImage(Pointer h) {
		String filePath = TestUtils.SelectImage();
		if (filePath == null)
			return;

		BufferedImage image = null;
		try {
			image = ImageIO.read(new FileInputStream(filePath));
		} catch (Throwable tr) {
			tr.printStackTrace();
		}
		if ((image == null) || (image.getWidth() == 0) || (image.getHeight() == 0))
			return;

		int printwidth = 384;
		int dstw = printwidth;
		int dsth = (int) (dstw * ((double) image.getHeight() / image.getWidth()));

		boolean result = AutoReplyPrint.CP_Pos_PrintRasterImageFromData_Helper.PrintRasterImageFromBufferedImage(h, dstw, dsth, image, AutoReplyPrint.CP_ImageBinarizationMethod_ErrorDiffusion, AutoReplyPrint.CP_ImageCompressionMethod_None);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_PrintHorizontalLine(Pointer h) {
		for (int i = 0; i < 50; i += 1)
			AutoReplyPrint.INSTANCE.CP_Pos_PrintHorizontalLine(h, i, i + 100);
		for (int i = 50; i > 0; i -= 1)
			AutoReplyPrint.INSTANCE.CP_Pos_PrintHorizontalLine(h, i, i + 100);

		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 3);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_PrintHorizontalLineSpecifyThickness(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Pos_PrintHorizontalLineSpecifyThickness(h, 0, 200, 10);

		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 3);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_PrintMultipleHorizontalLinesAtOneRow(Pointer h) {
		int r = 150;
		for (int y = -r; y <= r; ++y) {
			int x = (int) Math.sqrt(r * r - y * y);
			int x1 = -x + r;
			int x2 = x + r;
			int[] pLineStartPosition = new int[] { x1, x2 };
			int[] pLineEndPosition = new int[] { x1, x2 };
			if (AutoReplyPrint.INSTANCE.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, 2, pLineStartPosition, pLineEndPosition))
				continue;
			else
				break;
		}

		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 3);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_SetMovementUnit(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Pos_SetMovementUnit(h, 100, 100);
		AutoReplyPrint.INSTANCE.CP_Pos_SetAsciiTextCharRightSpacing(h, 10);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "1234567890\r\n");
		AutoReplyPrint.INSTANCE.CP_Pos_SetMovementUnit(h, 200, 200);
		AutoReplyPrint.INSTANCE.CP_Pos_SetAsciiTextCharRightSpacing(h, 10);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "1234567890\r\n");
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_SetAsciiTextCharRightSpacing(h, 0);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_SetPrintAreaLeftMargin(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Pos_SetPrintAreaLeftMargin(h, 96);
		AutoReplyPrint.INSTANCE.CP_Pos_SetPrintAreaWidth(h, 384);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "1234567890123456789012345678901234567890\r\n");
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_ResetPrinter(h);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_SetPrintAreaWidth(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Pos_SetPrintAreaWidth(h, 384);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "1234567890123456789012345678901234567890\r\n");
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_ResetPrinter(h);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_SetPrintPosition(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 0);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "12345678901234567890\r\n");
		AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 24);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "1234567890");
		AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalRelativePrintPosition(h, 24);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "1234567890\r\n");
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 3);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_SetAlignment(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Pos_SetAlignment(h, AutoReplyPrint.CP_Pos_Alignment_Right);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "12345678901234567890\r\n");
		AutoReplyPrint.INSTANCE.CP_Pos_SetAlignment(h, AutoReplyPrint.CP_Pos_Alignment_HCenter);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "12345678901234567890\r\n");
		AutoReplyPrint.INSTANCE.CP_Pos_SetAlignment(h, AutoReplyPrint.CP_Pos_Alignment_Left);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "12345678901234567890\r\n");
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 3);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_SetTextScale(Pointer h) {
		int nPosition = 0;
		AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, nPosition);
		AutoReplyPrint.INSTANCE.CP_Pos_SetTextScale(h, 0, 0);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "a");
		nPosition += 12;
		AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, nPosition);
		AutoReplyPrint.INSTANCE.CP_Pos_SetTextScale(h, 1, 1);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "a");
		nPosition += 12 * 2;
		AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, nPosition);
		AutoReplyPrint.INSTANCE.CP_Pos_SetTextScale(h, 2, 2);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "a");
		nPosition += 12 * 3;
		AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, nPosition);
		AutoReplyPrint.INSTANCE.CP_Pos_SetTextScale(h, 3, 3);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "a");
		nPosition += 12 * 4;
		AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, nPosition);
		AutoReplyPrint.INSTANCE.CP_Pos_SetTextScale(h, 4, 4);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "a");
		nPosition += 12 * 5;
		AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, nPosition);
		AutoReplyPrint.INSTANCE.CP_Pos_SetTextScale(h, 5, 5);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "a");
		nPosition += 12 * 6;
		AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, nPosition);
		AutoReplyPrint.INSTANCE.CP_Pos_SetTextScale(h, 6, 6);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "a");
		nPosition += 12 * 7;
		AutoReplyPrint.INSTANCE.CP_Pos_SetHorizontalAbsolutePrintPosition(h, nPosition);
		AutoReplyPrint.INSTANCE.CP_Pos_SetTextScale(h, 7, 7);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "a");
		AutoReplyPrint.INSTANCE.CP_Pos_SetTextScale(h, 0, 0);
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 3);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_SetAsciiTextFontType(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Pos_SetAsciiTextFontType(h, 0);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "FontA\r\n");
		AutoReplyPrint.INSTANCE.CP_Pos_SetAsciiTextFontType(h, 1);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "FontB\r\n");
		AutoReplyPrint.INSTANCE.CP_Pos_SetAsciiTextFontType(h, 2);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "FontC\r\n");
		AutoReplyPrint.INSTANCE.CP_Pos_SetAsciiTextFontType(h, 3);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "FontD\r\n");
		AutoReplyPrint.INSTANCE.CP_Pos_SetAsciiTextFontType(h, 4);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "FontE\r\n");
		AutoReplyPrint.INSTANCE.CP_Pos_SetAsciiTextFontType(h, 0);
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 3);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_SetTextBold(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Pos_SetTextBold(h, 1);
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteMode(h);
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_UTF8);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("粗体 Bold\r\n"));
		AutoReplyPrint.INSTANCE.CP_Pos_SetTextBold(h, 0);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "Normal\r\n");
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 3);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_SetTextUnderline(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteMode(h);
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_UTF8);
		AutoReplyPrint.INSTANCE.CP_Pos_SetTextUnderline(h, 2);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("下划线2点 Underline2\r\n"));
		AutoReplyPrint.INSTANCE.CP_Pos_SetTextUnderline(h, 1);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("下划线1点 Underline2\r\n"));
		AutoReplyPrint.INSTANCE.CP_Pos_SetTextUnderline(h, 0);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("无下划线 No Underline\r\n"));
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 3);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_SetTextUpsideDown(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteMode(h);
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_UTF8);
		AutoReplyPrint.INSTANCE.CP_Pos_SetTextUpsideDown(h, 1);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("上下倒置 UpsideDown\r\n"));
		AutoReplyPrint.INSTANCE.CP_Pos_SetTextUpsideDown(h, 0);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "Normal\r\n");
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 3);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_SetTextWhiteOnBlack(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteMode(h);
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_UTF8);
		AutoReplyPrint.INSTANCE.CP_Pos_SetTextWhiteOnBlack(h, 1);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("黑白反显 WhiteOnBlack\r\n"));
		AutoReplyPrint.INSTANCE.CP_Pos_SetTextWhiteOnBlack(h, 0);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "Normal\r\n");
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 3);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_SetTextRotate(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteMode(h);
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_UTF8);
		AutoReplyPrint.INSTANCE.CP_Pos_SetTextRotate(h, 1);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, new WString("文字旋转打印 TextRotate\r\n"));
		AutoReplyPrint.INSTANCE.CP_Pos_SetTextRotate(h, 0);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "Normal\r\n");
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 3);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_SetTextLineHeight(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Pos_SetTextLineHeight(h, 100);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "LineHeight 100\r\nLineHeight 100\r\nLineHeight 100\r\n");
		AutoReplyPrint.INSTANCE.CP_Pos_SetTextLineHeight(h, 32);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "LineHeight 32\r\nLineHeight 32\r\nLineHeight 32\r\n");
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 3);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_SetAsciiTextCharRightSpacing(Pointer h) {
		WString str = new WString("Hello你好\r\n");
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteMode(h);
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_UTF8);
		AutoReplyPrint.INSTANCE.CP_Pos_SetAsciiTextCharRightSpacing(h, 2);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, str);
		AutoReplyPrint.INSTANCE.CP_Pos_SetAsciiTextCharRightSpacing(h, 0);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, str);
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 3);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_SetKanjiTextCharSpacing(Pointer h) {
		WString str = new WString("Hello你好\r\n");
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteMode(h);
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_UTF8);
		AutoReplyPrint.INSTANCE.CP_Pos_SetKanjiTextCharSpacing(h, 2, 2);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, str);
		AutoReplyPrint.INSTANCE.CP_Pos_SetKanjiTextCharSpacing(h, 0, 0);
		AutoReplyPrint.INSTANCE.CP_Pos_PrintTextInUTF8(h, str);
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_FeedLine(h, 3);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_ResetPrinter(Pointer h) {
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_ResetPrinter(h);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_SetPrintSpeed_20(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Pos_SetPrintSpeed(h, 20);
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_PrintSelfTestPage(h);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_SetPrintSpeed_50(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Pos_SetPrintSpeed(h, 50);
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_PrintSelfTestPage(h);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_SetPrintSpeed_100(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Pos_SetPrintSpeed(h, 100);
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_PrintSelfTestPage(h);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_SetPrintDensity_0(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Pos_SetPrintDensity(h, 0);
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_PrintSelfTestPage(h);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_SetPrintDensity_7(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Pos_SetPrintDensity(h, 7);
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_PrintSelfTestPage(h);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_SetPrintDensity_15(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Pos_SetPrintDensity(h, 15);
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_PrintSelfTestPage(h);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_SetSingleByteMode(Pointer h) {
		String str = "Welcome 你好\r\n";

		AutoReplyPrint.INSTANCE.CP_Pos_SetSingleByteMode(h);
		AutoReplyPrint.INSTANCE.CP_Pos_SetCharacterSet(h, AutoReplyPrint.CP_CharacterSet_CHINA);
		AutoReplyPrint.INSTANCE.CP_Pos_SetCharacterCodepage(h, AutoReplyPrint.CP_CharacterCodepage_CP437);
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, str);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Pos_SetMultiByteMode(Pointer h) {
		String str = "Welcome 你好\r\n";

		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteMode(h);
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_UTF8);
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, str);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Page_SetPageDrawDirection(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
		AutoReplyPrint.INSTANCE.CP_Page_SetPageDrawDirection(h, AutoReplyPrint.CP_Page_DrawDirection_LeftToRight);
		AutoReplyPrint.INSTANCE.CP_Page_DrawText(h, 0, 0, "LeftToRight");
		AutoReplyPrint.INSTANCE.CP_Page_SetPageDrawDirection(h, AutoReplyPrint.CP_Page_DrawDirection_RightToLeft);
		AutoReplyPrint.INSTANCE.CP_Page_DrawText(h, 0, 0, "RightToLeft");
		AutoReplyPrint.INSTANCE.CP_Page_SetPageDrawDirection(h, AutoReplyPrint.CP_Page_DrawDirection_TopToBottom);
		AutoReplyPrint.INSTANCE.CP_Page_DrawText(h, 0, 0, "TopToBottom");
		AutoReplyPrint.INSTANCE.CP_Page_SetPageDrawDirection(h, AutoReplyPrint.CP_Page_DrawDirection_BottomToTop);
		AutoReplyPrint.INSTANCE.CP_Page_DrawText(h, 0, 0, "BottomToTop");
		AutoReplyPrint.INSTANCE.CP_Page_PrintPage(h);
		boolean result = AutoReplyPrint.INSTANCE.CP_Page_ExitPageMode(h);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Page_DrawRect(Pointer h) {
		// 10,10
		AutoReplyPrint.INSTANCE.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
		AutoReplyPrint.INSTANCE.CP_Page_DrawRect(h, 10, 10, 100, 100, 1);
		AutoReplyPrint.INSTANCE.CP_Page_DrawRect(h, 20, 20, 80, 80, 0);
		AutoReplyPrint.INSTANCE.CP_Page_PrintPage(h);
		AutoReplyPrint.INSTANCE.CP_Page_ExitPageMode(h);

		// left,top
		AutoReplyPrint.INSTANCE.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
		AutoReplyPrint.INSTANCE.CP_Page_DrawRect(h, -1, -1, 100, 20, 1);
		AutoReplyPrint.INSTANCE.CP_Page_PrintPage(h);
		AutoReplyPrint.INSTANCE.CP_Page_ExitPageMode(h);

		// left,vcenter
		AutoReplyPrint.INSTANCE.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
		AutoReplyPrint.INSTANCE.CP_Page_DrawRect(h, -1, -2, 100, 20, 1);
		AutoReplyPrint.INSTANCE.CP_Page_PrintPage(h);
		AutoReplyPrint.INSTANCE.CP_Page_ExitPageMode(h);

		// left,bottom
		AutoReplyPrint.INSTANCE.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
		AutoReplyPrint.INSTANCE.CP_Page_DrawRect(h, -1, -3, 100, 20, 1);
		AutoReplyPrint.INSTANCE.CP_Page_PrintPage(h);
		AutoReplyPrint.INSTANCE.CP_Page_ExitPageMode(h);

		// hcenter,top
		AutoReplyPrint.INSTANCE.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
		AutoReplyPrint.INSTANCE.CP_Page_DrawRect(h, -2, -1, 100, 20, 1);
		AutoReplyPrint.INSTANCE.CP_Page_PrintPage(h);
		AutoReplyPrint.INSTANCE.CP_Page_ExitPageMode(h);

		// hcenter,vcenter
		AutoReplyPrint.INSTANCE.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
		AutoReplyPrint.INSTANCE.CP_Page_DrawRect(h, -2, -2, 100, 20, 1);
		AutoReplyPrint.INSTANCE.CP_Page_PrintPage(h);
		AutoReplyPrint.INSTANCE.CP_Page_ExitPageMode(h);

		// hcenter,bottom
		AutoReplyPrint.INSTANCE.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
		AutoReplyPrint.INSTANCE.CP_Page_DrawRect(h, -2, -3, 100, 20, 1);
		AutoReplyPrint.INSTANCE.CP_Page_PrintPage(h);
		AutoReplyPrint.INSTANCE.CP_Page_ExitPageMode(h);

		// right,top
		AutoReplyPrint.INSTANCE.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
		AutoReplyPrint.INSTANCE.CP_Page_DrawRect(h, -3, -1, 100, 20, 1);
		AutoReplyPrint.INSTANCE.CP_Page_PrintPage(h);
		AutoReplyPrint.INSTANCE.CP_Page_ExitPageMode(h);

		// right,vcenter
		AutoReplyPrint.INSTANCE.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
		AutoReplyPrint.INSTANCE.CP_Page_DrawRect(h, -3, -2, 100, 20, 1);
		AutoReplyPrint.INSTANCE.CP_Page_PrintPage(h);
		AutoReplyPrint.INSTANCE.CP_Page_ExitPageMode(h);

		// right,bottom
		AutoReplyPrint.INSTANCE.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
		AutoReplyPrint.INSTANCE.CP_Page_DrawRect(h, -3, -3, 100, 20, 1);
		AutoReplyPrint.INSTANCE.CP_Page_PrintPage(h);
		AutoReplyPrint.INSTANCE.CP_Page_ExitPageMode(h);
	}

	void Test_Page_DrawText(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
		AutoReplyPrint.INSTANCE.CP_Page_DrawText(h, 0, 0, "12345678901234567890");
		AutoReplyPrint.INSTANCE.CP_Page_PrintPage(h);
		boolean result = AutoReplyPrint.INSTANCE.CP_Page_ExitPageMode(h);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Page_DrawTextInUTF8(Pointer h) {
		WString str = new WString("1234567890\r\n" + "abcdefghijklmnopqrstuvwxyz\r\n" + "ΑΒΓΔΕΖΗΘΙΚ∧ΜΝΞΟ∏Ρ∑ΤΥΦΧΨΩ\r\n" + "αβγδεζηθικλμνξοπρστυφχψω\r\n" + "你好，欢迎使用！\r\n" + "你號，歡迎使用！\r\n" + "梦を见る事が出来なければ\r\n未来を変える事は出来ません\r\n" + "왕관을 쓰려는자\r\n그 무게를 견뎌라\r\n");

		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteMode(h);
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_UTF8);

		AutoReplyPrint.INSTANCE.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInUTF8(h, 0, 0, str);
		AutoReplyPrint.INSTANCE.CP_Page_PrintPage(h);
		boolean result = AutoReplyPrint.INSTANCE.CP_Page_ExitPageMode(h);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Page_DrawTextInGBK(Pointer h) {
		WString str = new WString("1234567890\r\nabcdefghijklmnopqrstuvwxyz\r\n你好，欢迎使用！\r\n你號，歡迎使用！\r\n");

		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteMode(h);
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_GBK);

		AutoReplyPrint.INSTANCE.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInGBK(h, 0, 0, str);
		AutoReplyPrint.INSTANCE.CP_Page_PrintPage(h);
		boolean result = AutoReplyPrint.INSTANCE.CP_Page_ExitPageMode(h);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Page_DrawTextInBIG5(Pointer h) {
		WString str = new WString("1234567890\r\nabcdefghijklmnopqrstuvwxyz\r\n你號，歡迎使用！\r\n");

		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteMode(h);
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_BIG5);

		AutoReplyPrint.INSTANCE.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInBIG5(h, 0, 0, str);
		AutoReplyPrint.INSTANCE.CP_Page_PrintPage(h);
		boolean result = AutoReplyPrint.INSTANCE.CP_Page_ExitPageMode(h);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Page_DrawTextInShiftJIS(Pointer h) {
		WString str = new WString("1234567890\r\n" + "abcdefghijklmnopqrstuvwxyz\r\n" + "こんにちは\r\n");

		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteMode(h);
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_ShiftJIS);

		AutoReplyPrint.INSTANCE.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInShiftJIS(h, 0, 0, str);
		AutoReplyPrint.INSTANCE.CP_Page_PrintPage(h);
		boolean result = AutoReplyPrint.INSTANCE.CP_Page_ExitPageMode(h);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Page_DrawTextInEUCKR(Pointer h) {
		WString str = new WString("1234567890\r\n" + "abcdefghijklmnopqrstuvwxyz\r\n" + "왕관을 쓰려는자\r\n" + "그 무게를 견뎌라\r\n");

		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteMode(h);
		AutoReplyPrint.INSTANCE.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_EUCKR);

		AutoReplyPrint.INSTANCE.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
		AutoReplyPrint.INSTANCE.CP_Page_DrawTextInEUCKR(h, 0, 0, str);
		AutoReplyPrint.INSTANCE.CP_Page_PrintPage(h);
		boolean result = AutoReplyPrint.INSTANCE.CP_Page_ExitPageMode(h);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Page_DrawBarcode(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 1000);
		AutoReplyPrint.INSTANCE.CP_Pos_SetBarcodeUnitWidth(h, 2);
		AutoReplyPrint.INSTANCE.CP_Pos_SetBarcodeHeight(h, 60);
		AutoReplyPrint.INSTANCE.CP_Pos_SetBarcodeReadableTextFontType(h, 0);
		AutoReplyPrint.INSTANCE.CP_Pos_SetBarcodeReadableTextPosition(h, AutoReplyPrint.CP_Pos_BarcodeTextPrintPosition_BelowBarcode);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBarcode(h, 0, 0, AutoReplyPrint.CP_Pos_BarcodeType_UPCA, "01234567890");
		AutoReplyPrint.INSTANCE.CP_Page_DrawBarcode(h, 0, 100, AutoReplyPrint.CP_Pos_BarcodeType_UPCE, "123456");
		AutoReplyPrint.INSTANCE.CP_Page_DrawBarcode(h, 0, 200, AutoReplyPrint.CP_Pos_BarcodeType_EAN13, "123456789012");
		AutoReplyPrint.INSTANCE.CP_Page_DrawBarcode(h, 0, 300, AutoReplyPrint.CP_Pos_BarcodeType_EAN8, "1234567");
		AutoReplyPrint.INSTANCE.CP_Page_DrawBarcode(h, 0, 400, AutoReplyPrint.CP_Pos_BarcodeType_CODE39, "123456");
		AutoReplyPrint.INSTANCE.CP_Page_DrawBarcode(h, 0, 500, AutoReplyPrint.CP_Pos_BarcodeType_ITF, "123456");
		AutoReplyPrint.INSTANCE.CP_Page_DrawBarcode(h, 0, 600, AutoReplyPrint.CP_Pos_BarcodeType_CODEBAR, "A123456A");
		AutoReplyPrint.INSTANCE.CP_Page_DrawBarcode(h, 0, 700, AutoReplyPrint.CP_Pos_BarcodeType_CODE93, "123456");
		AutoReplyPrint.INSTANCE.CP_Page_DrawBarcode(h, 0, 800, AutoReplyPrint.CP_Pos_BarcodeType_CODE128, "No.123456");
		AutoReplyPrint.INSTANCE.CP_Page_PrintPage(h);
		AutoReplyPrint.INSTANCE.CP_Page_ExitPageMode(h);
	}

	void Test_Page_DrawBarcode_CODE128(Pointer h) {
		String str = "No.123456";

		AutoReplyPrint.INSTANCE.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
		AutoReplyPrint.INSTANCE.CP_Pos_SetBarcodeUnitWidth(h, 2);
		AutoReplyPrint.INSTANCE.CP_Pos_SetBarcodeHeight(h, 60);
		AutoReplyPrint.INSTANCE.CP_Pos_SetBarcodeReadableTextFontType(h, 0);
		AutoReplyPrint.INSTANCE.CP_Pos_SetBarcodeReadableTextPosition(h, AutoReplyPrint.CP_Pos_BarcodeTextPrintPosition_BelowBarcode);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBarcode(h, 10, 100, AutoReplyPrint.CP_Pos_BarcodeType_CODE128, str);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBarcode(h, 10, 200, AutoReplyPrint.CP_Pos_BarcodeType_CODE128, str);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBarcode(h, 10, 300, AutoReplyPrint.CP_Pos_BarcodeType_CODE128, str);
		AutoReplyPrint.INSTANCE.CP_Page_PrintPage(h);
		AutoReplyPrint.INSTANCE.CP_Page_ExitPageMode(h);

		AutoReplyPrint.INSTANCE.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
		AutoReplyPrint.INSTANCE.CP_Pos_SetBarcodeUnitWidth(h, 2);
		AutoReplyPrint.INSTANCE.CP_Pos_SetBarcodeHeight(h, 60);
		AutoReplyPrint.INSTANCE.CP_Pos_SetBarcodeReadableTextFontType(h, 0);
		AutoReplyPrint.INSTANCE.CP_Pos_SetBarcodeReadableTextPosition(h, AutoReplyPrint.CP_Pos_BarcodeTextPrintPosition_None);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBarcode(h, -1, -1, AutoReplyPrint.CP_Pos_BarcodeType_CODE128, str);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBarcode(h, -2, -2, AutoReplyPrint.CP_Pos_BarcodeType_CODE128, str);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBarcode(h, -3, -3, AutoReplyPrint.CP_Pos_BarcodeType_CODE128, str);
		AutoReplyPrint.INSTANCE.CP_Page_PrintPage(h);
		AutoReplyPrint.INSTANCE.CP_Page_ExitPageMode(h);

		AutoReplyPrint.INSTANCE.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
		AutoReplyPrint.INSTANCE.CP_Pos_SetBarcodeUnitWidth(h, 2);
		AutoReplyPrint.INSTANCE.CP_Pos_SetBarcodeHeight(h, 60);
		AutoReplyPrint.INSTANCE.CP_Pos_SetBarcodeReadableTextFontType(h, 0);
		AutoReplyPrint.INSTANCE.CP_Pos_SetBarcodeReadableTextPosition(h, AutoReplyPrint.CP_Pos_BarcodeTextPrintPosition_AboveAndBelowBarcode);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBarcode(h, -1, -1, AutoReplyPrint.CP_Pos_BarcodeType_CODE128, str);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBarcode(h, -2, -2, AutoReplyPrint.CP_Pos_BarcodeType_CODE128, str);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBarcode(h, -3, -3, AutoReplyPrint.CP_Pos_BarcodeType_CODE128, str);
		AutoReplyPrint.INSTANCE.CP_Page_PrintPage(h);
		AutoReplyPrint.INSTANCE.CP_Page_ExitPageMode(h);

		AutoReplyPrint.INSTANCE.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
		AutoReplyPrint.INSTANCE.CP_Pos_SetBarcodeUnitWidth(h, 2);
		AutoReplyPrint.INSTANCE.CP_Pos_SetBarcodeHeight(h, 60);
		AutoReplyPrint.INSTANCE.CP_Pos_SetBarcodeReadableTextFontType(h, 0);
		AutoReplyPrint.INSTANCE.CP_Pos_SetBarcodeReadableTextPosition(h, AutoReplyPrint.CP_Pos_BarcodeTextPrintPosition_AboveBarcode);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBarcode(h, -1, -1, AutoReplyPrint.CP_Pos_BarcodeType_CODE128, str);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBarcode(h, -2, -2, AutoReplyPrint.CP_Pos_BarcodeType_CODE128, str);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBarcode(h, -3, -3, AutoReplyPrint.CP_Pos_BarcodeType_CODE128, str);
		AutoReplyPrint.INSTANCE.CP_Page_PrintPage(h);
		AutoReplyPrint.INSTANCE.CP_Page_ExitPageMode(h);

		AutoReplyPrint.INSTANCE.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
		AutoReplyPrint.INSTANCE.CP_Pos_SetBarcodeUnitWidth(h, 2);
		AutoReplyPrint.INSTANCE.CP_Pos_SetBarcodeHeight(h, 60);
		AutoReplyPrint.INSTANCE.CP_Pos_SetBarcodeReadableTextFontType(h, 0);
		AutoReplyPrint.INSTANCE.CP_Pos_SetBarcodeReadableTextPosition(h, AutoReplyPrint.CP_Pos_BarcodeTextPrintPosition_BelowBarcode);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBarcode(h, -1, -1, AutoReplyPrint.CP_Pos_BarcodeType_CODE128, str);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBarcode(h, -2, -2, AutoReplyPrint.CP_Pos_BarcodeType_CODE128, str);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBarcode(h, -3, -3, AutoReplyPrint.CP_Pos_BarcodeType_CODE128, str);
		AutoReplyPrint.INSTANCE.CP_Page_PrintPage(h);
		boolean result = AutoReplyPrint.INSTANCE.CP_Page_ExitPageMode(h);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Page_DrawQRCode(Pointer h) {
		String str = "Hello";

		AutoReplyPrint.INSTANCE.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
		AutoReplyPrint.INSTANCE.CP_Pos_SetBarcodeUnitWidth(h, 4);
		AutoReplyPrint.INSTANCE.CP_Page_DrawQRCode(h, -1, -1, 0, AutoReplyPrint.CP_QRCodeECC_L, str);
		AutoReplyPrint.INSTANCE.CP_Page_DrawQRCode(h, -2, -2, 0, AutoReplyPrint.CP_QRCodeECC_L, str);
		AutoReplyPrint.INSTANCE.CP_Page_DrawQRCode(h, -3, -3, 0, AutoReplyPrint.CP_QRCodeECC_L, str);
		AutoReplyPrint.INSTANCE.CP_Page_PrintPage(h);
		AutoReplyPrint.INSTANCE.CP_Page_ExitPageMode(h);

		AutoReplyPrint.INSTANCE.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 1000);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBox(h, 0, 0, 384, 1000, 2, 1);
		AutoReplyPrint.INSTANCE.CP_Pos_SetBarcodeUnitWidth(h, 4);
		AutoReplyPrint.INSTANCE.CP_Page_DrawQRCode(h, 10, 10, 10, AutoReplyPrint.CP_QRCodeECC_L, str);
		AutoReplyPrint.INSTANCE.CP_Page_DrawQRCode(h, 10, 300, 10, AutoReplyPrint.CP_QRCodeECC_L, str);
		AutoReplyPrint.INSTANCE.CP_Page_DrawQRCode(h, 10, 600, 10, AutoReplyPrint.CP_QRCodeECC_L, str);
		AutoReplyPrint.INSTANCE.CP_Page_PrintPage(h);
		AutoReplyPrint.INSTANCE.CP_Page_ExitPageMode(h);
	}

	void Test_Page_DrawRasterImageFromBufferedImage(Pointer h) {
		String filePath = TestUtils.SelectImage();
		if (filePath == null)
			return;

		BufferedImage image = null;
		try {
			image = ImageIO.read(new FileInputStream(filePath));
		} catch (Throwable tr) {
			tr.printStackTrace();
		}
		if ((image == null) || (image.getWidth() == 0) || (image.getHeight() == 0))
			return;

		int srcw = image.getWidth();
		int srch = image.getHeight();
		int maxw = 384;
		int maxh = 600;
		int dstw = srcw;
		int dsth = srch;
		if (dstw > maxw) {
			dstw = maxw;
			dsth = maxw * srch / srcw;
		}
		if (dsth > maxh) {
			dsth = maxh;
			dstw = maxh * srcw / srch;
		}

		AutoReplyPrint.INSTANCE.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
		AutoReplyPrint.INSTANCE.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
		AutoReplyPrint.CP_Page_DrawRasterImageFromData_Helper.DrawRasterImageFromBufferedImage(h, 0, 0, dstw, dsth, image, AutoReplyPrint.CP_ImageBinarizationMethod_ErrorDiffusion);
		AutoReplyPrint.INSTANCE.CP_Page_PrintPage(h);
		AutoReplyPrint.INSTANCE.CP_Page_ExitPageMode(h);

		Test_Pos_QueryPrintResult(h);
	}

	void Test_BlackMark_EnableBlackMarkMode(Pointer h) {
		boolean result = AutoReplyPrint.INSTANCE.CP_BlackMark_EnableBlackMarkMode(h);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_BlackMark_DisableBlackMarkMode(Pointer h) {
		boolean result = AutoReplyPrint.INSTANCE.CP_BlackMark_DisableBlackMarkMode(h);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_BlackMark_SetBlackMarkMaxFindLength(Pointer h) {
		int maxFindLength = 300;

		boolean result = AutoReplyPrint.INSTANCE.CP_BlackMark_SetBlackMarkMaxFindLength(h, maxFindLength);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_BlackMark_FindNextBlackMark(Pointer h) {
		boolean result = AutoReplyPrint.INSTANCE.CP_BlackMark_FindNextBlackMark(h);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_BlackMark_SetBlackMarkPaperPrintPosition(Pointer h) {
		int position = 0;

		boolean result = AutoReplyPrint.INSTANCE.CP_BlackMark_SetBlackMarkPaperPrintPosition(h, position * 8);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_BlackMark_SetBlackMarkPaperCutPosition(Pointer h) {
		int position = 0;

		boolean result = AutoReplyPrint.INSTANCE.CP_BlackMark_SetBlackMarkPaperCutPosition(h, position * 8);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_BlackMark_PrintTextOnBlackMarkPaper(Pointer h) {
		boolean result = AutoReplyPrint.INSTANCE.CP_Pos_PrintText(h, "123456789012345678901234567890\r\n");
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_BlackMark_FullCutBlackMarkPaper(Pointer h) {
		boolean result = AutoReplyPrint.INSTANCE.CP_BlackMark_FullCutBlackMarkPaper(h);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_BlackMark_HalfCutBlackMarkPaper(Pointer h) {
		boolean result = AutoReplyPrint.INSTANCE.CP_BlackMark_HalfCutBlackMarkPaper(h);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Label_EnableLabelMode(Pointer h) {
		boolean result = AutoReplyPrint.INSTANCE.CP_Label_EnableLabelMode(h);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Label_DisableLabelMode(Pointer h) {
		boolean result = AutoReplyPrint.INSTANCE.CP_Label_DisableLabelMode(h);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Label_CalibrateLabel(Pointer h) {
		boolean result = AutoReplyPrint.INSTANCE.CP_Label_CalibrateLabel(h);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Label_FeedLabel(Pointer h) {
		boolean result = AutoReplyPrint.INSTANCE.CP_Label_FeedLabel(h);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Label_SetLabelPositionAdjustment(Pointer h) {
		boolean result = AutoReplyPrint.INSTANCE.CP_Printer_SetPrinterLabelPositionAdjustmentInfo(h, 0, 0);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Label_PageBegin_PagePrint(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Label_PageBegin(h, 0, 0, 384, 400, AutoReplyPrint.CP_Label_Rotation_0);
		AutoReplyPrint.INSTANCE.CP_Label_DrawBox(h, 0, 0, 384, 400, 1, AutoReplyPrint.CP_Label_Color_Black);
		boolean result = AutoReplyPrint.INSTANCE.CP_Label_PagePrint(h, 1);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Label_DrawText(Pointer h) {
		String str = "$$$$$$$$$$$$";

		AutoReplyPrint.INSTANCE.CP_Label_PageBegin(h, 0, 0, 384, 400, AutoReplyPrint.CP_Label_Rotation_0);
		AutoReplyPrint.INSTANCE.CP_Label_DrawBox(h, 0, 0, 384, 400, 1, AutoReplyPrint.CP_Label_Color_Black);
		AutoReplyPrint.INSTANCE.CP_Label_DrawText(h, 10, 10, 24, 0, str);
		AutoReplyPrint.INSTANCE.CP_Label_DrawText(h, 10, 40, 24, new AutoReplyPrint.CP_Label_TextStyle(true, true, false, false, AutoReplyPrint.CP_Label_Rotation_0, 1, 1).getStyle(), str);
		AutoReplyPrint.INSTANCE.CP_Label_DrawText(h, 10, 70, 24, new AutoReplyPrint.CP_Label_TextStyle(false, false, false, false, AutoReplyPrint.CP_Label_Rotation_0, 2, 2).getStyle(), str);
		AutoReplyPrint.INSTANCE.CP_Label_DrawText(h, 30, 130, 24, new AutoReplyPrint.CP_Label_TextStyle(false, false, false, false, AutoReplyPrint.CP_Label_Rotation_90, 1, 1).getStyle(), str);
		AutoReplyPrint.INSTANCE.CP_Label_DrawText(h, 40, 200, 26, 0, str);
		AutoReplyPrint.INSTANCE.CP_Label_DrawText(h, 40, 240, 28, 0, str);
		AutoReplyPrint.INSTANCE.CP_Label_DrawText(h, 40, 280, 16, 0, str);
		AutoReplyPrint.INSTANCE.CP_Label_DrawText(h, 40, 320, 21, 0, str);
		boolean result = AutoReplyPrint.INSTANCE.CP_Label_PagePrint(h, 1);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Label_DrawBarcode_UPCA(Pointer h) {
		String str = "01234567890";

		AutoReplyPrint.INSTANCE.CP_Label_PageBegin(h, 0, 0, 384, 400, AutoReplyPrint.CP_Label_Rotation_0);
		AutoReplyPrint.INSTANCE.CP_Label_DrawBox(h, 0, 0, 384, 400, 1, AutoReplyPrint.CP_Label_Color_Black);

		AutoReplyPrint.INSTANCE.CP_Label_DrawBarcode(h, 10, 10, AutoReplyPrint.CP_Label_BarcodeType_UPCA, AutoReplyPrint.CP_Label_BarcodeTextPrintPosition_BelowBarcode, 60, 2, AutoReplyPrint.CP_Label_Rotation_0, str);

		boolean result = AutoReplyPrint.INSTANCE.CP_Label_PagePrint(h, (byte) 1);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Label_DrawBarcode_UPCE(Pointer h) {
		String str = "123456";

		AutoReplyPrint.INSTANCE.CP_Label_PageBegin(h, 0, 0, 384, 400, AutoReplyPrint.CP_Label_Rotation_0);
		AutoReplyPrint.INSTANCE.CP_Label_DrawBox(h, 0, 0, 384, 400, 1, AutoReplyPrint.CP_Label_Color_Black);

		AutoReplyPrint.INSTANCE.CP_Label_DrawBarcode(h, 10, 10, AutoReplyPrint.CP_Label_BarcodeType_UPCE, AutoReplyPrint.CP_Label_BarcodeTextPrintPosition_BelowBarcode, 60, 2, AutoReplyPrint.CP_Label_Rotation_0, str);

		boolean result = AutoReplyPrint.INSTANCE.CP_Label_PagePrint(h, (byte) 1);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Label_DrawBarcode_EAN13(Pointer h) {
		String str = "123456789012";

		AutoReplyPrint.INSTANCE.CP_Label_PageBegin(h, 0, 0, 384, 400, AutoReplyPrint.CP_Label_Rotation_0);
		AutoReplyPrint.INSTANCE.CP_Label_DrawBox(h, 0, 0, 384, 400, 1, AutoReplyPrint.CP_Label_Color_Black);

		AutoReplyPrint.INSTANCE.CP_Label_DrawBarcode(h, 10, 10, AutoReplyPrint.CP_Label_BarcodeType_EAN13, AutoReplyPrint.CP_Label_BarcodeTextPrintPosition_BelowBarcode, 60, 2, AutoReplyPrint.CP_Label_Rotation_0, str);

		boolean result = AutoReplyPrint.INSTANCE.CP_Label_PagePrint(h, (byte) 1);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Label_DrawBarcode_EAN8(Pointer h) {
		String str = "1234567";

		AutoReplyPrint.INSTANCE.CP_Label_PageBegin(h, 0, 0, 384, 400, AutoReplyPrint.CP_Label_Rotation_0);
		AutoReplyPrint.INSTANCE.CP_Label_DrawBox(h, 0, 0, 384, 400, 1, AutoReplyPrint.CP_Label_Color_Black);

		AutoReplyPrint.INSTANCE.CP_Label_DrawBarcode(h, 10, 10, AutoReplyPrint.CP_Label_BarcodeType_EAN8, AutoReplyPrint.CP_Label_BarcodeTextPrintPosition_BelowBarcode, 60, 2, AutoReplyPrint.CP_Label_Rotation_0, str);

		boolean result = AutoReplyPrint.INSTANCE.CP_Label_PagePrint(h, 1);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Label_DrawBarcode_CODE39(Pointer h) {
		String str = "123456";

		AutoReplyPrint.INSTANCE.CP_Label_PageBegin(h, 0, 0, 384, 400, AutoReplyPrint.CP_Label_Rotation_0);
		AutoReplyPrint.INSTANCE.CP_Label_DrawBox(h, 0, 0, 384, 400, 1, AutoReplyPrint.CP_Label_Color_Black);

		AutoReplyPrint.INSTANCE.CP_Label_DrawBarcode(h, 10, 10, AutoReplyPrint.CP_Label_BarcodeType_CODE39, AutoReplyPrint.CP_Label_BarcodeTextPrintPosition_BelowBarcode, 60, 2, AutoReplyPrint.CP_Label_Rotation_0, str);

		boolean result = AutoReplyPrint.INSTANCE.CP_Label_PagePrint(h, 1);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Label_DrawBarcode_ITF(Pointer h) {
		String str = "123456";

		AutoReplyPrint.INSTANCE.CP_Label_PageBegin(h, 0, 0, 384, 400, AutoReplyPrint.CP_Label_Rotation_0);
		AutoReplyPrint.INSTANCE.CP_Label_DrawBox(h, 0, 0, 384, 400, 1, AutoReplyPrint.CP_Label_Color_Black);

		AutoReplyPrint.INSTANCE.CP_Label_DrawBarcode(h, 10, 10, AutoReplyPrint.CP_Label_BarcodeType_ITF, AutoReplyPrint.CP_Label_BarcodeTextPrintPosition_BelowBarcode, 60, 2, AutoReplyPrint.CP_Label_Rotation_0, str);

		boolean result = AutoReplyPrint.INSTANCE.CP_Label_PagePrint(h, 1);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Label_DrawBarcode_CODEBAR(Pointer h) {
		String str = "A123456A";

		AutoReplyPrint.INSTANCE.CP_Label_PageBegin(h, 0, 0, 384, 400, AutoReplyPrint.CP_Label_Rotation_0);
		AutoReplyPrint.INSTANCE.CP_Label_DrawBox(h, 0, 0, 384, 400, 1, AutoReplyPrint.CP_Label_Color_Black);

		AutoReplyPrint.INSTANCE.CP_Label_DrawBarcode(h, 10, 10, AutoReplyPrint.CP_Label_BarcodeType_CODEBAR, AutoReplyPrint.CP_Label_BarcodeTextPrintPosition_BelowBarcode, 60, 2, AutoReplyPrint.CP_Label_Rotation_0, str);

		boolean result = AutoReplyPrint.INSTANCE.CP_Label_PagePrint(h, 1);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Label_DrawBarcode_CODE93(Pointer h) {
		String str = "123456";

		AutoReplyPrint.INSTANCE.CP_Label_PageBegin(h, 0, 0, 384, 400, AutoReplyPrint.CP_Label_Rotation_0);
		AutoReplyPrint.INSTANCE.CP_Label_DrawBox(h, 0, 0, 384, 400, 1, AutoReplyPrint.CP_Label_Color_Black);

		AutoReplyPrint.INSTANCE.CP_Label_DrawBarcode(h, 10, 10, AutoReplyPrint.CP_Label_BarcodeType_CODE93, AutoReplyPrint.CP_Label_BarcodeTextPrintPosition_BelowBarcode, 60, 2, AutoReplyPrint.CP_Label_Rotation_0, str);

		boolean result = AutoReplyPrint.INSTANCE.CP_Label_PagePrint(h, 1);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Label_DrawBarcode_CODE128(Pointer h) {
		String str = "No.123456";

		AutoReplyPrint.INSTANCE.CP_Label_PageBegin(h, 0, 0, 384, 400, AutoReplyPrint.CP_Label_Rotation_0);
		AutoReplyPrint.INSTANCE.CP_Label_DrawBox(h, 0, 0, 384, 400, 1, AutoReplyPrint.CP_Label_Color_Black);

		AutoReplyPrint.INSTANCE.CP_Label_DrawBarcode(h, 10, 10, AutoReplyPrint.CP_Label_BarcodeType_CODE128, AutoReplyPrint.CP_Label_BarcodeTextPrintPosition_BelowBarcode, 60, 2, AutoReplyPrint.CP_Label_Rotation_0, str);

		boolean result = AutoReplyPrint.INSTANCE.CP_Label_PagePrint(h, 1);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Label_DrawQRCode(Pointer h) {
		String str = "Hello 你好";

		AutoReplyPrint.INSTANCE.CP_Label_PageBegin(h, 0, 0, 384, 400, AutoReplyPrint.CP_Label_Rotation_0);
		AutoReplyPrint.INSTANCE.CP_Label_DrawBox(h, 0, 0, 384, 400, 1, AutoReplyPrint.CP_Label_Color_Black);

		AutoReplyPrint.INSTANCE.CP_Label_DrawQRCode(h, 10, 10, 0, AutoReplyPrint.CP_QRCodeECC_L, 8, AutoReplyPrint.CP_Label_Rotation_0, str);

		boolean result = AutoReplyPrint.INSTANCE.CP_Label_PagePrint(h, 1);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Label_DrawPDF417Code(Pointer h) {
		String str = "Hello 你好";

		AutoReplyPrint.INSTANCE.CP_Label_PageBegin(h, 0, 0, 384, 400, AutoReplyPrint.CP_Label_Rotation_0);
		AutoReplyPrint.INSTANCE.CP_Label_DrawBox(h, 0, 0, 384, 400, 1, AutoReplyPrint.CP_Label_Color_Black);

		AutoReplyPrint.INSTANCE.CP_Label_DrawPDF417Code(h, 10, 10, 3, 3, 0, 3, AutoReplyPrint.CP_Label_Rotation_0, str);

		boolean result = AutoReplyPrint.INSTANCE.CP_Label_PagePrint(h, 1);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Label_DrawLine(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Label_PageBegin(h, 0, 0, 384, 400, AutoReplyPrint.CP_Label_Rotation_0);
		AutoReplyPrint.INSTANCE.CP_Label_DrawBox(h, 0, 0, 384, 400, 1, AutoReplyPrint.CP_Label_Color_Black);
		AutoReplyPrint.INSTANCE.CP_Label_DrawLine(h, 20, 20, 100, 300, 1, AutoReplyPrint.CP_Label_Color_Black);
		boolean result = AutoReplyPrint.INSTANCE.CP_Label_PagePrint(h, 1);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Label_DrawRect(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Label_PageBegin(h, 0, 0, 384, 400, AutoReplyPrint.CP_Label_Rotation_0);
		AutoReplyPrint.INSTANCE.CP_Label_DrawBox(h, 0, 0, 384, 400, 1, AutoReplyPrint.CP_Label_Color_Black);
		AutoReplyPrint.INSTANCE.CP_Label_DrawRect(h, 20, 20, 200, 10, AutoReplyPrint.CP_Label_Color_Black);
		boolean result = AutoReplyPrint.INSTANCE.CP_Label_PagePrint(h, 1);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Label_DrawBox(Pointer h) {
		AutoReplyPrint.INSTANCE.CP_Label_PageBegin(h, 0, 0, 384, 400, AutoReplyPrint.CP_Label_Rotation_0);
		AutoReplyPrint.INSTANCE.CP_Label_DrawBox(h, 0, 0, 384, 400, 1, AutoReplyPrint.CP_Label_Color_Black);
		AutoReplyPrint.INSTANCE.CP_Label_DrawBox(h, 30, 30, 300, 200, 1, AutoReplyPrint.CP_Label_Color_Black);
		boolean result = AutoReplyPrint.INSTANCE.CP_Label_PagePrint(h, 1);
		if (!result)
			TestUtils.showMessageOnUiThread("Write failed");
	}

	void Test_Label_DrawImageFromBufferedImage(Pointer h) {
		String filePath = TestUtils.SelectImage();
		if (filePath == null)
			return;

		BufferedImage image = null;
		try {
			image = ImageIO.read(new FileInputStream(filePath));
		} catch (Throwable tr) {
			tr.printStackTrace();
		}
		if ((image == null) || (image.getWidth() == 0) || (image.getHeight() == 0))
			return;

		int printwidth = 384;
		int dstw = printwidth;
		int dsth = (int) (dstw * ((double) image.getHeight() / image.getWidth()));

		AutoReplyPrint.INSTANCE.CP_Label_PageBegin(h, 0, 0, dstw, dsth, AutoReplyPrint.CP_Label_Rotation_0);
		AutoReplyPrint.INSTANCE.CP_Label_DrawBox(h, 0, 0, dstw, dsth, 1, AutoReplyPrint.CP_Label_Color_Black);
		AutoReplyPrint.CP_Label_DrawImageFromData_Helper.DrawImageFromBufferedImage(h, 0, 0, dstw, dsth, image, AutoReplyPrint.CP_ImageBinarizationMethod_ErrorDiffusion, AutoReplyPrint.CP_ImageCompressionMethod_None);
		AutoReplyPrint.INSTANCE.CP_Label_PagePrint(h, 1);
		Test_Pos_QueryPrintResult(h);
	}

}
