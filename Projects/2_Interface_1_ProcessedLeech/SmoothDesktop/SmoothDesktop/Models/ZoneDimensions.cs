using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothDesktop.Models
{
    /// <summary>
    /// A simple holde of the Zone's dimensions
    /// </summary>
    public class ZoneDimensions
    {
        /// <summary>
        /// The horizontal orientation of the Zone
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// The Vertical orientation of the Zone
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// The Height of the Zone
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// The Width of the Zone
        /// </summary>
        public int Width { get; set; }
    }
}
