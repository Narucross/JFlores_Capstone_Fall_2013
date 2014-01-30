using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFloresConsoleUtil.JFloresCReader;
using System.Diagnostics;
using SavingApplicationsToJSon.SmoothDesktop.FileUtil;
using SavingApplicationsToJSon.SmoothDesktop.SerializableObjects;

namespace SavingApplicationsToJSon.MessingWithProcesses.ProcessManipulators
{
    public class ProcessMasters
    {
        public void WriteFileNamesToConsole()
        {
            var procs = from cal in Process.GetProcesses() where (IntPtr.Zero != (cal.MainWindowHandle)) orderby cal.ProcessName select cal;
            var notePadsLocations = @"C:\Z_Temp\installers\TestResults.txt";
            var writer = new FileWriter();
            var listOfProcesses = new List<JFlowProcessActivator>(8);
            foreach (var proc in procs)
            {
                try
                {
                    var pa = new JFlowProcessActivator();
                    pa.FileNames = new List<string>(proc.Modules.Count);
                    for (var i = 0; i < proc.Modules.Count; i++)
                    {
                        pa.FileNames.Add(proc.Modules[i].FileName);
                    }
                    var processName = proc.ProcessName;                    
                    pa.ProcessName = processName;
                    listOfProcesses.Add(pa);
                }
                catch
                {
                    "Errror at".P(postText: proc.ProcessName);
                }
            }
            writer.WriteApplicationToFile(listOfProcesses, notePadsLocations);
        }

    }//end of class

}//end of namespace