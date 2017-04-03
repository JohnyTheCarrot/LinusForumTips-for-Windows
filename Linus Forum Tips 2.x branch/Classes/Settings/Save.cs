using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Linus_Forum_Tips.Classes.Settings
{
    class Save
    {
        /**
         * Create the appdata folder if it doesn't exist 
         */
        public void init()
        {
            //Task.Run(() => writeFile());
        }

        public void writeFile()
        {
            string path = @"C:\Linus Forum Tips\";
            string filename = "settings.txt";
            if(filename!="") File.SetAttributes(Path.Combine(path, filename), FileAttributes.Normal);
            FileStream fs = new FileStream(path,
            FileMode.Append, FileAccess.Write);
            StreamWriter outputStream = new StreamWriter(fs);
            outputStream.WriteLine("Test1");
            outputStream.WriteLine("Test2");
            outputStream.WriteLine("Test3");
            outputStream.Flush();
        }
    }

}


