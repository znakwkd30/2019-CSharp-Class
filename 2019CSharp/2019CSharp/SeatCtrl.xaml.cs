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
        string sendMessage;

        public SeatCtrl()
        {
            InitializeComponent();
            this.Loaded += SeatCtrl_Loaded;
            serverConnection.Text = "서버 미연결...";

            // 메인화면 타이머 기능
            myTimer.Interval = new TimeSpan(0, 0, 1);
            myTimer.Tick += myTimer_Tick;
            myTimer.Start();

            orderCtrl.ShowSeatCtrl += OrderCtrl_ShowSeatCtrl;
            statisCtrl.ShowSeatCtrl += StatisticCtrl_ShowSeatCtrl;
        }

        private void SeatCtrl_Loaded(object sender, RoutedEventArgs e)
        {
            InitBrowser();
            App.Load();

            lvSeat.ItemsSource = App.seatList;
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

        // 통계 화면에서 메인 화면 표시하는 함수
        private void StatisticCtrl_ShowSeatCtrl()
        {
            seatCtrl.Visibility = Visibility.Visible;
            statisCtrl.Visibility = Visibility.Collapsed;
        }

        // 주문 화면에서 메인 화면 표시하는 함수
        private void OrderCtrl_ShowSeatCtrl(object sender, OrderArgs args)
        {
            orderCtrl.Visibility = Visibility.Collapsed;
            seatCtrl.Visibility = Visibility.Visible;

            lvSeat.Items.Refresh();
        }

        // 메인화면 타이머에 현재 시각 저장하는 함수
        void myTimer_Tick(object sender, EventArgs e)
        {
            clock.Text = DateTime.Now.ToString();
        }

        // 테이블 클릭시 그 테이블 id의 OrderCtrl로 이동하는 함수
        private void SeatList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Seat seat = lvSeat.SelectedItem as Seat;

            if (seat == null) return;

            string selectedId = seat.id.ToString();
                
            orderCtrl.SetTableId(selectedId);

            orderCtrl.Visibility = Visibility.Visible;
            seatCtrl.Visibility = Visibility.Collapsed;

            orderCtrl.orderTime.Text = seat.time;

            orderCtrl.Refresh_List();
        }

        // 통계 화면 띄우는 함수
        private void SalesBtn_Click(object sender, RoutedEventArgs e)
        {
            seatCtrl.Visibility = Visibility.Collapsed;
            statisCtrl.Visibility = Visibility.Visible;
            
            statisCtrl.salesPrice.Text = (App.sales.AllPrice).ToString() + "원";
        }

        // 서버에 총 매출액 전송하는 함수
        private void Send_Sales(object sender, RoutedEventArgs e)
        {
            sendMessage = "@All#총 매출액: " + App.sales.AllPrice.ToString() + "원.";
            App.socket.Send_Message(sendMessage);
        }

        // 서버와 연결하는 함수
        private void Connect_Socket(object sender, RoutedEventArgs e)
        {
            string msg = App.socket.Connect_Server();

            bool connection = App.socket.Return_Connection();

            if (connection)
            {
                serverConnection.Text = "연결중...";
                lastClose.Text = msg;
            }
        }

        // 서버와 연결을 끊는 함수
        private void Socket_Logout(object sender, RoutedEventArgs e)
        {
            string msg = App.socket.Close_Socket();
            
            bool connection = App.socket.Return_Connection();

            if (!connection)
            {
                lastConnect.Text = msg;
                serverConnection.Text = "서버 미연결...";
            }
        }
    }
}
