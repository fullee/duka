using System;
using System.Collections.Generic;
using System.Text;
using autoreplyprint.cs;
using System.IO;
using System.Windows.Forms;

namespace samplepage_withoutautoreply
{
    class TestFunction
    {
        public static String[] testFunctionOrderedList = new String[] {

            "Test_Page_SampleTicket_58mm_1",
            "Test_Page_SampleTicket_80mm_1",

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
            "Test_Page_DrawRasterImageFromFile",
            "Test_Page_DrawRasterImageFromData",
            "Test_Page_DrawRasterImageFromPixels",

        };

        public void Test_Page_SampleTicket_58mm_1(UIntPtr h)
        {
            int paperWidth = 384;
            int paperHeight = 800;

            AutoReplyPrint.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, paperWidth, paperHeight);
            AutoReplyPrint.CP_Pos_SetMultiByteMode(h);
            AutoReplyPrint.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_UTF8);

            AutoReplyPrint.CP_Pos_SetTextScale(h, 1, 1);
            AutoReplyPrint.CP_Page_DrawTextInUTF8(h, AutoReplyPrint.CP_Page_DrawAlignment_HCenter, 10, "中国福利彩票");
            AutoReplyPrint.CP_Pos_SetTextScale(h, 0, 0);
            AutoReplyPrint.CP_Page_DrawTextInUTF8(h, 0, 60, "销售期2015033");
            AutoReplyPrint.CP_Page_DrawTextInUTF8(h, AutoReplyPrint.CP_Page_DrawAlignment_Right, 60, "兑奖期2015033");
            AutoReplyPrint.CP_Page_DrawTextInUTF8(h, 0, 90, "站号230902001");
            AutoReplyPrint.CP_Page_DrawTextInUTF8(h, AutoReplyPrint.CP_Page_DrawAlignment_Right, 90, "7639-A");
            AutoReplyPrint.CP_Page_DrawTextInUTF8(h, 0, 120, "注数5");
            AutoReplyPrint.CP_Page_DrawTextInUTF8(h, AutoReplyPrint.CP_Page_DrawAlignment_Right, 120, "金额10.00");

            AutoReplyPrint.CP_Pos_SetTextLineHeight(h, 60);
            AutoReplyPrint.CP_Pos_SetTextScale(h, 0, 1);
            AutoReplyPrint.CP_Pos_SetTextUnderline(h, 2);
            AutoReplyPrint.CP_Page_DrawTextInUTF8(h, 0, 160, " A: 02  07  10  17  20  21  25\r\n A: 02  07  10  17  20  21  25\r\n A: 02  07  10  17  20  21  25\r\n A: 02  07  10  17  20  21  25\r\n A: 02  07  10  17  20  21  25\r\n");
            AutoReplyPrint.CP_Pos_SetTextScale(h, 0, 0);
            AutoReplyPrint.CP_Pos_SetTextUnderline(h, 0);
            AutoReplyPrint.CP_Pos_SetTextLineHeight(h, 30);

            AutoReplyPrint.CP_Pos_SetBarcodeHeight(h, 60);
            AutoReplyPrint.CP_Pos_SetBarcodeUnitWidth(h, 3);
            AutoReplyPrint.CP_Pos_SetBarcodeReadableTextPosition(h, AutoReplyPrint.CP_Pos_BarcodeTextPrintPosition_BelowBarcode);
            AutoReplyPrint.CP_Page_DrawBarcode(h, 0, 460, AutoReplyPrint.CP_Pos_BarcodeType_CODE128, "1234567890");
            AutoReplyPrint.CP_Pos_SetBarcodeUnitWidth(h, 4);
            AutoReplyPrint.CP_Page_DrawQRCode(h, 284, 460, 0, AutoReplyPrint.CP_QRCodeECC_L, "1234567890");

            AutoReplyPrint.CP_Page_PrintPage(h);
            AutoReplyPrint.CP_Page_ExitPageMode(h);

            AutoReplyPrint.CP_Pos_FeedAndHalfCutPaper(h);
            AutoReplyPrint.CP_Pos_KickOutDrawer(h, 0, 100, 100);
            AutoReplyPrint.CP_Pos_KickOutDrawer(h, 1, 100, 100);
            AutoReplyPrint.CP_Pos_Beep(h, 1, 500);

            Test_Pos_QueryPrintResult(h);
        }

        public void Test_Page_SampleTicket_80mm_1(UIntPtr h)
        {
            AutoReplyPrint.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 576, 200);
            AutoReplyPrint.CP_Pos_SetMultiByteMode(h);
            AutoReplyPrint.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_GBK);

            AutoReplyPrint.CP_Pos_SetTextScale(h, 1, 1);
            AutoReplyPrint.CP_Page_DrawText(h, AutoReplyPrint.CP_Page_DrawAlignment_HCenter, 0, "Print Store");
            AutoReplyPrint.CP_Pos_SetTextScale(h, 7, 1);
            AutoReplyPrint.CP_Page_DrawText(h, AutoReplyPrint.CP_Page_DrawAlignment_HCenter, 48, "______");
            AutoReplyPrint.CP_Page_DrawBarcode(h, AutoReplyPrint.CP_Page_DrawAlignment_HCenter, 100, AutoReplyPrint.CP_Pos_BarcodeType_CODE128, "No.201804190001");

            AutoReplyPrint.CP_Page_SetPageArea(h, 0, 200, 576, 1400);
            AutoReplyPrint.CP_Page_DrawBox(h, 0, 0, 576, 1400, 1, 1);
            AutoReplyPrint.CP_Page_SetPageDrawDirection(h, AutoReplyPrint.CP_Page_DrawDirection_TopToBottom);

            int y = 0;
            AutoReplyPrint.CP_Pos_SetTextScale(h, 1, 1);
            AutoReplyPrint.CP_Page_DrawTextInGBK(h, AutoReplyPrint.CP_Page_DrawAlignment_HCenter, y, "Print物流（测试）托运单");

            y += 64;
            AutoReplyPrint.CP_Pos_SetTextScale(h, 0, 0);
            AutoReplyPrint.CP_Page_DrawTextInGBK(h, 0, y, "发站：厦门总部");
            AutoReplyPrint.CP_Page_DrawTextInGBK(h, 300, y, "到站：广州 0539-7825336");
            AutoReplyPrint.CP_Page_DrawTextInGBK(h, 600, y, "托运日期：2016-05-24");
            AutoReplyPrint.CP_Page_DrawTextInGBK(h, 900, y, "运单号：601052400032");

            y += 32;
            AutoReplyPrint.CP_Page_DrawRect(h, 0, y - 5, 1400, 2, 1);
            AutoReplyPrint.CP_Page_DrawTextInGBK(h, 0, y, "收货人");
            AutoReplyPrint.CP_Page_DrawTextInGBK(h, 300, y, "电话：15000353189");
            AutoReplyPrint.CP_Page_DrawTextInGBK(h, 600, y, "运费：提付10");

            y += 32;
            AutoReplyPrint.CP_Page_DrawRect(h, 0, y - 5, 1400, 2, 1);
            AutoReplyPrint.CP_Page_DrawTextInGBK(h, 0, y, "发货人");
            AutoReplyPrint.CP_Page_DrawTextInGBK(h, 300, y, "电话：15000353189");
            AutoReplyPrint.CP_Page_DrawTextInGBK(h, 600, y, "会员号");
            AutoReplyPrint.CP_Page_DrawTextInGBK(h, 900, y, "代收款：1000");

            y += 32;
            AutoReplyPrint.CP_Page_DrawRect(h, 0, y - 5, 1400, 2, 1);
            AutoReplyPrint.CP_Page_DrawTextInGBK(h, 0, y, "货物名称");
            AutoReplyPrint.CP_Page_DrawTextInGBK(h, 150, y, "件数");
            AutoReplyPrint.CP_Page_DrawTextInGBK(h, 300, y, "重量");
            AutoReplyPrint.CP_Page_DrawTextInGBK(h, 450, y, "体积");
            AutoReplyPrint.CP_Page_DrawTextInGBK(h, 600, y, "保价额");
            AutoReplyPrint.CP_Page_DrawTextInGBK(h, 750, y, "保价费");
            AutoReplyPrint.CP_Page_DrawTextInGBK(h, 900, y, "交货方式");
            AutoReplyPrint.CP_Page_DrawTextInGBK(h, 1050, y, "自提");

            y += 32;
            AutoReplyPrint.CP_Page_DrawRect(h, 0, y - 5, 1400, 2, 1);
            AutoReplyPrint.CP_Page_DrawTextInGBK(h, 0, y, "配件");
            AutoReplyPrint.CP_Page_DrawTextInGBK(h, 900, y, "送货费");

            y += 32;
            AutoReplyPrint.CP_Page_DrawRect(h, 0, y - 5, 1400, 2, 1);
            AutoReplyPrint.CP_Page_DrawTextInGBK(h, 0, y, "托运地址");
            AutoReplyPrint.CP_Page_DrawTextInGBK(h, 150, y, "运河路高架桥南张营中心街东首");
            AutoReplyPrint.CP_Page_DrawTextInGBK(h, 900, y, "预付运费");

            y += 32;
            AutoReplyPrint.CP_Page_DrawRect(h, 0, y - 5, 1400, 2, 1);
            AutoReplyPrint.CP_Page_DrawTextInGBK(h, 0, y, "到站地址");
            AutoReplyPrint.CP_Page_DrawTextInGBK(h, 150, y, "金兰物流E7区11号");
            AutoReplyPrint.CP_Page_DrawTextInGBK(h, 900, y, "提付合计");

            y += 32;
            AutoReplyPrint.CP_Page_DrawRect(h, 0, y - 5, 1400, 2, 1);
            AutoReplyPrint.CP_Page_DrawTextInGBK(h, 0, y, "备注");
            AutoReplyPrint.CP_Page_DrawTextInGBK(h, 900, y, "返款");

            y += 32;
            AutoReplyPrint.CP_Page_DrawRect(h, 0, y - 5, 1400, 2, 1);
            AutoReplyPrint.CP_Page_DrawTextInGBK(h, 0, y, "声明：1、不得虚假报货名 2、不得虚假报货名 3、不得虚假报货名 4、不得虚假报货名 5、不得虚假报货名 6、不得虚假报货名 7、不得虚假报货名 8、不得虚假报货名 1、不得虚假报货名 2、不得虚假报货名 3、不得虚假报货名 4、不得虚假报货名 5、不得虚假报货名 6、不得虚假报货名 7、不得虚假报货名 8、不得虚假报货名 1、不得虚假报货名 2、不得虚假报货名 3、不得虚假报货名 4、不得虚假报货名 5、不得虚假报货名 6、不得虚假报货名 7、不得虚假报货名 8、不得虚假报货名 1、不得虚假报货名 2、不得虚假报货名 3、不得虚假报货名 4、不得虚假报货名 5、不得虚假报货名 6、不得虚假报货名 7、不得虚假报货名 8、不得虚假报货名");

            y = 530;
            AutoReplyPrint.CP_Page_DrawRect(h, 0, y - 5, 1400, 2, 1);
            AutoReplyPrint.CP_Page_DrawTextInGBK(h, 0, y, "服务查询：2379911");
            AutoReplyPrint.CP_Page_DrawTextInGBK(h, 300, y, "发货人签名");
            AutoReplyPrint.CP_Page_DrawTextInGBK(h, 600, y, "第一联");
            AutoReplyPrint.CP_Page_DrawTextInGBK(h, 900, y, "制单");

            AutoReplyPrint.CP_Page_PrintPage(h);
            AutoReplyPrint.CP_Page_ExitPageMode(h);

            AutoReplyPrint.CP_Pos_FeedAndHalfCutPaper(h);
            AutoReplyPrint.CP_Pos_KickOutDrawer(h, 0, 100, 100);
            AutoReplyPrint.CP_Pos_KickOutDrawer(h, 1, 100, 100);
            AutoReplyPrint.CP_Pos_Beep(h, 1, 500);

            Test_Pos_QueryPrintResult(h);
        }

        public void Test_Pos_QueryPrintResult(UIntPtr h)
        {
            int result = AutoReplyPrint.CP_Pos_QueryPrintResult(h, 30000);
            if (result != 0)
                MessageBox.Show("Print Success");
            else
                MessageBox.Show("Print Failed");
        }

        public void Test_Page_SetPageDrawDirection(UIntPtr h)
        {
            AutoReplyPrint.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
            AutoReplyPrint.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
            AutoReplyPrint.CP_Page_SetPageDrawDirection(h, AutoReplyPrint.CP_Page_DrawDirection_LeftToRight);
            AutoReplyPrint.CP_Page_DrawText(h, 0, 0, "LeftToRight");
            AutoReplyPrint.CP_Page_SetPageDrawDirection(h, AutoReplyPrint.CP_Page_DrawDirection_RightToLeft);
            AutoReplyPrint.CP_Page_DrawText(h, 0, 0, "RightToLeft");
            AutoReplyPrint.CP_Page_SetPageDrawDirection(h, AutoReplyPrint.CP_Page_DrawDirection_TopToBottom);
            AutoReplyPrint.CP_Page_DrawText(h, 0, 0, "TopToBottom");
            AutoReplyPrint.CP_Page_SetPageDrawDirection(h, AutoReplyPrint.CP_Page_DrawDirection_BottomToTop);
            AutoReplyPrint.CP_Page_DrawText(h, 0, 0, "BottomToTop");
            AutoReplyPrint.CP_Page_PrintPage(h);
            int result = AutoReplyPrint.CP_Page_ExitPageMode(h);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Page_DrawRect(UIntPtr h)
        {
            // 10,10
            AutoReplyPrint.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
            AutoReplyPrint.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
            AutoReplyPrint.CP_Page_DrawRect(h, 10, 10, 100, 100, 1);
            AutoReplyPrint.CP_Page_DrawRect(h, 20, 20, 80, 80, 0);
            AutoReplyPrint.CP_Page_PrintPage(h);
            AutoReplyPrint.CP_Page_ExitPageMode(h);

            // left,top
            AutoReplyPrint.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
            AutoReplyPrint.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
            AutoReplyPrint.CP_Page_DrawRect(h, -1, -1, 100, 20, 1);
            AutoReplyPrint.CP_Page_PrintPage(h);
            AutoReplyPrint.CP_Page_ExitPageMode(h);

            // left,vcenter
            AutoReplyPrint.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
            AutoReplyPrint.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
            AutoReplyPrint.CP_Page_DrawRect(h, -1, -2, 100, 20, 1);
            AutoReplyPrint.CP_Page_PrintPage(h);
            AutoReplyPrint.CP_Page_ExitPageMode(h);

            // left,bottom
            AutoReplyPrint.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
            AutoReplyPrint.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
            AutoReplyPrint.CP_Page_DrawRect(h, -1, -3, 100, 20, 1);
            AutoReplyPrint.CP_Page_PrintPage(h);
            AutoReplyPrint.CP_Page_ExitPageMode(h);

            // hcenter,top
            AutoReplyPrint.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
            AutoReplyPrint.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
            AutoReplyPrint.CP_Page_DrawRect(h, -2, -1, 100, 20, 1);
            AutoReplyPrint.CP_Page_PrintPage(h);
            AutoReplyPrint.CP_Page_ExitPageMode(h);

            // hcenter,vcenter
            AutoReplyPrint.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
            AutoReplyPrint.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
            AutoReplyPrint.CP_Page_DrawRect(h, -2, -2, 100, 20, 1);
            AutoReplyPrint.CP_Page_PrintPage(h);
            AutoReplyPrint.CP_Page_ExitPageMode(h);

            // hcenter,bottom
            AutoReplyPrint.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
            AutoReplyPrint.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
            AutoReplyPrint.CP_Page_DrawRect(h, -2, -3, 100, 20, 1);
            AutoReplyPrint.CP_Page_PrintPage(h);
            AutoReplyPrint.CP_Page_ExitPageMode(h);

            // right,top
            AutoReplyPrint.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
            AutoReplyPrint.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
            AutoReplyPrint.CP_Page_DrawRect(h, -3, -1, 100, 20, 1);
            AutoReplyPrint.CP_Page_PrintPage(h);
            AutoReplyPrint.CP_Page_ExitPageMode(h);

            // right,vcenter
            AutoReplyPrint.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
            AutoReplyPrint.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
            AutoReplyPrint.CP_Page_DrawRect(h, -3, -2, 100, 20, 1);
            AutoReplyPrint.CP_Page_PrintPage(h);
            AutoReplyPrint.CP_Page_ExitPageMode(h);

            // right,bottom
            AutoReplyPrint.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
            AutoReplyPrint.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
            AutoReplyPrint.CP_Page_DrawRect(h, -3, -3, 100, 20, 1);
            AutoReplyPrint.CP_Page_PrintPage(h);
            AutoReplyPrint.CP_Page_ExitPageMode(h);
        }

        public void Test_Page_DrawText(UIntPtr h)
        {
            AutoReplyPrint.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
            AutoReplyPrint.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
            AutoReplyPrint.CP_Page_DrawText(h, 0, 0, "12345678901234567890");
            AutoReplyPrint.CP_Page_PrintPage(h);
            int result = AutoReplyPrint.CP_Page_ExitPageMode(h);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Page_DrawTextInUTF8(UIntPtr h)
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

            AutoReplyPrint.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
            AutoReplyPrint.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
            AutoReplyPrint.CP_Page_DrawTextInUTF8(h, 0, 0, str);
            AutoReplyPrint.CP_Page_PrintPage(h);
            int result = AutoReplyPrint.CP_Page_ExitPageMode(h);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Page_DrawTextInGBK(UIntPtr h)
        {
            String str = "1234567890\r\nabcdefghijklmnopqrstuvwxyz\r\n你好，欢迎使用！\r\n你號，歡迎使用！\r\n";

            AutoReplyPrint.CP_Pos_SetMultiByteMode(h);
            AutoReplyPrint.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_GBK);

            AutoReplyPrint.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
            AutoReplyPrint.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
            AutoReplyPrint.CP_Page_DrawTextInGBK(h, 0, 0, str);
            AutoReplyPrint.CP_Page_PrintPage(h);
            int result = AutoReplyPrint.CP_Page_ExitPageMode(h);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Page_DrawTextInBIG5(UIntPtr h)
        {
            String str = "1234567890\r\nabcdefghijklmnopqrstuvwxyz\r\n你號，歡迎使用！\r\n";

            AutoReplyPrint.CP_Pos_SetMultiByteMode(h);
            AutoReplyPrint.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_BIG5);

            AutoReplyPrint.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
            AutoReplyPrint.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
            AutoReplyPrint.CP_Page_DrawTextInBIG5(h, 0, 0, str);
            AutoReplyPrint.CP_Page_PrintPage(h);
            int result = AutoReplyPrint.CP_Page_ExitPageMode(h);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Page_DrawTextInShiftJIS(UIntPtr h)
        {
            String str =
                "1234567890\r\n" +
                "abcdefghijklmnopqrstuvwxyz\r\n" +
                "こんにちは\r\n";

            AutoReplyPrint.CP_Pos_SetMultiByteMode(h);
            AutoReplyPrint.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_ShiftJIS);

            AutoReplyPrint.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
            AutoReplyPrint.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
            AutoReplyPrint.CP_Page_DrawTextInShiftJIS(h, 0, 0, str);
            AutoReplyPrint.CP_Page_PrintPage(h);
            int result = AutoReplyPrint.CP_Page_ExitPageMode(h);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Page_DrawTextInEUCKR(UIntPtr h)
        {
            String str =
                "1234567890\r\n" +
                "abcdefghijklmnopqrstuvwxyz\r\n" +
                "왕관을 쓰려는자\r\n" +
                "그 무게를 견뎌라\r\n";

            AutoReplyPrint.CP_Pos_SetMultiByteMode(h);
            AutoReplyPrint.CP_Pos_SetMultiByteEncoding(h, AutoReplyPrint.CP_MultiByteEncoding_EUCKR);

            AutoReplyPrint.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
            AutoReplyPrint.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
            AutoReplyPrint.CP_Page_DrawTextInEUCKR(h, 0, 0, str);
            AutoReplyPrint.CP_Page_PrintPage(h);
            int result = AutoReplyPrint.CP_Page_ExitPageMode(h);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Page_DrawBarcode(UIntPtr h)
        {
            AutoReplyPrint.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 1000);
            AutoReplyPrint.CP_Pos_SetBarcodeUnitWidth(h, 2);
            AutoReplyPrint.CP_Pos_SetBarcodeHeight(h, 60);
            AutoReplyPrint.CP_Pos_SetBarcodeReadableTextFontType(h, 0);
            AutoReplyPrint.CP_Pos_SetBarcodeReadableTextPosition(h, AutoReplyPrint.CP_Pos_BarcodeTextPrintPosition_BelowBarcode);
            AutoReplyPrint.CP_Page_DrawBarcode(h, 0, 0, AutoReplyPrint.CP_Pos_BarcodeType_UPCA, "01234567890");
            AutoReplyPrint.CP_Page_DrawBarcode(h, 0, 100, AutoReplyPrint.CP_Pos_BarcodeType_UPCE, "123456");
            AutoReplyPrint.CP_Page_DrawBarcode(h, 0, 200, AutoReplyPrint.CP_Pos_BarcodeType_EAN13, "123456789012");
            AutoReplyPrint.CP_Page_DrawBarcode(h, 0, 300, AutoReplyPrint.CP_Pos_BarcodeType_EAN8, "1234567");
            AutoReplyPrint.CP_Page_DrawBarcode(h, 0, 400, AutoReplyPrint.CP_Pos_BarcodeType_CODE39, "123456");
            AutoReplyPrint.CP_Page_DrawBarcode(h, 0, 500, AutoReplyPrint.CP_Pos_BarcodeType_ITF, "123456");
            AutoReplyPrint.CP_Page_DrawBarcode(h, 0, 600, AutoReplyPrint.CP_Pos_BarcodeType_CODEBAR, "A123456A");
            AutoReplyPrint.CP_Page_DrawBarcode(h, 0, 700, AutoReplyPrint.CP_Pos_BarcodeType_CODE93, "123456");
            AutoReplyPrint.CP_Page_DrawBarcode(h, 0, 800, AutoReplyPrint.CP_Pos_BarcodeType_CODE128, "No.123456");
            AutoReplyPrint.CP_Page_PrintPage(h);
            AutoReplyPrint.CP_Page_ExitPageMode(h);
        }

        public void Test_Page_DrawBarcode_CODE128(UIntPtr h)
        {
            String str = "No.123456";

            AutoReplyPrint.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
            AutoReplyPrint.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
            AutoReplyPrint.CP_Pos_SetBarcodeUnitWidth(h, 2);
            AutoReplyPrint.CP_Pos_SetBarcodeHeight(h, 60);
            AutoReplyPrint.CP_Pos_SetBarcodeReadableTextFontType(h, 0);
            AutoReplyPrint.CP_Pos_SetBarcodeReadableTextPosition(h, AutoReplyPrint.CP_Pos_BarcodeTextPrintPosition_BelowBarcode);
            AutoReplyPrint.CP_Page_DrawBarcode(h, 10, 100, AutoReplyPrint.CP_Pos_BarcodeType_CODE128, str);
            AutoReplyPrint.CP_Page_DrawBarcode(h, 10, 200, AutoReplyPrint.CP_Pos_BarcodeType_CODE128, str);
            AutoReplyPrint.CP_Page_DrawBarcode(h, 10, 300, AutoReplyPrint.CP_Pos_BarcodeType_CODE128, str);
            AutoReplyPrint.CP_Page_PrintPage(h);
            AutoReplyPrint.CP_Page_ExitPageMode(h);

            AutoReplyPrint.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
            AutoReplyPrint.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
            AutoReplyPrint.CP_Pos_SetBarcodeUnitWidth(h, 2);
            AutoReplyPrint.CP_Pos_SetBarcodeHeight(h, 60);
            AutoReplyPrint.CP_Pos_SetBarcodeReadableTextFontType(h, 0);
            AutoReplyPrint.CP_Pos_SetBarcodeReadableTextPosition(h, AutoReplyPrint.CP_Pos_BarcodeTextPrintPosition_None);
            AutoReplyPrint.CP_Page_DrawBarcode(h, -1, -1, AutoReplyPrint.CP_Pos_BarcodeType_CODE128, str);
            AutoReplyPrint.CP_Page_DrawBarcode(h, -2, -2, AutoReplyPrint.CP_Pos_BarcodeType_CODE128, str);
            AutoReplyPrint.CP_Page_DrawBarcode(h, -3, -3, AutoReplyPrint.CP_Pos_BarcodeType_CODE128, str);
            AutoReplyPrint.CP_Page_PrintPage(h);
            AutoReplyPrint.CP_Page_ExitPageMode(h);

            AutoReplyPrint.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
            AutoReplyPrint.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
            AutoReplyPrint.CP_Pos_SetBarcodeUnitWidth(h, 2);
            AutoReplyPrint.CP_Pos_SetBarcodeHeight(h, 60);
            AutoReplyPrint.CP_Pos_SetBarcodeReadableTextFontType(h, 0);
            AutoReplyPrint.CP_Pos_SetBarcodeReadableTextPosition(h, AutoReplyPrint.CP_Pos_BarcodeTextPrintPosition_AboveAndBelowBarcode);
            AutoReplyPrint.CP_Page_DrawBarcode(h, -1, -1, AutoReplyPrint.CP_Pos_BarcodeType_CODE128, str);
            AutoReplyPrint.CP_Page_DrawBarcode(h, -2, -2, AutoReplyPrint.CP_Pos_BarcodeType_CODE128, str);
            AutoReplyPrint.CP_Page_DrawBarcode(h, -3, -3, AutoReplyPrint.CP_Pos_BarcodeType_CODE128, str);
            AutoReplyPrint.CP_Page_PrintPage(h);
            AutoReplyPrint.CP_Page_ExitPageMode(h);

            AutoReplyPrint.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
            AutoReplyPrint.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
            AutoReplyPrint.CP_Pos_SetBarcodeUnitWidth(h, 2);
            AutoReplyPrint.CP_Pos_SetBarcodeHeight(h, 60);
            AutoReplyPrint.CP_Pos_SetBarcodeReadableTextFontType(h, 0);
            AutoReplyPrint.CP_Pos_SetBarcodeReadableTextPosition(h, AutoReplyPrint.CP_Pos_BarcodeTextPrintPosition_AboveBarcode);
            AutoReplyPrint.CP_Page_DrawBarcode(h, -1, -1, AutoReplyPrint.CP_Pos_BarcodeType_CODE128, str);
            AutoReplyPrint.CP_Page_DrawBarcode(h, -2, -2, AutoReplyPrint.CP_Pos_BarcodeType_CODE128, str);
            AutoReplyPrint.CP_Page_DrawBarcode(h, -3, -3, AutoReplyPrint.CP_Pos_BarcodeType_CODE128, str);
            AutoReplyPrint.CP_Page_PrintPage(h);
            AutoReplyPrint.CP_Page_ExitPageMode(h);

            AutoReplyPrint.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
            AutoReplyPrint.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
            AutoReplyPrint.CP_Pos_SetBarcodeUnitWidth(h, 2);
            AutoReplyPrint.CP_Pos_SetBarcodeHeight(h, 60);
            AutoReplyPrint.CP_Pos_SetBarcodeReadableTextFontType(h, 0);
            AutoReplyPrint.CP_Pos_SetBarcodeReadableTextPosition(h, AutoReplyPrint.CP_Pos_BarcodeTextPrintPosition_BelowBarcode);
            AutoReplyPrint.CP_Page_DrawBarcode(h, -1, -1, AutoReplyPrint.CP_Pos_BarcodeType_CODE128, str);
            AutoReplyPrint.CP_Page_DrawBarcode(h, -2, -2, AutoReplyPrint.CP_Pos_BarcodeType_CODE128, str);
            AutoReplyPrint.CP_Page_DrawBarcode(h, -3, -3, AutoReplyPrint.CP_Pos_BarcodeType_CODE128, str);
            AutoReplyPrint.CP_Page_PrintPage(h);
            int result = AutoReplyPrint.CP_Page_ExitPageMode(h);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        public void Test_Page_DrawQRCode(UIntPtr h)
        {
            String str = "Hello";

            AutoReplyPrint.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
            AutoReplyPrint.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
            AutoReplyPrint.CP_Pos_SetBarcodeUnitWidth(h, 4);
            AutoReplyPrint.CP_Page_DrawQRCode(h, -1, -1, 0, AutoReplyPrint.CP_QRCodeECC_L, str);
            AutoReplyPrint.CP_Page_DrawQRCode(h, -2, -2, 0, AutoReplyPrint.CP_QRCodeECC_L, str);
            AutoReplyPrint.CP_Page_DrawQRCode(h, -3, -3, 0, AutoReplyPrint.CP_QRCodeECC_L, str);
            AutoReplyPrint.CP_Page_PrintPage(h);
            AutoReplyPrint.CP_Page_ExitPageMode(h);

            AutoReplyPrint.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 1000);
            AutoReplyPrint.CP_Page_DrawBox(h, 0, 0, 384, 1000, 2, 1);
            AutoReplyPrint.CP_Pos_SetBarcodeUnitWidth(h, 4);
            AutoReplyPrint.CP_Page_DrawQRCode(h, 10, 10, 10, AutoReplyPrint.CP_QRCodeECC_L, str);
            AutoReplyPrint.CP_Page_DrawQRCode(h, 10, 300, 10, AutoReplyPrint.CP_QRCodeECC_L, str);
            AutoReplyPrint.CP_Page_DrawQRCode(h, 10, 600, 10, AutoReplyPrint.CP_QRCodeECC_L, str);
            AutoReplyPrint.CP_Page_PrintPage(h);
            AutoReplyPrint.CP_Page_ExitPageMode(h);
        }

        public void Test_Page_DrawRasterImageFromFile(UIntPtr h)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "Image File|*.png;*.bmp";
            if (openFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            String str = openFileDialog.FileName;

            AutoReplyPrint.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
            AutoReplyPrint.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
            AutoReplyPrint.CP_Page_DrawRasterImageFromFile(h, 0, 0, 384, 600, str, AutoReplyPrint.CP_ImageBinarizationMethod_ErrorDiffusion);
            AutoReplyPrint.CP_Page_PrintPage(h);
            AutoReplyPrint.CP_Page_ExitPageMode(h);

            Test_Pos_QueryPrintResult(h);
        }

        public void Test_Page_DrawRasterImageFromData(UIntPtr h)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "Image File|*.png;*.bmp";
            if (openFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            String str = openFileDialog.FileName;
            byte[] data = FileUtils.ReadFromFile(str);
            if (data == null)
                return;

            AutoReplyPrint.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 600);
            AutoReplyPrint.CP_Page_DrawBox(h, 0, 0, 384, 600, 2, 1);
            AutoReplyPrint.CP_Page_DrawRasterImageFromData(h, 0, 0, 384, 600, data, data.Length, AutoReplyPrint.CP_ImageBinarizationMethod_ErrorDiffusion);
            AutoReplyPrint.CP_Page_PrintPage(h);
            AutoReplyPrint.CP_Page_ExitPageMode(h);

            Test_Pos_QueryPrintResult(h);
        }

        public void Test_Page_DrawRasterImageFromPixels(UIntPtr h)
        {
            AutoReplyPrint.CP_Page_SelectPageModeEx(h, 200, 200, 0, 0, 384, 1000);
            AutoReplyPrint.CP_Page_DrawBox(h, 0, 0, 384, 1000, 2, 1);
            AutoReplyPrint.CP_Page_DrawRasterImageFromPixels(
                    h, 0, 0,
                    FileUtils.imagewo_24x24_pixels_data, FileUtils.imagewo_24x24_pixels_data.Length,
                    24, 24, 3,
                    AutoReplyPrint.CP_ImagePixelsFormat_MONO,
                    AutoReplyPrint.CP_ImageBinarizationMethod_ErrorDiffusion);
            AutoReplyPrint.CP_Page_PrintPage(h);
            AutoReplyPrint.CP_Page_ExitPageMode(h);

            Test_Pos_QueryPrintResult(h);
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
