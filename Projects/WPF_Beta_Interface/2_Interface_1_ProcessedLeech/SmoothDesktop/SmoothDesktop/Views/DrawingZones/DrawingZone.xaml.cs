using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmoothDesktop.Views.DrawingZones
{
    /// <summary>
    /// Interaction logic for DrawingZone.xaml
    /// </summary>
    public partial class DrawingZone : UserControl
    {
        public DrawingZone()
        {
            InitializeComponent();
            myInvoker = new JF_CustomEventHandlers.DrawingRectangles.DrawingZoneMouseInvoker();
            ZoneNumber = 0;
            DataContext = this;
            IsEnabled = false;
            IsSelected = false;
        }

        public int ZoneNumber { get; set; }

        public bool IsSelected { 
            get { 
                return _isSelected; 
            }
            set { 
                _isSelected = value;
                MyBorder.BorderBrush = !value ? Brushes.Cyan : Brushes.Black;                 
            } 
        }

        private bool _isSelected { get; set; }

        public JF_CustomEventHandlers.DrawingRectangles.DrawingZoneMouseInvoker myInvoker { get; set; }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            myInvoker.InvokeDrawingZone(this, DrawingMattStates.PendingSelection);
            IsSelected = true;
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            myInvoker.InvokeDrawingZone(this, DrawingMattStates.PendingCreation);
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            IsSelected = true;
        }

    }
}
