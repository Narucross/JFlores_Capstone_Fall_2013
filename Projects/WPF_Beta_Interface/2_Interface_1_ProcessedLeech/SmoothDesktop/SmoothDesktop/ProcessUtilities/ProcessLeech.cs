﻿using SmoothDesktop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SmoothDesktop.ProcessUtilities
{
    public class ProcessLeech
    {

        public static List<CurrentProgram> Get_Processes()
        {
            IEnumerable<Process> currentProcesses;
            var savedProcesses = new List<CurrentProgram>();

            currentProcesses = filterUsableProcesses();
            //TODO: redesign this area with linq, cause I think we can return an Ienumerable of saved windowds faster
            foreach (Process proc in currentProcesses)
            {
                var window = new CurrentProgram(proc);
                savedProcesses.Add(window);                
            }
            return savedProcesses;
        }


        /// <summary>
        /// This calls upon all processes, and we make sure that each processes doesn't have a main window handler of the static pointer Zero
        /// This is so we know that the process at least has some zemblance of a window to work with, will expand this method as needed to ensure saftey
        /// </summary>
        private static IEnumerable<Process> filterUsableProcesses()
        {
            return from cal in Process.GetProcesses() where (IntPtr.Zero != (cal.MainWindowHandle)) orderby cal.ProcessName select cal;
        }

        /// <summary>
        /// I guess depreciated.
        /// This returns the first process with the same name as the string shot in.
        /// </summary>
        /// <param name="processName"></param>
        /// <returns></returns>
        public static Process getProcessByName(String processName)
        {
            Process[] array = Process.GetProcessesByName(processName);
            return array[0] != null ? array[0] : null;
        }

        //public static Process[] getProcessByName(String processName) { 
        //    return Process.GetProcessesByName(processName);
        //}

        /// <summary>
        /// This returns the single process whose processID is equal to the savedWindow passed in.
        /// </summary>
        /// <param name="window"></param>
        /// <returns></returns>
        public static Process getProcessByWindowId(CurrentProgram window)
        {
            if (window.PointerId != 0)
            {
                return Process.GetProcessById(window.PointerId);
            }
            else
            { return null; }
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
