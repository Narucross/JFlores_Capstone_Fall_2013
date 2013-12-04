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

using DragAndDrop_2.Views.CustomEvents.DrawingStateEventChain;
using DragAndDrop_2.Views.Enums;

namespace Views.Zones
{
    /// <summary>
    /// Interaction logic for ResizeZone.xaml
    /// </summary>
    public partial class ResizeZone : UserControl
    {
        #region Properties

        Point _offSet;
        bool _isPressed;
        bool _allowedToRedirect;

        #endregion


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
        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _isPressed = e.ButtonState == MouseButtonState.Pressed;
            if (_isPressed)
            {
                var parent = this.Parent as Canvas;
                _offSet = e.GetPosition(this);
                if (parent != null)
                {
                    Canvas.SetZIndex(this, 1);
                    Point mousePoint = e.GetPosition(parent);
                    double offSetX = Canvas.GetLeft(this);
                    double offSetY = Canvas.GetTop(this);
                    offSetX -= mousePoint.X;
                    offSetY -= mousePoint.Y;
                    _offSet = new Point(offSetX, offSetY);
                }
            }
        }

        private void UserControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (ableToMove())
            {
                Point currentMousePosition = e.GetPosition(Window.GetWindow(this));
                double distX = _offSet.X + currentMousePosition.X;
                double distY = _offSet.Y + currentMousePosition.Y;
                Canvas.SetLeft(this, distX);
                Canvas.SetTop(this, distY);
            }
        }

        private bool ableToMove()
        {
            return _isPressed && _allowedToRedirect;
        }

        private void UserControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _isPressed = false;
        }

        public void AdjustingDrawingState(object sender, DrawingStateEventArgs e)
        {
            _allowedToRedirect =
                (e != null && (e.passedInState == drawingState.PanView || e.passedInState == drawingState.RightClickOnCreateBounds));

        }

    }//end of class
}//end of namespacei