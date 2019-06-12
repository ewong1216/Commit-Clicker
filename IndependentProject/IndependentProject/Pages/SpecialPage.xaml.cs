using IndependentProject.Classes;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace IndependentProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SpecialPage : Page
    {

        Data Data;

        public SpecialPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Data = (Data)e.Parameter;
        }

        private void SpecialUpgrade_Click(object sender, RoutedEventArgs e)
        {
            ClickSound.Play();
            Data.Clicks++;
            Special s = ((FrameworkElement)sender).DataContext as Special; //https://stackoverflow.com/questions/1168976/button-in-a-column-getting-the-row-from-which-it-came-on-the-click-event-handle
            if (Data.Specialpoints >= s.Cost)
            {
                Data.Specialpoints -= s.Cost;
                s.Purchase();
                if(s.Name.Equals("Better Bargaining Skills"))
                {
                    foreach (Helper h in Data.Helpers)
                    {
                        h.SetCost(1.0 - Data.Specials.ElementAt(0).Multiplier);
                        h.SetCPS(1.0 + Data.Specials.ElementAt(2).Multiplier);
                    }
                }
                else if(s.Name.Equals("Cheaper Upgrades"))
                {
                    foreach (Upgrade u in Data.Upgrades)
                    {
                        u.Cost = (int)(u.Cost * (1.0 - Data.Specials.ElementAt(1).Multiplier));
                    }
                }
                else if(s.Name.Equals("Time Hacking"))
                {
                    foreach(Helper h in Data.Helpers)
                    {
                        h.SetCPS(1.0 + s.Multiplier);
                    }
                    Data.SetTotalCPS();
                }
            }
        }
    }
}
