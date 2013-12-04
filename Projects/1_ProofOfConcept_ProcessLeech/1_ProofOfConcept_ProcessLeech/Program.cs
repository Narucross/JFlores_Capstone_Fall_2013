using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace _1_ProofOfConcept_ProcessLeech
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting program");
            var notepadDoc1 = Process.GetProcessById(1176);
            var notepadDoc2 = Process.GetProcessById(5428);
            var notepadDoc3 = Process.GetProcessById(8940);
            Process[] processes = Process.GetProcesses();
            Console.WriteLine("" + processes.Length);
            var proc2 = (from cur in processes where !cur.MainWindowTitle.Equals("") select cur).ToArray();
            processes = new Process[] { notepadDoc1, notepadDoc2, notepadDoc3 };
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
                else
                {
                    Console.Write("No Container\n");
                }
                //TEST REGION
                if (currentProcess.Id == 9288)
                {
                    moveNotepad(currentProcess);
                }
                //TEST REGION!
                object[] obects = new object[] { i, processName, processWindowType, processWindowTypeToString, containerType };
                message = String.Format("{0}.) For the process: {1}\n\tThe type is : {2}\n\tEntity toString : {3}\n\tProcessType : {4}\n", obects);
                Console.WriteLine(message);

            }
            Console.WriteLine("End of the program Press enter to exit.");
            Console.ReadLine();
        }//end of main

        static void moveNotepad(Process notepadProcess)
        {
            int x = 740;
            int y = 360;
            int Width = 563;
            int Height = 371;
            //Begin test
            Console.WriteLine("=========\tBegin Test?\t=========");
            String s = Console.ReadLine();
            var ptrintReference = notepadProcess.MainWindowHandle;

            if (s.Trim().Equals("quit", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Wimp");
            }
            else
            {
                MoveWindow(ptrintReference, x, y, Width, Height, true);
                Console.WriteLine("Was it successful?");
                s = Console.ReadLine();
                if (s.Trim().Equals("yes", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Hurray!\nHazzah!\nI bid to say I do!");
                }
            }
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, ExactSpelling = true, SetLastError = true)]
        internal static extern void MoveWindow(IntPtr hwnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

    }//end of class
}//end of namespace