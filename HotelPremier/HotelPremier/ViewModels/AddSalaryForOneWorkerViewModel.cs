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
    public class AddSalaryForOneWorkerViewModel:ViewModelBase
    {
        AddSalaryForOneWorker addSalaryOneWorker;
        ServiceCode service = new ServiceCode();

        #region Constructor
        public AddSalaryForOneWorkerViewModel(HotelUser manager, HotelUser user, Worker worker, AddSalaryForOneWorker addSalaryOneWorkerOpen)
        {
            this.manager = manager;
            this.worker = worker;
            this.user = user;
            addSalaryOneWorker = addSalaryOneWorkerOpen;            
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

        private HotelUser user;
        public HotelUser User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        private Worker worker;
        public Worker Worker
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

        private decimal salaryInput;
        public decimal SalaryInput
        {
            get
            {
                return salaryInput;
            }
            set
            {
                salaryInput = value;
                OnPropertyChanged("SalaryInput");
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
            Worker editWorker = new Worker();
            editWorker.WorkerId = worker.WorkerId;
            editWorker.WorkExperience = worker.WorkExperience;
            editWorker.QualificationLevelId = worker.QualificationLevelId;
            editWorker.GenderId = worker.GenderId;
            decimal salary= Salary.SalaryCalculate(editWorker.WorkExperience, editWorker.QualificationLevelId, editWorker.GenderId, salaryInput);
            editWorker.Salary = salary;

            try
            {
              int userId = service.AddNewWorker(editWorker);
                if (userId != 0)
                { 
                  MessageBox.Show("You have successfully added salary");
                  ManagerLogedInView managerView = new ManagerLogedInView(manager);
                  managerView.Show();
                  addSalaryOneWorker.Close();                     
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
                ManagerLogedInView managerView = new ManagerLogedInView(manager);
                managerView.Show();
                addSalaryOneWorker.Close();
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
