using Shope.Components;
using Shope.Components.PartialClass;
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

namespace Shope.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductionList.xaml
    /// </summary>
    public partial class ProductionList : Page
    {
        public ProductionList()
        {
            InitializeComponent();
            if (App.isAdmin == false) AddBtn.Visibility = Visibility.Hidden;
            else AddBtn.Visibility = Visibility.Visible;

            var productList = App.db.Product.ToList();
            Refresh();
        }
        

        private void Refresh()
        {
            IEnumerable<Product> productSortList = App.db.Product;
            if (SortCB.SelectedIndex == 1)
            {
                productSortList = productSortList.OrderBy(x => x.Cost);
            }
            else if (SortCB.SelectedIndex == 2)
            {
                productSortList = productSortList.OrderByDescending(x => x.NewCost);
            }
            ProductionWP.Children.Clear();
            foreach (var service in productSortList)
            {
                ProductionWP.Children.Add(new ProductionUC(service));
            }
            CountDataTb.Text = productSortList.Count() + " из " + App.db.Product.Count();
        }

        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponent("Добавление услуг", new AddEditPage(new Product())));
        }

        private void Korzina_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponent("Корзина", new OrderPage()));
        }
    }
}
