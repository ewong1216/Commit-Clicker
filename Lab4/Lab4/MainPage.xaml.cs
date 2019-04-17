using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Lab4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            financialNavigate();
            FinancialListBoxItem.IsSelected = true;
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            SplitView.IsPaneOpen = !SplitView.IsPaneOpen;
        }

        private void IconsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FinancialListBoxItem.IsSelected)
            {
                financialNavigate();
            }
            else if (FoodListBoxItem.IsSelected)
            {
                foodNavigate();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            financialNavigate();
            FinancialListBoxItem.IsSelected = true;
            FoodListBoxItem.IsSelected = false;
        }

        private void financialNavigate()
        {
            MainPageFrame.Navigate(typeof(Financial));
            TitleTextBlock.Text = "Financial";
            BackButton.Visibility = Visibility.Collapsed;
        }

        private void foodNavigate()
        {
            MainPageFrame.Navigate(typeof(Food));
            TitleTextBlock.Text = "Food";
            BackButton.Visibility = Visibility.Visible;
        }
    }
}
