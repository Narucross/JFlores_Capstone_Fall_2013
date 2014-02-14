using SmoothDesktop.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothDesktop.JF_CustomEventHandlers.DrawingRectangles
{
    public class DrawingZoneEventArgs : EventArgs
    {
        public DrawingMattStates CurrentStateChange { get; set; }

        public DrawingZoneEventArgs(DrawingMattStates e)
        {
            CurrentStateChange = e;
        }
    }
}
