﻿using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace _2019CSharp
{
    /// <summary>
    /// Interaction logic for SeatCtrl.xaml
    /// </summary>
    public partial class SeatCtrl : UserControl
    {
        DispatcherTimer myTimer = new DispatcherTimer();

        public SeatCtrl()
        {
            InitializeComponent();
            this.Loaded += SeatCtrl_Loaded;

            myTimer.Interval = new TimeSpan(0, 0, 1);
            myTimer.Tick += myTimer_Tick;
            myTimer.Start();

            orderCtrl.ShowSeatCtrl += OrderCtrl_ShowSeatCtrl;
        }

        private void SeatCtrl_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("SeatCtrl_Loaded");
            App.seat.Load();
    #if true
            lvSeat.ItemsSource = App.seat.seatList;
            
    #else
                // LoadMenu();
    #endif
        }

        private void OrderCtrl_ShowSeatCtrl(object sender, OrderArgs args)
        {
            string msg = args.tableId + "번 테이블 주문 완료";

            MessageBox.Show(msg);

            orderCtrl.Visibility = Visibility.Collapsed;
            seatCtrl.Visibility = Visibility.Visible;
        }

        void myTimer_Tick(object sender, EventArgs e)
        {
            clock.Text = DateTime.Now.ToString();
        }


        private void SeatList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Seat seat = lvSeat.SelectedItem as Seat;
            
            string selectedCategory = seat.id.ToString();
            
            orderCtrl.SetTableId(selectedCategory);
            
            orderCtrl.Visibility = Visibility.Visible;
            seatCtrl.Visibility = Visibility.Collapsed;

            if (seat == null) return;
        }
    }
}