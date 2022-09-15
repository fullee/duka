using System;
using System.Collections.Generic;
using System.Text;
using autoreplyprint.cs;
using System.IO;
using System.Windows.Forms;

namespace samplelabel
{
    class TestFunction
    {
        public static String[] testFunctionOrderedList = new String[] {

            "Test_Label_SampleTicket_55mmx30mm_1",
            "Test_Label_SampleTicket_HeadImageTail_CompressionLevel0",
            "Test_Label_SampleTicket_HeadImageTail_CompressionLevel1",
            "Test_Label_SampleTicket_HeadImageTail_CompressionLevel2",

            "Test_Port_Write",
            "Test_Port_Read",
            "Test_Port_Available",
            "Test_Port_SkipAvailable",
            "Test_Port_IsConnectionValid",

            "Test_Printer_GetPrinterInfo",
            "Test_Printer_GetPrinterLabelPositionAdjustmentInfo",
            "Test_Printer_SetPrinterLabelPositionAdjustmentInfo_NoAdjust",
            "Test_Printer_SetPrinterLabelPositionAdjustmentInfo_TearPositionPlus4mm",
            "Test_Printer_SetPrinterLabelPositionAdjustmentInfo_TearPositionMinus4mm",
            "Test_Printer_ClearPrinterBuffer",
            "Test_Pos_QueryPrintResult",
            "Test_Pos_KickOutDrawer",
            "Test_Pos_PrintSelfTestPage",

            "Test_Pos_ResetPrinter",
            "Test_Pos_SetPrintSpeed",
            "Test_Pos_SetPrintDensity",
            "Test_Pos_SetSingleByteMode",
            "Test_Pos_SetMultiByteMode",

            "Test_Label_EnableLabelMode",
            "Test_Label_DisableLabelMode",
            "Test_Label_CalibrateLabel",
            "Test_Label_FeedLabel",
            "Test_Label_PageBegin_PageEnd_PagePrint",
            "Test_Label_DrawText",
            "Test_Label_DrawTextInGBK",
            "Test_Label_DrawBarcode",
            "Test_Label_DrawQRCode",
            "Test_Label_DrawPDF417Code",
            "Test_Label_DrawLine",
            "Test_Label_DrawRect",
            "Test_Label_DrawBox",
            "Test_Label_DrawImageFromFile",
            "Test_Label_DrawImageFromData",
            "Test_Label_DrawImageFromPixels",

        };

        public void Test_Label_SampleTicket_55mmx30mm_1(UIntPtr h)
        {
            int nPageWidth = 48 * 8;
            int nPageHeight = 25 * 8;

            AutoReplyPrint.CP_Pos_SetMultiByteMode(h);
            AutoReplyPrint.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_GBK);

            AutoReplyPrint.CP_Label_PageBegin(h, 0, 0, nPageWidth, nPageHeight, 0);
            AutoReplyPrint.CP_Label_DrawBox(h, 0, 0, nPageWidth, nPageHeight, 1, 1);
            AutoReplyPrint.CP_Label_DrawTextInGBK(h, 10, 10, 24, 0, "型号：P58A+");
            AutoReplyPrint.CP_Label_DrawTextInGBK(h, 10, 40, 24, 0, "MFG ：0000");
            AutoReplyPrint.CP_Label_DrawBarcode(h, 10, 70, AutoReplyPrint.CP_Label_BarcodeType_CODE128, AutoReplyPrint.CP_Label_BarcodeTextPrintPosition_BelowBarcode, 60, 2, AutoReplyPrint.CP_Label_Rotation_0, "No.123456");
            AutoReplyPrint.CP_Label_DrawQRCode(h, 240, 10, 4, AutoReplyPrint.CP_QRCodeECC_L, 4, AutoReplyPrint.CP_Label_Rotation_0, "No.123456");
            AutoReplyPrint.CP_Label_PagePrint(h, 1);

            Test_Pos_QueryPrintResult(h);
        }

        public void Test_Label_SampleTicket_HeadImageTail_CompressionLevel0(UIntPtr h)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "Image File|*.png;*.bmp";
            if (openFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            String str = openFileDialog.FileName;

            AutoReplyPrint.CP_Label_BackPaperToPrintPosition(h);
            AutoReplyPrint.CP_Pos_PrintRasterImageFromFile(h, 384, 0, str, AutoReplyPrint.CP_ImageBinarizationMethod_ErrorDiffusion, AutoReplyPrint.CP_ImageCompressionMethod_None);
            AutoReplyPrint.CP_Label_FeedPaperToTearPosition(h);

            Test_Pos_QueryPrintResult(h);
        }

        public void Test_Label_SampleTicket_HeadImageTail_CompressionLevel1(UIntPtr h)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "Image File|*.png;*.bmp";
            if (openFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            String str = openFileDialog.FileName;

            AutoReplyPrint.CP_Label_BackPaperToPrintPosition(h);
            AutoReplyPrint.CP_Pos_PrintRasterImageFromFile(h, 384, 0, str, AutoReplyPrint.CP_ImageBinarizationMethod_ErrorDiffusion, AutoReplyPrint.CP_ImageCompressionMethod_Level1);
            AutoReplyPrint.CP_Label_FeedPaperToTearPosition(h);

            Test_Pos_QueryPrintResult(h);
        }

        public void Test_Label_SampleTicket_HeadImageTail_CompressionLevel2(UIntPtr h)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "Image File|*.png;*.bmp";
            if (openFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            String str = openFileDialog.FileName;

            AutoReplyPrint.CP_Label_BackPaperToPrintPosition(h);
            AutoReplyPrint.CP_Pos_PrintRasterImageFromFile(h, 384, 0, str, AutoReplyPrint.CP_ImageBinarizationMethod_ErrorDiffusion, AutoReplyPrint.CP_ImageCompressionMethod_Level2);
            AutoReplyPrint.CP_Label_FeedPaperToTearPosition(h);

            Test_Pos_QueryPrintResult(h);
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

        public void Test_Printer_GetPrinterInfo(UIntPtr h)
        {
            long printer_error_status = 0;
            long printer_info_status = 0;
            long printer_status_timestamp_ms = 0;
            uint printer_received_byte_count = 0;
            long printer_received_byte_count_timestamp_ms = 0;
            uint printer_printed_page_id = 0;
            long printer_printed_page_id_timestamp_ms = 0;
            AutoReplyPrint.CP_Printer_GetPrinterStatusInfo(h, ref printer_error_status, ref printer_info_status, ref printer_status_timestamp_ms);
            AutoReplyPrint.CP_Printer_GetPrinterReceivedInfo(h, ref printer_received_byte_count, ref printer_received_byte_count_timestamp_ms);
            AutoReplyPrint.CP_Printer_GetPrinterPrintedInfo(h, ref printer_printed_page_id, ref printer_printed_page_id_timestamp_ms);

            String s = "";
            s += NewDate(printer_status_timestamp_ms).ToString("F") + " Printer Error Status: " + String.Format("0x{0:X}", printer_error_status) + "\r\n";
            s += NewDate(printer_status_timestamp_ms).ToString("F") + " Printer Info Status: " + String.Format("0x{0:X}", printer_info_status) + "\r\n";
            s += NewDate(printer_received_byte_count_timestamp_ms).ToString("F") + " Printer Received Byte Count: " + String.Format("{0:D}", printer_received_byte_count) + "\r\n";
            s += NewDate(printer_printed_page_id_timestamp_ms).ToString("F") + " Printer Printed Page ID: " + String.Format("{0:D}", printer_printed_page_id) + "\r\n";
            MessageBox.Show(s);
        }

        public void Test_Printer_GetPrinterLabelPositionAdjustmentInfo(UIntPtr h)
        {
            double label_print_position_adjustment = 0;
            double label_tear_position_adjustment = 0;
            long timestamp_ms = 0;
            AutoReplyPrint.CP_Printer_GetPrinterLabelPositionAdjustmentInfo(h, ref label_print_position_adjustment, ref label_tear_position_adjustment, ref timestamp_ms);
            String s = "";
            s += NewDate(timestamp_ms).ToString("F") +
                "\r\nLabel Print Position Adjustment: " + label_print_position_adjustment.ToString() +
                "\r\nLabel Tear Position Adjustment: " + label_tear_position_adjustment.ToString();
            MessageBox.Show(s);
        }

        public void Test_Printer_SetPrinterLabelPositionAdjustmentInfo_NoAdjust(UIntPtr h)
        {
            AutoReplyPrint.CP_Printer_SetPrinterLabelPositionAdjustmentInfo(h, 0, 0);
            AutoReplyPrint.CP_Label_FeedLabel(h);
        }

        public void Test_Printer_SetPrinterLabelPositionAdjustmentInfo_TearPositionPlus4mm(UIntPtr h)
        {
            AutoReplyPrint.CP_Printer_SetPrinterLabelPositionAdjustmentInfo(h, 0, 4);
            AutoReplyPrint.CP_Label_FeedLabel(h);
        }

        public void Test_Printer_SetPrinterLabelPositionAdjustmentInfo_TearPositionMinus4mm(UIntPtr h)
        {
            AutoReplyPrint.CP_Printer_SetPrinterLabelPositionAdjustmentInfo(h, 0, -4);
            AutoReplyPrint.CP_Label_FeedLabel(h);
        }

        public void Test_Printer_ClearPrinterBuffer(UIntPtr h)
        {
            AutoReplyPrint.CP_Printer_ClearPrinterBuffer(h);
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

        public void Test_Pos_PrintSelfTestPage(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_PrintSelfTestPage(h);
        }

        public void Test_Pos_ResetPrinter(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_ResetPrinter(h);
            AutoReplyPrint.CP_Pos_PrintSelfTestPage(h);
        }

        public void Test_Pos_SetPrintSpeed(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_SetPrintSpeed(h, 20);
            AutoReplyPrint.CP_Pos_PrintSelfTestPage(h);
        }

        public void Test_Pos_SetPrintDensity(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_SetPrintDensity(h, 0);
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

        public void Test_Label_EnableLabelMode(UIntPtr h)
        {
            int result = AutoReplyPrint.CP_Label_EnableLabelMode(h);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Label_DisableLabelMode(UIntPtr h)
        {
            int result = AutoReplyPrint.CP_Label_DisableLabelMode(h);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Label_CalibrateLabel(UIntPtr h)
        {
            int result = AutoReplyPrint.CP_Label_CalibrateLabel(h);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Label_FeedLabel(UIntPtr h)
        {
            int result = AutoReplyPrint.CP_Label_FeedLabel(h);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Label_PageBegin_PageEnd_PagePrint(UIntPtr h)
        {
            AutoReplyPrint.CP_Label_PageBegin(h, 0, 0, 384, 400, 0);
            AutoReplyPrint.CP_Label_DrawBox(h, 0, 0, 384, 400, 1, 1);
            int result = AutoReplyPrint.CP_Label_PagePrint(h, 1);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Label_DrawText(UIntPtr h)
        {
            // 0x24 is $
            String str = "$$$$$";

            AutoReplyPrint.CP_Label_PageBegin(h, 0, 0, 384, 400, 0);
            AutoReplyPrint.CP_Label_DrawBox(h, 0, 0, 384, 400, 1, 1);
            AutoReplyPrint.CP_Label_DrawText(h, 10, 10, 24, 0, str);
            AutoReplyPrint.CP_Label_DrawText(h, 10, 40, 24,
                    AutoReplyPrint.CP_LABEL_TEXT_STYLE_UNDERLINE | AutoReplyPrint.CP_LABEL_TEXT_STYLE_BOLD,
                                 str);
            AutoReplyPrint.CP_Label_DrawText(h, 10, 70, 24,
                    AutoReplyPrint.CP_LABEL_TEXT_STYLE_WIDTH_ENLARGEMENT(2) | AutoReplyPrint.CP_LABEL_TEXT_STYLE_HEIGHT_ENLARGEMENT(2),
                                 str);
            AutoReplyPrint.CP_Label_DrawText(h, 30, 130, 24, AutoReplyPrint.CP_LABEL_TEXT_STYLE_ROTATION_90,
                                 str);
            int result = AutoReplyPrint.CP_Label_PagePrint(h, 1);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Label_DrawTextInGBK(UIntPtr h)
        {
            AutoReplyPrint.CP_Pos_SetMultiByteMode(h);
            AutoReplyPrint.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_GBK);
            AutoReplyPrint.CP_Label_PageBegin(h, 0, 0, 384, 400, 0);
            AutoReplyPrint.CP_Label_DrawBox(h, 0, 0, 384, 400, 1, 1);
            AutoReplyPrint.CP_Label_DrawTextInGBK(h, 10, 10, 24, 0, "1234567890");
            AutoReplyPrint.CP_Label_DrawTextInGBK(h, 10, 40, 24,
                    AutoReplyPrint.CP_LABEL_TEXT_STYLE_UNDERLINE | AutoReplyPrint.CP_LABEL_TEXT_STYLE_BOLD,
                                 "abcdefghijklmnopqrstuvwxyz");
            AutoReplyPrint.CP_Label_DrawTextInGBK(h, 10, 70, 24,
                    AutoReplyPrint.CP_LABEL_TEXT_STYLE_WIDTH_ENLARGEMENT(2) | AutoReplyPrint.CP_LABEL_TEXT_STYLE_HEIGHT_ENLARGEMENT(2),
                                 "你好，欢迎使用！");
            AutoReplyPrint.CP_Label_DrawTextInGBK(h, 30, 130, 24, AutoReplyPrint.CP_LABEL_TEXT_STYLE_ROTATION_90,
                                 "你號，歡迎使用！");
            int result = AutoReplyPrint.CP_Label_PagePrint(h, 1);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Label_DrawBarcode(UIntPtr h)
        {
            String str = "01234567890";

            AutoReplyPrint.CP_Label_PageBegin(h, 0, 0, 384, 400, 0);
            AutoReplyPrint.CP_Label_DrawBox(h, 0, 0, 384, 400, 1, 1);

            AutoReplyPrint.CP_Label_DrawBarcode(h, 10, 10, AutoReplyPrint.CP_Label_BarcodeType_UPCA, AutoReplyPrint.CP_Label_BarcodeTextPrintPosition_BelowBarcode, 60, 2, 0, str);

            int result = AutoReplyPrint.CP_Label_PagePrint(h, 1);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Label_DrawQRCode(UIntPtr h)
        {
            String str = "Hello 你好";

            AutoReplyPrint.CP_Label_PageBegin(h, 0, 0, 384, 400, 0);
            AutoReplyPrint.CP_Label_DrawBox(h, 0, 0, 384, 400, 1, 1);

            AutoReplyPrint.CP_Label_DrawQRCode(h, 10, 10, 0, AutoReplyPrint.CP_QRCodeECC_L, 8, 0, str);

            int result = AutoReplyPrint.CP_Label_PagePrint(h, 1);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Label_DrawPDF417Code(UIntPtr h)
        {
            String str = "Hello 你好";

            AutoReplyPrint.CP_Label_PageBegin(h, 0, 0, 384, 400, 0);
            AutoReplyPrint.CP_Label_DrawBox(h, 0, 0, 384, 400, 1, 1);

            AutoReplyPrint.CP_Label_DrawPDF417Code(h, 10, 10, 3, 3, 0, 3, 0, str);

            int result = AutoReplyPrint.CP_Label_PagePrint(h, 1);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Label_DrawLine(UIntPtr h)
        {
            AutoReplyPrint.CP_Label_PageBegin(h, 0, 0, 384, 400, 0);
            AutoReplyPrint.CP_Label_DrawBox(h, 0, 0, 384, 400, 1, 1);
            AutoReplyPrint.CP_Label_DrawLine(h, 20, 20, 100, 300, 1, 1);
            int result = AutoReplyPrint.CP_Label_PagePrint(h, 1);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Label_DrawRect(UIntPtr h)
        {
            AutoReplyPrint.CP_Label_PageBegin(h, 0, 0, 384, 400, 0);
            AutoReplyPrint.CP_Label_DrawBox(h, 0, 0, 384, 400, 1, 1);
            AutoReplyPrint.CP_Label_DrawRect(h, 20, 20, 200, 10, 1);
            int result = AutoReplyPrint.CP_Label_PagePrint(h, 1);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Label_DrawBox(UIntPtr h)
        {
            AutoReplyPrint.CP_Label_PageBegin(h, 0, 0, 384, 400, 0);
            AutoReplyPrint.CP_Label_DrawBox(h, 0, 0, 384, 400, 1, 1);
            AutoReplyPrint.CP_Label_DrawBox(h, 30, 30, 300, 200, 1, 1);
            int result = AutoReplyPrint.CP_Label_PagePrint(h, 1);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Label_DrawImageFromFile(UIntPtr h)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "Image File|*.png;*.bmp";
            if (openFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            String str = openFileDialog.FileName;

            AutoReplyPrint.CP_Label_PageBegin(h, 0, 0, 384, 400, 0);
            AutoReplyPrint.CP_Label_DrawBox(h, 0, 0, 384, 400, 1, 1);
            AutoReplyPrint.CP_Label_DrawImageFromFile(h, 0, 0, 384, 400, str, AutoReplyPrint.CP_ImageBinarizationMethod_ErrorDiffusion, AutoReplyPrint.CP_ImageCompressionMethod_None);
            int result = AutoReplyPrint.CP_Label_PagePrint(h, 1);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Label_DrawImageFromData(UIntPtr h)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "Image File|*.png;*.bmp";
            if (openFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            String str = openFileDialog.FileName;
            byte[] data = FileUtils.ReadFromFile(str);
            if (data == null)
                return;

            AutoReplyPrint.CP_Label_PageBegin(h, 0, 0, 384, 400, 0);
            AutoReplyPrint.CP_Label_DrawBox(h, 0, 0, 384, 400, 1, 1);
            AutoReplyPrint.CP_Label_DrawImageFromData(h, 0, 0, 384, 400, data, data.Length, AutoReplyPrint.CP_ImageBinarizationMethod_ErrorDiffusion, AutoReplyPrint.CP_ImageCompressionMethod_None);
            int result = AutoReplyPrint.CP_Label_PagePrint(h, 1);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Label_DrawImageFromPixels(UIntPtr h)
        {
            AutoReplyPrint.CP_Label_PageBegin(h, 0, 0, 384, 100, 0);
            AutoReplyPrint.CP_Label_DrawBox(h, 0, 0, 384, 100, 1, 1);
            AutoReplyPrint.CP_Label_DrawImageFromPixels(
                    h, 0, 0,
                    FileUtils.imagewo_24x24_pixels_data, FileUtils.imagewo_24x24_pixels_data.Length,
                    24, 24, 3,
                    AutoReplyPrint.CP_ImagePixelsFormat_MONO,
                    AutoReplyPrint.CP_ImageBinarizationMethod_ErrorDiffusion,
                    AutoReplyPrint.CP_ImageCompressionMethod_None);
            int result = AutoReplyPrint.CP_Label_PagePrint(h, 1);

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
