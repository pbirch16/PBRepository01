using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xl = Microsoft.Office.Interop.Excel;

namespace TestExcelVsto
{
    class Program
    {
        static xl.Application _xlApp;
        static xl.Workbook _wb;
        static xl.Worksheet _ws;

        static void Main(string[] args)
        {
            //Init();
            //Test01();
            //Test02();
            TestFileCopy();
            Console.ReadKey();
        }

        static void Init()
        {
            _xlApp = new xl.Application();
            if (_xlApp == null)
            {
                Console.WriteLine("EXCEL could not be started. Check that your office installation and project references are correct.");
                return;
            }
            _xlApp.Visible = true;
            _xlApp.WindowState = xl.XlWindowState.xlMaximized;

            _wb = _xlApp.Workbooks.Add(xl.XlWBATemplate.xlWBATWorksheet);
            _ws = _wb.Worksheets[1];

        }


        static void Test01()
        {
            decimal d = Convert.ToDecimal("123456.123");
            _ws.Cells[1, 1].value = d;
            _ws.Cells[1, 2].value2 = d;
            _ws.Cells[1, 1].NumberFormat = "#,##0.0000";

            string strDT = "17/11/1940 15:37";
            DateTime dt = Convert.ToDateTime(strDT);
            _ws.Cells[2, 1].value = dt;
            _ws.Cells[2, 1].NumberFormat = "dd/mm/yyyy hh:mm";

            _ws.Cells[2, 2].value2 = dt;
            _ws.Cells[2, 2].NumberFormat = "dd/mm/yyyy hh:mm";
        }

        static void Test02()
        {
            string strDate = "31/12/2016 09:36:18";
            DateTime dt = Convert.ToDateTime(strDate);
            string strDate2 = dt.ToString("yyyy/MM/dd_HH:mm:ss");
        }

        static void TestFileCopy()
        {
            string strSourceDir = @"E:\Goldwave2\Podcasts\A Point of View 2017";
            string strTargetDir = @"E:\Goldwave3\Podcasts\Point of View 3";

            if (!Directory.Exists(strTargetDir))
            {
                DirectoryInfo di = Directory.CreateDirectory(strTargetDir);
            }

            string[] astrFiles = Directory.GetFiles(strSourceDir, "*.mp3");

            foreach (string f in astrFiles)
            {
                string strSourceFullPath = f;
                string strSourceFileName = Path.GetFileName(f);

                string strTargetFileName = "ZZ" + strSourceFileName;
                string strTargetFullPath = Path.Combine(strTargetDir, strTargetFileName);

                try
                {
                    File.Copy(strSourceFullPath, strTargetFullPath, true);
                }
                catch (DirectoryNotFoundException dirNotFound)
                {
                    Console.WriteLine(dirNotFound.Message);
                }
            }
        }
    }
}
