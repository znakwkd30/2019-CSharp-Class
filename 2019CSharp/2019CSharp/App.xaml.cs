﻿using ClassLibrary;
using System;
using System.Collections.Generic;
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
        public static SeatCtrl seatCtrl = new SeatCtrl();
        public static Sales sales = new Sales();
    }
}
