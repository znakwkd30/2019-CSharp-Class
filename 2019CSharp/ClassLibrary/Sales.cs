using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Sales
    {
        int result = 0;

        Seat seat;

        private int salesPrice = 0;
        public int SalesPrice
        {
            get { return salesPrice; }
            set { salesPrice = value; }
        }

        private List<Food> _SalesFoodList = new List<Food>();

        public List<Food> SalesFoodList
        {
            get { return _SalesFoodList; }
            set { _SalesFoodList = value; }
        }

        public List<Food> SetSalesFoodList(Food food)
        {
            foreach (Food fd in SalesFoodList)
            {
                if (fd.Equals(food))
                {
                    food.Count++;
                    return SalesFoodList;
                }
            }
            SalesFoodList.Add(food);
            food.Count++;
            Console.WriteLine("count: " + SalesFoodList.Count);
            return SalesFoodList;
        }

        public int changePrice()
        {
            foreach (Food fd in SalesFoodList)
            {
                result += fd.Price * fd.Count;
            }
            
            SalesPrice = result;
            Console.WriteLine("sales2: " + SalesPrice);

            return SalesPrice;
        }
    }
}
