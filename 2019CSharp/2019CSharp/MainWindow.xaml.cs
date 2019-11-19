using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _2019CSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Execute(() =>
            {
                seatCtrl.Visibility = Visibility.Visible;
                loadingScreen.Visibility = Visibility.Collapsed;
            }, 1000);
        }

        // 비동기식으로 Execute에 들어간 내용을 second 값 만큼 기다리고 한 번 실행
        // async void의 경우 곧바로 호출자에게 제어를 돌려줌
        public static async void Execute(Action action, int second)
        {
            await Task.Delay(second); //Thread.sleep(second)와 기능이 같음 (비동기식)
            action();
        }
    }
}
