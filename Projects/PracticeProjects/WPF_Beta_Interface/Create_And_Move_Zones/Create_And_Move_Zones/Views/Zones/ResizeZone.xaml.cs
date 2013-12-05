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
using Create_And_Move_Zones.Views.CustomEvents.DropApplicationAndResizeChain;


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
        public int number { get; set; }
        public Create_And_Move_Zones.Views.CustomEvents.DropApplicationAndResizeChain.DeskTopDroppedInvoker myInvoker { get; private set; }

        #endregion


        public ResizeZone()
        {
            number = 0;
            InitializeComponent();
            DataContext = this;
            IsEnabled = false;
            myInvoker = new Create_And_Move_Zones.Views.CustomEvents.DropApplicationAndResizeChain.DeskTopDroppedInvoker();
            InitializeComponent();
        }

        public ResizeZone(UIElement parentElement)
        {
            InitializeComponent();
        }

        #region Pan Movement


        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            MainBorder.BorderBrush = Brushes.Green;
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            MainBorder.BorderBrush = Brushes.Black;
            sendThisBack();
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
                    sendThisToFront();
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

        #endregion


        #region Drag and Drop Interfaces


        private void UserControl_DragEnter(object sender, DragEventArgs e)
        {
            sendThisToFront();
        }

        private void UserControl_DragLeave(object sender, DragEventArgs e)
        {
            sendThisBack();
        }

        private void UserControl_Drop(object sender, DragEventArgs e)
        {
            //Strong type only follow from a listbox sender...
            var bean = e.Data.GetData(typeof(Create_And_Move_Zones.ViewModels.DataBeans.DesktopApplicationBean)) as Create_And_Move_Zones.ViewModels.DataBeans.DesktopApplicationBean;
            if (bean != null)
            {
                var eventArgs = new DeskTopDroppedEventArgs();
                eventArgs.WindowName = bean.WindowName;
                eventArgs.ProcessIdNumber = bean.ProcessIdNumber;
                eventArgs.Height = this.Height;
                eventArgs.Width = this.Width;
                eventArgs.X = Canvas.GetLeft(this);
                eventArgs.Y = Canvas.GetTop(this);
                eventArgs.ZoneNumber = this.number;
                // Fire my recieved Event 
                myInvoker.RecievedItemInformHigherUps(eventArgs);
            }
            sendThisBack();
        }

        #endregion

        #region convience Methods
        private void _sendThisTo(int zIndex)
        {
            Canvas.SetZIndex(this, zIndex);
        }

        private void sendThisToFront()
        {
            _sendThisTo(1);
        }
        private void sendThisBack()
        {
            _sendThisTo(0);
        }
        #endregion

    }//end of class
}//end of namespacei