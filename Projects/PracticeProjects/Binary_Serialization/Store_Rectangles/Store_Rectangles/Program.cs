using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Store_Rectangles
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Beginning application");
            SavedAppications applicationTest = new SavedAppications();
            int gWid = 150;
            int gHei = 100;
            applicationTest.TempateName = "Demacia";
            SavedWindow window1 = newSwindow("Notepad.exe", 1, gWid, gHei, 0, 0);
            SavedWindow window2 = newSwindow("notepad2.exe", 2, gWid, gHei, 12, 50);
            SavedWindow window3 = newSwindow("firefox.exe", 4, gWid, gHei, 100, 500);
            applicationTest.Add(window1);
            applicationTest.Add(window2);
            applicationTest.Add(window3);
            string s = JsonConvert.SerializeObject(applicationTest);
            Console.WriteLine(String.Format("The serialized Object is:\n{0}", s));
            SavedAppications app2 = JsonConvert.DeserializeObject<SavedAppications>(s);
            if (applicationTest.Equals(app2)) {
                Console.WriteLine("\n\nSuccess");
            }
            //SerializationBeta(applicationTest);
            endProgram();
        }

        private static void SerializationBeta(SavedAppications applicationTest)
        {
            string generatedPath = WriteToFile(applicationTest);
            SavedAppications copy = ReadFromFile(generatedPath);
            bool test = applicationTest.Equals(copy);
            if (test)
            {
                Console.WriteLine("Basic serialization mastered");
            }
            else
            {
                Console.WriteLine("Something went Astray");
            }
        }
        public static void endProgram()
        {
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
            Console.WriteLine("Ending application");
        }

        static SavedWindow newSwindow(String procName, short tempNum, int width, int height, int pos_x, int pos_y)
        {
            return new SavedWindow() { WindowProcessName = procName, WindowTempateNumber = tempNum, Width = width, Height = height, Pos_X = pos_x, Pos_Y = pos_y };
        }

        static string  WriteToFile(SavedAppications applications)
        {            
            string pathName = "C:\\IDE\\SavedTemplates";
            string pathNameExtended = pathName + "\\" + applications.TempateName + ".txt";
            StreamWriter textWriter = new StreamWriter(pathNameExtended, true, Encoding.ASCII);

            string s = JsonConvert.SerializeObject(applications);
            textWriter.Write(s);
            textWriter.Flush();
            textWriter.Close();
            return pathNameExtended;
        }

        static SavedAppications ReadFromFile(string pathOfObject)
        {
            SavedAppications application = null;
            StreamReader reader = new StreamReader(pathOfObject);
            String line = reader.ReadLine();
            if (line != null) {
                application = JsonConvert.DeserializeObject<SavedAppications>(line);
            }
            reader.Close();
            return application;
        }

    }//end of class
}//end of namespace