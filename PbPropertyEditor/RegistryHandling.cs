//See Utilities\pbSetupBackups\RegistryHandling.cs
using System;
using Microsoft.Win32;
using System.Collections.Generic;

namespace PbPropertyEditor
{
    class RegistryHandling
    {
        //private string _strAppNameX = "pbPropertyEditor";
        //private string _strBaseKeyNameX;

        private string _strAppName = "pbPropertyEditor2";
        private string _strBaseKeyName;
        private string _strClb1 = "clb1Settings";    //Settings for CheckedListBox1
        private string _strClb2 = "clb2Settings";    //Settings for CheckedListBox2       

        public RegistryHandling()
        {
            //_strBaseKeyName = @"Software\" + _strAppName;
            _strBaseKeyName = @"Software\" + _strAppName;
        }

        public RegistryHandling(string strAppName, string strClb1, string strClb2)
        {
            _strAppName = strAppName;
            _strBaseKeyName = @"Software\" + _strAppName;
            _strClb1 = strClb1;
            _strClb2 = strClb2;
        }

        public string strAppName
        {
            get { return _strAppName; }
        }

        public string strClb1
        {
            get { return _strClb1; }
            set { _strClb1 = value; }
        }

        public string strClb2
        {
            get { return _strClb2; }
            set { _strClb2 = value; }
        }        

        public bool CheckRegistryEntryExists()
        {
            if (Registry.CurrentUser.OpenSubKey(_strBaseKeyName) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ClearFullRegistryEntry()
        {
            if (Registry.CurrentUser.OpenSubKey(_strBaseKeyName) != null)
            {
                Registry.CurrentUser.DeleteSubKeyTree(_strBaseKeyName);
            }
        }

        public void CreateInitialRegistryEntries(SortedList<string, bool> slProperties)
        {
            ClearFullRegistryEntry();
            using (RegistryKey rkBase2 = Registry.CurrentUser.CreateSubKey(_strBaseKeyName))
            {
                using (RegistryKey rkclb1Settings = rkBase2.CreateSubKey("clb1Settings"),
                    rkclb2Settings = rkBase2.CreateSubKey("clb2Settings"))
                {
                    foreach (KeyValuePair<string, bool> kvp1 in slProperties)
                    {
                        rkclb1Settings.SetValue(kvp1.Key, kvp1.Value);
                    }

                    foreach (KeyValuePair<string, bool> kvp2 in slProperties)
                    {
                        rkclb2Settings.SetValue(kvp2.Key, kvp2.Value);
                    }
                }
            }
        }

        public bool SetRegistryEntries(int clbNumber, SortedList<string, bool> slProperties)
        {
            //clbNumber: 1 = Set rkClb1 Settings, 2 = Set rkClb2 Settings

            using (RegistryKey rkBase = Registry.CurrentUser.CreateSubKey(_strBaseKeyName))
            {
                if (rkBase == null)
                {
                    return false;
                }
                else
                {
                    switch (clbNumber)
                    {
                        case 1:
                            using (RegistryKey rkCbl1Settings = rkBase.OpenSubKey(_strClb1, true))
                            {
                                foreach (KeyValuePair<string, bool> kvp1 in slProperties)
                                {
                                    rkCbl1Settings.SetValue(kvp1.Key, kvp1.Value);
                                }
                            }
                            break;
                        case 2:
                            using (RegistryKey rkCbl2Settings = rkBase.OpenSubKey(_strClb2, true))
                            {
                                foreach (KeyValuePair<string, bool> kvp2 in slProperties)
                                {
                                    rkCbl2Settings.SetValue(kvp2.Key, kvp2.Value);
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            return true;
        }

        public SortedList<string, bool> ReadRegistryEntries(int clbNumber)
        {
            //clbNumber: 1 = Set rkClb1 Settings, 2 = Set rkClb2 Settings

            SortedList<string, bool> slProperties = new SortedList<string, bool>();

            using (RegistryKey rkBase = Registry.CurrentUser.OpenSubKey(_strBaseKeyName, true))
            {
                if (rkBase == null)
                {
                    return null;
                }
                else
                {
                    switch (clbNumber)
                    {
                        case 1:
                            using (RegistryKey rkCbl1Settings = rkBase.OpenSubKey(_strClb1))
                            {
                                foreach (string strValueName in rkCbl1Settings.GetValueNames())
                                {
                                    string strValue = (string)rkCbl1Settings.GetValue(strValueName);
                                    slProperties.Add(strValueName, Convert.ToBoolean(strValue));
                                }
                            }
                            break;
                        case 2:
                            using (RegistryKey rkCbl2Settings = rkBase.OpenSubKey(_strClb2))
                            {
                                foreach (string strValueName in rkCbl2Settings.GetValueNames())
                                {
                                    string strValue = (string)rkCbl2Settings.GetValue(strValueName);
                                    slProperties.Add(strValueName, Convert.ToBoolean(strValue));
                                }
                            }
                            break;
                        default:
                            break;
                    }
                    return slProperties;
                }
            }
        }

        

        //public bool AmendRegistryValues(SortedList<string, bool> slProperties, int clbNumber)
        //{
        //    //clbNumber:  1 CheckedListBox1, 2 Checked ListBox2

        //    using (RegistryKey rkBase = Registry.CurrentUser.OpenSubKey(_strBaseKeyName))
        //    {
        //        if (rkBase == null)
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            switch (clbNumber)
        //            {
        //                case 1:
        //                    using (RegistryKey rkCbl1Settings = rkBase.OpenSubKey(_strClb1))
        //                    {
        //                        foreach (string strValueName in rkCbl1Settings.GetValueNames())
        //                        {
        //                            string strValue = (string)rkCbl1Settings.GetValue(strValueName);
        //                            slProperties.Add(strValueName, Convert.ToBoolean(strValue));
        //                        }
        //                    }
        //                    break;
        //                case 2:
        //                    using (RegistryKey rkCbl2Settings = rkBase.OpenSubKey(_strClb2))
        //                    {
        //                        foreach (string strValueName in rkCbl2Settings.GetValueNames())
        //                        {
        //                            string strValue = (string)rkCbl2Settings.GetValue(strValueName);
        //                            slProperties.Add(strValueName, Convert.ToBoolean(strValue));
        //                        }
        //                    }
        //                    break;
        //                default:
        //                    break;
        //            }
        //            using (RegistryKey rk = rkBase.OpenSubKey(_strBaseKeyName))
        //            {
        //                foreach (KeyValuePair<string, bool> kvp in slProperties)
        //                {
        //                    rkBase.SetValue(kvp.Key, kvp.Value);
        //                }
        //            }
        //        }

        //  }

        //public void TestAmendRegValue(string strValueName, int Value)
        //{
        //    using (RegistryKey rkBase = Registry.CurrentUser.CreateSubKey(_strBaseKeyNameX))
        //    {
        //        rkBase.SetValue(strValueName, Value);
        //    }
        //}
    }
}
