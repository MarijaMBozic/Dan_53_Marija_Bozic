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
    public class WorkerLogedInViewModel:ViewModelBase
    {
        ServiceCode service = new ServiceCode();
        WorkerLogedInView workerLogedInView;

        #region Constructore
        public WorkerLogedInViewModel(HotelUser worker, WorkerLogedInView workerLogedInViewOpen)
        {
            this.worker = worker;
            workerLogedInView = workerLogedInViewOpen;
            HotelUser = service.GetWorkerDetailsById(worker.HotelUserId);
            RequestList = new ObservableCollection<vwRequest>(service.RequestListByWorker(worker.HotelUserId));
        }
        #endregion

        #region Property
        private HotelUser worker;
        public HotelUser Worker
        {
            get
            {
                return worker;
            }
            set
            {
                worker = value;
                OnPropertyChanged("Worker");
            }
        }
        private vwWorker hotelUser;
        public vwWorker HotelUser
        {
            get
            {
                return hotelUser;
            }
            set
            {
                hotelUser = value;
                OnPropertyChanged("HotelUser");
            }
        }

        private ObservableCollection<vwRequest> requestList;
        public ObservableCollection<vwRequest> RequestList
        {
            get
            {
                return requestList;
            }
            set
            {
                requestList = value;
                OnPropertyChanged("RequestList");
            }
        }

        #endregion

        #region Commands
        private ICommand addNewRequest;

        public ICommand AddNewRequest
        {
            get
            {
                if (addNewRequest == null)
                {
                    addNewRequest = new RelayCommand(param => AddNewRequestExecute(), param => CanAddNewRequestExecute());
                }
                return addNewRequest;
            }
        }

        public void AddNewRequestExecute()
        {
            try
            {
                RequestView main = new RequestView(worker, HotelUser);
                main.Show();
                workerLogedInView.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanAddNewRequestExecute()
        {
            return true;
        }

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
                workerLogedInView.Close();
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

        #endregion
    }
}
