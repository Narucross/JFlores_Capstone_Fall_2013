using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Collections;
using Store_Rectangles;
using WPF_Unfurbished_Processed.StoredObjects;

namespace WPF_Unfurbished_Processed.ProcessLeech
{
    class LeechProcesses
    {

        public static List<SavedActiveWindow> Get_Processes()
        {
            IEnumerable<Process> currentProcesses ;
            List<SavedActiveWindow> savedProcesses = new List<SavedActiveWindow>();

            currentProcesses = from cal in Process.GetProcesses() where (IntPtr.Zero!=cal.MainWindowHandle) select cal;
            foreach (Process proc in currentProcesses)
            {
                SavedActiveWindow window = new SavedActiveWindow(proc);
                savedProcesses.Add(window);
            }
            return savedProcesses;
        }

        public static Process getProcessByName(String processName)
        {
            Process[] array = Process.GetProcessesByName(processName);
            return array[0] != null ? array[0] : null;
        }

        public static Process getProcess(SavedActiveWindow window) {
            if (window.processId != 0)
            {
                return Process.GetProcessById(window.processId);
            }
            return null;
        }

        public static void moveWindow(Process notepadProcess, int x, int y, int width, int height)
        {
            var ptrintReference = notepadProcess.MainWindowHandle;

            MoveWindow(ptrintReference, x, y, width, height, true);
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, ExactSpelling = true, SetLastError = true)]
        internal static extern void MoveWindow(IntPtr hwnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
    }
}
