using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;


namespace _1_ProofOfConcept_ProcessLeech
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting program");
            var notepadDoc1 = Process.GetProcessById(9288);
            var notepadDoc2 = Process.GetProcessById(9312);
            var notepadDoc3 = Process.GetProcessById(41056);
            Process[] processes = Process.GetProcesses();
            Console.WriteLine(""+processes.Length);
            var proc2  = (from cur in processes where !cur.MainWindowTitle.Equals("") select cur ).ToArray();
            processes = new Process[] { notepadDoc1, notepadDoc2 ,notepadDoc3};
            int i = 0;
            foreach (Process currentProcess in processes)
            {
                i++;
                String message;
                var processName = currentProcess.ProcessName;
                var processWindowType = currentProcess.MainWindowHandle.GetType().ToString();
                var processWindowTypeToString = currentProcess.MainWindowHandle.ToString();

                var containerType = currentProcess.GetType();

                bool something = currentProcess.Container != null;
                if (something)
                {
                    Console.WriteLine("" + i + ".) Has Container");
                }
                else {
                    Console.Write("No Container\n");
                }
                
                object[] obects = new object[] { i, processName, processWindowType, processWindowTypeToString,containerType };
                message = String.Format("{0}.) For the process: {1}\n\tThe type is : {2}\n\tEntity toString : {3}\n\tProcessType : {4}\n", obects);
                Console.WriteLine(message);
                
            }
            Console.WriteLine("End of the program Press enter to exit.");
            Console.ReadLine();
        }
    }
}