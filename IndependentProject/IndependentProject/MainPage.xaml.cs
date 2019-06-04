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

namespace IndependentProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public Data Data { get; set; } = new Data();
        private DispatcherTimer timer;
        public MainPage()
        {
            this.InitializeComponent();
            Data.CommitsClickIncrement = 1;
            Data.Commits = 0;
            Data.CommitsPerSecond = 0;
            InnerFrame.Navigate(typeof(ButtonPage), Data);
            BackButton.Visibility = Visibility.Collapsed;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.Tick += DispatcherTimer_Tick;
            timer.Start();
        }
        private void DispatcherTimer_Tick(object sender, object e)
        {
            Data.Commits += Data.CommitsPerSecond;
            Data.CheckAchievements();
        }
        private void NavigateButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            OptionsButton.Visibility = Visibility.Visible;
            if (b.Name.Equals("UpgradesButton"))
            {
                InnerFrame.Navigate(typeof(UpgradesPage), Data);
            }
            else if (b.Name.Equals("SpecialButton"))
            {
                InnerFrame.Navigate(typeof(SpecialPage), Data);
            }
            else if (b.Name.Equals("CustomizeButton"))
            {
                InnerFrame.Navigate(typeof(CustomizePage));
            }
            else if(b.Name.Equals("AchievementsButton"))
            {
                InnerFrame.Navigate(typeof(AchievementsPage), Data);
            }
            else if (b.Name.Equals("OptionsButton"))
            {
                InnerFrame.Navigate(typeof(OptionsPage));
                OptionsButton.Visibility = Visibility.Collapsed;
            }
            BackButton.Visibility = Visibility.Visible;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            InnerFrame.Navigate(typeof(ButtonPage), Data);
            BackButton.Visibility = Visibility.Collapsed;
            OptionsButton.Visibility = Visibility.Visible;
        }
    }
}
