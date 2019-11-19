using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Seat
    {
        public string id { get; set; }

        public Food food { get; set; }

        public string time { get; set; }

        public string OrderedMenus { get; set; }

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
            bool isExist = false;

            foreach (Food fd in SeatFoodlst)
            {
                if (fd.Name.Equals(food.Name))
                {
                    isExist = true;
                    fd.Count++;
                    //OrderedMenus += fd.Name + " * " + fd.Count + Environment.NewLine;
                }
            }

            if(isExist == false)
            {
                SeatFoodlst.Add(food);
                food.Count++;
                //OrderedMenus += food.Name + " * " + food.Count + Environment.NewLine;
                Debug.WriteLine(OrderedMenus);
            }

            Set_MenuList();

            return SeatFoodlst;
        }

        public void Set_MenuList()
        {
            //모든 주문메뉴 -> string data로 변경
            OrderedMenus = string.Empty;
            foreach (Food fd in SeatFoodlst)
            {
                OrderedMenus += fd.Name + " * " + fd.Count + Environment.NewLine;
            }
        }
    }
}