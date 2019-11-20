using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace _2019CSharp
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        public static FoodDataSource FoodData = new FoodDataSource();
        public static OrderArgs OrderArg = new OrderArgs();
        public static Seat seat = new Seat();
        
        public static bool isLoaded = false;

        public static List<Seat> seatList;

        public static void Load()
        {
            if (isLoaded) return;

            seatList = new List<Seat>()
            {
                new Seat() { id="1", SeatFoodlst = new List<Food>() },
                new Seat() { id="2", SeatFoodlst = new List<Food>() },
                new Seat() { id="3", SeatFoodlst = new List<Food>() },
                new Seat() { id="4", SeatFoodlst = new List<Food>() },
                new Seat() { id="5", SeatFoodlst = new List<Food>() },
                new Seat() { id="6", SeatFoodlst = new List<Food>() },
            };

            isLoaded = true;
        }
        
        // 비동기식으로 Execute에 들어간 내용을 second 값 만큼 기다리고 한 번 실행
        // async void의 경우 곧바로 호출자에게 제어를 돌려줌
        public static async void Execute(Action action, int second)
        {
            await Task.Delay(second); //Thread.sleep(second)와 기능이 같음 (비동기식)
            action();
        }

        // Food 데이터를 깊은 복사하는 함수
        public static Food NewFood(Food food)
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

        public static SeatCtrl seatCtrl = new SeatCtrl();
        public static Sales sales = new Sales();
        public static ServerClient socket = new ServerClient();
    }
}
