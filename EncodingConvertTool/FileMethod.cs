using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EncodingConvertTool
{
    public static class FileMethod
    {
        public static string OpenFile(string filepath)
        {
            using (StreamReader sr = new StreamReader(filepath, Encoding.Default))
            {
                string temp = sr.ReadToEnd();
                sr.Close();
                return temp;
            }
        }
        public static void SaveFile(string filepath, string source)
        {
            if (filepath.Trim() == "")
                throw new Exception("未打开任何文件");
            using (StreamWriter wr = new StreamWriter(filepath, false, Encoding.Default))
            {
                wr.Write(source);
                wr.Close();
            }
        }
        public static void RenameFile(string before,string after)
        {
            File.Delete(after);
            File.Move(before, after);
        }
    }
}
