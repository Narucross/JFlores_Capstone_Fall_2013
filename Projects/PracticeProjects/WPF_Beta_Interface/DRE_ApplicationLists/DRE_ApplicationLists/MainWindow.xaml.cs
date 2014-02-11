using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using DRE_ApplicationLists.DreApplicationListComponents.AppCards;
using DRE_ApplicationLists.DreApplicationListComponents.AppList;
using DRE_ApplicationLists.DreApplicationListComponents.AppListDataModels;

namespace DRE_ApplicationLists
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var list = new DreAppList();
            list.MainListBox.ItemsSource = randomAppCards();
            MainStackPanel.Children.Add(list);
            //            MainListBox.ItemsSource = randomAppCards();
        }

        private ObservableCollection<DreAppCardModel> randomAppCards()
        {
            var collection = new ObservableCollection<DreAppCardModel>();
            var randy = new Random(12);
            for (var i = 0; i < 10; i++)
            {
                collection.Add(new DreAppCardModel
                {
                    ProcessId = randy.Next(),
                    ProcessName = String.Format("Joshua {0}", randy.Next()),
                    CommandLine = String.Format("c:\\Flores\\{0}", randy.Next())
                });
            }
            return collection;
        }
    }
}
