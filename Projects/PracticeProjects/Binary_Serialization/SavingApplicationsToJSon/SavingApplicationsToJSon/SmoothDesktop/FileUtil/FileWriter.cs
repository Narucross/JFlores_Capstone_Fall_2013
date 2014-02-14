using System.Net.Mime;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingApplicationsToJSon.SmoothDesktop.FileUtil
{
    /// <summary>
    /// This class writes to the files... 
    /// </summary>
    public class FileWriter
    {
        /// <summary>
        /// Writes the object to the file location... however you probably want to use from: FileAccessPoints
        /// </summary>
        public string WriteApplicationToFile<G>(G generic, string pathToFile) {
            var overWriteFile = new FileStream(pathToFile, FileMode.Create);
            var textWriter = new StreamWriter(overWriteFile);
            
            String serialized = JsonConvert.SerializeObject(generic);
            textWriter.Write(serialized);            
            textWriter.Flush();
            textWriter.Close();

            return pathToFile;
        }

        public void WriteErrorsToFile(string pathToFile,string errorMessages)
        {
            var overWriteFile = new FileStream(pathToFile, FileMode.Create);
            var textWriter = new StreamWriter(overWriteFile);
            textWriter.Write(errorMessages);
            textWriter.Flush();
            textWriter.Close();
        }

    }//end of class

}// end of namespace