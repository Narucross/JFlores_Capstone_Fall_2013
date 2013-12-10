using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Newtonsoft.Json;
using Create_And_Move_Zones.Model.DesktopApplicationModels;

namespace Create_And_Move_Zones.Model.SavingFunctionality
{
    public class SimpleDesktopWindowSaver
    {
        private static string pathStringUnPopulated()
        {
            return "C:\\IDE\\SavedTemplates\\{0}.txt";
        }

        /// <summary>
        /// Returns the string where we wrote the file
        /// </summary>
        public static string WriteApplicationsToStaticFile(SavedAppications applications)
        {
            string pathToFile = String.Format(pathStringUnPopulated(), applications.TemplateName);
            return WriteApplicationToFile(applications, pathToFile);
        }

        public static string WriteApplicationToFile(SavedAppications applications, string pathToFile)
        {
            FileStream overWriteFile = new FileStream(pathToFile, FileMode.Create);
            StreamWriter textWriter = new StreamWriter(overWriteFile);
            SavedAppications reFormatted = new SavedAppications();
            reFormatted.TemplateName = applications.TemplateName;
            reFormatted.SavedWindows = new List<SavedWindow>(
                applications.SavedWindows.OrderBy(x => x.WindowPositionNumber)); ;
            string toObject = JsonConvert.SerializeObject(applications);
            textWriter.Write(toObject);
            textWriter.Flush();
            textWriter.Close();
            return pathToFile;
        }

        public static SavedAppications getWindowAppsFromStaticFile(string pathname)
        {
            SavedAppications application = null;
            StreamReader reader = new StreamReader(pathname);
            StringBuilder builder = new StringBuilder();
            while (!reader.EndOfStream)
            {
                builder.Append(reader.ReadLine());
            }
            reader.Close();
            String line = builder.ToString();
            if (!String.IsNullOrEmpty(line))
            {
                application = JsonConvert.DeserializeObject<SavedAppications>(line);
            }
            return application;
        }

    }
}
