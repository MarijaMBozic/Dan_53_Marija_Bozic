using HotelPremier.Commands;
using HotelPremier.Helper;
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
    public class SalaryInfoViewModel:ViewModelBase
    {
        ServiceCode service = new ServiceCode();
        SalariInfoView salariInfoView;

        #region Constructore
        public SalaryInfoViewModel(HotelUser worker, vwWorker userWorker, SalariInfoView salariInfoViewOpen)
        {
            this.worker = worker;
            this.userWorker = userWorker;
            salariInfoView = salariInfoViewOpen;
            ManagerInput = Salary.CalculateManagerInput(userWorker.Salary, userWorker.WorkExperience, userWorker.QualificationLevelId, userWorker.GenderId);
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
        private vwWorker userWorker;
        public vwWorker UserWorker
        {
            get
            {
                return userWorker;
            }
            set
            {
                userWorker = value;
                OnPropertyChanged("UserWorker");
            }
        }

        private decimal managerInput;
        public decimal ManagerInput
        {
            get
            {
                return managerInput;
            }
            set
            {
                managerInput = value;
                OnPropertyChanged("ManagerInput");
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
                WorkerLogedInView workerView = new WorkerLogedInView(worker);
                workerView.Show();
                salariInfoView.Close();
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
