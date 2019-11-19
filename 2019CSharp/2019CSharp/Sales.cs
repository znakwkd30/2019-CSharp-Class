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

        // 결제된 음식을 받아와 그 음식의 count를 증가시키는 함수
        public void SetSalesFoodList(List<Food> food)
        {
            int countFood = 0;

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
                    salesFood.Price = salesFood.Count * App.FoodData.lstFood[countFood].Price;
                }
                countFood++;
            }
        }

        // Food 데이터를 깊은 복사하는 함수
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

        // 카테고리 별 가격과 전체 가격을 저장하는 함수
        public int changePrice()
        {
            int i = 0;
            result = 0;
            foreach (Food food in SalesFoodList)
            {
                if (food.Count != 0)
                {
                    result += App.FoodData.lstFood[i].Price * food.Count;

                    switch (food.Category)
                    {
                        case Category.eCategory.단품:
                            SinglePrice += App.FoodData.lstFood[i].Price * food.Count;
                            break;
                        case Category.eCategory.식사:
                            MealPrice += App.FoodData.lstFood[i].Price * food.Count;
                            break;
                        case Category.eCategory.음료:
                            DrinkPrice += App.FoodData.lstFood[i].Price * food.Count;
                            break;
                    }
                }
                AllPrice = result;
                i++;
            }

            return AllPrice;
        }
    }
}