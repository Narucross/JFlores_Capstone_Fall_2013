using System;
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
        public short TemplateNumber { get; set; }


        public MasterViewModel()
        {
            _SavedProcesses = ProcessLeech.Get_Processes();
            _MySaver = new SimpleDesktopWindowSaver();
            TemplateName = "Default";
            TemplateNumber = 1;
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
                    var pointer = ProcessLeech.getProcessByWindowId(SelectedSavedActiveWindow);

                    ProcessLeech.moveWindow(pointer, (int)e.X, (int)e.Y, (int)e.Width, (int)e.Height);
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
            foreach (SavedActiveWindow x in _SavedProcesses) {
                x.WindowTempateNumber = this.TemplateNumber;                
            }
            var list2 = new List<SavedWindow>(_SavedProcesses.AsEnumerable());
            applications.SavedWindows = list2;
            return applications;
        }

        #endregion

    }
}
