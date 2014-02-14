using SmoothDesktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmoothDesktop.ViewModels
{
    /// <summary>
    /// The purpose of this class is to handle all things relating to the screen
    /// for instance gettin gmultiple monitors
    /// </summary>
    public class ScreenUtilityViewModel
    {

        public static ZoneTemplate[] getScreens()
        {
            var screens = Screen.AllScreens;
            return null;
        }
        public void test()
        {
            var screens = Screen.AllScreens;
            var length = screens.Length;
            Screen primary;
            foreach (Screen s in screens)
            {
                if (s.Primary)
                {
                    primary = s;
                }
            }

        }
    }
}
