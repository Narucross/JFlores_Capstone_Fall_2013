using SmoothDesktop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SmoothDesktop.ViewModels
{
    public class SimpleDesktopWindowSaver
    {
        private static string pathStringUnPopulated()
        {
            return "C:\\IDE\\SavedTemplates\\{0}.txt";
        }

        public static string WriteTemplateToFile(ZoneTemplate tepl, string pathToFile) {
            var overWriteFile = new FileStream(pathToFile, FileMode.Create);
            var textWriter = new StreamWriter(overWriteFile);
            var copy = new ZoneTemplate(tepl);
            String serialized = JsonConvert.SerializeObject(copy);
            textWriter.Write(serialized);
            textWriter.Flush();
            textWriter.Close();
            return pathToFile;
        }

        public static ZoneTemplate getWinAppsFromStaticFile(string pathname) {
            ZoneTemplate master = null;
            var reader = new StreamReader(pathname);
            StringBuilder builder = new StringBuilder();
            while (!reader.EndOfStream)
            {
                builder.Append(reader.ReadLine());
            }
            reader.Close();
            string line = builder.ToString();
            if (!String.IsNullOrEmpty(line)) {
                master = JsonConvert.DeserializeObject<ZoneTemplate>(line);
            }
            return master;
        }

    }
}
