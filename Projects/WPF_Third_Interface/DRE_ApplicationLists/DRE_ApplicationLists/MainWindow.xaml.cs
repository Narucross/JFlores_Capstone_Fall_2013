using System;
using System.Collections.ObjectModel;
using System.Windows;
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
            list.MainListBox.ItemsSource = InitiatedListAppCards();
            MainStackPanel.Children.Add(list);
            //            MainListBox.ItemsSource = RandomAppCards();
        }

        private ObservableCollection<DreAppCardModel> RandomAppCards()
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

        private ObservableCollection<DreAppCardModel> InitiatedListAppCards()
        {
            return new ObservableCollection<DreAppCardModel>()
            {
                new DreAppCardModel
                {
                    ProcessId = 8420,
                    ProcessName = "Notepad++",
                    CommandLine = @"C:\Program Files (x86)\Notepad++\notepad++.exe"
                },
                new DreAppCardModel
                {
                    ProcessId = 9088,
                    ProcessName = "notepad",
                    CommandLine = @"C:\Windows\system32\notepad.exe"
                },
                new DreAppCardModel
                {
                    ProcessId = 6348,
                    ProcessName = "devenv",
                    CommandLine = @"C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\devenv.exe"
                },
                // Broken ones
                new DreAppCardModel
                {
                    ProcessId = 8420,
                    ProcessName = "Notepad++",
                    CommandLine = @"C:\Program Files(x86)\Notepad++\notepad++.exe"
                },
                new DreAppCardModel
                {
                    ProcessId = 9088,
                    ProcessName = "notepad",
                    CommandLine = @"C:\Windows\system2\notepad.exe"
                },
                new DreAppCardModel
                {
                    ProcessId = 6348,
                    ProcessName = "devenv",
                    CommandLine = @"C:\Program Files(x86)\Microsoft Visual Studio 12.0\Common7\IDE\devenv.exe"
                }
            };
        }
    }
}
