using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Create_And_Move_Zones.Views.CustomEvents.DropApplicationAndResizeChain
{
    public class DeskTopDroppedInvoker
    {
        public event EventHandler<DeskTopDroppedEventArgs> OnDroppedDelegate;

        public void RecievedItemInformHigherUps(DeskTopDroppedEventArgs args)
        {
            EventHandler<DeskTopDroppedEventArgs> safteyNet = OnDroppedDelegate;

            if (safteyNet != null && args != null)
            {
                DeskTopDroppedEventArgs arguments = args;
                safteyNet(this, arguments);
            }
        }

    }
}
