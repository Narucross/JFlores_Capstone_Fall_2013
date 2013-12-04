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

using DragAndDrop_2.Views.Enums;
using DragAndDrop_2.Views.CustomEvents.DrawingStateEventChain;
using Views.Zones;

namespace DragAndDrop_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _DrawingStateHandler = new DrawingStateEventInvoker();
        }

        #region switch States and Buttons area
        
        private void Pan_And_Selection_View_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source == RectangleCreator)
            {
                DrawingArea.Background = Brushes.Blue;
                currentState = drawingState.CreateNewBounds;
            }
            else if (e.Source == PanView)
            {
                DrawingArea.Background = Brushes.Cyan;
                currentState = drawingState.PanView;
            }
            _DrawingStateHandler.OnDrawingChangeInvoker(currentState);
        }
        
        #endregion

        #region Drawing Area and creation events
        
        private void DrawingArea_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (IsCurrentState(drawingState.CreateNewBounds) && e.RightButton == MouseButtonState.Pressed && NotCurrentState(drawingState.PanView))
            {
                currentState = drawingState.RightClickOnCreateBounds;
                _DrawingStateHandler.OnDrawingChangeInvoker(currentState);
            }
            else
                if (IsCurrentState(drawingState.CreateNewBounds))
                {
                    startingPoint = e.GetPosition(DrawingArea);
                    // Creating and tracking a new Zone
                    currentZone = new ResizeZone();
                    currentZone.Opacity = .65;
                    currentZone.MinWidth = 25;
                    currentZone.MinHeight = 25;
                    Canvas.SetLeft(currentZone, startingPoint.X);
                    Canvas.SetTop(currentZone, startingPoint.Y);

                    DrawingArea.Children.Add(currentZone);
                    currentZone.number = DrawingArea.Children.Count;
                }
        }

        private void DrawingArea_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePositionRDrawingArea = e.GetPosition(DrawingArea);
            if (IsCurrentState(drawingState.CreateNewBounds) && currentZone != null)// On creation
            {
                Point mpRectangle = mousePositionRDrawingArea;
                double widthDiff = Math.Abs((startingPoint.X - mpRectangle.X));
                double heightDiff = Math.Abs((startingPoint.Y - mpRectangle.Y));

                if (mpRectangle.X < startingPoint.X)
                {
                    Canvas.SetLeft(currentZone, mpRectangle.X);
                }
                if (mpRectangle.Y < startingPoint.Y)
                {
                    Canvas.SetTop(currentZone, mpRectangle.Y);
                }
                currentZone.Width = widthDiff;
                currentZone.Height = heightDiff;
            }
        }

        private void DrawingArea_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (IsCurrentState(drawingState.CreateNewBounds))
            {
                if (currentZone != null)
                {
                    currentZone.IsEnabled = true;
                    _DrawingStateHandler.DrawingStateChange += currentZone.AdjustingDrawingState;
                }
            }

            if (IsCurrentState(drawingState.RightClickOnCreateBounds))
            {
                currentState = drawingState.CreateNewBounds;
                _DrawingStateHandler.OnDrawingChangeInvoker(currentState);
            }

            currentZone = null;
            startingPoint = new Point();
        }
        
        #endregion

        #region Listbox specifications
        #endregion


        #region Properties

        drawingState currentState = drawingState.CreateNewBounds;


        private bool IsCurrentState(drawingState variable)
        {
            return currentState == variable;
        }

        private bool NotCurrentState(drawingState variable)
        {
            return !IsCurrentState(variable);
        }

        ResizeZone currentZone;
        Point startingPoint;
        DrawingStateEventInvoker _DrawingStateHandler;

        #endregion

    }// end of class

}// end of namespace