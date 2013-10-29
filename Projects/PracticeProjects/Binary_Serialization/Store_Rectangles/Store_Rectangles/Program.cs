using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Store_Rectangles
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Beginning application");
            SavedAppications applicationTest = new SavedAppications();
            int gWid=150;
            int gHei = 100;
            SavedWindow window1 = newSwindow("Notepad.exe", 1, gWid, gHei, 0, 0);
            SavedWindow window2 = newSwindow("notepad2.exe", 2, gWid, gHei, 12, 50);
            SavedWindow window3 = newSwindow("firefox.exe", 4, gWid, gHei, 100, 500);
            applicationTest.Add(window1);
            applicationTest.Add(window2);
            applicationTest.Add(window3);
            string s = JsonConvert.SerializeObject(applicationTest);
            Console.WriteLine(String.Format("The serialized Object is:\n{0}", s));
            
            // Fill after we know how we want to store the data.
            /*
             * Here is the syntax we will probably settle on with in json format:
              {
                "Template-Name":"{0}",
                "Windows" : [
                    {
                        "Window process Name" : "{1}",
                        "Window number" : "{2}",
                        "Width" : "{3}",
                        "Height" : "{4}",
                        "Pos-X" : "{5}",
                        "Pos-Y" : "{6}",
                    }
                ]
              }           
             **/

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
            Console.WriteLine("Ending application");
        }

        static SavedWindow newSwindow(String procName, short tempNum, int width, int height, int pos_x, int pos_y){
            return new SavedWindow(){WindowProcessName=procName,WindowTempateNumber=tempNum,Width=width,Height=height,Pos_X=pos_x,Pos_Y=pos_y};
        }
    }//end of class
}//end of namespace