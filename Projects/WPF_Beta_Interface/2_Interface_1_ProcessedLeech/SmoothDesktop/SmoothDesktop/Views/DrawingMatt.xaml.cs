using SmoothDesktop.Views.DrawingZones;
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

namespace SmoothDesktop.Views
{
    /// <summary>
    /// Interaction logic for DrawingMatt.xaml
    /// </summary>
    public partial class DrawingMatt : UserControl
    {
        public DrawingMatt()
        {
            InitializeComponent();
            CurrentState = DrawingMattStates.PendingCreation;

        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseLocation = e.GetPosition(CanvasArea);//Left corner of mouse
            // Have members created so that when the mouse is over them that the master control locks down
            if (e.LeftButton == MouseButtonState.Pressed && CurrentState.Equals(DrawingMattStates.PendingCreation))
            {
                CurrentState = DrawingMattStates.DrawZoneCreation;

                var drawingArea = new DrawingZone();

                Canvas.SetLeft(drawingArea, MouseLocation.X);
                Canvas.SetTop(drawingArea, MouseLocation.Y);

                CanvasArea.Children.Add(drawingArea);
                drawingArea.ZoneNumber = CanvasArea.Children.Count;
                SubToDrawingZoneInvoker(drawingArea);

                // Need to select it
                Selected = drawingArea;
            }
        }
        private void CanvasArea_MouseMove(object sender, MouseEventArgs e)
        {
            var position2 = e.GetPosition(CanvasArea); // new position
            if (CurrentState.Equals(DrawingMattStates.DrawZoneCreation) && e.LeftButton == MouseButtonState.Pressed)
            {
                Point mpRectangle = position2;
                double widthDiff = Math.Abs((MouseLocation.X - mpRectangle.X));
                double heightDiff = Math.Abs((MouseLocation.Y - mpRectangle.Y));

                if (mpRectangle.X < MouseLocation.X)
                {
                    Canvas.SetLeft(Selected, mpRectangle.X);
                }
                if (mpRectangle.Y < MouseLocation.Y)
                {
                    Canvas.SetTop(Selected, mpRectangle.Y);
                }
                Selected.Width = widthDiff;
                Selected.Height = heightDiff;
            }
        }

        private void CanvasArea_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (CurrentState == DrawingMattStates.DrawZoneCreation)
            {
                CurrentState = DrawingMattStates.PendingCreation;
                Selected.IsEnabled = true;
            }
        }

        #region drawingZones
        private void SubToDrawingZoneInvoker(DrawingZones.DrawingZone e)
        {
            e.myInvoker.DrawingStateChange += OnDrawingStateChange;
        }

        /// <summary>
        /// This method is invoked when a drawing area comes in contact with the mouse
        /// </summary>
        void OnDrawingStateChange(object sender, JF_CustomEventHandlers.DrawingRectangles.DrawingZoneEventArgs e)
        {
            if (sender is DrawingZone)
            {
                if (CurrentState != DrawingMattStates.DrawZoneCreation)
                {
                    CurrentState = e.CurrentStateChange;
                    if (CurrentState.Equals(DrawingMattStates.DrawZonePanning))
                    {
                        Selected.IsSelected = false;
                        Selected = sender as DrawingZone;
                        Selected.IsSelected = true;
                    }
                }
            }
        }
        #endregion

        public DrawingMattStates CurrentState { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Point MouseLocation { get; set; }

        /// <summary>
        /// Tracker of the current zone we are examining
        /// </summary>
        public DrawingZone Selected { get; set; }


    }
}
