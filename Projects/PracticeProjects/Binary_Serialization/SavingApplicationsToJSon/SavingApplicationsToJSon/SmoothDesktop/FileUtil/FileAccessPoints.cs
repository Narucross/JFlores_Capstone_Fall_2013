using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingApplicationsToJSon.SmoothDesktop.FileUtil
{
    /// <summary>
    /// This class contains the static references used by the file reader and loader.
    /// </summary>
    public class FileAccessPoints
    {
        public static string GetDefaultFileLocation(bool onDesktop = false)
        {
            return onDesktop ? "C:\\_temp\\" : "E:\\Temp\\Cap_SavedTemplates";
        }
    }//end of class

}// end of namespace
