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
    /// Interaction logic for AddWorkerView.xaml
    /// </summary>
    public partial class AddWorkerView : Window
    {
        private bool isValidFullName;
        private bool isValiDate;
        private bool isValidEmail;
        private bool isValidUsername;
        private bool isValidPassword;
        private bool isValidHotelFloor;
        private bool isValidGender;
        private bool isValidCitizenship;
        private bool isValidEngagment;
        private bool isValidWorkExperience;
        private bool isValidQualificationLevel;

        public AddWorkerView()
        {
            InitializeComponent();
            this.DataContext = new AddWorkerViewModel(this);
        }

        private void IsAddingNewWorkerEnabled()
        {
            if (isValidFullName &&
            isValiDate &&
            isValidEmail &&
            isValidUsername &&
            isValidPassword &&
            isValidHotelFloor &&
            isValidGender &&
            isValidCitizenship &&
            isValidEngagment &&
            isValidQualificationLevel &&
            isValidWorkExperience)
            {
                btnSave.IsEnabled = true;
            }
            else
            {
                btnSave.IsEnabled = false;
            }
        }       

        private void cmbGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbGender.Focus())
            {
                lblValidationGender.Visibility = Visibility.Visible;
                lblValidationGender.FontSize = 16;
                lblValidationGender.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationGender.Content = "You have to select Qualification Level!";
            }

            if (cmbGender.SelectedItem == null)
            {
                lblValidationGender.BorderBrush = new SolidColorBrush(Colors.Red);
                lblValidationGender.Foreground = new SolidColorBrush(Colors.Red);
                isValidGender = false;
            }
            else
            {
                lblValidationGender.BorderBrush = new SolidColorBrush(Colors.Black);
                lblValidationGender.Foreground = new SolidColorBrush(Colors.Black);
                isValidGender = true;
            }
            IsAddingNewWorkerEnabled();
        }

        private void cmbEngagment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbEngagment.Focus())
            {
                lblValidationEngagment.Visibility = Visibility.Visible;
                lblValidationEngagment.FontSize = 16;
                lblValidationEngagment.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationEngagment.Content = "You have to select Qualification Level!";
            }

            if (cmbEngagment.SelectedItem == null)
            {
                lblValidationEngagment.BorderBrush = new SolidColorBrush(Colors.Red);
                lblValidationEngagment.Foreground = new SolidColorBrush(Colors.Red);
                isValidEngagment = false;
            }
            else
            {
                lblValidationEngagment.BorderBrush = new SolidColorBrush(Colors.Black);
                lblValidationEngagment.Foreground = new SolidColorBrush(Colors.Black);
                isValidEngagment = true;
            }
            IsAddingNewWorkerEnabled();
        }       

        private void txtCitizenship_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtCitizenship.Focus())
            {
                lblValidationCitizenship.Visibility = Visibility.Visible;
                lblValidationCitizenship.FontSize = 16;
                lblValidationCitizenship.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationCitizenship.Content = "The citizenship must contain \nat least 5 caracters!";
            }

            string patternCitizenship = @"^([a-zA-Z]{5,100})$";
            Match match = Regex.Match(txtCitizenship.Text, patternCitizenship, RegexOptions.IgnoreCase);

            if (!match.Success)
            {
                txtCitizenship.BorderBrush = new SolidColorBrush(Colors.Red);
                txtCitizenship.Foreground = new SolidColorBrush(Colors.Red);
                isValidCitizenship = false;
            }
            else
            {
                lblValidationCitizenship.Visibility = Visibility.Hidden;
                txtCitizenship.BorderBrush = new SolidColorBrush(Colors.Black);
                txtCitizenship.Foreground = new SolidColorBrush(Colors.Black);
                isValidCitizenship = true;
            }
            IsAddingNewWorkerEnabled();
        }

        private void txtFullname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtFullname.Focus())
            {
                lblValidationFullname.Visibility = Visibility.Visible;
                lblValidationFullname.FontSize = 16;
                lblValidationFullname.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationFullname.Content = "The full name must contain \nat least 10 caracters!";
            }

            string patternFullName = @"^([a-zA-Z ]{10,100})$";
            Match match = Regex.Match(txtFullname.Text, patternFullName, RegexOptions.IgnoreCase);

            if (!match.Success)
            {
                txtFullname.BorderBrush = new SolidColorBrush(Colors.Red);
                txtFullname.Foreground = new SolidColorBrush(Colors.Red);
                isValidFullName = false;
            }
            else
            {
                lblValidationFullname.Visibility = Visibility.Hidden;
                txtFullname.BorderBrush = new SolidColorBrush(Colors.Black);
                txtFullname.Foreground = new SolidColorBrush(Colors.Black);
                isValidFullName = true;
            }
            IsAddingNewWorkerEnabled();
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtEmail.Focus())
            {
                lblValidationEmail.Visibility = Visibility.Visible;
                lblValidationEmail.FontSize = 16;
                lblValidationEmail.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationEmail.Content = "The email is not valid!";
            }

            string patterntxtEmail = @"^([a-zA-Z0-9_\-\\.]+)@([a-zA-Z0-9_\-\\.]+)\.([a-zA-Z]{2,5})$";
            Match match = Regex.Match(txtEmail.Text, patterntxtEmail, RegexOptions.IgnoreCase);

            if (!match.Success)
            {
                lblValidationEmail.BorderBrush = new SolidColorBrush(Colors.Red);
                lblValidationEmail.Foreground = new SolidColorBrush(Colors.Red);
                isValidEmail = false;
            }
            else
            {
                lblValidationEmail.Visibility = Visibility.Hidden;
                txtEmail.BorderBrush = new SolidColorBrush(Colors.Black);
                txtEmail.Foreground = new SolidColorBrush(Colors.Black);
                isValidEmail = true;
            }
            IsAddingNewWorkerEnabled();
        }

        private void dpDateOfBirth_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            int currentYear = DateTime.Now.Year;
            int choosenDate = 0;
            if (dpDateOfBirth.SelectedDate != null)
            {
                choosenDate = dpDateOfBirth.SelectedDate.Value.Year;
            }

            if (!dpDateOfBirth.SelectedDate.HasValue)
            {
                dpDateOfBirth.BorderBrush = new SolidColorBrush(Colors.Red);
                dpDateOfBirth.Foreground = new SolidColorBrush(Colors.Red);
                isValiDate = false;
            }
            else if ((currentYear - choosenDate) < 18)
            {
                dpDateOfBirth.BorderBrush = new SolidColorBrush(Colors.Red);
                dpDateOfBirth.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationDateOfBirth.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationDateOfBirth.Content = "The person must be of legal age!";
                isValiDate = false;
            }
            else if ((currentYear - choosenDate) > 80)
            {
                dpDateOfBirth.BorderBrush = new SolidColorBrush(Colors.Red);
                dpDateOfBirth.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationDateOfBirth.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationDateOfBirth.Content = "Invalid year!";
                isValiDate = false;
            }
            else
            {
                lblValidationDateOfBirth.Visibility = Visibility.Hidden;
                dpDateOfBirth.BorderBrush = new SolidColorBrush(Colors.Black);
                dpDateOfBirth.Foreground = new SolidColorBrush(Colors.Black);
                isValiDate = true;
            }
            IsAddingNewWorkerEnabled();
        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtUsername.Focus())
            {
                lblValidationUsername.Visibility = Visibility.Visible;
                lblValidationUsername.FontSize = 16;
                lblValidationUsername.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationUsername.Content = "The username contains \nat least 5 characters!";
            }

            string patternUserName = @"^([a-zA-Z0-9]{5,100})$";
            Match match = Regex.Match(txtUsername.Text, patternUserName, RegexOptions.IgnoreCase);

            if (!match.Success)
            {
                txtUsername.BorderBrush = new SolidColorBrush(Colors.Red);
                txtUsername.Foreground = new SolidColorBrush(Colors.Red);
                isValidUsername = false;
            }
            else
            {
                lblValidationUsername.Visibility = Visibility.Hidden;
                txtUsername.BorderBrush = new SolidColorBrush(Colors.Black);
                txtUsername.Foreground = new SolidColorBrush(Colors.Black);
                isValidUsername = true;
            }
            IsAddingNewWorkerEnabled();
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Focus())
            {
                lblValidationPassword.Visibility = Visibility.Visible;
                lblValidationPassword.FontSize = 16;
                lblValidationPassword.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationPassword.Content = "The password must contains at least:\n1 special characters.\n1 numbers.\n1 uppercase letter.\n1 one lowercase letter.\nMinimum length 8 characters!";
            }

            string patternPassword = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$";
            Match match = Regex.Match(txtPassword.Password, patternPassword, RegexOptions.IgnoreCase);

            if (!match.Success)
            {
                txtPassword.BorderBrush = new SolidColorBrush(Colors.Red);
                txtPassword.Foreground = new SolidColorBrush(Colors.Red);
                isValidPassword = false;
            }
            else
            {
                lblValidationPassword.Visibility = Visibility.Hidden;
                txtPassword.BorderBrush = new SolidColorBrush(Colors.Black);
                txtPassword.Foreground = new SolidColorBrush(Colors.Black);
                isValidPassword = true;
            }
            IsAddingNewWorkerEnabled();
        }

        private void cmbFloor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFloor.Focus())
            {
                lblValidationHotelFloor.Visibility = Visibility.Visible;
                lblValidationHotelFloor.FontSize = 16;
                lblValidationHotelFloor.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationHotelFloor.Content = "You have to select floor!";
            }

            if (cmbFloor.SelectedItem == null)
            {
                lblValidationHotelFloor.BorderBrush = new SolidColorBrush(Colors.Red);
                lblValidationHotelFloor.Foreground = new SolidColorBrush(Colors.Red);
                isValidHotelFloor = false;
            }
            else
            {
                lblValidationHotelFloor.BorderBrush = new SolidColorBrush(Colors.Black);
                lblValidationHotelFloor.Foreground = new SolidColorBrush(Colors.Black);
                isValidHotelFloor = true;
            }
            IsAddingNewWorkerEnabled();
        }

        private void txtWorkExperience_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtWorkExperience.Focus())
            {
                lblValidationWorkExperience.Visibility = Visibility.Visible;
                lblValidationWorkExperience.FontSize = 16;
                lblValidationWorkExperience.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationWorkExperience.Content = "The work experience can't \nbe larger then 40 years \n and less then one!";
            }

            string patterntxtWorkExperience = @"^([0-9]{1,2})$";
            Match match = Regex.Match(txtWorkExperience.Text, patterntxtWorkExperience, RegexOptions.IgnoreCase);

            bool isValid = int.TryParse(txtWorkExperience.Text, out int inputvalu);

            if (!match.Success || inputvalu > 40 || inputvalu <=0)
            {
                txtWorkExperience.BorderBrush = new SolidColorBrush(Colors.Red);
                txtWorkExperience.Foreground = new SolidColorBrush(Colors.Red);
                isValidWorkExperience = false;
            }
            else
            {
                lblValidationWorkExperience.Visibility = Visibility.Hidden;
                txtWorkExperience.BorderBrush = new SolidColorBrush(Colors.Black);
                txtWorkExperience.Foreground = new SolidColorBrush(Colors.Black);
                isValidWorkExperience = true;
            }
            IsAddingNewWorkerEnabled();
        }

        private void cmbQualificationLevel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbQualificationLevel.Focus())
            {
                lblValidationQualificationLevel.Visibility = Visibility.Visible;
                lblValidationQualificationLevel.FontSize = 16;
                lblValidationQualificationLevel.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationQualificationLevel.Content = "You have to select Qualification Level!";
            }

            if (cmbQualificationLevel.SelectedItem == null)
            {
                cmbQualificationLevel.BorderBrush = new SolidColorBrush(Colors.Red);
                cmbQualificationLevel.Foreground = new SolidColorBrush(Colors.Red);
                isValidQualificationLevel = false;
            }
            else
            {
                cmbQualificationLevel.BorderBrush = new SolidColorBrush(Colors.Black);
                cmbQualificationLevel.Foreground = new SolidColorBrush(Colors.Black);
                isValidQualificationLevel = true;
            }
            IsAddingNewWorkerEnabled();
        }

    }
}
