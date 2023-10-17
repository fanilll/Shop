using Shope.Components;
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
    /// Логика взаимодействия для listPage.xaml
    /// </summary>
    public partial class listPage : Page
    {
        public listPage()
        {
            InitializeComponent();
            IEnumerable<Product> productSortList = App.db.Product;
            foreach (var product in productSortList)
            {
                MainWp.Children.Add(new userControl(product));
            }
        }
    }
}
