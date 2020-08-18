using HotelPremier.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HotelPremier.Views
{
    /// <summary>
    /// Interaction logic for RequestView.xaml
    /// </summary>
    public partial class RequestView : Window
    {
        RequestViewModel requestViewModel;
        public RequestView(HotelUser worker, vwWorker hotelUser)
        {
            InitializeComponent();
            RequestViewModel requestViewModel = new RequestViewModel(worker, hotelUser, this);
            this.DataContext = requestViewModel;
            this.requestViewModel = requestViewModel;
        }

        private bool isValidStartDate;
        private bool isValidEndDate;
        private bool isValidRequest;

        private void IsAddRequestEnabled()
        {
            if (isValidStartDate &&
            isValidEndDate &&
            isValidRequest)
            {
                btnSave.IsEnabled = true;
            }
            else
            {
                btnSave.IsEnabled = false;
            }
        }

        private void dpStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

            if (dpStartDate.SelectedDate > DateTime.Now.AddDays(-20))
            {
                dpStartDate.BorderBrush = new SolidColorBrush(Colors.Red);
                dpStartDate.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationStartDate.Content = "The request can be\nsubmitted at least \n20 days in advance!";
                isValidStartDate = false;
            }
            else
            {
                lblValidationStartDate.Visibility = Visibility.Hidden;
                dpStartDate.BorderBrush = new SolidColorBrush(Colors.Black);
                dpStartDate.Foreground = new SolidColorBrush(Colors.Black);
                isValidStartDate = true;
            }
            IsAddRequestEnabled();
        }

        private void dpEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dpEndDate.SelectedDate > DateTime.Now.AddDays(-20))
            {
                dpEndDate.BorderBrush = new SolidColorBrush(Colors.Red);
                dpEndDate.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationEndDate.Content = "The request can be\nsubmitted at least \n20 days in advance!";
                isValidEndDate = false;
            }
            else if(dpStartDate.SelectedDate > dpEndDate.SelectedDate)
            {
                dpEndDate.BorderBrush = new SolidColorBrush(Colors.Red);
                dpEndDate.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationEndDate.Content = "End date can't be before start date!";
                isValidEndDate = false;
            }
            else
            {
                lblValidationEndDate.Visibility = Visibility.Hidden;
                dpEndDate.BorderBrush = new SolidColorBrush(Colors.Black);
                dpEndDate.Foreground = new SolidColorBrush(Colors.Black);
                isValidEndDate = true;
            }
            IsAddRequestEnabled();
        }

        private void txtReason_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtReason.Focus())
            {
                lblValidationReason.Visibility = Visibility.Visible;
                lblValidationReason.FontSize = 16;
                lblValidationReason.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationReason.Content = "The reason must contain \nat least 10 caracters!";
            }

            string patternFullName = @"^([a-zA-Z ]{10,100})$";
            Match match = Regex.Match(txtReason.Text, patternFullName, RegexOptions.IgnoreCase);

            if (!match.Success)
            {
                txtReason.BorderBrush = new SolidColorBrush(Colors.Red);
                txtReason.Foreground = new SolidColorBrush(Colors.Red);
                isValidRequest = false;
            }
            else
            {
                lblValidationReason.Visibility = Visibility.Hidden;
                txtReason.BorderBrush = new SolidColorBrush(Colors.Black);
                txtReason.Foreground = new SolidColorBrush(Colors.Black);
                isValidRequest = true;
            }
            IsAddRequestEnabled();
        }
    }
}
