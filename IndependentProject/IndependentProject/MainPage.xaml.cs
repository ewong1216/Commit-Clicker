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
            Data.Commits = 99999999999;
            Data.CommitsPerSecond = 0;
            Data.Specialpoints = 0;
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
            Data.AllTimeCommits += Data.CommitsPerSecond;
            foreach (Achievement a in Data.Achievements)
            {
                if (!a.Unlocked)
                {
                    if (a.Update())
                    {
                        Data.AchievementsUnlocked++;
                        PopupText.Text = a.Name;
                        Popup.IsOpen = true;
                    }
                }
            }
            Data.Seconds+=10000000;
            Player.Volume = Data.MusicVolume;
            ClickSound.Volume = Data.SoundVolume;
        }
        private void PopupButton_Click(object sender, RoutedEventArgs e)
        {
            Popup.IsOpen = false;
        }
        private void NavigateButton_Click(object sender, RoutedEventArgs e)
        {
            Click();
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
            else if (b.Name.Equals("StatsButton"))
            {
                InnerFrame.Navigate(typeof(StatsPage), Data);
            }
            else if(b.Name.Equals("AchievementsButton"))
            {
                InnerFrame.Navigate(typeof(AchievementsPage), Data);
            }
            else if (b.Name.Equals("OptionsButton"))
            {
                InnerFrame.Navigate(typeof(OptionsPage), Data);
                OptionsButton.Visibility = Visibility.Collapsed;
            }
            BackButton.Visibility = Visibility.Visible;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Click();
            InnerFrame.Navigate(typeof(ButtonPage), Data);
            BackButton.Visibility = Visibility.Collapsed;
            OptionsButton.Visibility = Visibility.Visible;
        }

        public void Click()
        {
            ClickSound.Play();
            Data.Clicks++;
        }
    }
}
