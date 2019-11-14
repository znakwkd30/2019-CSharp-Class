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
#if true
            lvFood.ItemsSource = App.FoodData.lstFood;
            TotalPrice.Text = "0원";
            OrderPrice.Text = "0원";
#else   
            //    LoadMenu();
#endif
        }
        
        private void OrderBtn_Click(object sender, RoutedEventArgs e)
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

        public void SetTableId(string id)
        {
            tableId = id;
            tIdx.Text = tableId.ToString() + "번테이블";
        }

        public string getTableId()
        {
            return tableId;
        }

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

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedCategory = ((ListViewItem)listBox.SelectedItem).Content.ToString();
            ListItemSet(selectedCategory);
        }

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
                check.Visibility = Visibility.Collapsed;
                bord.Visibility = Visibility.Collapsed;
                OrderPrice.Visibility = Visibility.Collapsed;
                payFood.Visibility = Visibility.Collapsed;
            }
        }

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

        private void show_complete(object sender, RoutedEventArgs e)
        {
            if (com.Visibility == Visibility.Collapsed)
            {
                pay.Visibility = Visibility.Collapsed;
                com.Visibility = Visibility.Visible;
                
                foreach (Seat seat in App.seatList)
                {
                    if (tableId.Equals(seat.id))
                    {
                        App.sales.SetSalesFoodList(seat.SeatFoodlst);
                        App.sales.changePrice();

                        sendMessage = "@2208#" + seat.id.ToString() + "번 테이블 " + seat.TotalPrice.ToString() +"원 결제 완료.";

                        App.socket.Send_Message(sendMessage);
                    }
                }

                Remove_List();

                Execute(delegate ()
                {
                    com.Visibility = Visibility.Collapsed;
                    bord.Visibility = Visibility.Collapsed;
                }, 1000);
            }
        }

        public static async void Execute(Action action, int timeoutInMilliseconds)
        {
            await Task.Delay(timeoutInMilliseconds);
            action();
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            Remove_List();
        }

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
