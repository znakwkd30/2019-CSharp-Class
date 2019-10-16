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
    /// Interaction logic for StatisticCtrlxaml.xaml
    /// </summary>
    public partial class StatisticCtrlxaml : UserControl
    {
        public delegate void ShowSeatCtrlHandler();
        public event ShowSeatCtrlHandler ShowSeatCtrl;

        public StatisticCtrlxaml()
        {
            InitializeComponent();

            //salesPrice.Text = (App.sales.SalesPrice).ToString();
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
                payFood.ItemsSource = App.sales.SalesFoodList;
                payFood.Items.Refresh();
                return;
            }

            foreach (Food food in App.FoodData.lstFood)
            {
                if (food.Category.ToString().Equals(category))
                {
                    CategoryFoodList.Add(food);
                }
            }
            payFood.ItemsSource = CategoryFoodList;
            payFood.Items.Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShowSeatCtrl();
        }
    }

}
