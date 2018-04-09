//https://stackoverflow.com/questions/5337683/how-to-set-extended-file-properties/31997865
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;

namespace SetExtendedFilePropertiesExample
{
    class Program
    {
        static string _filePath = @"E:\Goldwave2\Podcasts\Friday Night Comedy from BBC Radio 4\FriComedy_ Now Show - Budget Without.mp3";
        

        static void Main(string[] args)
        {
            SetProps();
        }

        static void SetProps()
        {
            var file = ShellFile.FromFilePath(_filePath);
            string oldTitle = file.Properties.System.Title.Value;
            file.Properties.System.Title.Value = "Example Title";  //this replaces the existing title with null
        }
    }
}
