using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Create_And_Move_Zones.Model.ProcessLeechModel;
using Create_And_Move_Zones.Model.DesktopApplicationModels;
using Create_And_Move_Zones.ViewModels.DataBeans;

namespace Create_And_Move_Zones.ViewModels
{
    class MasterViewModel
    {
        // Get and track processes
        // Wrap active windows to the bear nessessitities height, width, name, x , y
        // Have the "On save function"

        private List<SavedActiveWindow> _SavedProcesses;
        public MasterViewModel()
        {
            _SavedProcesses = ProcessLeech.Get_Processes();
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

    }
}
