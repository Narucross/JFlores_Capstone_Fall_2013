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

        public override bool Equals(object obj)
        {
            Boolean retValue = false;

            if (obj is SavedWindow)
            {
                SavedWindow casted = (SavedWindow)obj;
                bool sameProcName = casted.WindowProcessName.Equals(this.WindowProcessName);
                bool sameNumber = (casted.WindowTempateNumber == this.WindowTempateNumber);
                bool sameWidth = (casted.Width == this.Width);
                bool sameheight = (casted.Height == this.Height);
                bool sameX = (casted.Pos_X == this.Pos_X);
                bool sameY = (casted.Pos_Y == this.Pos_Y);
                retValue = sameProcName && sameNumber && sameWidth && sameheight && sameX && sameY;
            }
            return retValue;
        }
        public override int GetHashCode()
        {
            return (((int)WindowTempateNumber) + Width + Height + Pos_X + Pos_Y + WindowProcessName.GetHashCode());
        }

    }
}
