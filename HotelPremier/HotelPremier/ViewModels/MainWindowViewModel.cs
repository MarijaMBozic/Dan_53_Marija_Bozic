using HotelPremier.Commands;
using HotelPremier.Service;
using HotelPremier.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HotelPremier.ViewModels
{
    public class MainWindowViewModel:ViewModelBase
    {
        MainWindow main;
        ServiceCode service = new ServiceCode();

        #region Constructor
        public MainWindowViewModel(MainWindow mainOpen)
        {
            this.main = mainOpen;

        }
        #endregion

        #region Properties
        private string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }
        #endregion
        #region Command
        private ICommand login;
        public ICommand Login
        {
            get
            {
                if (login == null)
                {
                    login = new RelayCommand(param => LoginExecute(param));
                }
                return login;
            }
        }

        private void LoginExecute(object parametar)
        {
            var passwordBox = parametar as PasswordBox;
            var password = passwordBox.Password;
            try
            {
                if (OwnerLogIn.Login(username, password) == true)
                {
                    MessageBox.Show("Successful login");
                    OwnerView window = new OwnerView();
                    window.Show();
                    main.Close();

                }
                else if (OwnerLogIn.Login(username, password) == false)
                {
                    HotelUser user = service.LoginUser(username, password);
                    if (user != null)
                    {
                        if (user.RoleId == 1)
                        {

                            MessageBox.Show("Successful login");
                            WorkerLogedInView window = new WorkerLogedInView(user);
                            window.Show();
                            main.Close();
                        }
                        else if (user.RoleId == 2)
                        {
                            MessageBox.Show("Successful login");
                            ManagerLogedInView window = new ManagerLogedInView(user);
                            window.Show();
                            main.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong user or password credentials");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion
    }
}
