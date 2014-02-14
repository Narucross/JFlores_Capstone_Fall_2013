using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace DataModelingExcercise.Views
{
    /// <summary>
    /// Interaction logic for LabelTextBoxNiSlider.xaml
    /// </summary>
    public partial class LabelTextBoxNiSlider : UserControl, INotifyPropertyChanged
    {
        #region properties

        public string _myLabel { get; set; }

        private double _tickValue;
        public double TickValue
        {
            get { return _tickValue; }
            set
            {
                if (value != _tickValue)
                {
                    _tickValue = value;
                    InvokePropertyChange(_myLabel);
                }
            }
        }
        #endregion

        public LabelTextBoxNiSlider(String label)
        {
            _myLabel = label;
            this.DataContext = this;
            InitializeComponent();
            _tickValue = MySlider.Value;
        }

        private void MySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TickValue = MySlider.Value;
        }


        #region Property Change Event components
        public event PropertyChangedEventHandler PropertyChanged;

        private void InvokePropertyChange(String nameOfPropertyChangeDontMindValuesOrActualUsefulInfo)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(nameOfPropertyChangeDontMindValuesOrActualUsefulInfo));
            }
        }
        #endregion

    }//end of class
}//end of namespace