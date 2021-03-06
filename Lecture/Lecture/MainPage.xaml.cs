﻿using System;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Lecture
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Book> Books;

        public MainPage()
        {
            this.InitializeComponent();

            Books = BookManager.GetBooks();
            
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var book = (Book)e.ClickedItem;
            ResultTextBlock.Text = "You selected " + book.Title;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Books.Add(new Book { BookId = 4, Title = "Title", Author = "Author", CoverImage = "Assets/Financial.png" });
        }

        /*
        private void CalenderView1_SelectedDatesChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
        {
            var selectedDates = sender.SelectedDates.Select(p => p.Date.Month.ToString() + "/" + p.Date.Day.ToString()).ToArray();

            var values = string.Join(", ", selectedDates);
            CalenderViewResultTextBlock.Text = values;
        }

        private void InnerFlyoutButton_Click(object sender, RoutedEventArgs e)
        {
            Flyout.Hide();
        }

        private string[] selectionItems = new string[] {"Ferdinand","Frank", "Frida", "Nigel", "Tag", "Tanya", "Tanner", "Todd"};

        private void AutoSuggestBox1_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            var autosuggestbox = (AutoSuggestBox)sender;
            var filtered = selectionItems.Where(p => p.StartsWith(autosuggestbox.Text)).ToArray();

            autosuggestbox.ItemsSource = filtered;
        }

        private void Slider1_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            ProgressBar1.Value = Slider1.Value;
        }
        */
        /*
        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            SplitView.IsPaneOpen = !SplitView.IsPaneOpen;
        }

        private void IconsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ShareListBoxItem.IsSelected)
            {
                ResultTextBox.Text = "Share";
            }
            else if (FavoritesListBoxItem.IsSelected)
            {
                ResultTextBox.Text = "Favorites";
            }
        }
        */
        /*
        private void CheckBox1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (CheckBox1.IsChecked.Value)
            {
                CheckBoxResultTextBlock.Text = "Yes";
            }
            else
            {
                CheckBoxResultTextBlock.Text = "No";
            }
        }

        private void Radio_Checked(object sender, RoutedEventArgs e)
        {
            if (YesRadio.IsChecked.Value)
            {
                RadioTextBlock.Text = "Yes";
            }
            else
            {
                RadioTextBlock.Text = "No";
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ComboBoxTextBlock != null)
            {
                ComboBox combo = (ComboBox)sender;
                ComboBoxItem item = (ComboBoxItem)combo.SelectedItem;

                ComboBoxTextBlock.Text = item.Content.ToString();
            }
        }

        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string s = "";
            foreach(object item in ListBox1.Items)
            {
                ListBoxItem listboxitem = (ListBoxItem)item;
                if (listboxitem.IsSelected)
                {
                    s += listboxitem.Content.ToString();
                }
            }

            ListBoxTextBlock.Text = s;
        }

        private void ToggleButton1_Click(object sender, RoutedEventArgs e)
        {
            if (ToggleButton1.IsChecked.HasValue)
            {
                if (ToggleButton1.IsChecked.Value)
                {
                    ToggleButtonTextBlock.Text = "True";
                }
                else
                {
                    ToggleButtonTextBlock.Text = "False";
                }
            }
            else
            {
                ToggleButtonTextBlock.Text = "Null";
            }
        }
        */



        /*
        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            InnerFrame.Navigate(typeof(Page1));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (InnerFrame.CanGoBack)
            {
                InnerFrame.GoBack();
            }
        }

        private void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            if (InnerFrame.CanGoForward)
            {
                InnerFrame.GoForward();
            }
        }

        */
        /*
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sv.IsPaneOpen = !sv.IsPaneOpen;
        }
        */
    }
}
