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
        public string CostDiscount
        {
            get
            {
                if (Discount == 0)
                    return Cost.ToString("N0") + " ₽";
                else
                    return (Cost - (Cost * (decimal)Discount / 100)).ToString("N0") + " ₽  ";
            }
        }
        public Visibility CostVisibility
        {
            get
            {
                if (Discount == 0)
                    return Visibility.Collapsed;
                else
                    return Visibility.Visible;
            }
        }

        public string OverrideFeedback
        {
            get
            {
                double sum = 0;

                foreach (var item in Feedback)
                {
                    sum += item.Evaluation;
                }
                if (Feedback.Count() >= 11 && Feedback.Count() <= 19)
                    return $"★ {(sum / Feedback.Count()).ToString("N2")}  {Feedback.Count()} отзывов";
                else if (Feedback.Count() == 1 || Feedback.Count() % 10 == 1)
                    return $"★ {(sum / Feedback.Count()).ToString("N2")}  {Feedback.Count()} отзыв";
                else if (Feedback.Count() % 10 >= 2 || Feedback.Count() % 10 <= 4)
                    return $"★ {(sum / Feedback.Count()).ToString("N2")}  {Feedback.Count()} отзывa";
                else
                    return $"★ {(sum / Feedback.Count()).ToString("N2")}  {Feedback.Count()} отзывов";

            }
        }

        public string GetImage
        {
            get
            {
                string g = "\u005c" + MainImagepPath.Replace(' ', '\0').Replace('/', '\u005c');

                return g;
            }
        }

    }
}
