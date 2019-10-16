using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Sales
    {
        private int salesPrice;
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
            Console.WriteLine("sales: " + SalesFoodList.Count);
            return SalesFoodList;
        }

        public int changePrice()
        {
            int result = 0;

            foreach (Food fd in SalesFoodList)
            {
                result += fd.Price * fd.Count;
            }

            Console.WriteLine("sales: " + result);
            SalesPrice = result;

            return SalesPrice;
        }
    }
}
