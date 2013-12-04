using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Model.DesktopApplicationModel
{
    public class SavedActiveWindow : SavedWindow
    {
        public int processId;
        public void something() { 
            
        }
        public SavedActiveWindow(Process proc) : base(proc)
        {
            processId = proc.Id;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
