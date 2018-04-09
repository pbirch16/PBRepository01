//http://www.bbc.co.uk/programmes/b0129c7j	
//https://docs.microsoft.com/en-us/dotnet/csharp/codedoc
//Documenting your code with XML comments

using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ListFiles;
using System.Text;

namespace PbPropertyEditor
{
    /// <include file='Documentation.xml' >

    public partial class frmPE : Form
    {
        #region MEMBER VARIABLES
        private string _strPropertyName;
        private string _strPropertyValue;

        private string _strRootFolderName;
        private string _strFileName;
        //private bool _firstTime = true;

        private string _strTargetFolder = @"E:\Goldwave3\Podcasts\";
        private const string _strTypicalFile = @"E:\Goldwave2\Podcasts\A Point of View\PoV_ Nobel 17 Oct 08.mp3";
        private const string _strInitialFolder = @"E:\Goldwave2\Podcasts\A Point of View";

        const string _cstrDateCreated = "System.DateCreated";
        const string _cstrDocumentDateCreated = "System.Document.DateCreated";

        private const string _strAppName = "pbPropertyEditor2";
        private const string _strSubKey1 = "clb1Settings";  //Settings for CheckedListBox1
        private const string _strSubKey2 = "clb2Settings";  //Settings for CheckedListBox2

        private string _strFunctionName;

        RegistryHandling _rh = new RegistryHandling(_strAppName, _strSubKey1, _strSubKey2);

        private SortedList<string, SortedList<string, g_strucPVT>> _slFilesAndProperties = new SortedList<string, SortedList<string, g_strucPVT>>();
        private List<string> _lstRequiredPropNames = new List<string>();

        private g_strucRootFolder1 _strucRootFolder = new g_strucRootFolder1();
        #endregion MEMBER VARIABLES


        #region MISC FUNCTIONS
        public frmPE()
        {
            InitializeComponent();
        }

        private void frmPE_Load(object sender, EventArgs e)
        {
            Excel excel = new Excel();
            //excel.WsDisplayStatsForCompareDates();
            //TestDuplicateSortedList();
            //EnumProperties2(_strSampleFile, null, _slSampleProductValues);
            //SortedList<string, strucPVA> slTypicalProperties = EnumAllPropsSingleFile(_strTypicalFile);
            //EnumAllPropsSingleFile();
            //GetSortedFilesInFolder(_strInitialFolder);

            //SortedList<string, bool> slPropertyNames = ConvertSL(slTypicalProperties);
            //FillComboBoxX(slPropertyNames);
            //FillCheckedListBox(slPropertyNames);
            //FillControlsFromRegistry();
            //SortFilesInFolder(_InitialFolder);
            //GetFolders(_strTargetFolder);

        }

        private void SelectFunction(string FunctionName)
        {
            Excel xl;
            switch (FunctionName)
            {
                case "GetProperty":
                    ReadFileName();
                    GetProperty();
                    break;
                case "SetProperty":
                    ReadFileName();
                    ReadNewPropertyValue();
                    SetProperty();
                    break;
                case "GetInfo":
                    GetInfo();
                    break;
                case "CompareDatesInAllFiles":
                    ReadFolderName();
                    g_strucRootFolder2 strucRootFolder2 = CompareDatesInAllFiles(_strRootFolderName);
                    g_strucStats strucStats = CalculateStats(strucRootFolder2);
                    xl = new Excel();
                    xl.WsDisplayStatsForCompareDates(strucStats);
                    break;
                case "EnumAllPropertiesInASingleFile":
                    ReadFileName();
                    SortedList<string, g_strucPVT> slProperties = EnumAllPropertiesInASingleFile(_strFileName);
                    xl = new Excel();
                    xl.WsEnumAllPropsForASingleFile(_strFileName, slProperties);
                    break;
                case "EnumSelectedPropsForAllFilesInFolder":
                    ReadFolderName();
                    _slFilesAndProperties = EnumSelectedPropsForAllFilesInFolder(_strRootFolderName);
                    xl = new Excel();
                    xl.WsEnumSelectedPropsForAllFilesInFolder(_slFilesAndProperties);
                    break;
                case "EnumSelPropsForFirstFileInAllFolders":
                    ReadFolderName();
                    //EnumSelPropsForFirstFileInAllFolders
                    _strucRootFolder = EnumSelPropsForFirstFileInAllFolders(_strRootFolderName);
                    xl = new Excel();
                    xl.WsEnumSelPropsForFirstFileInAllFolders(_strucRootFolder);
                    break;
                case "CopyAndRenameFiles":
                    break;
                default:
                    break;
            }
        }

        private SortedList<string, bool> ConvertSL(SortedList<string, g_strucPVT> slProperties)
        {
            //Convert SL containing <PropertyName>, <PropertyValue>, <PropertyType>
            //to SL containing <PropertyName>, <False>.
            //This is to set up the initial Registry entry.

            SortedList<string, bool> slPropertyNames = new SortedList<string, bool>();

            foreach (KeyValuePair<string, g_strucPVT> kvp in slProperties)
            {
                //strucPVA sp = new strucPVA();
                slPropertyNames.Add(kvp.Key, false);
            }
            return slPropertyNames;
        }

        private bool FillControlsFromRegistry()
        {
            if (!_rh.CheckRegistryEntryExists())
            {
                MessageBox.Show("The Registry Entry has not yet been created");
                return false;
            }
            else
            {
                FillCheckedListBoxesFromRegistry();
                FillComboBoxFromRegistry();
                return true;
            }
        }

        private void InitRegistry()
        {
            //Initialise the Registry entries by accessing extended properties in a typical file

            SortedList<string, bool> slInitValues = new SortedList<string, bool>();
            SortedList<string, g_strucPVT> slSamplePropertyValues = EnumAllPropertiesInASingleFile(_strTypicalFile);

            foreach (KeyValuePair<string, g_strucPVT> kvp in slSamplePropertyValues)
            {
                slInitValues.Add(kvp.Key, false);
            }

            _rh.CreateInitialRegistryEntries(slInitValues);
        }

        private void SaveClb1Settings()
        {
            SortedList<string, bool> sl = new SortedList<string, bool>();

            for (int i = 0; i < clbPropertyNames1.Items.Count; i++)
            {
                bool Checked = clbPropertyNames1.GetItemChecked(i);
                sl.Add((clbPropertyNames1.Items[i]).ToString(), clbPropertyNames1.GetItemChecked(i));
            }
            _rh.SetRegistryEntries(1, sl);
        }

        private void SaveClb2Settings()
        {
            SortedList<string, bool> sl = new SortedList<string, bool>();

            for (int i = 0; i < clbPropertyNames2.Items.Count; i++)
            {
                bool Checked = clbPropertyNames2.GetItemChecked(i);
                sl.Add((clbPropertyNames2.Items[i]).ToString(), clbPropertyNames2.GetItemChecked(i));
            }
            _rh.SetRegistryEntries(2, sl);
        }
        #endregion MISC FUNCTIONS       


        #region CHECKBOXES
        private void chkGetProperty_Click(object sender, EventArgs e)
        {
            chkCompareDates.Checked = false;
            chkCopyAndRename.Checked = false;
            chkEnumAllSingle.Checked = false;
            chkEnumSelAll.Checked = false;
            chkEnumSelFirstAll.Checked = false;
            chkPropertyInfo.Checked = false;
            chkSetProperty.Checked = false;

            lblPropName.Visible = true;
            lblPropName.Enabled = true;
            cboPropertyNames.Visible = true;
            cboPropertyNames.Enabled = true;

            lblPropValue.Visible = false;
            txtPropertyValue.Visible = false;

            lblFolder.Visible = true;
            lblFolder.Enabled = false;
            txtFolder.Visible = true;
            txtFolder.Enabled = false;

            btnFolderBrowse.Visible = false;

            lblFile.Visible = true;
            lblFile.Enabled = true;
            txtFile.Visible = true;
            btnFileBrowse.Visible = true;

            lblTargetFolder.Visible = false;
            txtTargetFolder.Visible = false;

            lblClb1.Visible = false;
            clbPropertyNames1.Visible = false;
            btnSelectAll1.Visible = false;
            btnSelectNone1.Visible = false;
            btnSaveSettings1.Visible = false;

            clbPropertyNames2.Visible = false;
            btnSelectAll2.Visible = false;
            btnSelectNone2.Visible = false;
            btnSaveSettings2.Visible = false;

            btnOKSel.Visible = true;
            btnOKSel.Enabled = true;

            _strFunctionName = "GetProperty";
        }

        private void chkSetProperty_Click(object sender, EventArgs e)
        {
            chkCompareDates.Checked = false;
            chkCopyAndRename.Checked = false;
            chkEnumAllSingle.Checked = false;
            chkEnumSelAll.Checked = false;
            chkEnumSelFirstAll.Checked = false;
            chkGetProperty.Checked = false;
            chkPropertyInfo.Checked = false;

            lblPropName.Visible = true;
            lblPropName.Enabled = true;
            cboPropertyNames.Visible = true;
            cboPropertyNames.Enabled = true;

            lblPropValue.Visible = true;
            lblPropName.Enabled = true;
            txtPropertyValue.Visible = true;

            lblFolder.Visible = true;
            lblFolder.Enabled = false;
            txtFolder.Visible = true;
            txtFolder.Enabled = false;

            btnFolderBrowse.Visible = false;

            lblFile.Visible = true;
            lblFile.Enabled = true;
            txtFile.Visible = true;
            btnFileBrowse.Visible = true;

            lblTargetFolder.Visible = false;
            txtTargetFolder.Visible = false;

            lblClb1.Visible = false;
            clbPropertyNames1.Visible = false;
            btnSelectAll1.Visible = false;
            btnSelectNone1.Visible = false;
            btnSaveSettings1.Visible = false;

            clbPropertyNames2.Visible = false;
            btnSelectAll2.Visible = false;
            btnSelectNone2.Visible = false;
            btnSaveSettings2.Visible = false;

            btnOKSel.Visible = true;
            btnOKSel.Enabled = true;

            _strFunctionName = "SetProperty";
        }

        private void chkPropertyInfo_Click(object sender, EventArgs e)
        {
            chkCompareDates.Checked = false;
            chkCopyAndRename.Checked = false;
            chkEnumAllSingle.Checked = false;
            chkEnumSelAll.Checked = false;
            chkEnumSelFirstAll.Checked = false;
            chkGetProperty.Checked = false;
            chkSetProperty.Checked = false;

            lblPropName.Visible = true;
            lblPropName.Enabled = true;
            cboPropertyNames.Visible = true;
            cboPropertyNames.Enabled = true;

            lblPropValue.Visible = false;
            txtPropertyValue.Visible = false;

            lblFolder.Visible = true;
            lblFolder.Enabled = false;
            txtFolder.Visible = true;
            txtFolder.Enabled = false;
            btnFolderBrowse.Visible = false;

            lblFile.Visible = true;
            lblFile.Enabled = true;
            txtFile.Visible = true;
            btnFileBrowse.Visible = true;

            lblTargetFolder.Visible = false;
            txtTargetFolder.Visible = false;

            lblClb1.Visible = false;
            clbPropertyNames1.Visible = false;
            btnSelectAll1.Visible = false;
            btnSelectNone1.Visible = false;
            btnSaveSettings1.Visible = false;

            clbPropertyNames2.Visible = false;
            btnSelectAll2.Visible = false;
            btnSelectNone2.Visible = false;
            btnSaveSettings2.Visible = false;

            btnOKSel.Visible = true;
            btnOKSel.Enabled = true;

            _strFunctionName = "GetInfo";
        }

        private void chkCompareDates_Click(object sender, EventArgs e)
        {
            chkCopyAndRename.Checked = false;
            chkEnumAllSingle.Checked = false;
            chkEnumSelAll.Checked = false;
            chkEnumSelFirstAll.Checked = false;
            chkGetProperty.Checked = false;
            chkPropertyInfo.Checked = false;
            chkSetProperty.Checked = false;

            lblPropName.Visible = false;
            cboPropertyNames.Visible = false;

            lblPropValue.Visible = false;
            txtPropertyValue.Visible = false;

            lblFolder.Visible = true;
            lblFolder.Enabled = true;
            txtFolder.Visible = true;
            txtFolder.Enabled = true;

            btnFolderBrowse.Visible = true;

            lblFile.Visible = false;
            txtFile.Visible = false;
            btnFileBrowse.Visible = false;

            lblTargetFolder.Visible = false;
            txtTargetFolder.Visible = false;

            lblClb1.Visible = false;
            clbPropertyNames1.Visible = false;
            btnSelectAll1.Visible = false;
            btnSelectNone1.Visible = false;
            btnSaveSettings1.Visible = false;

            clbPropertyNames2.Visible = false;
            btnSelectAll2.Visible = false;
            btnSelectNone2.Visible = false;
            btnSaveSettings2.Visible = false;

            btnOKSel.Visible = true;
            btnOKSel.Enabled = true;

            _strFunctionName = "CompareDatesInAllFiles";
        }

        private void chkEnumSelAll_Click(object sender, EventArgs e)
        {
            chkCompareDates.Checked = false;
            chkCopyAndRename.Checked = false;
            chkEnumAllSingle.Checked = false;
            chkEnumSelFirstAll.Checked = false;
            chkGetProperty.Checked = false;
            chkPropertyInfo.Checked = false;
            chkSetProperty.Checked = false;

            cboPropertyNames.Visible = false;
            txtPropertyValue.Visible = false;

            lblFolder.Visible = true;
            lblFolder.Enabled = true;
            txtFolder.Visible = true;
            txtFolder.Enabled = true;
            btnFolderBrowse.Visible = true;

            txtFile.Visible = false;
            btnFileBrowse.Visible = false;

            clbPropertyNames1.Visible = true;
            btnSelectAll1.Visible = true;
            btnSelectNone1.Visible = true;
            btnSaveSettings1.Visible = true;

            clbPropertyNames2.Visible = false;
            btnSelectAll2.Visible = false;
            btnSelectNone2.Visible = false;
            btnSaveSettings2.Visible = false;

            btnOKSel.Visible = true;
            btnOKSel.Enabled = true;

            _strFunctionName = "EnumSelectedPropsForAllFilesInFolder";
        }

        private void chkEnumSelFirstAll_Click(object sender, EventArgs e)
        {
            chkCompareDates.Checked = false;
            chkCopyAndRename.Checked = false;
            chkEnumAllSingle.Checked = false;
            chkEnumSelAll.Checked = false;
            chkGetProperty.Checked = false;
            chkPropertyInfo.Checked = false;
            chkSetProperty.Checked = false;

            lblPropName.Visible = false;
            cboPropertyNames.Visible = false;

            lblPropValue.Visible = false;
            txtPropertyValue.Visible = false;

            lblFolder.Visible = true;
            lblFolder.Enabled = true;
            txtFolder.Visible = true;
            txtFolder.Enabled = true;
            btnFolderBrowse.Visible = true;

            lblFile.Visible = false;
            txtFile.Visible = false;
            btnFileBrowse.Visible = false;

            lblTargetFolder.Visible = false;
            txtTargetFolder.Visible = false;

            lblClb1.Visible = false;
            clbPropertyNames1.Visible = false;
            btnSelectAll1.Visible = false;
            btnSelectNone1.Visible = false;
            btnSaveSettings1.Visible = false;

            clbPropertyNames2.Visible = true;
            clbPropertyNames2.Enabled = true;
            btnSelectAll2.Visible = true;
            btnSelectNone2.Visible = true;
            btnSaveSettings2.Visible = true;

            btnOKSel.Visible = true;
            btnOKSel.Enabled = true;

            _strFunctionName = "EnumSelPropsForFirstFileInAllFolders";


        }

        private void chkEnumAllSingle_Click(object sender, EventArgs e)
        {
            chkCompareDates.Checked = false;
            chkCopyAndRename.Checked = false;
            chkEnumSelAll.Checked = false;
            chkEnumSelFirstAll.Checked = false;
            chkGetProperty.Checked = false;
            chkPropertyInfo.Checked = false;
            chkSetProperty.Checked = false;

            lblPropName.Visible = false;
            cboPropertyNames.Visible = false;

            lblPropValue.Visible = false;
            txtPropertyValue.Visible = false;

            lblFolder.Visible = true;
            lblFolder.Enabled = false;
            txtFolder.Visible = true;
            txtFolder.Enabled = false;
            btnFolderBrowse.Visible = false;

            lblFile.Visible = true;
            lblFile.Enabled = true;
            txtFile.Visible = true;
            btnFileBrowse.Visible = true;

            lblTargetFolder.Visible = false;
            txtTargetFolder.Visible = false;
            btnTargetFolderBrowse.Visible = false;
            btnTargetFolderBrowse.Visible = false;

            lblClb1.Visible = false;
            clbPropertyNames1.Visible = false;
            btnSelectAll1.Visible = false;
            btnSelectNone1.Visible = false;
            btnSaveSettings1.Visible = false;

            clbPropertyNames2.Visible = false;
            btnSelectAll2.Visible = false;
            btnSelectNone2.Visible = false;
            btnSaveSettings2.Visible = false;

            btnOKSel.Visible = true;
            btnOKSel.Enabled = true;

            _strFunctionName = "EnumAllPropertiesInASingleFile";
        }

        private void chkCopyAndRename_Click(object sender, EventArgs e)
        {
            chkCompareDates.Checked = false;
            chkEnumAllSingle.Checked = false;
            chkEnumSelAll.Checked = false;
            chkEnumSelFirstAll.Checked = false;
            chkGetProperty.Checked = false;
            chkPropertyInfo.Checked = false;
            chkSetProperty.Checked = false;

            cboPropertyNames.Visible = false;
            txtPropertyValue.Visible = false;

            lblFolder.Visible = true;
            lblFolder.Enabled = true;
            txtFolder.Visible = true;
            txtFolder.Enabled = true;
            btnFolderBrowse.Visible = true;
            btnFolderBrowse.Enabled = true;

            lblTargetFolder.Visible = true;
            lblTargetFolder.Enabled = true;
            txtTargetFolder.Visible = true;
            txtTargetFolder.Enabled = true;
            btnTargetFolderBrowse.Visible = true;
            btnTargetFolderBrowse.Enabled = true;

            lblFile.Visible = false;
            txtFile.Visible = false;
            btnFileBrowse.Visible = false;

            clbPropertyNames1.Visible = false;
            btnSelectAll1.Visible = false;
            btnSelectNone1.Visible = false;
            btnSaveSettings1.Visible = false;

            clbPropertyNames2.Visible = false;
            btnSelectAll2.Visible = false;
            btnSelectNone2.Visible = false;
            btnSaveSettings2.Visible = false;

            btnOKSel.Visible = true;
            btnOKSel.Enabled = true;

            //_strFunctionName = "EnumSelPropsForFirstFileInAllFolders";
        }
        #endregion CHECKBOXES       


        #region BUTTONS                
        private void btnSaveSettings1_Click(object sender, EventArgs e)
        {
            SaveClb1Settings();
        }

        private void btnSaveSettings2_Click(object sender, EventArgs e)
        {
            SaveClb2Settings();
        }

        private void btnSelectAll1_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < clbPropertyNames1.Items.Count; i++)
            {
                clbPropertyNames1.SetItemChecked(i, true);
            }
        }

        private void btnSelectAll2_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < clbPropertyNames2.Items.Count; i++)
            {
                clbPropertyNames2.SetItemChecked(i, true);
            }
        }

        private void btnSelectNone1_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < clbPropertyNames1.Items.Count; i++)
            {
                clbPropertyNames1.SetItemChecked(i, false);
            }
        }

        private void btnSelectNone2_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < clbPropertyNames2.Items.Count; i++)
            {
                clbPropertyNames2.SetItemChecked(i, false);
            }
        }

        private void btnFileBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFolder.Text = Path.GetDirectoryName(openFileDialog1.FileName);
                txtFile.Text = openFileDialog1.SafeFileName;
            }
        }

        private void btnFolderBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = _strInitialFolder;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnOKSel_Click(object sender, EventArgs e)
        {
            SelectFunction(_strFunctionName);
        }

        private void btnClearReg_Click(object sender, EventArgs e)
        {
            _rh.ClearFullRegistryEntry();
        }

        private void btnInitReg_Click(object sender, EventArgs e)
        {
            InitRegistry();
        }
        #endregion BUTTONS


        #region SAVE FORM SETTINGS
        private bool ReadFileName()
        {
            if (txtFile.Text == string.Empty)
            {
                MessageBox.Show("Please select a <FileName>");
                return false;
            }
            _strPropertyName = cboPropertyNames.SelectedItem.ToString();
            _strFileName = txtFolder.Text + "\\" + txtFile.Text;
            return true;
        }

        private bool ReadFolderName()
        {
            if (txtFolder.Text == string.Empty)
            {
                MessageBox.Show("Please select a <FolderName>");
                return false;
            }
            _strRootFolderName = txtFolder.Text;
            return true;
        }

        /// <summary>
        /// Stores the required New Value for which the property to be changed
        /// </summary>
        /// <returns>true,false</returns>
        private bool ReadNewPropertyValue()
        {
            if (txtPropertyValue.Text == string.Empty)
            {
                MessageBox.Show("Please insert a <PropertyValue>");
                return false;
            }
            _strPropertyValue = txtPropertyValue.Text;
            return true;
        }
        #endregion SAVE FORM SETTINGS


        #region PROPERTY DISPLAY FUNCTIONS
        private void GetProperty()
        {
            IShellProperty prop = ShellObject.FromParsingName(_strFileName).Properties.GetProperty(_strPropertyName);
            DisplayPropertyValue(prop);
        }

        private void SetProperty()
        {
            //_strPropertyName = cboPropertyNames.SelectedItem.ToString();
            //_strPropertyValue = txtPropertyValue.Text;
            //_strFileName = txtFolder.Text + "\\" + txtFile.Text;

            IShellProperty prop = ShellObject.FromParsingName(_strFileName).Properties.GetProperty(_strPropertyName);
            SetPropertyValue(_strPropertyValue, prop);
            DisplayPropertyValue(prop);
        }

        private bool GetInfo()
        {
            _strPropertyName = cboPropertyNames.SelectedItem.ToString();
            _strFileName = txtFolder.Text + "\\" + txtFile.Text;

            ShellPropertyDescription propDesc = SystemProperties.GetPropertyDescription(_strPropertyName);
            ShowPropertyInfo(_strPropertyName, propDesc);
            return false;
        }

        private g_strucRootFolder2 CompareDatesInAllFiles(string strRootFolder)
        {
            //Compare Date.Created and Document.Date.Created in all Files in the Root Folder            

            g_strucRootFolder2 strucRootFolder = new g_strucRootFolder2();

            List<string> lstSubFoldersInFolder = GetSubfoldersInAFolder(strRootFolder);
            List<string> lstFilesInFolder = new List<string>();
            //List<string> lstRequiredProperties = GetListOfCheckedItems(2);
            List<string> lstRequiredProperties = new List<string>
            {
                _cstrDateCreated,
                _cstrDocumentDateCreated
            };

            strucRootFolder.strRootFolderName = strRootFolder;
            strucRootFolder.slSubFolders = new SortedList<string, g_strucSubFolder2>();

            foreach (string strSubFolderName in lstSubFoldersInFolder)
            {
                g_strucSubFolder2 strucSubFolders = new g_strucSubFolder2
                {
                    slFiles = new SortedList<string, g_strucFile>()
                };

                EnumFiles enf = new EnumFiles(strSubFolderName, "*.mp3", SearchOption.TopDirectoryOnly);
                lstFilesInFolder = enf.GetFiles();

                if (lstFilesInFolder.Count == 0)
                {
                    continue;
                }

                strucSubFolders.strSubFolderName = strSubFolderName;

                foreach (string strFileName in lstFilesInFolder)
                {
                    g_strucFile strucFiles = new g_strucFile
                    {
                        strFileName = strFileName,
                        slProperties = new SortedList<string, g_strucPVT>()
                    };

                    foreach (string strPropName in lstRequiredProperties)
                    {
                        string strPropValue = string.Empty;
                        IShellProperty p = ShellObject.FromParsingName(strFileName).Properties.GetProperty(strPropName);
                        g_strucPVT strucPVA = GetPropertyValue(p);
                        strucFiles.slProperties.Add(strPropName, strucPVA);
                    }
                    strucSubFolders.slFiles.Add(strFileName, strucFiles);
                }
                strucRootFolder.slSubFolders.Add(strSubFolderName, strucSubFolders);
            }
            return strucRootFolder;
        }

        private g_strucStats CalculateStats(g_strucRootFolder2 strucRootFolder)
        {
            string strCurrentDateCreatedValue = string.Empty;
            string strCurrentDocDateCreatedValue = string.Empty;

            g_strucStats strucStats = new g_strucStats()
            {
                strRootFolderName = strucRootFolder.strRootFolderName,
                totalFiles = 0,
                totalFolders = 0,
                missingDatesCreated = 0,
                missingDocumentDatesCreated = 0,
                duplicateDatesCreated = 0,
                duplicateDocumentDatesCreated = 0,
                numberOfEqualDocumentDatesCreated = 0,
                numberOfUnequalDocumentDatesCreated = 0,
                slDuplicateDocumentDatesCreated = new SortedList<string, string>()
            };

            foreach (KeyValuePair<string, g_strucSubFolder2> kvpSF in strucRootFolder.slSubFolders)
            {
                int increment = 0;
                DateTime dtCurrent = new DateTime();

                SortedList<DateTime, string> slDatesCreated = new SortedList<DateTime, string>();
                SortedList<DateTime, string> slDocumentDatesCreated = new SortedList<DateTime, string>();

                g_strucSubFolder2 strucSubFolder = kvpSF.Value;

                string strSubFolderName = strucSubFolder.strSubFolderName;
                ++strucStats.totalFolders;
                string strCurrentProperty1 = string.Empty;
                string strCurrentProperty2 = string.Empty;

                foreach (KeyValuePair<string, g_strucFile> kvpF in strucSubFolder.slFiles)
                {
                    string strFileName = kvpF.Key;
                    ++strucStats.totalFiles;

                    g_strucFile strucFile = kvpF.Value;
                    foreach (KeyValuePair<string, g_strucPVT> kvpP in strucFile.slProperties)
                    {
                        string strPropertyName = kvpP.Key;

                        g_strucPVT strucPVT = kvpP.Value;
                        string strPropertyValue = strucPVT.strPropertyValue;
                        string strPropertytype = strucPVT.strPropertyType;

                        switch (strPropertyName)
                        {
                            case _cstrDateCreated:
                                DateTime dt1 = Convert.ToDateTime(strPropertyValue);
                                if (!slDatesCreated.ContainsKey(dt1))
                                {
                                    ++strucStats.totalDatesCreated;
                                    slDatesCreated.Add(dt1, strFileName);
                                }
                                else
                                {
                                    ++strucStats.duplicateDatesCreated;
                                }
                                break;
                            case _cstrDocumentDateCreated:
                                if (strPropertyValue == string.Empty)
                                {
                                    ++strucStats.missingDocumentDatesCreated;
                                    break;
                                }

                                DateTime dt2 = Convert.ToDateTime(strPropertyValue);

                                if (slDocumentDatesCreated.ContainsKey(dt2))
                                {
                                    if (dt2 == dtCurrent)
                                    {
                                        ++increment;
                                    }
                                    else
                                    {
                                        dtCurrent = dt2;
                                        increment = 1;
                                    }
                                    DateTime dtInc = dt2.AddSeconds(increment);
                                    strucStats.slDuplicateDocumentDatesCreated.Add(strFileName, Convert.ToString(dt2));
                                    slDocumentDatesCreated.Add(dtInc, strFileName);
                                    ++strucStats.duplicateDocumentDatesCreated;
                                }
                                else
                                {
                                    ++strucStats.totalDocumentDatesCreated;
                                    slDocumentDatesCreated.Add(dt2, strFileName);
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            return strucStats;
        }

        private SortedList<string, g_strucPVT> EnumAllPropertiesInASingleFile(string strFileName)
        {
            ShellPropertyCollection collection = new ShellPropertyCollection(strFileName);
            SortedList<string, g_strucPVT> slProperties = new SortedList<string, g_strucPVT>();
            string strPropertyType;

            foreach (var p in collection)
            {
                string strPropertyValue = string.Empty;

                if (p.CanonicalName == null)
                {
                    continue;
                }

                ShellPropertyDescription propDesc = SystemProperties.GetPropertyDescription(p.CanonicalName);
                strPropertyType = propDesc.DisplayType.ToString();

                if (strPropertyType == "DateTime")
                {
                    strPropertyValue = p.ValueAsObject == null ? string.Empty : p.ValueAsObject.ToString();
                }
                else
                {
                    strPropertyValue = p.ValueAsObject == null ? string.Empty : p.FormatForDisplay(PropertyDescriptionFormatOptions.None);
                    RemoveUnprintableChars(ref strPropertyValue);
                }

                g_strucPVT strucPVT = new g_strucPVT(strPropertyValue, strPropertyType);
                slProperties.Add(p.CanonicalName, strucPVT);
            }
            return slProperties;
        }

        private SortedList<string, SortedList<string, g_strucPVT>> EnumSelectedPropsForAllFilesInFolder(string strFolder)
        {
            SortedList<string, SortedList<string, g_strucPVT>> slFilesAndProperties = new SortedList<string, SortedList<string, g_strucPVT>>();

            List<string> lstFilesInfolder = GetSortedFilesInFolder(strFolder);
            List<string> lstRequiredProperties = GetListOfCheckedItems(1);

            foreach (string strFileName in lstFilesInfolder)
            {
                SortedList<string, g_strucPVT> slRequiredProps = new SortedList<string, g_strucPVT>();
                foreach (string strPropName in lstRequiredProperties)
                {
                    string strPropValue = string.Empty;
                    IShellProperty p = ShellObject.FromParsingName(strFileName).Properties.GetProperty(strPropName);
                    g_strucPVT spva = GetPropertyValue(p);
                    slRequiredProps.Add(strPropName, spva);
                }
                slFilesAndProperties.Add(strFileName, slRequiredProps);
            }
            return slFilesAndProperties;
        }

        private g_strucRootFolder1 EnumSelPropsForFirstFileInAllFolders(string strRootFolder)
        {
            g_strucRootFolder1 strucRootFolder = new g_strucRootFolder1();

            List<string> lstSubFoldersInFolder = GetSubfoldersInAFolder(strRootFolder);
            List<string> lstFilesInFolder = new List<string>();
            List<string> lstRequiredProperties = GetListOfCheckedItems(2);

            strucRootFolder.strRootFolderName = strRootFolder;
            strucRootFolder.slSubFolders = new SortedList<string, g_strucSubFolder1>();
            //strucSubFolders.slProperties = new SortedList<string, g_strucPVA>();

            foreach (string strSubFolderName in lstSubFoldersInFolder)
            {
                g_strucSubFolder1 strucSubFolders = new g_strucSubFolder1
                {
                    slProperties = new SortedList<string, g_strucPVT>()
                };

                EnumFiles enf = new EnumFiles(strSubFolderName, "*.mp3", SearchOption.TopDirectoryOnly);
                lstFilesInFolder = enf.GetFiles();

                if (lstFilesInFolder.Count == 0)
                {
                    continue;
                }

                string strFirstFileName = lstFilesInFolder[0];
                strucSubFolders.strSubFolderName = strSubFolderName;
                strucSubFolders.strNameOfFirstFileInSubFolder = strFirstFileName;

                foreach (string strPropName in lstRequiredProperties)
                {
                    string strPropValue = string.Empty;
                    IShellProperty p = ShellObject.FromParsingName(strFirstFileName).Properties.GetProperty(strPropName);
                    g_strucPVT strucPVA = GetPropertyValue(p);
                    strucSubFolders.slProperties.Add(strPropName, strucPVA);
                }
                strucRootFolder.slSubFolders.Add(strSubFolderName, strucSubFolders);
            }
            return strucRootFolder;
        }

        private void CopyAndRenameFiles(string strRootFolder)
        {
            g_strucRootFolder2 strucRootFolder = new g_strucRootFolder2();

            List<string> lstSubFoldersInFolder = GetSubfoldersInAFolder(strRootFolder);
            List<string> lstFilesInFolder = new List<string>();

            strucRootFolder.strRootFolderName = strRootFolder;
            strucRootFolder.slSubFolders = new SortedList<string, g_strucSubFolder2>();

            foreach (string strSubFolderName in lstSubFoldersInFolder)
            {
                g_strucSubFolder2 strucSubFolders = new g_strucSubFolder2
                {
                    slFiles = new SortedList<string, g_strucFile>()
                };

                EnumFiles enf = new EnumFiles(strSubFolderName, "*.mp3", SearchOption.TopDirectoryOnly);
                lstFilesInFolder = enf.GetFiles();

                if (lstFilesInFolder.Count == 0)
                {
                    continue;
                }

                strucSubFolders.strSubFolderName = strSubFolderName;

                foreach (string strFileName in lstFilesInFolder)
                {
                    g_strucFile strucFiles = new g_strucFile
                    {
                        strFileName = strFileName,
                        slProperties = new SortedList<string, g_strucPVT>()
                    };

                    string strPropValue = string.Empty;

                    IShellProperty p = ShellObject.FromParsingName(strFileName).Properties.GetProperty(_cstrDocumentDateCreated);


                }
            }
        }
        #endregion PROPERTY DISPLAY FUNCTIONS


        #region MISCELLANEOUS FUNCTIONS
        private void GetFolders(string strRootFolder)
        {
            EnumFiles ef = new EnumFiles(strRootFolder, "*.mp3", SearchOption.TopDirectoryOnly);
            List<string> lstFolders = ef.GetFolders();

            foreach (string strfolder in lstFolders)
            {
                string strPathRoot = Path.GetPathRoot(strfolder);
                string strDirName = Path.GetDirectoryName(strfolder);
                //Path.
            }

        }

        /// <summary>
        /// From all the files in "Folder", produce a SortedList of
        ///     Key = DateTime System.Document.DateCreated
        ///     Value = string FileName
        /// This has the effect of sorting the files by the date they were first created
        /// </summary>
        /// <param name="Folder"></param>
        /// <returns>List of Files in "System.Document.DateCreated" order</returns>
        private List<string> GetSortedFilesInFolder(string Folder)
        {
            const string strPropertyName = "System.Document.DateCreated";

            //slFiles contains Key:System.Document.DateCreated; Value: FileName
            SortedList<DateTime, string> slFiles = new SortedList<DateTime, string>();

            List<string> lstSortedFiles = new List<string>();

            EnumFiles enf = new EnumFiles(Folder, "*.mp3", SearchOption.TopDirectoryOnly);
            List<string> lstFilesInFolder = enf.GetFiles();
            foreach (string strFile in lstFilesInFolder)
            {
                IShellProperty prop = ShellObject.FromParsingName(strFile).Properties.GetProperty(strPropertyName);
                g_strucPVT sp = GetPropertyValue(prop);
                DateTime dtValue = Convert.ToDateTime(sp.strPropertyValue);
                slFiles.Add(dtValue, strFile);
            }
            //CopyFiles(slFiles, "Point of View");

            foreach (KeyValuePair<DateTime, string> kvp in slFiles)
            {
                lstSortedFiles.Add(kvp.Value);
            }
            return lstSortedFiles;
        }

        private List<string> GetSubfoldersInAFolder(string strFolderName)
        {
            List<string> lstSubFolders = new List<string>();

            EnumFiles enf = new EnumFiles(strFolderName);
            lstSubFolders = enf.GetFolders();

            return lstSubFolders;
        }

        private void CopyFiles(SortedList<DateTime, string> slFiles, string strFolderName)
        {
            int n = 0;
            foreach (KeyValuePair<DateTime, string> kvp in slFiles)
            {
                string strNumber = (++n).ToString("000");
                string strDate = kvp.Key.ToString("yyyy-MM-dd_HH-mm-ss");
                string strSourceFullPath = kvp.Value;
                string strSourceFileName = Path.GetFileName(strSourceFullPath);
                string strTargetFolder = Path.Combine(_strTargetFolder, strFolderName);

                if (!Directory.Exists(strTargetFolder))
                {
                    Directory.CreateDirectory(strTargetFolder);
                }

                StringBuilder sb = new StringBuilder();
                sb.Append(_strTargetFolder);
                sb.Append(strFolderName);
                sb.Append("\\");
                sb.Append(strNumber);
                sb.Append(". ");
                sb.Append(strFolderName);
                sb.Append("_");
                sb.Append(strDate);
                sb.Append(".mp3");

                string strTargetFullPath = sb.ToString();


                File.Copy(strSourceFullPath, strTargetFullPath, true);
            }
        }

        private g_strucPVT GetPropertyValue(IShellProperty prop)
        {
            string value = string.Empty;
            ShellPropertyDescription propDesc = SystemProperties.GetPropertyDescription(prop.CanonicalName);
            string strPropertyType = propDesc.DisplayType.ToString();

            //Console.WriteLine("{0}:  {1}", prop.CanonicalName, strPropertyType);

            if (strPropertyType == "DateTime")
            {
                value = prop.ValueAsObject == null ? string.Empty : prop.ValueAsObject.ToString();
            }
            else
            {
                value = prop.ValueAsObject == null ? string.Empty : prop.FormatForDisplay(PropertyDescriptionFormatOptions.None);
                RemoveUnprintableChars(ref value);
            }

            g_strucPVT sp = new g_strucPVT
            {
                strPropertyValue = value,
                strPropertyType = strPropertyType
            };
            return sp;
        }

        private void DisplayPropertyValue(IShellProperty prop)
        {
            string value = string.Empty;
            ShellPropertyDescription propDesc = SystemProperties.GetPropertyDescription(prop.CanonicalName);
            string str = propDesc.DisplayType.ToString();

            if (str == "DateTime")
            {
                value = prop.ValueAsObject == null ? "" : prop.ValueAsObject.ToString();
            }
            else
            {
                value = prop.ValueAsObject == null ? "" : prop.FormatForDisplay(PropertyDescriptionFormatOptions.None);
                RemoveUnprintableChars(ref value);
            }
            Console.WriteLine("{0} = {1}", prop.CanonicalName, value);
            MessageBox.Show(string.Format("{0} = {1}", prop.CanonicalName, value));
        }

        /// <summary>
        /// Remove a possible unprintable character from the beginning of a string.
        /// Sometimes FormatForDisplay adds an unprintable character to the beginning of the string.
        /// </summary>
        /// <param name="ref s"></param>
        private void RemoveUnprintableChars(ref string s)
        {
            if (s == string.Empty)
            {
                return;
            }
            char c = s[0];
            byte b = (byte)c;
            if (b < 32)
            {
                //if unprintable char detected, remove it from the beginning of the string
                s = s.Substring(1);
            }
        }

        private void ShowPropertyInfo(string propertyName, ShellPropertyDescription propDesc)
        {
            Console.WriteLine("\nProperty {0}", propDesc.CanonicalName);
            Console.WriteLine("\tPropertyKey: {0}, {1}", propDesc.PropertyKey.FormatId.ToString("B"), propDesc.PropertyKey.PropertyId);
            Console.WriteLine("\tLabel:  {0}", propDesc.DisplayName);
            Console.WriteLine("\tEdit Invitation:  {0}", propDesc.EditInvitation);
            Console.WriteLine("\tDisplay Type:  {0}", propDesc.DisplayType);
            Console.WriteLine("\tVar Enum Type:  {0}", propDesc.VarEnumType);
            Console.WriteLine("\tValue Type:  {0}", propDesc.ValueType);
            Console.WriteLine("\tDefault Column Width:  {0}", propDesc.DefaultColumWidth);
            Console.WriteLine("\tAggregation Type:  {0}", propDesc.AggregationTypes);
            Console.WriteLine("\tHas Multiple Values:  {0}", (propDesc.TypeFlags & PropertyTypeOptions.MultipleValues) == PropertyTypeOptions.MultipleValues);
            Console.WriteLine("\tIs Group:  {0}", (propDesc.TypeFlags & PropertyTypeOptions.IsGroup) == PropertyTypeOptions.IsGroup);
            Console.WriteLine("\tIs Innate:  {0}", (propDesc.TypeFlags & PropertyTypeOptions.IsInnate) == PropertyTypeOptions.IsInnate);
            Console.WriteLine("\tIs Queryable:  {0}", (propDesc.TypeFlags & PropertyTypeOptions.IsQueryable) == PropertyTypeOptions.IsQueryable);
            Console.WriteLine("\tIs Viewable:  {0}", (propDesc.TypeFlags & PropertyTypeOptions.IsViewable) == PropertyTypeOptions.IsViewable);
            Console.WriteLine("\tIs SystemProperty:  {0}", (propDesc.TypeFlags & PropertyTypeOptions.IsSystemProperty) == PropertyTypeOptions.IsSystemProperty);
        }

        private void StorePropertyValue(IShellProperty prop, SortedList<string, string> slResults)
        {
            string value = string.Empty;
            value = prop.ValueAsObject == null ? "" : prop.FormatForDisplay(PropertyDescriptionFormatOptions.None);
            slResults.Add(prop.CanonicalName, value);
        }

        private void FillComboBoxFromRegistry()
        {
            RegistryHandling rh = new RegistryHandling();
            List<string> lstCbValues = new List<string>();

            SortedList<string, bool> slRegistryEntries = rh.ReadRegistryEntries(1);
            foreach (KeyValuePair<string, bool> kvp in slRegistryEntries)
            {
                lstCbValues.Add(kvp.Key);
            }
            cboPropertyNames.DataSource = lstCbValues;
            cboPropertyNames.Enabled = false;
        }

        private void SetPropertyValue(string value, IShellProperty prop)
        {
            if (prop.ValueType == typeof(string[]))
            {
                string[] values = value.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                (prop as ShellProperty<string[]>).Value = values; //PB this sets .Value to null
            }
            if (prop.ValueType == typeof(string))
            {
                (prop as ShellProperty<string>).Value = value;
            }
            else if (prop.ValueType == typeof(ushort?))
            {
                (prop as ShellProperty<ushort?>).Value = ushort.Parse(value);
            }
            else if (prop.ValueType == typeof(short?))
            {
                (prop as ShellProperty<short?>).Value = short.Parse(value);
            }
            else if (prop.ValueType == typeof(uint?))
            {
                (prop as ShellProperty<uint?>).Value = uint.Parse(value);
            }
            else if (prop.ValueType == typeof(int?))
            {
                (prop as ShellProperty<int?>).Value = int.Parse(value);
            }
            else if (prop.ValueType == typeof(ulong?))
            {
                (prop as ShellProperty<ulong?>).Value = ulong.Parse(value);
            }
            else if (prop.ValueType == typeof(long?))
            {
                (prop as ShellProperty<long?>).Value = long.Parse(value);
            }
            else if (prop.ValueType == typeof(DateTime?))
            {
                (prop as ShellProperty<DateTime?>).Value = DateTime.Parse(value);
            }
            else if (prop.ValueType == typeof(double?))
            {
                (prop as ShellProperty<double?>).Value = double.Parse(value);
            }
        }

        private void FillCheckedListBoxesFromRegistry()
        {
            RegistryHandling rh = new RegistryHandling();
            SortedList<string, bool> slRegEntries1 = rh.ReadRegistryEntries(1);
            SortedList<string, bool> slRegEntries2 = rh.ReadRegistryEntries(2);

            int i = 0;
            foreach (KeyValuePair<string, bool> kvp in slRegEntries1)
            {
                clbPropertyNames1.Items.Add(kvp.Key);
                clbPropertyNames1.SetItemChecked(i++, kvp.Value);
            }

            i = 0;
            foreach (KeyValuePair<string, bool> kvp in slRegEntries2)
            {
                clbPropertyNames2.Items.Add(kvp.Key);
                clbPropertyNames2.SetItemChecked(i++, kvp.Value);
            }
        }

        private List<string> GetListOfCheckedItems(int clbNumber)
        {
            List<string> lstCheckedItems = new List<string>();

            switch (clbNumber)
            {
                case 1:
                    foreach (string s in clbPropertyNames1.CheckedItems)
                    {
                        lstCheckedItems.Add(s);
                    }
                    break;
                case 2:
                    foreach (string s in clbPropertyNames2.CheckedItems)
                    {
                        lstCheckedItems.Add(s);
                    }
                    break;
                default:
                    break;
            }
            return lstCheckedItems;
        }

        private void TestDuplicateSortedList()
        {
            SortedList<int, string> slDup = new SortedList<int, string>(new DuplicateKeyComparer<int>());
            slDup.Add(1, "One");
            slDup.Add(2, "Two1");
            slDup.Add(2, "Two2");
            slDup.Add(2, "Two3");
            slDup.Add(3, "Three1");

            foreach (KeyValuePair<int, string> kvp in slDup)
            {
                int i = kvp.Key;
                string str = kvp.Value;
            }
        }
        #endregion MISCELLANEOUS FUNCTIONS        


    }
}
