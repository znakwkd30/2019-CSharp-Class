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

        public static SeatCtrl seatCtrl = new SeatCtrl();
        public static Sales sales = new Sales();
    }
}
