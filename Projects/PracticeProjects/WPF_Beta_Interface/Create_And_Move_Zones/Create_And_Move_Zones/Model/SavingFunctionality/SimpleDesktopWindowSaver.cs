using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model.DesktopApplicationModel;
using System.IO;
using Newtonsoft.Json;
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
            StreamWriter textWriter = new StreamWriter(pathToFile, true, Encoding.ASCII);
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
            String line = reader.ReadLine();
            if (line != null)
            {
                application = JsonConvert.DeserializeObject<SavedAppications>(line);
            }
            reader.Close();
            return application;
        }

    }
}
