using HotelPremier.Commands;
using HotelPremier.Service;
using HotelPremier.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HotelPremier.ViewModels
{
    public class OwnerViewModel : ViewModelBase
    {
        OwnerView ownerView;
        ServiceCode service = new ServiceCode();

        #region Constructor
        public OwnerViewModel(OwnerView ownerViewOpen)
        {
            ownerView = ownerViewOpen;
        }
        #endregion

        #region Commands

        private ICommand logOut;

        public ICommand LogOut
        {
            get
            {
                if (logOut == null)
                {
                    logOut = new RelayCommand(param => LogOutExecute(), param => CanLogOutExecute());
                }
                return logOut;
            }
        }

        public void LogOutExecute()
        {
            try
            {
                MainWindow main = new MainWindow();
                main.Show();
                ownerView.Close();
                MessageBox.Show("You have successfully log out");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanLogOutExecute()
        {
            return true;
        }

        private ICommand goToAddWorker;

        public ICommand GoToAddWorker
        {
            get
            {
                if (goToAddWorker == null)
                {
                    goToAddWorker = new RelayCommand(param => GoToAddWorkerExecute(), param => CanGoToAddWorkerExecute());
                }
                return goToAddWorker;
            }
        }

        public void GoToAddWorkerExecute()
        {
            try
            {
                AddWorkerView main = new AddWorkerView();
                main.Show();
                ownerView.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanGoToAddWorkerExecute()
        {
            return true;
        }

        private ICommand goToAddManager;

        public ICommand GoToAddManager
        {
            get
            {
                if (goToAddManager == null)
                {
                    goToAddManager = new RelayCommand(param => GoToAddManagerExecute(), param => CanGoToAddManagerExecute());
                }
                return goToAddManager;
            }
        }
        public void GoToAddManagerExecute()
        {
            try
            {
                AddManagerView main = new AddManagerView();
                main.Show();
                ownerView.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanGoToAddManagerExecute()
        {
            return true;
        }
        #endregion
    }
}