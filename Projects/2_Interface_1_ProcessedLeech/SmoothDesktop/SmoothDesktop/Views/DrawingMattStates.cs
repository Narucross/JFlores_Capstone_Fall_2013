using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothDesktop.Views
{
    public enum DrawingMattStates
    {
        /// <summary>
        /// We are in a free area
        /// </summary>
        PendingCreation , 
        /// <summary>
        /// When we entering and hovering over a zone
        /// </summary>
        PendingSelection, 
        /// <summary>
        /// When the Zone is in Pan Mode
        /// </summary>
        DrawZonePanning,
        /// <summary>
        /// When a new DrawZone has been created
        /// </summary>
        DrawZoneCreation,
    }
}
