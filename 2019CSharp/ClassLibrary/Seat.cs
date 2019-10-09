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

        private int totalPrice;
        public int TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }

        public int plusPrice()
        {
            int result = 0;
            foreach(Food fd in SeatFoodlst)
            {
                result += fd.Price * fd.Count;
            }
            Console.WriteLine(result);
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
                if (fd.Equals(food))
                {
                    food.Count++;
                    return SeatFoodlst;
                }
            }
            SeatFoodlst.Add(food);
            food.Count++;
            Console.WriteLine(SeatFoodlst.Count);
            return SeatFoodlst;
        }

        bool isLoaded = false;

        public List<Seat> seatList;

        public void Load()
        {
            if (isLoaded) return;

            seatList = new List<Seat>()
                {
                    new Seat() { id="1" },
                    new Seat() { id="2" },
                    new Seat() { id="3" },
                    new Seat() { id="4" },
                    new Seat() { id="5" },
                    new Seat() { id="6" },
                };

            isLoaded = true;
        }
    }
}
