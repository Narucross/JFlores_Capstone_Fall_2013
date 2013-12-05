using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Create_And_Move_Zones.Views.CustomEvents.DropApplicationAndResizeChain
{
    public class DeskTopDroppedEventArgs : EventArgs
    {
        public string WindowName { get; private set; }
        public int ProcessIdNumber { get; private set; }

        public double Width { get; set; }
        public double Height { get; set; }

        public double X { get; set; }
        public double Y { get; set; }


        public DeskTopDroppedEventArgs(ViewModels.DataBeans.DesktopApplicationBean recievedBean, double _width, double _height, double _x, double _y)
        {
            WindowName = recievedBean.WindowName;
            ProcessIdNumber = recievedBean.ProcessIdNumber;
            Width = _width;
            Height = _height;
            X = _x;
            Y = _y;
        }
    } //end of class
}// end of namespace
