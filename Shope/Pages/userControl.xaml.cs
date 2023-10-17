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
    /// Логика взаимодействия для userControl.xaml
    /// </summary>
    public partial class userControl : Page
    {
        public userControl(Product product)
        {
            InitializeComponent();
            //if(product.MainImagePath == null)

            MainImage.Source = new BitmapImage(new Uri(@"/Resources/NoImage.png", UriKind.Relative));
            TitleTb.Text = product.Title;
            NewPrice.Text = product.CostDiscount;
            OldPrice.Visibility = product.CostVisibility;
            EvalutionTb.Text = product.OverrideFeedback;
            OldPrice.Text = product.Cost.ToString("N0");
            BasketBt.Source = new BitmapImage(new Uri(@"/Resources/Basket.png", UriKind.Relative));
            LikeBt.Source = new BitmapImage(new Uri(@"/Resources/Heart.png", UriKind.Relative));
            StatisticBt.Source = new BitmapImage(new Uri(@"/Resources/Statistik.png", UriKind.Relative));
        }
    }
}
