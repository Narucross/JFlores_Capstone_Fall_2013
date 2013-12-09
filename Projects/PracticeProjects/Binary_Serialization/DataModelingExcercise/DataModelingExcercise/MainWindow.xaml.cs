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
using DataModelingExcercise.Views;
using DataModelingExcercise.BindingOperations.ViewModels;

namespace DataModelingExcercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            myProps = new string[] { "Height", "Width", "Pos_X", "Pos_Y" };
            Init_Panel_1();
            _MasterModel = new MasterViewModel("TemplateNameDefault_1");
            ListOfItems.ItemsSource = _MasterModel._MyArray._MyBeans;
            var x = new DataModelingExcercise.BindingOperations.Models.DataBean();
        }
        string[] myProps { get; set; }
        private void Init_Panel_1()
        {
            int i = 0;
            _Height_Slider = createNewThing(myProps[i++]);
            _Width_Slider = createNewThing(myProps[i++]);
            _Pos_X_Slider = createNewThing(myProps[i++]);
            _Pos_Y_Slider = createNewThing(myProps[i++]);
        }

        private LabelTextBoxNiSlider createNewThing(string name)
        {
            var bar = new LabelTextBoxNiSlider(name);
            // apply to property change here
            bar.PropertyChanged += bar_PropertyChanged;
            StackPanel_1.Children.Add(bar);
            return bar;
        }

        void bar_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var itemSelected = ListOfItems.SelectedItem as DataModelingExcercise.BindingOperations.Models.DataBean;
            if (itemSelected != null)
            {
                int i = 0;
                if (myProps[i++] == e.PropertyName)
                {
                    itemSelected.MyHeight = _Height_Slider.TickValue;
                }
                else if (myProps[i++] == e.PropertyName)
                {
                    itemSelected.MyWidth = _Width_Slider.TickValue;
                }
                else if (myProps[i++] == e.PropertyName)
                {
                    itemSelected.MyPosX = _Pos_X_Slider.TickValue;
                }
                else if (myProps[i++] == e.PropertyName)
                {
                    itemSelected.MyPosY = _Pos_Y_Slider.TickValue;
                }
            }
        }

        LabelTextBoxNiSlider _Height_Slider; LabelTextBoxNiSlider _Width_Slider; LabelTextBoxNiSlider _Pos_X_Slider; LabelTextBoxNiSlider _Pos_Y_Slider;
        MasterViewModel _MasterModel;
    }
}
