using SmoothDesktop.Views;
using SmoothDesktop.Views.DrawingZones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothDesktop.JF_CustomEventHandlers.DrawingRectangles
{
    public class DrawingZoneMouseInvoker
    {
        public event EventHandler<DrawingZoneEventArgs> DrawingStateChange;

        public void InvokeDrawingZone(DrawingZone abs, DrawingMattStates currentState)
        {
            var safteyNet = DrawingStateChange;
            if (safteyNet != null)
            {
                safteyNet(abs, new DrawingZoneEventArgs(currentState));
            }
        }
    }
}
