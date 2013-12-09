using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataModelingExcercise.BindingOperations.Models
{
    public class DataBean : INotifyPropertyChanged
    {
        string _myName;
        public String MyName
        {
            get { return _myName; }
            set
            {
                if (_myName != value)
                {
                    _myName = value;
                    InvokePropertyChangeEvent();
                }
            }
        }

        double _myNumber;
        public double MyNumber
        {
            get { return _myNumber; }
            set
            {
                if (_myNumber != value)
                {
                    _myNumber = value;
                    InvokePropertyChangeEvent();
                }
            }
        }
        double _myHeight;
        public double MyHeight
        {
            get { return _myHeight; }
            set
            {
                if (_myHeight != value)
                {
                    _myHeight = value;
                    InvokePropertyChangeEvent();
                }
            }
        }
        double _myWidth;
        public double MyWidth
        {
            get { return _myWidth; }
            set
            {
                if (_myWidth != value)
                {
                    _myWidth = value;
                    InvokePropertyChangeEvent();
                }
            }
        }
        double _myPosX;
        public double MyPosX
        {
            get { return _myPosX; }
            set
            {
                if (_myPosX != value)
                {
                    _myPosX = value;
                    InvokePropertyChangeEvent();
                }
            }
        }

        double _myPosY;
        public double MyPosY
        {
            get { return _myPosY; }
            set
            {
                if (value != _myPosY)
                {
                    _myPosY = value;
                    InvokePropertyChangeEvent();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void InvokePropertyChangeEvent([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}