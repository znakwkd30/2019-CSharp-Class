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
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : UserControl
    {
        public Order()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("MainWindow_Loaded");
            App.FoodData.Load();
#if true
            lvFood.ItemsSource = App.FoodData.lstFood;

#else
            //    LoadMenu();
#endif
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
            lvSelectFood.Items.Refresh();
            lvFood.SelectedIndex = -1;
        }

        private void MainBtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).OrderCtrl.Visibility = Visibility.Collapsed;
            ((MainWindow)Application.Current.MainWindow).OrderBtn.Visibility = Visibility.Visible;
        }

        private void AllMinus_Click(object sender, RoutedEventArgs e)
        {
            Food food = (lvFood.SelectedItem as Food);

            lvSelectFood.ItemsSource = App.seat.ResetFoodList();
            lvSelectFood.Items.Refresh();
        }
    }
}
