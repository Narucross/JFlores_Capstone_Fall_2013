using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace JFlores_Module_ProcessManagers
{
    public class ProcessManager
    {

        public static IEnumerable<Process> AllProcessesWithHandles()
        {
            return from cal in Process.GetProcesses() where (IntPtr.Zero != (cal.MainWindowHandle)) orderby cal.ProcessName select cal;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, ExactSpelling = true, SetLastError = true)]
        internal static extern void MoveWindow(IntPtr hwnd, int x, int y, int nWidth, int nHeight, bool bRepaint);


    }//end of class
}//End of namespace