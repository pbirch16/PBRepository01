//See My PIA Examples
using System;
using System.Collections.Generic;
using System.IO;
//using System.Reflection;
using xl = Microsoft.Office.Interop.Excel;


namespace PbPropertyEditor
{
    class Excel
    {
        private xl.Application _xlApp;
        private xl.Workbook _wb;
        private xl.Worksheet _ws;
        SortedList<string, string> _slProperties;

        public Excel()
        {
            Init();
        }

        public Excel(SortedList<string, string> slProperties)
        {
            _slProperties = slProperties;
            Init();
        }

        private void Init()
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

        public void WsEnumAllPropsForASingleFile(string strFileName, SortedList<string, g_strucPVT> slProperties)
        {
            ////slProperties contains Key=PropertyCanonicalName; Value=PropertyValue, PropertyType

            //Display the File Name
            xl.Range Rng = _ws.Cells[1, 1];
            Rng.Value2 = "File Name: ";
            Rng.HorizontalAlignment = xl.XlHAlign.xlHAlignRight;

            Rng = _ws.Cells[1, 2];
            Rng.Value2 = strFileName;
            Rng.HorizontalAlignment = xl.XlHAlign.xlHAlignLeft;

            Rng = _ws.Cells[3, 1];
            _ws.Cells[3, 1].Value2 = "Property Canonical Name";
            _ws.Cells[3, 2].Value2 = "Property Value";

            int r = 4;

            foreach (KeyValuePair<string, g_strucPVT> kvp in slProperties)
            {
                _ws.Cells[++r, 1].Value2 = kvp.Key; //Property Canonical Name
                ConvertAndWriteValue(kvp.Value, _ws.Cells[r, 2]);   //Property Value
            }
            for (int i = 1; i < r + 1; i++)
            {
                _ws.Columns[i].Autofit();
            }
        }

        public void WsEnumSelectedPropsForAllFilesInFolder(SortedList<string, SortedList<string, g_strucPVT>> slFilesAndProperties)
        {
            bool firstTime = true;

            ////slStrucPropertyStrings contains <FileName>; <PropertyValue>, <PropertyType>

            ////slProps contains Key =<Filename>; Value = SL
            ////SL contains Key = <PropertyName>; Value = [<PropertyValue>, <PropertyType>]

            SortedList<string, g_strucPVT> slRequiredProperties = new SortedList<string, g_strucPVT>();
            List<string> lstFiles = new List<string>();

            int r = 4;
            int c = 0;
            foreach (KeyValuePair<string, SortedList<string, g_strucPVT>> kvpS in slFilesAndProperties)
            {
                string strFileName = kvpS.Key;
                SortedList<string, g_strucPVT> slProps = kvpS.Value;

                if (firstTime)
                {
                    string strFolder = Path.GetDirectoryName(strFileName);
                    _ws.Cells[1, 1].value2 = "Folder Name:  " + strFolder;
                    _ws.Cells[1, 1].HorizontalAlignment = xl.XlHAlign.xlHAlignLeft;

                    //Column Titles
                    c = 0;
                    _ws.Cells[3, 1].Value2 = "File Name";
                    _ws.Cells[3, 1].HorizontalAlignment = xl.XlHAlign.xlHAlignCenter;

                    for (int i = 0; i < slProps.Count; i++)
                    {
                        _ws.Cells[3, i + 2].Value2 = (CondensePropertyName(slProps.Keys[i])); //Property Name with '.System' removed
                        _ws.Cells[3, i + 2].HorizontalAlignment = xl.XlHAlign.xlHAlignCenter;
                    }
                    _ws.Columns[1].Autofit();

                    firstTime = false;
                }

                //Rows
                _ws.Cells[r, 1].Value2 = Path.GetFileName(strFileName);
                c = 2;
                foreach (KeyValuePair<string, g_strucPVT> kvpP in slProps)
                {
                    //The Property's Canonical Name in kvpP.Key is already in the Column Titles,
                    //so we are only interested in the strucPVA in kvpP.Value (<PropertyValue>, <PropertyType>)
                    ConvertAndWriteValue(kvpP.Value, _ws.Cells[r, c]);
                    _ws.Columns[c++].Autofit();
                }
                r++;
            }

            for (int i = 1; i < c + 1; i++)
            {
                _ws.Columns[i].Autofit();
            }
        }

        public void WsEnumSelPropsForFirstFileInAllFolders(g_strucRootFolder1 strucRootFolder)
        {
            string strRootFolder = strucRootFolder.strRootFolderName;

            //Get the Names of the Required Properties
            g_strucSubFolder1 strucSubFolders = strucRootFolder.slSubFolders.Values[0];
            SortedList<string, g_strucPVT> slRequiredProperties = strucSubFolders.slProperties;

            //Print Titles
            xl.Range rng = _ws.Cells[1, 1];
            rng.Value2 = "Root Folder:   ";
            rng.HorizontalAlignment = xl.XlHAlign.xlHAlignRight;

            rng = _ws.Cells[1, 2];
            rng.Value2 = strRootFolder;
            rng.HorizontalAlignment = xl.XlHAlign.xlHAlignLeft;

            //Column Titles
            int r = 4;
            int c = 0;

            rng = _ws.Cells[3, 1];
            rng.Value2 = "Sub Folder Name";
            rng.HorizontalAlignment = xl.XlHAlign.xlHAlignCenter;

            rng = _ws.Cells[3, 2];
            rng.Value2 = "First File Name";
            rng.HorizontalAlignment = xl.XlHAlign.xlHAlignCenter;

            _ws.Columns[1].Autofit();
            _ws.Columns[2].Autofit();

            for (int i = 0; i < slRequiredProperties.Count; i++)
            {
                rng = _ws.Cells[3, i + 3];
                rng.Value2 = CondensePropertyName(slRequiredProperties.Keys[i]);
                rng.HorizontalAlignment = xl.XlHAlign.xlHAlignCenter;
                _ws.Columns[i + 3].Autofit();
            }

            //Print Values            

            foreach (KeyValuePair<string, g_strucSubFolder1> kvp1 in strucRootFolder.slSubFolders)
            {
                g_strucSubFolder1 strucSF = kvp1.Value;

                string strFirstFileName = strucSF.strNameOfFirstFileInSubFolder;
                string strSubFolderName = strucSF.strSubFolderName;

                _ws.Cells[r, 1].Value2 = IsolateSubFolderName(strSubFolderName, strRootFolder);
                _ws.Cells[r, 2].Value2 = Path.GetFileName(strFirstFileName);

                c = 3;

                foreach (KeyValuePair<string, g_strucPVT> kvp2 in strucSF.slProperties)
                {
                    ConvertAndWriteValue(kvp2.Value, _ws.Cells[r, c]);
                    _ws.Columns[c++].autofit();
                }
                r++;
            }

            for (int i = 1; i < c + 1; i++)
            {
                _ws.Columns[i].Autofit();
            }
        }

        public void WsDisplayStatsForCompareDates(g_strucStats strucStats)
        {
            //Print Titles
            string[][] aaTitles =
            {
                new string[] {"Root Folder"},
                new string[] {"Total","Files"},
                new string[] {"Total", "Folders"},
                new string[] {"Missing", "Dates", "Created"},
                new string[] {"Missing", "Document", "Dates", "Created" },
                new string[] {"Duplicate", "Document", "Dates", "Created" },
                new string[] {"Equal", "Document", "Dates", "Created" },
                new string[] {"Unequal", "Document", "Dates", "Created" },
                new string[] {"FileName"},
                new string[] {"Duplicate", "Document", "Dates", "Created" }
            };

            xl.Range rng;

            for (int i = 0; i < aaTitles.Length; i++)   //Rows
            {
                for (int j = 0; j < aaTitles[i].Length; j++) //Columns in each row
                {
                    rng = _ws.Cells[j + 1, i + 1];
                    rng.Value2 = aaTitles[i][j];
                    rng.HorizontalAlignment = xl.XlHAlign.xlHAlignCenter;
                }
            }


            //Print Stats
            rng = _ws.Cells[6, 1];
            rng.Value2 = strucStats.strRootFolderName;

            rng = _ws.Cells[6, 2];
            rng.Value2 = strucStats.totalFiles;

            rng = _ws.Cells[6, 3];
            rng.Value2 = strucStats.totalFolders;

            rng = _ws.Cells[6, 4];
            rng.Value2 = strucStats.missingDatesCreated;

            rng = _ws.Cells[6, 5];
            rng.Value2 = strucStats.missingDocumentDatesCreated;

            rng = _ws.Cells[6, 6];
            rng.Value2 = strucStats.duplicateDocumentDatesCreated;

            int r = 6;
            foreach (KeyValuePair<string, string> kvp in strucStats.slDuplicateDocumentDatesCreated)
            {
                _ws.Cells[r, 9].Value2 = kvp.Key;
                _ws.Cells[r++, 10].Value2 = kvp.Value;
            }

            for (int i = 1; i <= aaTitles.Length + 1; i++)
            {
                _ws.Columns[i].Autofit();
            }

        }

        private void ConvertAndWriteValue(g_strucPVT sp, xl.Range rng)
        {
            string strValue = sp.strPropertyValue;
            string strType = sp.strPropertyType;

            switch (strType)
            {
                case "DateTime":
                    rng.Value2 = Convert.ToDateTime(strValue);
                    rng.NumberFormat = "dd/mm/yyyy hh:mm";
                    rng.HorizontalAlignment = xl.XlHAlign.xlHAlignLeft;
                    break;
                case "Enumerated":
                    rng.Value2 = strValue;
                    rng.NumberFormat = "@";
                    rng.HorizontalAlignment = xl.XlHAlign.xlHAlignLeft;
                    break;
                case "Number":
                    //Number may be eg 64KB; so treat it as text.
                    rng.Value2 = strValue;
                    rng.NumberFormat = "@"; //Text
                    rng.HorizontalAlignment = xl.XlHAlign.xlHAlignRight;
                    break;
                case "String":
                case "Boolean":
                    rng.Value2 = strValue;
                    rng.NumberFormat = "@"; //Text
                    rng.HorizontalAlignment = xl.XlHAlign.xlHAlignLeft;
                    break;
                default:
                    break;
            }
        }

        private string CondensePropertyName(string strName)
        {
            //Remove "System." from Name
            return strName.Substring(7);
        }

        private string IsolateSubFolderName(string strFullPath, string strRootFolder)
        {
            if (!strFullPath.Contains(strRootFolder))
            {
                return null;
            }

            return strFullPath.Substring(strRootFolder.Length + 1);
        }
    }
}
