using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019CSharp
{
    public class Sales
    {
        int result = 0;
        bool flag = true;

        private int allPrice = 0;
        public int AllPrice
        {
            get { return allPrice; }
            set { allPrice = value; }
        }

        private int singlePrice = 0;
        public int SinglePrice
        {
            get { return singlePrice; }
            set { singlePrice = value; }
        }

        private int mealPrice = 0;
        public int MealPrice
        {
            get { return mealPrice; }
            set { mealPrice = value; }
        }

        private int drinkPrice = 0;
        public int DrinkPrice
        {
            get { return drinkPrice; }
            set { drinkPrice = value; }
        }

        public List<Food> _SalesFoodList = new List<Food>();

        public List<Food> SalesFoodList
        {
            get { return _SalesFoodList; }
            set { _SalesFoodList = value; }
        }

        public void SetSalesFoodList(List<Food> food)
        {
            if (flag)
            {
                for (int i = 0; i < App.FoodData.lstFood.Count; i++)
                {
                    _SalesFoodList.Add(NewFood(App.FoodData.lstFood[i]));
                }
                flag = false;
            }

            foreach (Food salesFood in SalesFoodList)
            {
                for (int i = 0; i < food.Count; i++)
                {
                    if (salesFood.Name.Equals(food[i].Name))
                    {
                        for (int j = food[i].Count; j > 0; j--)
                        {
                            salesFood.Count++;
                            food[i].Count--;
                            App.FoodData.lstFood[i].Count--;
                        }
                    }
                }
            }
        }

        private Food NewFood(Food food)
        {
            Food item = new Food();

            if (food == null)
                return food;

            item.Name = food.Name;
            item.Price = food.Price;
            item.Count = food.Count;
            item.Category = food.Category;

            return item;
        }

        public int changePrice()
        {
            result = 0;
            foreach (Food food in SalesFoodList)
            {
                if (food.Count != 0)
                {
                    if (food.Count != 0)
                        result += food.Price * food.Count;

                    switch (food.Category)
                    {
                        case Category.eCategory.단품:
                            SinglePrice += food.Price * food.Count;
                            break;
                        case Category.eCategory.식사:
                            MealPrice += food.Price * food.Count;
                            break;
                        case Category.eCategory.음료:
                            DrinkPrice += food.Price * food.Count;
                            break;
                    }
                }
                AllPrice = result;
            }

            return AllPrice;
        }
    }
}