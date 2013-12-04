using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragAndDrop_2.Enums;

namespace DragAndDrop_2.CustomEvents.DrawingStateEventChain
{
    public class DrawingStateEventInvoker
    {
        public event EventHandler<DrawingStateEventArgs> DrawingStateChange;
        public void OnDrawingChangeInvoker(drawingState e)
        {
            EventHandler<DrawingStateEventArgs> safetyNetHandler = DrawingStateChange;
            if (safetyNetHandler != null)
            {
                safetyNetHandler(this, new DrawingStateEventArgs(e));
            }
        }

    }
}
