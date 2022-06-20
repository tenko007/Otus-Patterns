using System.IO;
using System.Text;

namespace CodeGeneration.SaveAndLoad
{
    public class SaveAndLoadFile
    {
        public static string ReadFile(string filePath)
        {
            if (!File.Exists(filePath)) return "";
            
            string fileText = "";
            using (FileStream fstream = File.OpenRead(filePath))
            {
                byte[] buffer = new byte[fstream.Length];
                fstream.Read(buffer, 0, buffer.Length);
                fileText = Encoding.Default.GetString(buffer);
            }

            return fileText;
        }
        
        public static void SaveFile(string fileText, string filePath)
        {
            using (var outfile = new StreamWriter(filePath, false, Encoding.UTF8))
                outfile.Write(fileText);
        }
    }
}