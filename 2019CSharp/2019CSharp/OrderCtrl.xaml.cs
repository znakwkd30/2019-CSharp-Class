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

namespace _2019CSharp
{
    /// <summary>
    /// Interaction logic for OrderCtrl.xaml
    /// </summary>
    public partial class OrderCtrl : UserControl
    {
        string tableId;
        Food selectedFood;
        string sendMessage;

        public delegate void ShowSeatCtrlHandler(object sender, OrderArgs args);
        public event ShowSeatCtrlHandler ShowSeatCtrl;

        public OrderCtrl()
        {
            InitializeComponent();
            this.Loaded += OrderCtrl_Loaded;
        }

        private void OrderCtrl_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("OrderCtrl_Loaded");
            App.FoodData.Load();

            lvFood.ItemsSource = App.FoodData.lstFood;
            TotalPrice.Text = "0원";
            OrderPrice.Text = "0원";
        }
        
        // 메인 화면을 띄우는 함수
        private void Show_SeatCtrl(object sender, RoutedEventArgs e)
        {
            OrderArgs args = new OrderArgs();
            args.tableId = getTableId();

            if (ShowSeatCtrl != null)
            {
                ShowSeatCtrl(this, args);

                lvSelectFood.ItemsSource = new List<Food>();
                TotalPrice.Text = "0원";
            }
        }

        // tableId를 저장하는 함수
        public void SetTableId(string id)
        {
            tableId = id;
            tIdx.Text = tableId.ToString() + "번테이블";
        }

        // tableId를 반환하는 함수
        public string getTableId()
        {
            return tableId;
        }

        // 음식의 count를 감소시키는 함수
        private void BtnMinus_Click(object sender, RoutedEventArgs e)
        {
            Food food = (lvSelectFood.SelectedItem as Food);

            if (food == null) return;

            foreach (Seat seat in App.seatList)
            {
                if (tableId.Equals(seat.id))
                {
                    food.Count--;
                    if (food.Count == 0)
                    {
                        seat.SeatFoodlst.Remove(food);
                    }
                    seat.changePrice();
                    
                    TotalPrice.Text = seat.TotalPrice.ToString() + "원";
                    OrderPrice.Text = TotalPrice.Text;
                    lvSelectFood.Items.Refresh();

                    seat.Set_MenuList();

                    return;
                }
            }
        }

        // 선택한 카테고리를 받아오는 함수
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedCategory = ((ListViewItem)listBox.SelectedItem).Content.ToString();
            ListItemSet(selectedCategory);
        }

        // 각 카테고리별로 음식을 보여주는 함수
        private void ListItemSet(string category)
        {
            List<Food> CategoryFoodList = new List<Food>();

            if (category.ToString().Equals("All"))
            {
                lvFood.ItemsSource = App.FoodData.lstFood;
                lvFood.Items.Refresh();
                return;
            }

            foreach (Food food in App.FoodData.lstFood)
            {
                if (food.Category.ToString().Equals(category))
                {
                    CategoryFoodList.Add(food);
                }
            }
            lvFood.ItemsSource = CategoryFoodList;
            lvFood.Items.Refresh();
        }

        // Food 데이터를 깊은 복사하는 함수
        private Food NewFood(Food food)
        {
            Food item = new Food();

            if (food == null)
                return food;
            
            Debug.Write(food);

            item.Name = food.Name;
            item.Price = food.Price;
            item.Count = food.Count;
            item.Category = food.Category;

            return item;
        }

        // 주문한 음식 및 가격을 Refresh하는 함수
        public void Refresh_List()
        {
            foreach (Seat seat in App.seatList)
            {
                if (tableId.Equals(seat.id))
                {
                    lvSelectFood.ItemsSource = seat.SeatFoodlst;
                    TotalPrice.Text = seat.TotalPrice.ToString() + "원";
                }
            }
        }

        // 음식을 선택했을 때 주문 내역 리스트에 음식 저장
        private void LvFood_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedFood = NewFood(lvFood.SelectedItem as Food);

            if (selectedFood == null) return;

            foreach (Seat seat in App.seatList)
            {
                if (tableId.Equals(seat.id))
                {
                    lvSelectFood.ItemsSource = seat.SetFoodList(selectedFood);
                    seat.changePrice();

                    TotalPrice.Text = seat.TotalPrice.ToString() + "원";

                    lvSelectFood.Items.Refresh();
                    lvFood.SelectedIndex = -1;
                }
            }
        }

        // 주문한 음식 목록과 가격을 출력하는 함수
        private void Show_OrderMenu()
        {
            foreach (Seat seat in App.seatList)
            {
                if (tableId.Equals(seat.id))
                {
                    payFood.ItemsSource = lvSelectFood.ItemsSource;
                    OrderPrice.Text = TotalPrice.Text;

                    payFood.Items.Refresh();
                }
            }
        }

        // 결제하시겠습니까? 출력 및 주문한 음식 목록을 출력하는 함수
        private void show_check(object sender, RoutedEventArgs e)
        {
            bord.Visibility = Visibility.Visible;

            if (check.Visibility == Visibility.Collapsed)
            {
                check.Visibility = Visibility.Visible;
                OrderPrice.Visibility = Visibility.Visible;
                payFood.Visibility = Visibility.Visible;
                Show_OrderMenu();
            }
            else
            {
                bord.Visibility = Visibility.Collapsed;
                check.Visibility = Visibility.Collapsed;
                OrderPrice.Visibility = Visibility.Collapsed;
                payFood.Visibility = Visibility.Collapsed;
            }
        }

        // 결제 방법에 대해 묻는 함수
        private void show_pay(object sender, RoutedEventArgs e)
        {
            if (pay.Visibility == Visibility.Collapsed)
            {
                pay.Visibility = Visibility.Visible;
                check.Visibility = Visibility.Collapsed;
                OrderPrice.Visibility = Visibility.Collapsed;
                payFood.Visibility = Visibility.Collapsed;
            }
            else
            {
                pay.Visibility = Visibility.Collapsed;
                bord.Visibility = Visibility.Collapsed;
            }
        }

        // 결제가 완료되었을때 실행하는 함수
        private void show_complete(object sender, RoutedEventArgs e)
        {
            if (com.Visibility == Visibility.Collapsed)
            {
                pay.Visibility = Visibility.Collapsed;
                com.Visibility = Visibility.Visible;
                
                // 결제된 음식의 리스트를 Sales의 리스트에 저장 & 서버에 테이블별 매출액 전송
                foreach (Seat seat in App.seatList)
                {
                    if (tableId.Equals(seat.id))
                    {
                        App.sales.SetSalesFoodList(seat.SeatFoodlst);
                        App.sales.changePrice();

                        sendMessage = "@2208#" + seat.id.ToString() + "번 테이블 " + seat.TotalPrice.ToString() +"원 결제 완료.";

                        App.socket.Send_Message(sendMessage);

                        seat.time = string.Format("{0:D2}:{1:D2}:{2:D2}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                        orderTime.Text = seat.time;
                    }
                }

                // 주문 내역 초기화
                Remove_List();

                Execute(delegate ()
                {
                    com.Visibility = Visibility.Collapsed;
                    bord.Visibility = Visibility.Collapsed;
                }, 1000);
            }
        }

        // 비동기식으로 Execute에 들어간 내용을 second 값 만큼 기다리고 한 번 실행
        // async void의 경우 곧바로 호출자에게 제어를 돌려줌
        public static async void Execute(Action action, int second)
        {
            await Task.Delay(second); //Thread.sleep(second)와 기능이 같음 (비동기식)
            action();
        }

        // 전체 취소 버튼
        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            Remove_List();
        }
        
        // 주문 내역을 초기화하는 함수
        private void Remove_List()
        {
            foreach (Seat seat in App.seatList)
            {
                if (tableId.Equals(seat.id))
                {
                    seat.SeatFoodlst.Clear();
                    seat.changePrice();

                    TotalPrice.Text = seat.TotalPrice.ToString() + "원";
                    OrderPrice.Text = TotalPrice.Text;

                    lvSelectFood.Items.Refresh();
                    payFood.Items.Refresh();

                    seat.Set_MenuList();
                }
            }
        }
    }

    public class OrderArgs : EventArgs
    {
        public string tableId { get; set; }
    }
}
