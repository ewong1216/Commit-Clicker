﻿using System;
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

        public Data data = new Data();

        public MainPage()
        {
            this.InitializeComponent();
            data.commitsIncrement = 1;
            InnerFrame.Navigate(typeof(ButtonPage), data);
        }

        private void NavigateButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (b.Name.Equals("UpgradesButton"))
            {
                InnerFrame.Navigate(typeof(UpgradesPage), data);
            }
            else if (b.Name.Equals("SpecialButton"))
            {
                InnerFrame.Navigate(typeof(SpecialPage), data);
            }
            else if (b.Name.Equals("CustomizeButton"))
            {
                InnerFrame.Navigate(typeof(CustomizePage));
            }
            else if(b.Name.Equals("AchievementsButton"))
            {
                InnerFrame.Navigate(typeof(AchievementsPage));
            }
        }
    }
}
