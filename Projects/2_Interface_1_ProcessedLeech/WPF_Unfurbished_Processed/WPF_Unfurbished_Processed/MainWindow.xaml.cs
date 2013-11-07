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
using Store_Rectangles;
using WPF_Unfurbished_Processed.ProcessLeech;
using WPF_Unfurbished_Processed.StoredObjects;

namespace WPF_Unfurbished_Processed
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SavedAppications applications = new SavedAppications();
            applications.SavedWindows = new List<SavedWindow>(LeechProcesses.Get_Processes());
            Applications_ListBox.ItemsSource = applications.SavedWindows;

        }

        private void RequestingMoveWindow(object sender, RoutedEventArgs e)
        {
            if (Applications_ListBox.SelectedItem is SavedActiveWindow)
            {
                SavedWindow selectedWindow = Applications_ListBox.SelectedItem as SavedActiveWindow;
                int x = Convert.ToInt32(X_Slider.Value);
                int y = Convert.ToInt32(Y_Slider.Value);
                int width = Convert.ToInt32(Width_Slider.Value);
                int height = Convert.ToInt32(Height_Slider.Value);
                var process = LeechProcesses.getProcessByName(selectedWindow.WindowProcessName);
                if (process != null)
                {
                    LeechProcesses.moveWindow(process, x, y, width, height);
                }
            }
            else
            {
                Console.WriteLine("Error somehow we got something outside out processes lists");

            }


        }
    }
}
