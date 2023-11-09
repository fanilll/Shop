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
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        productsComboBox.DataSource = productService.GetProducts(); // загрузка продуктов
        orderItemsGrid.DataSource = Order.Items; // привязка к коллекции позиций
    }

    private void AddProductButton_Click(object sender, EventArgs e)
    {
        // добавление выбранного продукта в заказ

        var product = (Product)productsComboBox.SelectedItem;
        var item = new OrderItem
        {
            Product = product,
            Quantity = 1
        };

        Order.Items.Add(item);
    }

    // сохранение заказа в БД
}
    }
}
