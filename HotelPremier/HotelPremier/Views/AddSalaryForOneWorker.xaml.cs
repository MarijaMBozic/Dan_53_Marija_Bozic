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
    /// Interaction logic for AddSalaryForOneWorker.xaml
    /// </summary>
    public partial class AddSalaryForOneWorker : Window
    {
        private bool isValidSalary;
        public AddSalaryForOneWorker(HotelUser manager, HotelUser user, Worker worker)
        {
            InitializeComponent();
            this.DataContext = new AddSalaryForOneWorkerViewModel(manager, user, worker, this);
        }
        private void EditingSalaryEnabled()
        {
            if (isValidSalary)
            {
                btnSave.IsEnabled = true;
            }
            else
            {
                btnSave.IsEnabled = false;
            }
        }
        private void txtSalary_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSalary.Focus())
            {
                lblValidationSalary.Visibility = Visibility.Visible;
                lblValidationSalary.FontSize = 16;
                lblValidationSalary.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationSalary.Content = "The salary must be \nbetween 1-1000 !";
            }

            string patternSalary = @"^([0-9]{1,3})$";
            Match match = Regex.Match(txtSalary.Text, patternSalary, RegexOptions.IgnoreCase);

            bool isValid = int.TryParse(txtSalary.Text, out int inputvalu);

            if (!match.Success || inputvalu >1000 || inputvalu <1)
            {
                txtSalary.BorderBrush = new SolidColorBrush(Colors.Red);
                txtSalary.Foreground = new SolidColorBrush(Colors.Red);
                isValidSalary = false;
            }
            else
            {
                lblValidationSalary.Visibility = Visibility.Hidden;
                txtSalary.BorderBrush = new SolidColorBrush(Colors.Black);
                txtSalary.Foreground = new SolidColorBrush(Colors.Black);
                isValidSalary = true;
            }
            EditingSalaryEnabled();
        }
    }
}
