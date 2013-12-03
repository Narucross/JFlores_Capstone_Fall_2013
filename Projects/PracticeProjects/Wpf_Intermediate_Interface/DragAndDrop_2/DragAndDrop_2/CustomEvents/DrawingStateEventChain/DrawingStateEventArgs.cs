using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragAndDrop_2.Enums;

namespace DragAndDrop_2.CustomEvents.DrawingStateEventChain
{
    /// <summary>
    /// An events argument class that sends the drawing state of the parent class to its subscriptions
    /// </summary>
    public class DrawingStateEventArgs : EventArgs
    {
        public drawingState passedInState { get; set; }

        public DrawingStateEventArgs(drawingState x)
        {
            this.passedInState = x;
        }
    }
}
