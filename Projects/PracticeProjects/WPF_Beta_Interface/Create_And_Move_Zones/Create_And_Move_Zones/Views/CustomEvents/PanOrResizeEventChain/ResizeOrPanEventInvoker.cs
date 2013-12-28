using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Create_And_Move_Zones.Views.CustomEvents.PanOrResizeEventChain
{
    public class ResizeOrPanEventInvoker
    {
        public event EventHandler<ResizeOrPanEventArgs> OnChangedDimension;

        public void CurrentlyResizing(ResizeOrPanEventArgs args)
        {
            EventHandler<ResizeOrPanEventArgs> safteyNet = OnChangedDimension;
            ;

            if (safteyNet != null && args != null)
            {
                var arguments = args;
                safteyNet(this, arguments);
            }
        }

    }
}
