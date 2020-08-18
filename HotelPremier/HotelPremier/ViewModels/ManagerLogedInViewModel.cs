using HotelPremier.Commands;
using HotelPremier.Service;
using HotelPremier.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HotelPremier.ViewModels
{
    public class ManagerLogedInViewModel:ViewModelBase
    {
        ServiceCode service = new ServiceCode();
        ManagerLogedInView managerLogedInView;

        #region Constructore
        public ManagerLogedInViewModel(HotelUser manager, ManagerLogedInView managerLogedInViewOpen)
        {
            this.manager = manager;
            managerLogedInView = managerLogedInViewOpen;
            ManagerFloor = service.GetManagerFlorByUserId(manager.HotelUserId);
            WorkerList = new ObservableCollection<vwWorker>(service.GetAllWorkersByFloor(ManagerFloor));
        }
        #endregion

        #region Property
        private HotelUser manager;
        public HotelUser Manager
        {
            get
            {
                return manager;
            }
            set
            {
                manager = value;
                OnPropertyChanged("Manager");
            }
        }

        private int managerFloor;
        public int ManagerFloor
        {
            get
            {
                return managerFloor;
            }
            set
            {
                managerFloor = value;
                OnPropertyChanged("ManagerFloor");
            }
        }

        private ObservableCollection<vwWorker> workerList;
        public ObservableCollection<vwWorker> WorkerList
        {
            get
            {
                return workerList;
            }
            set
            {
                workerList = value;
                OnPropertyChanged("WorkerList");
            }
        }

        private vwWorker selectedWorker = new vwWorker();
        public vwWorker SelectedWorker
        {
            get
            {
                return selectedWorker;
            }
            set
            {
                selectedWorker = value;
                OnPropertyChanged("SelectedWorker");
            }
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
                managerLogedInView.Close();
                MessageBox.Show("You have successfully logged out");
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

        public void EditWorker()
        {
            try
            {
                HotelUser hotelUser = new HotelUser();
                hotelUser.HotelUserId = selectedWorker.HotelUserId;
                hotelUser.FullName = selectedWorker.FullName;

                Worker hotelWorker = new Worker();
                hotelWorker.WorkerId = selectedWorker.WorkerId;
                hotelWorker.WorkExperience = selectedWorker.WorkExperience;
                hotelWorker.QualificationLevelId = selectedWorker.QualificationLevelId;
                hotelWorker.GenderId = selectedWorker.GenderId;

                AddSalaryForOneWorker AddSalaryForOneWorker = new AddSalaryForOneWorker(manager, hotelUser, hotelWorker);
                AddSalaryForOneWorker.Show();
                managerLogedInView.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private ICommand editAllSalary;

        public ICommand EditAllSalary
        {
            get
            {
                if (editAllSalary == null)
                {
                    editAllSalary = new RelayCommand(param => EditAllSalaryExecute(), param => CanEditAllSalaryExecute());
                }
                return editAllSalary;
            }
        }

        public void EditAllSalaryExecute()
        {
            try
            {
                ChangeAllSalary main = new ChangeAllSalary();
                main.Show();
                managerLogedInView.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanEditAllSalaryExecute()
        {
            return true;
        }

        #endregion

    }
}
