using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WPF_Unfurbished_Processed.StoredObjects
{
    class SavedActiveWindow : Store_Rectangles.SavedWindow
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
