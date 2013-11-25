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

namespace BorderTesting
{
    /// <summary>
    /// Interaction logic for ResizeZone.xaml
    /// </summary>
    public partial class ResizeZone : UserControl
    {


        public ResizeZone()
        {
            number = 0;
            InitializeComponent();
            DataContext = this;
            IsEnabled = false;
        }
        public int number { get; set; }

        public ResizeZone(UIElement parentElement)
        {
            InitializeComponent();
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            MainBorder.BorderBrush = Brushes.Green;
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            MainBorder.BorderBrush = Brushes.Black;
            Canvas.SetZIndex(this, 0);
        }

        Point offSet;
        bool isPressed;
        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isPressed = e.ButtonState == MouseButtonState.Pressed;
            if (isPressed)
            {
                var parent = this.Parent as Canvas;
                offSet = e.GetPosition(this);
                if (parent != null)
                {
                    Canvas.SetZIndex(this, 1);
                    Point mousePoint = e.GetPosition(parent);
                    double offSetX = Canvas.GetLeft(this);
                    double offSetY = Canvas.GetTop(this);
                    offSetX -= mousePoint.X;
                    offSetY -= mousePoint.Y;
                    offSet = new Point(offSetX, offSetY);
                }
            }
        }

        private void UserControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPressed)
            {
                Point currentMousePosition = e.GetPosition(Window.GetWindow(this));
                double distX = offSet.X + currentMousePosition.X;
                double distY = offSet.Y + currentMousePosition.Y;
                Canvas.SetLeft(this, distX);
                Canvas.SetTop(this, distY);
            }
        }

        private void UserControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isPressed = false;
        }

    }//end of class
}//end of namespace