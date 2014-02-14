using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothDesktop.Models
{
    /// <summary>
    /// This class represents a program that is currently active from the process Leeches
    /// </summary>
    public class CurrentProgram
    {
        /// <summary>
        /// The dimensions of the freaken program
        /// </summary>
        public ZoneDimensions MyDim { get; set; }


        [JsonIgnore]
        /// <summary>
        /// If not null, that is expected that this progran is active, is ignored during serialization
        /// </summary>
        public int PointerId { get; set; }

        /// <summary>
        /// The name of the process
        /// </summary>
        public string ProcessName { get; set; }

        /// <summary>
        /// Gets the full path of the process
        /// </summary>
        public string FullPath { get; set; }

        public CurrentProgram(Process myProc)
        {
            MyDim = new ZoneDimensions();
            MyDim.X = 0;
            MyDim.Y = 0;
            MyDim.Width = 0;
            MyDim.Height = 0;
            ProcessName = myProc.ProcessName;
            PointerId = myProc.Id;
            FullPath = myProc.Modules[0].FileName;
        }
    } // End of class
}// End of Namespace