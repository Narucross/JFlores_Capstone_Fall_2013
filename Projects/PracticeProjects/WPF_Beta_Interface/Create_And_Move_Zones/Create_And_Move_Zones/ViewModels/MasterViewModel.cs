﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Create_And_Move_Zones.Model.ProcessLeechModel;
using Create_And_Move_Zones.Model.DesktopApplicationModels;
using Create_And_Move_Zones.ViewModels.DataBeans;
using Create_And_Move_Zones.Model.SavingFunctionality;

namespace Create_And_Move_Zones.ViewModels
{
    class MasterViewModel
    {
        // Get and track processes
        // Wrap active windows to the bear nessessitities height, width, name, x , y
        // Have the "On save function"

        private List<SavedActiveWindow> _SavedProcesses;
        private SimpleDesktopWindowSaver _MySaver;
        public string TemplateName { get; set; }


        public MasterViewModel()
        {
            _SavedProcesses = ProcessLeech.Get_Processes();
            _MySaver = new SimpleDesktopWindowSaver();
            TemplateName = "Default";
        }

        public List<DesktopApplicationBean> GetCurrentProcesses()
        {
            List<DesktopApplicationBean> list = null;
            if (_SavedProcesses != null || _SavedProcesses.Count > 0)
            {
                list = new List<DesktopApplicationBean>();
                foreach (SavedActiveWindow currentWindow in _SavedProcesses)
                {
                    DesktopApplicationBean bean = new DesktopApplicationBean(currentWindow);
                    list.Add(bean);
                }
            }
            return list;
        }

        internal void moveWindow(Views.CustomEvents.DropApplicationAndResizeChain.DeskTopDroppedEventArgs e)
        {
            var ienumerableShortedResults = from cal in _SavedProcesses where e.ProcessIdNumber == cal.processId select cal;

            if (ienumerableShortedResults != null)
            {
                var SelectedSavedActiveWindow = ienumerableShortedResults.FirstOrDefault();
                if (SelectedSavedActiveWindow != null && SelectedSavedActiveWindow.processId == e.ProcessIdNumber)
                {
                    SelectedSavedActiveWindow.WindowPositionNumber = e.ZoneNumber;
                    SelectedSavedActiveWindow.Width = (int)e.Width;
                    SelectedSavedActiveWindow.Height = (int)e.Height;
                    SelectedSavedActiveWindow.Pos_X = (int)e.X;
                    SelectedSavedActiveWindow.Pos_Y = (int)e.Y;
                    var pointer = ProcessLeech.getProcessByWindowId(SelectedSavedActiveWindow);
                    ProcessLeech.moveWindow(pointer, SelectedSavedActiveWindow.Pos_X, SelectedSavedActiveWindow.Pos_Y, SelectedSavedActiveWindow.Width, SelectedSavedActiveWindow.Height);
                }
            }
        }

        #region Saving functionality

        public void saveCurrentWindowState()
        {
            SimpleDesktopWindowSaver.WriteApplicationsToStaticFile(createSavedApplicationFromCurrentState());
        }

        private SavedAppications createSavedApplicationFromCurrentState()
        {
            SavedAppications applications = new SavedAppications();
            applications.TemplateName = this.TemplateName;
            var list2 = new List<SavedWindow>(_SavedProcesses.AsEnumerable());
            applications.SavedWindows = list2;
            return applications;
        }

        #endregion


        #region LoadFunctionality
        //SHould I use windows.forms?>
        public bool LoadApparatus()
        {
            bool success = false;
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.InitialDirectory = "C:\\";
            bool? result = dialog.ShowDialog();
            if (result == true)
            {

                string fileName = dialog.FileName;
                System.Windows.MessageBox.Show(fileName);

                //var savedApplications = SimpleDesktopWindowSaver.getWindowAppsFromStaticFile(fileName);
                //if (savedApplications != null)
                //{

                //}
                //success = true;
            }
            return success;
        }

        private void setProperties(SavedAppications x)
        {
            TemplateName = x.TemplateName;
            // ohh i have to match this shit... iF it exists.
            // TODO: I may want to wrap the processes thing in its own model to separate my concersn more...
            // But I already have a list of active windows... How Do I compare these things together? What should I do?
            // Two things that I think this needs to do now: 
                // First one is to load up applications that are currently not ON
                // Second resize what is on to their appropriate areas... Wow this just got cool
        }
        #endregion
    }
}
