using ClassLibrary;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for StatisticCtrl.xaml
    /// </summary>
    public partial class StatisticCtrl : UserControl
    {
        public delegate void ShowSeatCtrlHandler();
        public event ShowSeatCtrlHandler ShowSeatCtrl;
        
        public StatisticCtrl()
        {
            InitializeComponent();
            this.Loaded += StatisticCtrl_Loaded;
        }

        private void StatisticCtrl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        // 각 카테고리 클릭시 일어나는 이벤트 관리 함수
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedCategory = ((ListViewItem)listBox.SelectedItem).Content.ToString();
            Console.WriteLine("category: " + selectedCategory);
            ListItemSet(selectedCategory);
        }

        // 선택된 카테고리 별로 가격 및 메뉴를 띄우는 함수
        private void ListItemSet(string category)
        {
            List<Food> CategoryFoodList = new List<Food>();

            if (category.Equals("All"))
            {
                payFood.ItemsSource = App.sales.SalesFoodList;
                payFood.Items.Refresh();
                return;
            }

            foreach (Food food in App.sales.SalesFoodList)
            {
                if (food.Category.ToString().Equals(category))
                {
                    CategoryFoodList.Add(food);
                }
            }

            Set_Price(category);

            payFood.ItemsSource = CategoryFoodList;
            payFood.Items.Refresh();
        }

        // 메인 화면 띄워주는 함수
        private void Show_SeatCtrl(object sender, RoutedEventArgs e)
        {
            ShowSeatCtrl();
        }

        // 각 카테고리의 총 가격 띄우는 함수
        private void Set_Price(string category)
        {
            switch (category)
            {
                case "All":
                    salesPrice.Text = App.sales.AllPrice.ToString() + "원";
                    break;
                case "단품":
                    salesPrice.Text = App.sales.SinglePrice.ToString() + "원";
                    break;
                case "식사":
                    salesPrice.Text = App.sales.MealPrice.ToString() + "원";
                    break;
                case "음료":
                    salesPrice.Text = App.sales.DrinkPrice.ToString() + "원";
                    break;
            }
        }
    }
}
