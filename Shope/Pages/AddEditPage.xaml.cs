using Microsoft.Win32;
using Shope.Components;
using Shope.Components.PartialClass;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Product product;
        public AddEditPage(Product _product)
        {
            InitializeComponent();
            product = _product;
            this.DataContext = product;
        }

        private void SaveButt_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (product.Cost < 0)
            {
                error.AppendLine("Услуга не может иметь такую цену!");
            }

            // если у нас такого объекта нет, соответственно, ид = 0
            if (product.Id == 0)
            {
                //если совпадают названия, то выдаем ошибку
                if (App.db.Product.Any(X => X.Title == product.Title))
                {
                    error.AppendLine("Такая услуга уже существует!");
                    MessageBox.Show(error.ToString());
                }
                else if (product.Title == "" || product.Cost == 0)
                {
                    error.AppendLine("Введите название или цену!");
                    MessageBox.Show(error.ToString());
                }
                else
                {
                    App.db.Product.Add(product);
                }
            }
            //вывод ошибкок
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            App.db.SaveChanges();
            MessageBox.Show("Сохранено!");
            Navigation.NextPage(new PageComponent("Список услуг", new ProductionList()));
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void EditImageButt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jpg|*.jepg|*.jepg"
            };
            if (openFile.ShowDialog() == true)
            {
                product.MainImage = File.ReadAllBytes(openFile.FileName);
                MainImage.Source = new BitmapImage(new Uri(openFile.FileName));
            }

        }
    }
}
