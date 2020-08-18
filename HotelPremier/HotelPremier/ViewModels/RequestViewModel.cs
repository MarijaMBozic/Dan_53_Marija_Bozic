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
    public class RequestViewModel:ViewModelBase
    {
        ServiceCode service = new ServiceCode();
        RequestView requestViewView;

        #region Constructore
        public RequestViewModel(HotelUser worker, vwWorker hotelWorker, RequestView requestViewViewOpen)
        {
            this.worker = worker;
            this.hotelWorker = hotelWorker;
            requestViewView = requestViewViewOpen;
            Request = new Request();
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
        private vwWorker hotelWorker;
        public vwWorker HotelWorker
        {
            get
            {
                return hotelWorker;
            }
            set
            {
                hotelWorker = value;
                OnPropertyChanged("HotelWorker");
            }
        }

        private Request request;
        public Request Request
        {
            get
            {
                return request;
            }
            set
            {
                request = value;
                OnPropertyChanged("Request");
            }
        }
        #endregion

        #region Commands
        private ICommand save;

        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(param));
                }
                return save;
            }
        }
        public void SaveExecute(object parametar)
        {
            Request.WorkerId = hotelWorker.WorkerId;
            Request.ManagerId = hotelWorker.ManagerId;
            try
            {
                if (service.AddNewRequest(Request) != 0)
                {
                    MessageBox.Show("You have successfully added new request");
                    WorkerLogedInView ownerView = new WorkerLogedInView(worker);
                    ownerView.Show();
                    requestViewView.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private ICommand quit;

        public ICommand Quit
        {
            get
            {
                if (quit == null)
                {
                    quit = new RelayCommand(param => QuitExecute(), param => CanQuitExecute());
                }
                return quit;
            }
        }

        public void QuitExecute()
        {
            try
            {
                WorkerLogedInView ownerView = new WorkerLogedInView(worker);
                ownerView.Show();
                requestViewView.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanQuitExecute()
        {
            return true;
        }
        #endregion
    }
}
