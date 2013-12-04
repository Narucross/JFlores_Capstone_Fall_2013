using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Create_And_Move_Zones.ViewModels.DataBeans
{
    public class DesktopApplicationBean
    {
        public string WindowName { get; private set; }
        public int ProcessIdNumber { get; private set; }

        public DesktopApplicationBean(Create_And_Move_Zones.Model.DesktopApplicationModels.SavedActiveWindow myWindow)
        {
            WindowName = myWindow.WindowProcessName;
            ProcessIdNumber = myWindow.processId;
        }
    }//end of class
}
