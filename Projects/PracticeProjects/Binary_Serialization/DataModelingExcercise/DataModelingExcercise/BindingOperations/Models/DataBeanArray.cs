using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModelingExcercise.BindingOperations.Models
{
    public class DataBeanArray
    {
        public List<DataBean> _MyBeans { get; set; }

        public DataBeanArray()
        {
            _MyBeans = genericStuff();
        }

        private List<DataBean> genericStuff()
        {
            short value = 1;
            var myList = new DataBean[]{
                newBean("John",value++), newBean("Jacob",value++), newBean("JingleHeimer",value++), newBean("Smidth",value++), 
                newBean("Annie",value++), newBean("Irelia",value++), newBean("Katarina",value++), newBean("Sona",value++), 
                newBean("Joshua ;)",value++), newBean("Joshua",value++), newBean("Garen",value++), newBean("Jax",value++), 
           };
            return new List<DataBean>(myList.AsEnumerable());
        }

        private DataBean newBean(String name, int number)
        {
            return new DataBean() { MyName = name, MyNumber = number, MyHeight = 0, MyWidth = 0, MyPosX = 0, MyPosY = 0 };
        }
    }
}
