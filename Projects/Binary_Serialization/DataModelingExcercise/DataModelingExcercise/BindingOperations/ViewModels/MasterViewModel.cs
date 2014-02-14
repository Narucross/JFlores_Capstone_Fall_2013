using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModelingExcercise.BindingOperations.ViewModels
{
    public class MasterViewModel
    {
        public DataModelingExcercise.BindingOperations.Models.DataBeanArray _MyArray { get; set; }

        public String MasterName { get; set; }

        public MasterViewModel(String name)
        {
            _MyArray = new DataModelingExcercise.BindingOperations.Models.DataBeanArray();
            MasterName = name;
        }



    }//end of class
}//end of namespace