using IndependentProject.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace IndependentProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UpgradesPage : Page
    {
        Data Data;

        public UpgradesPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Data = (Data)e.Parameter;      
        }

        private void Upgrade_Click(object sender, RoutedEventArgs e)
        {
            ClickSound.Play();
            Data.Clicks++;
            Upgrade u = ((FrameworkElement)sender).DataContext as Upgrade; //https://stackoverflow.com/questions/1168976/button-in-a-column-getting-the-row-from-which-it-came-on-the-click-event-handle
            if (u.Cost <= Data.Commits)
            {
                u.Helper.UpgradesMultiplier += u.CPSMultiplier;
                Data.Commits -= u.Cost;
                Data.Upgrades.Remove(u);
                Data.PastUpgrades.Add(u);
                u.Helper.SetCPS(1.0 + Data.Specials.ElementAt(2).Multiplier);
                Data.SetTotalCPS();
            }
        }

        private void HireUpgrade_Click(object sender, RoutedEventArgs e)
        {
            ClickSound.Play();
            Data.Clicks++;
            Helper helper = ((FrameworkElement)sender).DataContext as Helper; //https://stackoverflow.com/questions/1168976/button-in-a-column-getting-the-row-from-which-it-came-on-the-click-event-handle
            if (Data.Commits >= helper.Cost)
            {
                Data.Commits -= helper.Cost;
                helper.LevelUp(1.0 - Data.Specials.ElementAt(0).Multiplier, 1.0 + Data.Specials.ElementAt(2).Multiplier);
                Data.SetTotalCPS();
            }
        }
    }
}
