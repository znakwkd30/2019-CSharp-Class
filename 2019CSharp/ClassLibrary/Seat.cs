using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Seat
    {
        public string id { get; set; }

        public Food food { get; set; }

        private int totalPrice;
        public int TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }

        public int changePrice()
        {
            int result = 0;

            foreach(Food fd in SeatFoodlst)
            {
                result += fd.Price * fd.Count;
            }
            
            TotalPrice = result;

            return TotalPrice;
        }

        private List<Food> _SeatFoodlst = new List<Food>();

        public List<Food> SeatFoodlst
        {
            get { return _SeatFoodlst; }
            set { _SeatFoodlst = value; }
        }

        public List<Food> SetFoodList(Food food)
        {
            foreach(Food fd in SeatFoodlst)
            {
                if (fd.Name.Equals(food.Name))
                {
                    fd.Count++;
                    return SeatFoodlst;
                }
            }
            SeatFoodlst.Add(food);
            food.Count++;
            return SeatFoodlst;
        }
    }
}