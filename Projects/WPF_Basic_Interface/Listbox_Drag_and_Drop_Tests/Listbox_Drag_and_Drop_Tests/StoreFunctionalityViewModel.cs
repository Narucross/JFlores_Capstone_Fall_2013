using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Listbox_Drag_and_Drop_Tests.Models;

namespace Listbox_Drag_and_Drop_Tests
{
    public class StoreFunctionalityViewModel
    {
        public List<CardItem> StoreItems1 { get; set; }
        public List<CardItem> StoreItems2 { get; set; }
        public List<CardItem> BoughtItems { get; set; }

        public StoreFunctionalityViewModel()
        {
            var random = new Random(42);
            StoreItems1 = new List<CardItem>
            {
                new CardItem{ProductName = "Claymore", ProductPrice = random.Next()},
                new CardItem{ProductName = "Dao Sabre", ProductPrice = random.Next()},
                new CardItem{ProductName = "Dirk", ProductPrice = random.Next()},
                new CardItem{ProductName = "Gladius", ProductPrice = random.Next()},
                new CardItem{ProductName = "Hanger", ProductPrice = random.Next()},
                new CardItem{ProductName = "Katana", ProductPrice = random.Next()},
            };
            StoreItems2 = new List<CardItem> {
                new CardItem{ProductName = "Razor", ProductPrice = random.Next()},
                new CardItem{ProductName = "Rapier", ProductPrice = random.Next()},
                new CardItem{ProductName = "Seax", ProductPrice = random.Next()},
                new CardItem{ProductName = "Scimitar", ProductPrice = random.Next()},
                new CardItem{ProductName = "Xiphos", ProductPrice = random.Next()},
            };
            BoughtItems = new List<CardItem>();

        }
    }//end of class
}//end of namespace