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
            }
        }

        public void SetTableId(string id)
        {
            tableId = id;
        }

        public string getTableId()
        {
            return tableId;
        }

        private void BtnMinus_Click(object sender, RoutedEventArgs e)
        {
            Food food = (lvSelectFood.SelectedItem as Food);
            if (food == null) return;
            food.Count--;
            if (food.Count == 0)
            {
                App.seat.SeatFoodlst.Remove(food);
            }
            lvSelectFood.Items.Refresh();
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

        private void LvFood_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Food food = (lvFood.SelectedItem as Food);

            if (food == null) return;

            lvSelectFood.ItemsSource = App.seat.SetFoodList(food);
            App.seat.plusPrice();

            TotalPrice.Text = App.seat.TotalPrice.ToString();

            lvSelectFood.Items.Refresh();
            lvFood.SelectedIndex = -1;
        }

        private void show_pay(object sender, RoutedEventArgs e)
        {
            if (pay.Visibility == Visibility.Collapsed)
            {
                check.Visibility = Visibility.Collapsed;
                pay.Visibility = Visibility.Visible;
            }
            else
            {
                pay.Visibility = Visibility.Collapsed;
                bord.Visibility = Visibility.Collapsed;
            }
        }

        private void show_check(object sender, RoutedEventArgs e)
        {
            bord.Visibility = Visibility.Visible;

            if (check.Visibility == Visibility.Collapsed)
            {
                check.Visibility = Visibility.Visible;
            }
            else
            {
                check.Visibility = Visibility.Collapsed;
                bord.Visibility = Visibility.Collapsed;
            }
        }

        private void show_complete(object sender, RoutedEventArgs e)
        {
            if (com.Visibility == Visibility.Collapsed)
            {
                pay.Visibility = Visibility.Collapsed;
                com.Visibility = Visibility.Visible;

                Execute(delegate ()
                {
                    com.Visibility = Visibility.Collapsed;
                    bord.Visibility = Visibility.Collapsed;
                }, 3000);
            }
        }

        public static async void Execute(Action action, int timeoutInMilliseconds)
        {
            await Task.Delay(timeoutInMilliseconds);
            action();
        }
    }

    public class OrderArgs : EventArgs
    {
        public string tableId { get; set; }
    }
}
