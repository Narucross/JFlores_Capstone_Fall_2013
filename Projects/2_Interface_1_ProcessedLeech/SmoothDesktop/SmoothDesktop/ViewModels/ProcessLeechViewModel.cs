using SmoothDesktop.Models;
using SmoothDesktop.ProcessUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothDesktop.ViewModels
{
    public class ProcessLeechViewModel
    {
        /// <summary>
        /// Gets all processes from the desktop
        /// </summary>
        private List<CurrentProgram> GetPrograms()
        {
            return ProcessLeech.Get_Processes();
        }


        public List<CurrentProgram> Programs { get; private set; }

        public ProcessLeechViewModel()
        {
            Programs = GetPrograms();
        }


    }//end of class
}//End of Namespace