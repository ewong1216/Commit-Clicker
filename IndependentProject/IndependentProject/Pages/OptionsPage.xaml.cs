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
    public sealed partial class OptionsPage : Page
    {
        Data Data;

        public OptionsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Data = (Data)e.Parameter;
            MusicSlider.Value = (int) (Data.MusicVolume * 100);
            SoundSlider.Value = (int) (Data.SoundVolume * 100);
        }

        private void MusicSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (Data != null)
            {
                Data.MusicVolume = (double)MusicSlider.Value / 100.0;
            }
        }

        private void SoundSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (Data != null)
            {
                Data.SoundVolume = (double)SoundSlider.Value / 100.0;
            }
        }

        private void RestoreToDefault_Click(object sender, RoutedEventArgs e)
        {
            MusicSlider.Value = 50;
            SoundSlider.Value = 50;
            Data.MusicVolume = 0.5;
            Data.SoundVolume = 0.5;
        }
    }
}
