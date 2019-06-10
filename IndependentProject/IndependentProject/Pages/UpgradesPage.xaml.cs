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
            foreach(Helper h in Data.Helpers)
            {
                h.SetCost(1.0 - Data.Specials.ElementAt(0).Multiplier);
            }
            foreach(Upgrade u in Data.Upgrades)
            {
                u.Cost = (int) (u.Cost * (1.0 - Data.Specials.ElementAt(1).Multiplier));
            }
        }

        private void Upgrade_Click(object sender, RoutedEventArgs e)
        {
            ClickSound.Play();
            Data.Clicks++;
            Upgrade u = ((FrameworkElement)sender).DataContext as Upgrade;
            if(u.Cost <= Data.Commits)
            {
                u.Helper.Multiplier += u.Multiplier;
                Data.Commits -= u.Cost;
                Data.Upgrades.Remove(u);
                Data.PastUpgrades.Add(u);
                Data.CommitsPerSecond -= u.Helper.CPS;
                u.Helper.SetCPS();
                Data.CommitsPerSecond += u.Helper.CPS;
            }
        }

        private void HireUpgrade_Click(object sender, RoutedEventArgs e)
        {
            ClickSound.Play();
            Data.Clicks++;
            Helper helper = ((FrameworkElement)sender).DataContext as Helper;
            if (Data.Commits >= helper.Cost)
            {
                Data.Commits -= helper.Cost;
                Data.CommitsPerSecond -= helper.CPS;
                helper.LevelUp(1.0 - Data.Specials.ElementAt(0).Multiplier);
                Data.CommitsPerSecond += helper.CPS;
            }
        }
    }
}
