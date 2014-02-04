using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRE_ApplicationLists.DreApplicationListComponents.AppCards
{
    /// <summary>
    /// A model class just because supposidely it makes it easier to bind stuff
    /// </summary>
    public class DreAppCardModel
    {
        #region privateProperties for that freaken paradigm that I hate

        private string _processName { get; set; }

        int _processId { get; set; }

        string _commandLine { get; set; }

        #endregion


        #region exposed properties, part 2 of that stupid paradigm
        public string ProcessName { get { return _processName; } set { _processName = value; } }

        public int ProcessId { get { return _processId; } set { _processId = value; } }
        public string CommandLine { get { return _commandLine; } set { _commandLine = value; } }

        #endregion

        public DreAppCardModel(string processName, int procId, string commandLine)
        {
            this.ProcessName = processName;
            this.CommandLine = commandLine;
            this.ProcessId = procId;
        }

        public DreAppCardModel()
        {

        }
    }//end of class
}//end of Namespace