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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace IndependentProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ButtonPage : Page
    {
        Data Data;

        public ButtonPage()
        {
            this.InitializeComponent();
        }

        private void CommitButton_Click(object sender, RoutedEventArgs e)
        {
            ClickSound.Play();
            Data.Clicks++;
            Data.Commits += Data.CommitsClickIncrement;
            Data.AllTimeCommits += Data.CommitsClickIncrement;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Data = (Data)e.Parameter;
        }
    }
}
