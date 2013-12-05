using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Create_And_Move_Zones.Views.CustomEvents.DropApplicationAndResizeChain
{
    public class DeskTopDroppedEventArgs : EventArgs
    {
        public string WindowName { get; set; }
        public int ProcessIdNumber { get; set; }

        public double Width { get; set; }
        public double Height { get; set; }

        public double X { get; set; }
        public double Y { get; set; }

        public short ZoneNumber { get; set; }


    } //end of class
}// end of namespace
