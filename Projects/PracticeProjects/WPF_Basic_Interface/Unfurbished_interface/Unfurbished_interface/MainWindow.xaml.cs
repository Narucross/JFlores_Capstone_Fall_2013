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
using System.Collections;

namespace Unfurbished_interface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Applications_ListBox.ItemsSource = GetData();
            
        }

        public ArrayList GetData() {
            ArrayList list = new ArrayList();
            for (int i =0; i <= 24; i++) {
                list.Add("Item Number: " + i);
            }
            list.Add("Jingle All the way!! All what fun it is to ride on a one horse open slay!!!");
                return list;
        }
    }
}
