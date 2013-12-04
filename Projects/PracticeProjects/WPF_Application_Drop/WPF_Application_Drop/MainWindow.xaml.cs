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


namespace ApplicationDrop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            String[] strings = new String[] { "John", "Jacob", "jinklehiemer", "Smith", "His Name is my Name too", "Whenever I go out!!!", "The People always shout!" };
            Applications_Domain.ItemsSource = strings;
        }

        private void Applications_Domain_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void Applications_Domain_MouseMove(object sender, MouseEventArgs e)
        {
            string name = Applications_Domain.SelectedItem as String;

            if (name != null && e.LeftButton == MouseButtonState.Pressed)
            {
                DataObject StringToCopy = new DataObject(DataFormats.Text, name);

                DragDrop.DoDragDrop(Applications_Domain, StringToCopy, DragDropEffects.Copy);
            }
        }

        private void Applications_Domain_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Drawing_Area_DragEnter(object sender, DragEventArgs e)
        {
            Drawing_Area.Opacity = .75;

        }

        private void Drawing_Area_DragLeave(object sender, DragEventArgs e)
        {
            Drawing_Area.Opacity = 1;

        }

        private void Drawing_Area_Drop(object sender, DragEventArgs e)
        {
            Label label = new Label();
            label.Content = e.Data.GetData(DataFormats.Text);
            Point labelCord = e.GetPosition(Drawing_Area);
            Canvas.SetLeft(label, labelCord.X);
            Canvas.SetTop(label, labelCord.Y);
            Drawing_Area.Children.Add(label);
            Drawing_Area.Opacity = 1;
        }

        private void EditTextLabel_Drop(object sender, DragEventArgs e)
        {
            EditTextLabel.Content = e.Data.GetData(DataFormats.Text);
        }
    }
}
