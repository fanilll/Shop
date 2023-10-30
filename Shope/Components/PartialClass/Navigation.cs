using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Shope.Components.PartialClass
{
    internal class Navigation
    {
        private static List<PageComponent> components = new List<PageComponent>();
        public static MainWindow mainWindow;
        public static void ClearHistory()
        {
            App.isAdmin = false;
            components.Clear();
        }
        public static void Update(PageComponent pageComponent)
        {
            mainWindow.TitleTB.Text = pageComponent.Title;
            mainWindow.BackButt.Visibility = components.Count() > 1 ? System.Windows.Visibility.Visible : System.Windows.Visibility.Hidden;
            mainWindow.ExitButt.Visibility = App.isAdmin ? System.Windows.Visibility.Visible : System.Windows.Visibility.Hidden;
            mainWindow.MainFrame.Navigate(pageComponent.Page);
        }
        public static void NextPage(PageComponent pageComponent)
        {
            components.Add(pageComponent);
            Update(pageComponent);
        }
        public static void BackPage()
        {
            if (components.Count > 1)
            {
                components.RemoveAt(components.Count - 1);
                Update(components[components.Count - 1]);
            }
        }
    }

    class PageComponent
    {
        public string Title { get; set; }
        public Page Page { get; set; }
        public PageComponent(string tile, Page page)
        {
            Page = page;
            Title = tile;
        }
    }
}
