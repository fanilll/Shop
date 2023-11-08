using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Shope.Components
{
    public partial class Product
    {
        public decimal NewCost
        {
            get
            {
                if (Discount == 0 || Discount is null) return Cost;
                else return Cost - Cost * (decimal)Discount / 100;
            }
        }

        public Visibility CostVisibility
        {
            get
            {
                if (Discount == 0)
                    return Visibility.Collapsed;
                else return Visibility.Visible;
            }
        }
    }
}
