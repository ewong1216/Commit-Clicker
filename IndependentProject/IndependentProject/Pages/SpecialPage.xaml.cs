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
            Special s = ((FrameworkElement)sender).DataContext as Special;
            if(Data.Specialpoints >= s.Cost)
            {
                Data.Specialpoints -= s.Cost;
                s.Purchase();
            }
        }
    }
}
