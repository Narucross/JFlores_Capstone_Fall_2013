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

namespace DragDropMove
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }




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

        }


        private void DrawingArea_MouseDown(object sender, MouseButtonEventArgs e)
        {
            startingPoint = e.GetPosition(DrawingArea);
            if (currentState == drawingState.CreateNewBounds)
            {// Creating and tracking a new Rectangle
                toCreateRectangle = new System.Windows.Shapes.Rectangle();
                toCreateRectangle.Stroke = Brushes.Black;
                toCreateRectangle.Opacity = .25;
                toCreateRectangle.Fill = Brushes.RosyBrown;
                toCreateRectangle.StrokeThickness = 4;
                toCreateRectangle.MinWidth = 25;
                toCreateRectangle.MinHeight = 25;
                Canvas.SetLeft(toCreateRectangle, startingPoint.X);
                Canvas.SetTop(toCreateRectangle, startingPoint.Y);
                DrawingArea.Children.Add(toCreateRectangle);
            }
            if (currentState == drawingState.PanView)
            {
                HitTestResult result = VisualTreeHelper.HitTest(DrawingArea, startingPoint);
                if (result != null)
                {
                    if (result.VisualHit is Rectangle)
                    {
                        toCreateRectangle = (Rectangle)result.VisualHit;

                        double offSetX = Canvas.GetLeft(toCreateRectangle) - startingPoint.X;
                        double offSetY = Canvas.GetTop(toCreateRectangle) - startingPoint.Y;
                        startingPoint = new Point(offSetX, offSetY);
                    }
                }
            }
        }

        private void DrawingArea_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePositionRDrawingArea = e.GetPosition(DrawingArea);
            if (IsCurrentState(drawingState.CreateNewBounds) && toCreateRectangle != null)// On creation
            {
                Point mpRectangle = mousePositionRDrawingArea;
                double widthDiff = Math.Abs((startingPoint.X - mpRectangle.X));
                double heightDiff = Math.Abs((startingPoint.Y - mpRectangle.Y));

                if (mpRectangle.X < startingPoint.X)
                {
                    Canvas.SetLeft(toCreateRectangle, mpRectangle.X);
                }
                if (mpRectangle.Y < startingPoint.Y)
                {
                    Canvas.SetTop(toCreateRectangle, mpRectangle.Y);
                }
                toCreateRectangle.Width = widthDiff;
                toCreateRectangle.Height = heightDiff;
            }
            if (IsCurrentState(drawingState.PanView) && toCreateRectangle != null)
            {
                /* Difference between the starting point and the current point
                 * The idea is to use the starting position to keep the relative distance between the two
                 */
                Point offset = startingPoint; // assuming panview is not the default
                double diffX = mousePositionRDrawingArea.X + offset.X;
                double diffY = mousePositionRDrawingArea.Y + offset.Y;
                Canvas.SetLeft(toCreateRectangle, diffX);
                Canvas.SetTop(toCreateRectangle, diffY);
            }
        }

        private void DrawingArea_MouseUp(object sender, MouseButtonEventArgs e)
        {

            toCreateRectangle = null;
            startingPoint = new Point();
        }


        #region Properties

        private enum drawingState : byte { PanView, CreateNewBounds }

        drawingState currentState = drawingState.CreateNewBounds;


        private bool IsCurrentState(drawingState variable)
        {
            return currentState == variable;
        }

        System.Windows.Shapes.Rectangle toCreateRectangle;
        Point startingPoint;

        #endregion
    }
}
