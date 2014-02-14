using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingApplicationsToJSon.SmoothDesktop.SerializableObjects
{
    /// <summary>
    /// A Flores class that contains everything a c# Process needs in order to jump start the applicaiton you wan tit to start.
    /// </summary>
    class JFlowProcessActivator
    {
        public string ProcessName { get; set; }
        public List<string> FileNames { get; set; }
    }
}
