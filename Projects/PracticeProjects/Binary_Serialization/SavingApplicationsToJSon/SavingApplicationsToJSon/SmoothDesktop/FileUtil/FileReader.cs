using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SavingApplicationsToJSon.SmoothDesktop.FileUtil
{
    /// <summary>
    /// Loads up and returns lists of objects from files
    /// </summary>
    public class FileReader
    {
        /// <summary>
        /// Returns a list using the json reader
        /// </summary>
        public List<G> getListFromFile<G>(String path) { //TODO where G : serializable?
            //TODO Create a file and read from it and collect your does, there is a reflextion exception somewhere here... find it and kill it
            // var master = null;
            var reader =   new StreamReader(path);
            StringBuilder builder = new StringBuilder();
            while (!reader.EndOfStream)
            {
                builder.Append(reader.ReadLine());
            }
            reader.Close();
            string line = builder.ToString();
            if (!String.IsNullOrEmpty(line))
            {
                //master = JsonConvert.DeserializeObject<ZoneTemplate>(line);
            }
            //return master;
            return null;
        }

    }//end of class

}// end of namespace
