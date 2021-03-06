﻿using System;
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
            _myModel = new Create_And_Move_Zones.ViewModels.MasterViewModel();
            ListboxInitialization();
        }

        #region switch States and Buttons area

        private void Pan_And_Selection_View_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source == RectangleCreator)
            {
                DrawingArea.Background = (Brush) this.FindResource("DrawingAreaColor");
                currentState = drawingState.CreateNewBounds;
            }
            else if (e.Source == PanView)
            {
                DrawingArea.Background = (Brush)this.FindResource("DrawingAreaPanView");

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
                    Canvas.SetLeft(currentZone, startingPoint.X);
                    Canvas.SetTop(currentZone, startingPoint.Y);

                    DrawingArea.Children.Add(currentZone);
                    currentZone.number = DrawingArea.Children.Count;
                    subToInvoker(currentZone);
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

        private void ListboxInitialization()
        {
            ApplicationsTracker.ItemsSource = _myModel.GetCurrentProcesses();
        }

        private void subToInvoker(ResizeZone x)
        {
            x.myInvoker.OnDroppedDelegate += myInvoker_AfterAnItemHasBeenDroppedFeedBack;
        }

        void myInvoker_AfterAnItemHasBeenDroppedFeedBack(object sender, Create_And_Move_Zones.Views.CustomEvents.DropApplicationAndResizeChain.DeskTopDroppedEventArgs e)
        {
            //TODO: We will either need some logic here where we rescale the size of the rectangle to be fitting of the actual size of the screen we are working on...
            // Or we can go into my view model and see if we should do it there.
            // wrap this event 1 more time where we send in the template name and template number of this main window:
            var all_Screens = System.Windows.Forms.Screen.PrimaryScreen;
            var ratio = all_Screens.Bounds;
            
            
            _myModel.moveWindow(e);
        }

        private void ApplicationsTracker_MouseMove(object sender, MouseEventArgs e)
        {
            var selectedItemAndStuff = ApplicationsTracker.SelectedItem as Create_And_Move_Zones.ViewModels.DataBeans.DesktopApplicationBean;
            if (selectedItemAndStuff != null && e.LeftButton == MouseButtonState.Pressed)
            {
                var args = new DataObject(
                        typeof(Create_And_Move_Zones.ViewModels.DataBeans.DesktopApplicationBean), selectedItemAndStuff);
                DragDrop.DoDragDrop(ApplicationsTracker, args, DragDropEffects.Copy);
            }
        }

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
        Create_And_Move_Zones.ViewModels.MasterViewModel _myModel;

        #endregion

        private void SizeFinderAkASAVEEVENTUALLY_Click(object sender, RoutedEventArgs e)
        {
            //var WindowHeight = this.Height;
            //var WindowWidth = this.Width;
            //String s = String.Format("Height : {0} || Width : {1}", WindowHeight, WindowWidth);
            //MessageBoxResult some = MessageBox.Show(s);
            _myModel.saveCurrentWindowState();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            _myModel.LoadApparatus();
            ListboxInitialization();
        }





    }// end of class

}// end of namespace