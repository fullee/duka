using System;
using System.Collections.Generic;
using System.Text;
using autoreplyprint.cs;
using System.IO;
using System.Windows.Forms;

namespace samplepos_withoutautoreply
{
    class TestFunction
    {
        public static String[] testFunctionOrderedList = new String[] {

            "Test_Pos_SampleTicket_58MM_1",
            "Test_Pos_SampleTicket_80MM_1",

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
            "Test_Pos_FeedAndHalfCutPaper",
            "Test_Pos_FullCutPaper",
            "Test_Pos_HalfCutPaper",
            "Test_Pos_Feed",

            "Test_Pos_PrintSelfTestPage",
            "Test_Pos_PrintText",
            "Test_Pos_PrintTextInUTF8",
            "Test_Pos_PrintTextInGBK",
            "Test_Pos_PrintTextInBIG5",
            "Test_Pos_PrintTextInShiftJIS",
            "Test_Pos_PrintTextInEUCKR",
            "Test_Pos_PrintBarcode",
            "Test_Pos_PrintQRCode",
            "Test_Pos_PrintQRCodeUseEpsonCmd",
            "Test_Pos_PrintDoubleQRCode",
            "Test_Pos_PrintPDF417BarcodeUseEpsonCmd",

            "Test_Pos_PrintRasterImageFromFile",
            "Test_Pos_PrintRasterImageFromData",
            "Test_Pos_PrintRasterImageFromPixels",
            "Test_Pos_PrintHorizontalLine",
            "Test_Pos_PrintHorizontalLineSpecifyThickness",
            "Test_Pos_PrintMultipleHorizontalLinesAtOneRow",

            "Test_Pos_ResetPrinter",
            "Test_Pos_SetPrintSpeed_20",
            "Test_Pos_SetPrintSpeed_50",
            "Test_Pos_SetPrintSpeed_100",
            "Test_Pos_SetPrintDensity_0",
            "Test_Pos_SetPrintDensity_7",
            "Test_Pos_SetPrintDensity_15",
            "Test_Pos_SetSingleByteMode",
            "Test_Pos_SetMultiByteMode",

            "Test_Pos_SetMovementUnit",
            "Test_Pos_SetPrintAreaLeftMargin",
            "Test_Pos_SetPrintAreaWidth",
            "Test_Pos_SetPrintPosition",
            "Test_Pos_SetAlignment",
            "Test_Pos_SetTextScale",
            "Test_Pos_SetAsciiTextFontType",
            "Test_Pos_SetTextBold",
            "Test_Pos_SetTextUnderline",
            "Test_Pos_SetTextUpsideDown",
            "Test_Pos_SetTextWhiteOnBlack",
            "Test_Pos_SetTextRotate",
            "Test_Pos_SetTextLineHeight",
            "Test_Pos_SetAsciiTextCharRightSpacing",
            "Test_Pos_SetKanjiTextCharSpacing",

        };

        public void Test_Pos_SampleTicket_58MM_1(UIntPtr h)
        {
            int paperWidth = 384;

            AutoReplyPrint.CP_Pos_ResetPrinter(h);
            AutoReplyPrint.CP_Pos_SetMultiByteMode(h);
            AutoReplyPrint.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_UTF8);

            AutoReplyPrint.CP_Pos_PrintText(h, "123xxstreet,xxxcity,xxxxstate\r\n");
            AutoReplyPrint.CP_Pos_SetAlignment(h, AutoReplyPrint.CP_Pos_Alignment_Right);
            AutoReplyPrint.CP_Pos_PrintText(h, "TEL 9999-99-9999  C#2\r\n");
            AutoReplyPrint.CP_Pos_SetAlignment(h, AutoReplyPrint.CP_Pos_Alignment_HCenter);
            AutoReplyPrint.CP_Pos_PrintText(h, "2018-06-19 14:09:00");
            AutoReplyPrint.CP_Pos_FeedLine(h, 1);

            AutoReplyPrint.CP_Pos_FeedLine(h, 1);
            AutoReplyPrint.CP_Pos_PrintText(h, "apples");
            AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, paperWidth - 12 * 6);
            AutoReplyPrint.CP_Pos_PrintText(h, "$10.00");
            AutoReplyPrint.CP_Pos_FeedLine(h, 1);
            AutoReplyPrint.CP_Pos_PrintText(h, "grapes");
            AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, paperWidth - 12 * 6);
            AutoReplyPrint.CP_Pos_PrintText(h, "$20.00");
            AutoReplyPrint.CP_Pos_FeedLine(h, 1);
            AutoReplyPrint.CP_Pos_PrintText(h, "bananas");
            AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, paperWidth - 12 * 6);
            AutoReplyPrint.CP_Pos_PrintText(h, "$30.00");
            AutoReplyPrint.CP_Pos_FeedLine(h, 1);
            AutoReplyPrint.CP_Pos_PrintText(h, "lemons");
            AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, paperWidth - 12 * 6);
            AutoReplyPrint.CP_Pos_PrintText(h, "$40.00");
            AutoReplyPrint.CP_Pos_FeedLine(h, 1);
            AutoReplyPrint.CP_Pos_PrintText(h, "oranges");
            AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, paperWidth - 12 * 7);
            AutoReplyPrint.CP_Pos_PrintText(h, "$100.00");
            AutoReplyPrint.CP_Pos_FeedLine(h, 1);
            AutoReplyPrint.CP_Pos_FeedLine(h, 1);
            AutoReplyPrint.CP_Pos_PrintText(h, "Before adding tax");
            AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, paperWidth - 12 * 7);
            AutoReplyPrint.CP_Pos_PrintText(h, "$200.00");
            AutoReplyPrint.CP_Pos_FeedLine(h, 1);
            AutoReplyPrint.CP_Pos_PrintText(h, "tax 5.0%");
            AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, paperWidth - 12 * 6);
            AutoReplyPrint.CP_Pos_PrintText(h, "$10.00");
            AutoReplyPrint.CP_Pos_FeedLine(h, 1);
            string line = "";
            for (int i = 0; i < paperWidth / 12; ++i)
                line += " ";
            AutoReplyPrint.CP_Pos_SetTextUnderline(h, 2);
            AutoReplyPrint.CP_Pos_PrintText(h, line);
            AutoReplyPrint.CP_Pos_SetTextUnderline(h, 0);
            AutoReplyPrint.CP_Pos_FeedLine(h, 1);
            AutoReplyPrint.CP_Pos_SetTextScale(h, 1, 0);
            AutoReplyPrint.CP_Pos_PrintText(h, "total");
            AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, paperWidth - 12 * 2 * 7);
            AutoReplyPrint.CP_Pos_PrintText(h, "$190.00");
            AutoReplyPrint.CP_Pos_SetTextScale(h, 0, 0);
            AutoReplyPrint.CP_Pos_FeedLine(h, 1);
            AutoReplyPrint.CP_Pos_PrintText(h, "Customer's payment");
            AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, paperWidth - 12 * 7);
            AutoReplyPrint.CP_Pos_PrintText(h, "$200.00");
            AutoReplyPrint.CP_Pos_FeedLine(h, 1);
            AutoReplyPrint.CP_Pos_PrintText(h, "Change");
            AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, paperWidth - 12 * 6);
            AutoReplyPrint.CP_Pos_PrintText(h, "$10.00");
            AutoReplyPrint.CP_Pos_FeedLine(h, 1);

            AutoReplyPrint.CP_Pos_SetBarcodeHeight(h, 60);
            AutoReplyPrint.CP_Pos_SetBarcodeUnitWidth(h, 3);
            AutoReplyPrint.CP_Pos_SetBarcodeReadableTextPosition(h, AutoReplyPrint.CP_Pos_BarcodeTextPrintPosition_BelowBarcode);
            AutoReplyPrint.CP_Pos_PrintBarcode(h, AutoReplyPrint.CP_Pos_BarcodeType_UPCA, "12345678901");

            //AutoReplyPrint.CP_Pos_FeedLine(h, 3);
            AutoReplyPrint.CP_Pos_FeedAndHalfCutPaper(h);

            {
                Test_Pos_QueryPrintResult(h);
            }
        }

        public void Test_Pos_SampleTicket_80MM_1(UIntPtr h)
        {
            int[] nLineStartPos = { 0, 201, 401 };
            int[] nLineEndPos = { 200, 400, 575 };

            {
                AutoReplyPrint.CP_Pos_ResetPrinter(h);
                AutoReplyPrint.CP_Pos_FeedLine(h, 2);
            }

            {
                AutoReplyPrint.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.Length, nLineStartPos, nLineEndPos);
                AutoReplyPrint.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.Length, nLineStartPos, nLineEndPos);
            }

            {
                AutoReplyPrint.CP_Pos_SetMultiByteMode(h);
                AutoReplyPrint.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_UTF8);
                AutoReplyPrint.CP_Pos_FeedLine(h, 2);
                AutoReplyPrint.CP_Pos_SetAlignment(h, AutoReplyPrint.CP_Pos_Alignment_Right);
                AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, "服务台\r\n");
            }

            {
                AutoReplyPrint.CP_Pos_FeedLine(h, 2);

                int nStartPos = 0;
                int nEndPos = 120;
                AutoReplyPrint.CP_Pos_PrintHorizontalLineSpecifyThickness(h, nStartPos, nEndPos, 3);
                AutoReplyPrint.CP_Pos_FeedDot(h, 10);
                AutoReplyPrint.CP_Pos_SetAlignment(h, AutoReplyPrint.CP_Pos_Alignment_Left);
                AutoReplyPrint.CP_Pos_SetTextBold(h, 1);
                AutoReplyPrint.CP_Pos_SetTextScale(h, 1, 1);
                AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 12);
                AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, "圆桌");
                AutoReplyPrint.CP_Pos_FeedDot(h, 0);
                AutoReplyPrint.CP_Pos_SetTextScale(h, 0, 0);
                AutoReplyPrint.CP_Pos_FeedDot(h, 10);
                AutoReplyPrint.CP_Pos_PrintHorizontalLineSpecifyThickness(h, nStartPos, nEndPos, 3);
                AutoReplyPrint.CP_Pos_FeedLine(h, 1);
                AutoReplyPrint.CP_Pos_SetTextBold(h, 0);
                AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, "麻辣香锅（上梅林店）\r\n2018年2月7日15:51:00\r\n\r\n");
            }

            {
                AutoReplyPrint.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.Length, nLineStartPos, nLineEndPos);
                AutoReplyPrint.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.Length, nLineStartPos, nLineEndPos);
                AutoReplyPrint.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.Length, nLineStartPos, nLineEndPos);
                AutoReplyPrint.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.Length, nLineStartPos, nLineEndPos);
                AutoReplyPrint.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.Length, nLineStartPos, nLineEndPos);
                AutoReplyPrint.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.Length, nLineStartPos, nLineEndPos);
            }

            {
                AutoReplyPrint.CP_Pos_SetAlignment(h, AutoReplyPrint.CP_Pos_Alignment_HCenter);
                AutoReplyPrint.CP_Pos_SetTextScale(h, 1, 1);
                AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, "\r\n15-D-一楼-大厅-散座\r\n");
                AutoReplyPrint.CP_Pos_SetAlignment(h, AutoReplyPrint.CP_Pos_Alignment_Left);
                AutoReplyPrint.CP_Pos_SetTextScale(h, 0, 0);
                AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, "\r\n扫码点餐订单\r\n店内用餐\r\n7人\r\n");
            }

            {
                AutoReplyPrint.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.Length, nLineStartPos, nLineEndPos);
                AutoReplyPrint.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.Length, nLineStartPos, nLineEndPos);
                AutoReplyPrint.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.Length, nLineStartPos, nLineEndPos);
                AutoReplyPrint.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.Length, nLineStartPos, nLineEndPos);
            }

            {
                AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 0);
                AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, "\r\n热菜类\r\n");
                AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 80);
                AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, "鱼香肉丝");
                AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 200);
                AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, "1");
                AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 480);
                AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, "¥23.50\r\n");
                AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 80);
                AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, "麻辣鸡丝");
                AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 200);
                AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, "1");
                AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 480);
                AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, "¥23.50\r\n");
                AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 0);

                AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, "凉菜类\r\n");
                AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 80);
                AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, "凉拌腐竹");
                AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 200);
                AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, "1");
                AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 480);
                AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, "¥23.50\r\n");
                AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 80);
                AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, "糖醋花生");
                AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 200);
                AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, "1");
                AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 480);
                AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, "¥23.50\r\n");
            }

            {
                AutoReplyPrint.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.Length, nLineStartPos, nLineEndPos);
                AutoReplyPrint.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.Length, nLineStartPos, nLineEndPos);
                AutoReplyPrint.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.Length, nLineStartPos, nLineEndPos);
                AutoReplyPrint.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.Length, nLineStartPos, nLineEndPos);
            }

            {
                AutoReplyPrint.CP_Pos_FeedDot(h, 30);
                AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 80);
                AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, "消毒餐具");
                AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 200);
                AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, "7");
                AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 480);
                AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, "¥14.00\r\n");
            }

            {
                AutoReplyPrint.CP_Pos_FeedLine(h, 2);
                AutoReplyPrint.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.Length, nLineStartPos, nLineEndPos);
                AutoReplyPrint.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.Length, nLineStartPos, nLineEndPos);
                AutoReplyPrint.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.Length, nLineStartPos, nLineEndPos);
                AutoReplyPrint.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.Length, nLineStartPos, nLineEndPos);
                AutoReplyPrint.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.Length, nLineStartPos, nLineEndPos);
                AutoReplyPrint.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.Length, nLineStartPos, nLineEndPos);
                AutoReplyPrint.CP_Pos_FeedLine(h, 1);
            }

            {
                AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 0);
                AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, "在线支付");
                AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 480);
                AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, "¥114.00\r\n");
            }

            {
                AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, "备注\r\n");
                AutoReplyPrint.CP_Pos_SetPrintAreaLeftMargin(h, 80);
                AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, "所有菜都不要放葱，口味要微辣。百事可乐不要加冰。上菜快点，太慢了！！\r\n\r\n");
                AutoReplyPrint.CP_Pos_SetPrintAreaLeftMargin(h, 0);
            }

            {
                AutoReplyPrint.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.Length, nLineStartPos, nLineEndPos);
                AutoReplyPrint.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.Length, nLineStartPos, nLineEndPos);
                AutoReplyPrint.CP_Pos_FeedLine(h, 1);
            }

            {
                AutoReplyPrint.CP_Pos_SetAlignment(h, AutoReplyPrint.CP_Pos_Alignment_HCenter);
                AutoReplyPrint.CP_Pos_PrintQRCode(h, 0, AutoReplyPrint.CP_QRCodeECC_L, "麻辣香锅");
                AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, "\r\n用心服务每一天\r\n40008083030\r\n\r\n");
            }

            {
                AutoReplyPrint.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.Length, nLineStartPos, nLineEndPos);
                AutoReplyPrint.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, nLineStartPos.Length, nLineStartPos, nLineEndPos);
            }

            {
                AutoReplyPrint.CP_Pos_Beep(h, 3, 300);
                AutoReplyPrint.CP_Pos_FeedAndHalfCutPaper(h);
            }

            {
                Test_Pos_QueryPrintResult(h);
            }
        }

        public void Test_Port_Write(UIntPtr h)
        {
            // send this cmd to print a selftest page
            byte[] cmd = { 0x12, 0x54 };
            if (AutoReplyPrint.CP_Port_Write(h, cmd, cmd.Length, 1000) != cmd.Length)
                MessageBox.Show("Write failed");
        }

        public void Test_Port_Read(UIntPtr h)
        {
            // send this cmd to query printer status
            byte[] cmd = { 0x10, 0x04, 0x01 };
            AutoReplyPrint.CP_Port_SkipAvailable(h);
            if (AutoReplyPrint.CP_Port_Write(h, cmd, cmd.Length, 1000) == cmd.Length)
            {
                byte[] status = new byte[1];
                if (AutoReplyPrint.CP_Port_Read(h, status, 1, 2000) == 1)
                {
                    MessageBox.Show(String.Format("Status: {0:X2}", status[0]));
                }
                else
                {
                    MessageBox.Show("Read failed");
                }
            }
            else
            {
                MessageBox.Show("Write failed");
            }
        }

        public void Test_Port_Available(UIntPtr h)
        {
            int available = AutoReplyPrint.CP_Port_Available(h);
            MessageBox.Show(String.Format("available: {0:D}", available));
        }

        public void Test_Port_SkipAvailable(UIntPtr h)
        {
            AutoReplyPrint.CP_Port_SkipAvailable(h);
        }

        public void Test_Port_IsConnectionValid(UIntPtr h)
        {
            int valid = AutoReplyPrint.CP_Port_IsConnectionValid(h);
            MessageBox.Show(String.Format("valid: {0:D}", valid));
        }

        public DateTime NewDate(long timestamp)
        {
            DateTime dt1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            long t = dt1970.Ticks + timestamp * 10000;
            return new DateTime(t);
        }

        public void Test_Printer_ClearPrinterBuffer(UIntPtr h)
        {
            AutoReplyPrint.CP_Printer_ClearPrinterBuffer(h);
        }

        public void Test_Printer_ClearPrinterError(UIntPtr h)
        {
            AutoReplyPrint.CP_Printer_ClearPrinterError(h);
        }

        public void Test_Pos_QueryRTStatus(UIntPtr h)
        {
            int status = AutoReplyPrint.CP_Pos_QueryRTStatus(h, 3000);
            if (status != 0)
            {
                String s = "";
                s += String.Format("RTStatus: {0:X} {1:X} {2:X} {3:X}\r\n", status & 0xff, (status >> 8) & 0xff, (status >> 16) & 0xff, (status >> 24) & 0xff);
                if (AutoReplyPrint.CP_RTSTATUS_COVERUP(status))
                    s += "[Cover Up]";
                if (AutoReplyPrint.CP_RTSTATUS_NOPAPER(status))
                    s += "[No Paper]";
                if (AutoReplyPrint.CP_RTSTATUS_PAPER_NEAREND(status))
                    s += "[Paper Near End]";
                MessageBox.Show(s);
            }
            else
            {
                MessageBox.Show("Query Failed");
            }
        }

        public void Test_Pos_QueryPrintResult(UIntPtr h)
        {
            int result = AutoReplyPrint.CP_Pos_QueryPrintResult(h, 30000);
            if (result != 0)
                MessageBox.Show("Print Success");
            else
                MessageBox.Show("Print Failed");
        }

        public void Test_Pos_KickOutDrawer(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_KickOutDrawer(h, 0, 100, 100);
            AutoReplyPrint.CP_Pos_KickOutDrawer(h, 1, 100, 100);
        }

        public void Test_Pos_Beep(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_Beep(h, 3, 300);
        }

        public void Test_Pos_FeedAndHalfCutPaper(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_FeedAndHalfCutPaper(h);
        }

        public void Test_Pos_FullCutPaper(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_FullCutPaper(h);
        }

        public void Test_Pos_HalfCutPaper(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_HalfCutPaper(h);
        }

        public void Test_Pos_Feed(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_PrintText(h, "12345678901234567890");
            AutoReplyPrint.CP_Pos_FeedLine(h, 4);
            AutoReplyPrint.CP_Pos_PrintText(h, "12345678901234567890");
            AutoReplyPrint.CP_Pos_FeedDot(h, 100);
            int result = AutoReplyPrint.CP_Pos_FeedLine(h, 3);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Pos_PrintSelfTestPage(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_PrintSelfTestPage(h);
        }

        public void Test_Pos_PrintText(UIntPtr h)
        {
            int result = AutoReplyPrint.CP_Pos_PrintText(h, "12345678901234567890\r\n");
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Pos_PrintTextInUTF8(UIntPtr h)
        {
            String str =
                    "1234567890\r\n" +
                    "abcdefghijklmnopqrstuvwxyz\r\n" +
                    "ΑΒΓΔΕΖΗΘΙΚ∧ΜΝΞΟ∏Ρ∑ΤΥΦΧΨΩ\r\n" +
                    "αβγδεζηθικλμνξοπρστυφχψω\r\n" +
                    "你好，欢迎使用！\r\n" +
                    "你號，歡迎使用！\r\n" +
                    "梦を见る事が出来なければ\r\n未来を変える事は出来ません\r\n" +
                    "왕관을 쓰려는자\r\n그 무게를 견뎌라\r\n";
            AutoReplyPrint.CP_Pos_SetMultiByteMode(h);
            AutoReplyPrint.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_UTF8);
            int result = AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, str);
            if (result == 0)
                MessageBox.Show("Write failed");
        }
        public void Test_Pos_PrintTextInGBK(UIntPtr h)
        {
            String str = "1234567890\r\nabcdefghijklmnopqrstuvwxyz\r\n你好，欢迎使用！\r\n你號，歡迎使用！\r\n";
            AutoReplyPrint.CP_Pos_SetMultiByteMode(h);
            AutoReplyPrint.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_GBK);
            int result = AutoReplyPrint.CP_Pos_PrintTextInGBK(h, str);
            if (result == 0)
                MessageBox.Show("Write failed");
        }
        public void Test_Pos_PrintTextInBIG5(UIntPtr h)
        {
            String str = "1234567890\r\nabcdefghijklmnopqrstuvwxyz\r\n你號，歡迎使用！\r\n";
            AutoReplyPrint.CP_Pos_SetMultiByteMode(h);
            AutoReplyPrint.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_BIG5);
            int result = AutoReplyPrint.CP_Pos_PrintTextInBIG5(h, str);
            if (result == 0)
                MessageBox.Show("Write failed");
        }
        public void Test_Pos_PrintTextInShiftJIS(UIntPtr h)
        {
            String str =
                            "1234567890\r\n" +
                            "abcdefghijklmnopqrstuvwxyz\r\n" +
                            "こんにちは\r\n";
            AutoReplyPrint.CP_Pos_SetMultiByteMode(h);
            AutoReplyPrint.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_ShiftJIS);
            int result = AutoReplyPrint.CP_Pos_PrintTextInShiftJIS(h, str);
            if (result == 0)
                MessageBox.Show("Write failed");
        }
        public void Test_Pos_PrintTextInEUCKR(UIntPtr h)
        {
            String str =
                            "1234567890\r\n" +
                            "abcdefghijklmnopqrstuvwxyz\r\n" +
                            "왕관을 쓰려는자\r\n" +
                            "그 무게를 견뎌라\r\n";
            AutoReplyPrint.CP_Pos_SetMultiByteMode(h);
            AutoReplyPrint.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_EUCKR);
            int result = AutoReplyPrint.CP_Pos_PrintTextInEUCKR(h, str);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Pos_PrintBarcode(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_SetBarcodeUnitWidth(h, 2);
            AutoReplyPrint.CP_Pos_SetBarcodeHeight(h, 60);
            AutoReplyPrint.CP_Pos_SetBarcodeReadableTextFontType(h, 0);
            AutoReplyPrint.CP_Pos_SetBarcodeReadableTextPosition(h, AutoReplyPrint.CP_Pos_BarcodeTextPrintPosition_BelowBarcode);
            AutoReplyPrint.CP_Pos_PrintBarcode(h, AutoReplyPrint.CP_Pos_BarcodeType_UPCA, "01234567890");
            AutoReplyPrint.CP_Pos_PrintBarcode(h, AutoReplyPrint.CP_Pos_BarcodeType_UPCE, "123456");
            AutoReplyPrint.CP_Pos_PrintBarcode(h, AutoReplyPrint.CP_Pos_BarcodeType_EAN13, "123456789012");
            AutoReplyPrint.CP_Pos_PrintBarcode(h, AutoReplyPrint.CP_Pos_BarcodeType_EAN8, "1234567");
            AutoReplyPrint.CP_Pos_PrintBarcode(h, AutoReplyPrint.CP_Pos_BarcodeType_CODE39, "123456");
            AutoReplyPrint.CP_Pos_PrintBarcode(h, AutoReplyPrint.CP_Pos_BarcodeType_ITF, "123456");
            AutoReplyPrint.CP_Pos_PrintBarcode(h, AutoReplyPrint.CP_Pos_BarcodeType_CODEBAR, "A123456A");
            AutoReplyPrint.CP_Pos_PrintBarcode(h, AutoReplyPrint.CP_Pos_BarcodeType_CODE93, "123456");
            AutoReplyPrint.CP_Pos_PrintBarcode(h, AutoReplyPrint.CP_Pos_BarcodeType_CODE128, "No.123456");

            int result = AutoReplyPrint.CP_Pos_FeedLine(h, 3);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Pos_PrintQRCode(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_SetBarcodeUnitWidth(h, 8);
            AutoReplyPrint.CP_Pos_PrintQRCode(h, 0, AutoReplyPrint.CP_QRCodeECC_L, "Hello 欢迎使用");

            int result = AutoReplyPrint.CP_Pos_FeedLine(h, 3);
            if (result == 0)
                MessageBox.Show("Write failed");

        }
        public void Test_Pos_PrintQRCodeUseEpsonCmd(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_PrintQRCodeUseEpsonCmd(h, 8, AutoReplyPrint.CP_QRCodeECC_L, "Hello 欢迎使用");

            int result = AutoReplyPrint.CP_Pos_FeedLine(h, 3);
            if (result == 0)
                MessageBox.Show("Write failed");

        }
        public void Test_Pos_PrintDoubleQRCode(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_PrintDoubleQRCode(h, 4, 0, 4, AutoReplyPrint.CP_QRCodeECC_L, "hello", 200, 3, AutoReplyPrint.CP_QRCodeECC_L, "test");

            int result = AutoReplyPrint.CP_Pos_FeedLine(h, 3);
            if (result == 0)
                MessageBox.Show("Write failed");

        }
        public void Test_Pos_PrintPDF417BarcodeUseEpsonCmd(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_PrintPDF417BarcodeUseEpsonCmd(h, 0, 0, 3, 3, 0, 0, "test 测试");

            int result = AutoReplyPrint.CP_Pos_FeedLine(h, 3);
            if (result == 0)
                MessageBox.Show("Write failed");

        }

        public void Test_Pos_PrintRasterImageFromFile(UIntPtr h)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "Image File|*.png;*.bmp";
            if (openFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            String str = openFileDialog.FileName;

            AutoReplyPrint.CP_Pos_PrintRasterImageFromFile(h, 384, 0, str, AutoReplyPrint.CP_ImageBinarizationMethod_Dithering, AutoReplyPrint.CP_ImageCompressionMethod_None);
            AutoReplyPrint.CP_Pos_PrintRasterImageFromFile(h, 384, 0, str, AutoReplyPrint.CP_ImageBinarizationMethod_Thresholding, AutoReplyPrint.CP_ImageCompressionMethod_None);
            AutoReplyPrint.CP_Pos_PrintRasterImageFromFile(h, 384, 0, str, AutoReplyPrint.CP_ImageBinarizationMethod_ErrorDiffusion, AutoReplyPrint.CP_ImageCompressionMethod_None);

            int result = AutoReplyPrint.CP_Pos_FeedLine(h, 3);
            if (result == 0)
                MessageBox.Show("Write failed");
        }
        public void Test_Pos_PrintRasterImageFromData(UIntPtr h)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "Image File|*.png;*.bmp";
            if (openFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            String str = openFileDialog.FileName;
            byte[] data = FileUtils.ReadFromFile(str);
            if (data == null)
                return;

            AutoReplyPrint.CP_Pos_PrintRasterImageFromData(h, 384, 0, data, data.Length, AutoReplyPrint.CP_ImageBinarizationMethod_ErrorDiffusion, AutoReplyPrint.CP_ImageCompressionMethod_None);

            int result = AutoReplyPrint.CP_Pos_FeedLine(h, 3);
            if (result == 0)
                MessageBox.Show("Write failed");
        }
        public void Test_Pos_PrintRasterImageFromPixels(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_PrintRasterImageFromPixels(
                    h, FileUtils.imagewo_24x24_pixels_data, FileUtils.imagewo_24x24_pixels_data.Length,
                    24, 24, 3,
                    AutoReplyPrint.CP_ImagePixelsFormat_MONO,
                    AutoReplyPrint.CP_ImageBinarizationMethod_ErrorDiffusion,
                    AutoReplyPrint.CP_ImageCompressionMethod_None);

            int result = AutoReplyPrint.CP_Pos_FeedLine(h, 3);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Pos_PrintHorizontalLine(UIntPtr h)
        {
            for (int i = 0; i < 50; i += 1)
                AutoReplyPrint.CP_Pos_PrintHorizontalLine(h, i, i + 100);
            for (int i = 50; i > 0; i -= 1)
                AutoReplyPrint.CP_Pos_PrintHorizontalLine(h, i, i + 100);

            int result = AutoReplyPrint.CP_Pos_FeedLine(h, 3);
            if (result == 0)
                MessageBox.Show("Write failed");
        }
        public void Test_Pos_PrintHorizontalLineSpecifyThickness(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_PrintHorizontalLineSpecifyThickness(h, 0, 200, 10);

            int result = AutoReplyPrint.CP_Pos_FeedLine(h, 3);
            if (result == 0)
                MessageBox.Show("Write failed");
        }
        public void Test_Pos_PrintMultipleHorizontalLinesAtOneRow(UIntPtr h)
        {
            int r = 150;
            for (int y = -r; y <= r; ++y)
            {
                int x = (int)Math.Sqrt(r * r - y * y);
                int x1 = -x + r;
                int x2 = x + r;
                int[] pLineStartPosition = new int[] { x1, x2 };
                int[] pLineEndPosition = new int[] { x1, x2 };
                if (AutoReplyPrint.CP_Pos_PrintMultipleHorizontalLinesAtOneRow(h, 2, pLineStartPosition, pLineEndPosition) != 0)
                    continue;
                else
                    break;
            }

            int result = AutoReplyPrint.CP_Pos_FeedLine(h, 3);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Pos_ResetPrinter(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_ResetPrinter(h);
            AutoReplyPrint.CP_Pos_PrintSelfTestPage(h);
        }

        public void Test_Pos_SetPrintSpeed_20(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_SetPrintSpeed(h, 20);
            AutoReplyPrint.CP_Pos_PrintSelfTestPage(h);
        }

        public void Test_Pos_SetPrintSpeed_50(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_SetPrintSpeed(h, 50);
            AutoReplyPrint.CP_Pos_PrintSelfTestPage(h);
        }

        public void Test_Pos_SetPrintSpeed_100(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_SetPrintSpeed(h, 100);
            AutoReplyPrint.CP_Pos_PrintSelfTestPage(h);
        }

        public void Test_Pos_SetPrintDensity_0(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_SetPrintDensity(h, 0);
            AutoReplyPrint.CP_Pos_PrintSelfTestPage(h);
        }

        public void Test_Pos_SetPrintDensity_7(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_SetPrintDensity(h, 7);
            AutoReplyPrint.CP_Pos_PrintSelfTestPage(h);
        }

        public void Test_Pos_SetPrintDensity_15(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_SetPrintDensity(h, 15);
            AutoReplyPrint.CP_Pos_PrintSelfTestPage(h);
        }

        public void Test_Pos_SetSingleByteMode(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_SetSingleByteMode(h);
            AutoReplyPrint.CP_Pos_SetCharacterSet(h, AutoReplyPrint.CP_CharacterSet_USA);
            AutoReplyPrint.CP_Pos_SetCharacterCodepage(h, AutoReplyPrint.CP_CharacterCodepage_CP437);
        }

        public void Test_Pos_SetMultiByteMode(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_SetMultiByteMode(h);
            AutoReplyPrint.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_GBK);
        }

        public void Test_Pos_SetMovementUnit(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_SetMovementUnit(h, 100, 100);
            AutoReplyPrint.CP_Pos_SetAsciiTextCharRightSpacing(h, 10);
            AutoReplyPrint.CP_Pos_PrintText(h, "1234567890\r\n");
            AutoReplyPrint.CP_Pos_SetMovementUnit(h, 200, 200);
            AutoReplyPrint.CP_Pos_SetAsciiTextCharRightSpacing(h, 10);
            AutoReplyPrint.CP_Pos_PrintText(h, "1234567890\r\n");
            int result = AutoReplyPrint.CP_Pos_SetAsciiTextCharRightSpacing(h, 0);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Pos_SetPrintAreaLeftMargin(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_SetPrintAreaLeftMargin(h, 96);
            AutoReplyPrint.CP_Pos_SetPrintAreaWidth(h, 384);
            AutoReplyPrint.CP_Pos_PrintText(h, "1234567890123456789012345678901234567890\r\n");
            int result = AutoReplyPrint.CP_Pos_ResetPrinter(h);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Pos_SetPrintAreaWidth(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_SetPrintAreaWidth(h, 384);
            AutoReplyPrint.CP_Pos_PrintText(h, "1234567890123456789012345678901234567890\r\n");
            int result = AutoReplyPrint.CP_Pos_ResetPrinter(h);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Pos_SetPrintPosition(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 0);
            AutoReplyPrint.CP_Pos_PrintText(h, "12345678901234567890\r\n");
            AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, 24);
            AutoReplyPrint.CP_Pos_PrintText(h, "1234567890");
            AutoReplyPrint.CP_Pos_SetHorizontalRelativePrintPosition(h, 24);
            AutoReplyPrint.CP_Pos_PrintText(h, "1234567890\r\n");
            int result = AutoReplyPrint.CP_Pos_FeedLine(h, 3);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Pos_SetAlignment(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_SetAlignment(h, AutoReplyPrint.CP_Pos_Alignment_Right);
            AutoReplyPrint.CP_Pos_PrintText(h, "12345678901234567890\r\n");
            AutoReplyPrint.CP_Pos_SetAlignment(h, AutoReplyPrint.CP_Pos_Alignment_HCenter);
            AutoReplyPrint.CP_Pos_PrintText(h, "12345678901234567890\r\n");
            AutoReplyPrint.CP_Pos_SetAlignment(h, AutoReplyPrint.CP_Pos_Alignment_Left);
            AutoReplyPrint.CP_Pos_PrintText(h, "12345678901234567890\r\n");
            int result = AutoReplyPrint.CP_Pos_FeedLine(h, 3);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Pos_SetTextScale(UIntPtr h)
        {
            int nPosition = 0;
            AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, nPosition);
            AutoReplyPrint.CP_Pos_SetTextScale(h, 0, 0);
            AutoReplyPrint.CP_Pos_PrintText(h, "a");
            nPosition += 12;
            AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, nPosition);
            AutoReplyPrint.CP_Pos_SetTextScale(h, 1, 1);
            AutoReplyPrint.CP_Pos_PrintText(h, "a");
            nPosition += 12 * 2;
            AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, nPosition);
            AutoReplyPrint.CP_Pos_SetTextScale(h, 2, 2);
            AutoReplyPrint.CP_Pos_PrintText(h, "a");
            nPosition += 12 * 3;
            AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, nPosition);
            AutoReplyPrint.CP_Pos_SetTextScale(h, 3, 3);
            AutoReplyPrint.CP_Pos_PrintText(h, "a");
            nPosition += 12 * 4;
            AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, nPosition);
            AutoReplyPrint.CP_Pos_SetTextScale(h, 4, 4);
            AutoReplyPrint.CP_Pos_PrintText(h, "a");
            nPosition += 12 * 5;
            AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, nPosition);
            AutoReplyPrint.CP_Pos_SetTextScale(h, 5, 5);
            AutoReplyPrint.CP_Pos_PrintText(h, "a");
            nPosition += 12 * 6;
            AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, nPosition);
            AutoReplyPrint.CP_Pos_SetTextScale(h, 6, 6);
            AutoReplyPrint.CP_Pos_PrintText(h, "a");
            nPosition += 12 * 7;
            AutoReplyPrint.CP_Pos_SetHorizontalAbsolutePrintPosition(h, nPosition);
            AutoReplyPrint.CP_Pos_SetTextScale(h, 7, 7);
            AutoReplyPrint.CP_Pos_PrintText(h, "a");
            AutoReplyPrint.CP_Pos_SetTextScale(h, 0, 0);
            int result = AutoReplyPrint.CP_Pos_FeedLine(h, 3);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Pos_SetAsciiTextFontType(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_SetAsciiTextFontType(h, 0);
            AutoReplyPrint.CP_Pos_PrintText(h, "FontA\r\n");
            AutoReplyPrint.CP_Pos_SetAsciiTextFontType(h, 1);
            AutoReplyPrint.CP_Pos_PrintText(h, "FontB\r\n");
            AutoReplyPrint.CP_Pos_SetAsciiTextFontType(h, 2);
            AutoReplyPrint.CP_Pos_PrintText(h, "FontC\r\n");
            AutoReplyPrint.CP_Pos_SetAsciiTextFontType(h, 3);
            AutoReplyPrint.CP_Pos_PrintText(h, "FontD\r\n");
            AutoReplyPrint.CP_Pos_SetAsciiTextFontType(h, 4);
            AutoReplyPrint.CP_Pos_PrintText(h, "FontE\r\n");
            AutoReplyPrint.CP_Pos_SetAsciiTextFontType(h, 0);
            int result = AutoReplyPrint.CP_Pos_FeedLine(h, 3);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Pos_SetTextBold(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_SetTextBold(h, 1);
            AutoReplyPrint.CP_Pos_SetMultiByteMode(h);
            AutoReplyPrint.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_UTF8);
            AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, "粗体 Bold\r\n");
            AutoReplyPrint.CP_Pos_SetTextBold(h, 0);
            AutoReplyPrint.CP_Pos_PrintText(h, "Normal\r\n");
            int result = AutoReplyPrint.CP_Pos_FeedLine(h, 3);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Pos_SetTextUnderline(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_SetMultiByteMode(h);
            AutoReplyPrint.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_UTF8);
            AutoReplyPrint.CP_Pos_SetTextUnderline(h, 2);
            AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, "下划线2点 Underline2\r\n");
            AutoReplyPrint.CP_Pos_SetTextUnderline(h, 1);
            AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, "下划线1点 Underline2\r\n");
            AutoReplyPrint.CP_Pos_SetTextUnderline(h, 0);
            AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, "无下划线 No Underline\r\n");
            int result = AutoReplyPrint.CP_Pos_FeedLine(h, 3);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Pos_SetTextUpsideDown(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_SetMultiByteMode(h);
            AutoReplyPrint.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_UTF8);
            AutoReplyPrint.CP_Pos_SetTextUpsideDown(h, 1);
            AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, "上下倒置 UpsideDown\r\n");
            AutoReplyPrint.CP_Pos_SetTextUpsideDown(h, 0);
            AutoReplyPrint.CP_Pos_PrintText(h, "Normal\r\n");
            int result = AutoReplyPrint.CP_Pos_FeedLine(h, 3);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Pos_SetTextWhiteOnBlack(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_SetMultiByteMode(h);
            AutoReplyPrint.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_UTF8);
            AutoReplyPrint.CP_Pos_SetTextWhiteOnBlack(h, 1);
            AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, "黑白反显 WhiteOnBlack\r\n");
            AutoReplyPrint.CP_Pos_SetTextWhiteOnBlack(h, 0);
            AutoReplyPrint.CP_Pos_PrintText(h, "Normal\r\n");
            int result = AutoReplyPrint.CP_Pos_FeedLine(h, 3);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Pos_SetTextRotate(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_SetMultiByteMode(h);
            AutoReplyPrint.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_UTF8);
            AutoReplyPrint.CP_Pos_SetTextRotate(h, 1);
            AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, "文字旋转打印 TextRotate\r\n");
            AutoReplyPrint.CP_Pos_SetTextRotate(h, 0);
            AutoReplyPrint.CP_Pos_PrintText(h, "Normal\r\n");
            int result = AutoReplyPrint.CP_Pos_FeedLine(h, 3);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Pos_SetTextLineHeight(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_SetTextLineHeight(h, 100);
            AutoReplyPrint.CP_Pos_PrintText(h, "LineHeight 100\r\nLineHeight 100\r\nLineHeight 100\r\n");
            AutoReplyPrint.CP_Pos_SetTextLineHeight(h, 32);
            AutoReplyPrint.CP_Pos_PrintText(h, "LineHeight 32\r\nLineHeight 32\r\nLineHeight 32\r\n");
            int result = AutoReplyPrint.CP_Pos_FeedLine(h, 3);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Pos_SetAsciiTextCharRightSpacing(UIntPtr h)
        {
            String str = "Hello你好\r\n";
            AutoReplyPrint.CP_Pos_SetMultiByteMode(h);
            AutoReplyPrint.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_UTF8);
            AutoReplyPrint.CP_Pos_SetAsciiTextCharRightSpacing(h, 2);
            AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, str);
            AutoReplyPrint.CP_Pos_SetAsciiTextCharRightSpacing(h, 0);
            AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, str);
            int result = AutoReplyPrint.CP_Pos_FeedLine(h, 3);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Pos_SetKanjiTextCharSpacing(UIntPtr h)
        {
            String str = "Hello你好\r\n";
            AutoReplyPrint.CP_Pos_SetMultiByteMode(h);
            AutoReplyPrint.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_UTF8);
            AutoReplyPrint.CP_Pos_SetKanjiTextCharSpacing(h, 2, 2);
            AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, str);
            AutoReplyPrint.CP_Pos_SetKanjiTextCharSpacing(h, 0, 0);
            AutoReplyPrint.CP_Pos_PrintTextInUTF8(h, str);
            int result = AutoReplyPrint.CP_Pos_FeedLine(h, 3);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

    }

    class FileUtils
    {
        public static byte[] ReadFromFile(String fileName)
        {
            byte[] data = null;
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);
            }
            return data;
        }

        public static byte[] imagea_12x24_pixels_data = {
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x03, 0x00, 0x04, 0x80, 0x00, 0x80, 0x07, 0x80, 0x08, 0x80, 0x09, 0x80, 0x06, 0x80,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
        };

        public static byte[] imagewo_24x24_pixels_data = {
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x1D, 0x60, 0x00, 0xF1, 0x10, 0x00, 0x11,
            0x00, 0x00, 0xFF, 0xF8, 0x00, 0x11, 0x00, 0x00, 0x11, 0x10, 0x00, 0x1F, 0x20, 0x00, 0xF0, 0xC0,
            0x00, 0x10, 0x88, 0x00, 0x13, 0x88, 0x00, 0x16, 0x48, 0x00, 0xF0, 0x30, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
        };
    }
}
