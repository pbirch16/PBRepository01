using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbPropertyEditor
{
    #region STRUCTURES
    struct g_strucRootFolder1
    {
        public string strRootFolderName;
        public SortedList<string, g_strucSubFolder1> slSubFolders;
        // Key = SubFolderName
        // Value = g_strucSubFolders
    }

    struct g_strucSubFolder1
    {
        public string strSubFolderName;
        public string strNameOfFirstFileInSubFolder;
        public SortedList<string, g_strucPVT> slProperties;
        //Key = Property Name
        //Value = g_strucPVA
    }

    struct g_strucRootFolder2
    {
        public string strRootFolderName;
        public SortedList<string, g_strucSubFolder2> slSubFolders;
        // Key = SubFolderName
        // Value = g_strucSubFolders
    }

    struct g_strucSubFolder2
    {
        public string strSubFolderName;
        public SortedList<string, g_strucFile> slFiles;
        //Key = File Name
        //Value = g_strucFile
    }

    struct g_strucFile
    {
        public string strFileName;
        public SortedList<string, g_strucPVT> slProperties;
        //Key = Property Name
        //Value = g_strucPVA
    }

    struct g_strucPVT
    {
        public string strPropertyValue;
        public string strPropertyType;

        public g_strucPVT(string strPropVal, string strPropType)
        {
            strPropertyValue = strPropVal;
            strPropertyType = strPropType;
        }
    }

    struct g_strucStats
    {
        public string strRootFolderName;
        public int totalFolders;
        public int totalFiles;
        public int totalDatesCreated;
        public int totalDocumentDatesCreated;
        public int missingDatesCreated;
        public int missingDocumentDatesCreated;
        public int duplicateDatesCreated;
        public int duplicateDocumentDatesCreated;
        public int numberOfEqualDocumentDatesCreated;
        public int numberOfUnequalDocumentDatesCreated;
        public SortedList<string, string> slDuplicateDocumentDatesCreated;
    }
    #endregion STRUCTURES    
}


