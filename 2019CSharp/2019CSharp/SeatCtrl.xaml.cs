using CefSharp;
using CefSharp.Wpf;
using ClassLibrary;
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
            statisCtrl.ShowSeatCtrl += StatisticCtrl_ShowSeatCtrl;
        }

        private void SeatCtrl_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("SeatCtrl_Loaded");
            InitBrowser();
            App.Load();
    #if true
            lvSeat.ItemsSource = App.seatList;
    #else
                // LoadMenu();

    #endif
        }

        private ChromiumWebBrowser browser;

        public void InitBrowser()
        {
            CefSettings settings = new CefSettings();
            settings.CefCommandLineArgs.Add("disable-usb-keyboard-detect", "1");
            Cef.Initialize(settings);

            browser = new ChromiumWebBrowser();
            browser.Address = "http://youtube.com";
            musicCtrl.youtube.Children.Add(browser);
        }

        private void StatisticCtrl_ShowSeatCtrl()
        {
            seatCtrl.Visibility = Visibility.Visible;
            statisCtrl.Visibility = Visibility.Collapsed;
        }

        private void OrderCtrl_ShowSeatCtrl(object sender, OrderArgs args)
        {
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

            orderCtrl.Refresh_List();

            if (seat == null) return;
        }

        private void SalesBtn_Click(object sender, RoutedEventArgs e)
        {
            seatCtrl.Visibility = Visibility.Collapsed;
            statisCtrl.Visibility = Visibility.Visible;
            
            statisCtrl.salesPrice.Text = (App.sales.AllPrice).ToString() + "원";
        }
    }
}
