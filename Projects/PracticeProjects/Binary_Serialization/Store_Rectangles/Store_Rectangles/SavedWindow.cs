using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Rectangles
{
    /// <summary>
    /// A "Bean" for an item stored in the saved application.
    /// </summary>
    public class SavedWindow
    {
        public string WindowProcessName { get; set; }
        public short WindowTempateNumber { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Pos_X { get; set; }
        public int Pos_Y { get; set; }

    }
}
