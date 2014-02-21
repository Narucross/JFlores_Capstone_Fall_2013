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
                new CardItem{ProductName = "George Flores", ProductPrice = int.MaxValue},
                new CardItem{ProductName = "Lil Eric Flores", ProductPrice = int.MaxValue},
                new CardItem{ProductName = "Big Erick Flores", ProductPrice = int.MaxValue},
                new CardItem{ProductName = "Jelly Poole", ProductPrice = int.MaxValue},
                new CardItem{ProductName = "Henry Flores", ProductPrice = int.MaxValue},
                new CardItem{ProductName = "Stacie Flores", ProductPrice = int.MaxValue},
                new CardItem{ProductName = "Dillian Flores", ProductPrice = int.MaxValue},
                new CardItem{ProductName = "Claymore", ProductPrice = random.Next()},
                new CardItem{ProductName = "Dao Sabre", ProductPrice = random.Next()},
                new CardItem{ProductName = "Dirk", ProductPrice = random.Next()},
                new CardItem{ProductName = "Gladius", ProductPrice = random.Next()},
                new CardItem{ProductName = "Hanger", ProductPrice = random.Next()},
                new CardItem{ProductName = "Katana", ProductPrice = random.Next()},
            };
            StoreItems2 = new List<CardItem> {
                new CardItem{ProductName = "Margarita Flores", ProductPrice = int.MaxValue},
                new CardItem{ProductName = "Alberto Flores", ProductPrice = int.MaxValue},
                new CardItem{ProductName = "Alex Flores", ProductPrice = int.MaxValue},
                new CardItem{ProductName = "Susie Diaz", ProductPrice = int.MaxValue},
                new CardItem{ProductName = "Noel Diaz", ProductPrice = int.MaxValue},
                new CardItem{ProductName = "Noeh Diaz", ProductPrice = int.MaxValue},
                new CardItem{ProductName = "Pita Diaz", ProductPrice = int.MaxValue},
                new CardItem{ProductName = "Bella Flores", ProductPrice = int.MaxValue},
                new CardItem{ProductName = "Razor", ProductPrice = random.Next()},
                new CardItem{ProductName = "Rapier", ProductPrice = random.Next()},
                new CardItem{ProductName = "Seax", ProductPrice = random.Next()},
                new CardItem{ProductName = "Scimitar", ProductPrice = random.Next()},
                new CardItem{ProductName = "Xiphos", ProductPrice = random.Next()},
            };
            BoughtItems = new List<CardItem>(); //ones who are with me now...

        }
    }//end of class
}//end of namespace