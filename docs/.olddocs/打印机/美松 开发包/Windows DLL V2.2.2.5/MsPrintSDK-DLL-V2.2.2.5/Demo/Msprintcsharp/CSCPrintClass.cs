using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Msprintcsharp
{

    class CSCPrintClass
    {
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool OpenPrinter(string printer, out IntPtr handle, ref structPrinterDefaults pDefault);

        [DllImport("winspool.drv")]
        public static extern bool ClosePrinter(IntPtr handle);

        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool GetPrinter(IntPtr handle, Int32 level, IntPtr buffer, Int32 size, out Int32 sizeNeeded);

        [DllImport("winspool.drv", CharSet = CharSet.Auto)]
        static extern bool EnumJobs(IntPtr hPrinter, int FirstJob, int NoJobs, int Level, IntPtr pJob, int cbBuf, out int pcbNeeded, out int pcReturned);

        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEMTIME
        {
            public short wYear;
            public short wMonth;
            public short wDayOfWeek;
            public short wDay;
            public short wHour;
            public short wMinute;
            public short wSecond;
            public short wMilliseconds;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct JOB_INFO_1
        {
            public int JobId;
            public string pPrinterName;
            public string pMachineName;
            public string pUserName;
            public string pDocument;
            public string pDatatype;
            public string pStatus;
            public int Status;
            public int Priority;
            public int Position;
            public int TotalPages;
            public int PagesPrinted;
            public SYSTEMTIME Submitted;
        }
        

        public static string GetPrinterStatus(string PrinterName)
        {
            int intValue = GetPrinterStatusInt(PrinterName);
            string strRet = string.Empty;
            switch (intValue)
            {
                case 0:
                    strRet = "Ready";               //准备就绪
                    break;
                case 0x00000200:
                    strRet = "Busy";                //忙
                    break;
                case 0x00400000:
                    strRet = "Printer Door Open";   //被打开
                    break;
                case 0x00000002:
                    strRet = "Printer Error";       //错误
                    break;
                case 0x0008000:
                    strRet = "Initializing";        //初始化
                    break;
                case 0x00000100:
                    strRet = "I/O Active";      //正在输入/输出
                    break;
                case 0x00000020:
                    strRet = "Manual Feed";     //手工送纸
                    break;
                case 0x00040000:
                    strRet = "No Toner";        //无墨粉
                    break;
                case 0x00001000:
                    strRet = "Not Available";   //不可用
                    break;
                case 0x00000080:
                    strRet = "Off Line";        //脱机
                    break;
                case 0x00200000:
                    strRet = "Out of Memory";   //内存溢出
                    break;
                case 0x00000800:
                    strRet = "Output Bin Full"; //输出口已满
                    break;
                case 0x00080000:
                    strRet = "Page Punt";       //当前页无法打印
                    break;
                case 0x00000008:
                    strRet = "Paper Jam";       //塞纸
                    break;
                case 0x00000010:
                    strRet = "Paper Out";       //打印纸用完
                    break;
                case 0x00000040:
                    strRet = "Page Problem";    //纸张问题
                    break;
                case 0x00000001:
                    strRet = "Paused";          //暂停
                    break;
                case 0x00000004:
                    strRet = "Pending Deletion";    //正在删除
                    break;
                case 0x00000400:
                    strRet = "Printing";            //正在打印
                    break;
                case 0x00004000:
                    strRet = "Processing";          //正在处理
                    break;
                case 0x00020000:
                    strRet = "Toner Low";           //墨粉不足
                    break;
                case 0x00100000:
                    strRet = "User Intervention";   //需要用户干预
                    break;
                case 0x20000000:
                    strRet = "Waiting";         //等待
                    break;
                case 0x00010000:
                    strRet = "Warming Up";      //热机中
                    break;
                default:
                    strRet = "Unknown Status";  //未知状态
                    break;
            }
            return strRet;
        }

        public static int GetPrinterStatusInt(string PrinterName)
        {
            int intRet = -1;
            IntPtr hPrinter;


            structPrinterDefaults defaults = new structPrinterDefaults();


            if (OpenPrinter(PrinterName, out hPrinter, ref defaults))
            {
                int cbNeeded = 0;
                int pcbNeeded = 0;
                int pcReturned = 0;
                bool bolRet = GetPrinter(hPrinter, 2, IntPtr.Zero, 0, out cbNeeded);
                if (cbNeeded > 0)
                {
                    IntPtr pAddr = Marshal.AllocHGlobal((int)cbNeeded);
                    bolRet = GetPrinter(hPrinter, 2, pAddr, cbNeeded, out cbNeeded);
                    if (bolRet)
                    {
                        PRINTER_INFO_2 Info2 = new PRINTER_INFO_2();

                        Info2 = (PRINTER_INFO_2)Marshal.PtrToStructure(pAddr, typeof(PRINTER_INFO_2));

                        intRet = System.Convert.ToInt32(Info2.Status);

                        if (intRet == 0)
                        {

                            EnumJobs(hPrinter, 0, 127, 2, IntPtr.Zero, 0, out pcbNeeded, out pcReturned);

                            if (pcbNeeded > 0)
                                intRet = 0x00000400;


                            //// allocate unmanaged memory
                        //    IntPtr pJob = Marshal.AllocHGlobal(pcReturned);

                        //    // get structs  
                        //    EnumJobs(hPrinter, 0, 127, 1, pJob, 0, out pcbNeeded, out pcReturned);

                        //    // create array of managed job structs  
                        //    JOB_INFO_1[] jobArray = new JOB_INFO_1[pcReturned];

                        //    Console.WriteLine("---pcbNeeded={0}--pcReturned={1}--", pcbNeeded.ToString(), pcReturned.ToString());

                        //    // marshal struct to managed  
                        //    int pTemp = pJob.ToInt32(); //start pointer
                        //    // IntPtr current = pJob;
                        //    for (int i = 0; i < jobArray.Length; i++)
                        //    {
                        //        jobArray[i] = (JOB_INFO_1)Marshal.PtrToStructure(new IntPtr(pTemp), typeof(JOB_INFO_1));
                        //        //	 current=(IntPtr)((int)current+Marshal.SizeOf(typeof(JOB_INFO_1)));

                        //        Console.WriteLine(i + ": \n" + "User:" + jobArray[i].pUserName + "\n" + "PrinterName:" + jobArray[i].pPrinterName + "\n"
                        //        + "Document:" + jobArray[i].pDocument + "\n" + "Page:" + jobArray[i].TotalPages + "\n" + "MachineName:" + jobArray[i].pMachineName + "\n" + "Type:" + jobArray[i].pDatatype + "\n");
                        //    }
                        }
                    }
                    Marshal.FreeHGlobal(pAddr);
                }
                ClosePrinter(hPrinter);
            }

            return intRet;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct structPrinterDefaults
        {
            [MarshalAs(UnmanagedType.LPTStr)]
            public String pDatatype;
            public IntPtr pDevMode;
            [MarshalAs(UnmanagedType.I4)]
            public int DesiredAccess;
        };

        //状态枚举
        [FlagsAttribute]
        internal enum PrinterStatus
        {
            PRINTER_STATUS_BUSY = 0x00000200,
            PRINTER_STATUS_DOOR_OPEN = 0x00400000,
            PRINTER_STATUS_ERROR = 0x00000002,
            PRINTER_STATUS_INITIALIZING = 0x00008000,
            PRINTER_STATUS_IO_ACTIVE = 0x00000100,
            PRINTER_STATUS_MANUAL_FEED = 0x00000020,
            PRINTER_STATUS_NO_TONER = 0x00040000,
            PRINTER_STATUS_NOT_AVAILABLE = 0x00001000,
            PRINTER_STATUS_OFFLINE = 0x00000080,
            PRINTER_STATUS_OUT_OF_MEMORY = 0x00200000,
            PRINTER_STATUS_OUTPUT_BIN_FULL = 0x00000800,
            PRINTER_STATUS_PAGE_PUNT = 0x00080000,
            PRINTER_STATUS_PAPER_JAM = 0x00000008,
            PRINTER_STATUS_PAPER_OUT = 0x00000010,
            PRINTER_STATUS_PAPER_PROBLEM = 0x00000040,
            PRINTER_STATUS_PAUSED = 0x00000001,
            PRINTER_STATUS_PENDING_DELETION = 0x00000004,
            PRINTER_STATUS_PRINTING = 0x00000400,
            PRINTER_STATUS_PROCESSING = 0x00004000,
            PRINTER_STATUS_TONER_LOW = 0x00020000,
            PRINTER_STATUS_USER_INTERVENTION = 0x00100000,
            PRINTER_STATUS_WAITING = 0x20000000,
            PRINTER_STATUS_WARMING_UP = 0x00010000
        }

        public struct PRINTER_INFO_2
        {
            public string pServerName;
            public string pPrinterName;
            public string pShareName;
            public string pPortName;
            public string pDriverName;
            public string pComment;
            public string pLocation;
            public IntPtr pDevMode;
            public string pSepFile;
            public string pPrintProcessor;
            public string pDatatype;
            public string pParameters;
            public IntPtr pSecurityDescriptor;
            public UInt32 Attributes;
            public UInt32 Priority;
            public UInt32 DefaultPriority;
            public UInt32 StartTime;
            public UInt32 UntilTime;
            public UInt32 Status;
            public UInt32 cJobs;
            public UInt32 AveragePPM;
        }

        //public static void Main()
        //{
        //    Console.WriteLine(CSCPrintClass.GetPrinterStatus("EP802").ToString());
        //    Console.ReadLine();
        //}
    }

}
