using HotelPremier.Commands;
using HotelPremier.Helper;
using HotelPremier.Service;
using HotelPremier.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HotelPremier.ViewModels
{
    public class AddWorkerViewModel:ViewModelBase
    {
        AddWorkerView addworkerview;
        ServiceCode service = new ServiceCode();

        #region Constructor
        public AddWorkerViewModel(AddWorkerView addworkerviewOpen)
        {
            addworkerview = addworkerviewOpen;
            FloorList= new ObservableCollection<int>(service.ListOfFloorsForWorker());
            GenderList = new ObservableCollection<Gender>(service.GetAllGender());
            EngagmentList= new ObservableCollection<Engagment>(service.GetAllEngagment());
            QualificationLevelList = new ObservableCollection<QualificationLevel>(service.GetAllQualificationLevel());
            UserWorker = new Worker();
            User = new HotelUser();
        }
        #endregion

        #region Properties

        private ObservableCollection<QualificationLevel> qualificationLevelList;
        public ObservableCollection<QualificationLevel> QualificationLevelList
        {
            get
            {
                return qualificationLevelList;
            }
            set
            {
                qualificationLevelList = value;
                OnPropertyChanged("QualificationLevelList");
            }
        }
        private QualificationLevel selectedQualificationLevel;
        public QualificationLevel SelectedQualificationLevel
        {
            get
            {
                return selectedQualificationLevel;
            }
            set
            {
                selectedQualificationLevel = value;
                OnPropertyChanged("SelectedQualificationLevel");
            }
        }
        private ObservableCollection<Gender> genderList;
        public ObservableCollection<Gender> GenderList
        {
            get
            {
                return genderList;
            }
            set
            {
                genderList = value;
                OnPropertyChanged("GenderList");
            }
        }

        private Gender selectedGender;
        public Gender SelectedGender
        {
            get
            {
                return selectedGender;
            }
            set
            {
                selectedGender = value;
                OnPropertyChanged("SelectedGender");
            }
        }
        private ObservableCollection<int> floorList;
        public ObservableCollection<int> FloorList
        {
            get
            {
                return floorList;
            }
            set
            {
                floorList = value;
                OnPropertyChanged("FloorList");
            }
        }

        private int selectedFloor;
        public int SelectedFloor
        {
            get
            {
                return selectedFloor;
            }
            set
            {
                selectedFloor = value;
                OnPropertyChanged("SelectedFloor");
            }
        }

        private ObservableCollection<Engagment> engagmentList;
        public ObservableCollection<Engagment> EngagmentList
        {
            get
            {
                return engagmentList;
            }
            set
            {
                engagmentList = value;
                OnPropertyChanged("EngagmentList");
            }
        }

        private Engagment selectedEngagment;
        public Engagment SelectedEngagment
        {
            get
            {
                return selectedEngagment;
            }
            set
            {
                selectedEngagment = value;
                OnPropertyChanged("SelectedEngagment");
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

        private Worker userWorker;
        public Worker UserWorker
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
            var passwordBox = parametar as PasswordBox;
            var password = passwordBox.Password;
            var email = User.Email.ToLower();
            User.Password = password;
            User.Email = email;
            User.RoleId = 1;
            try
            {
                if (User.HotelUserId == 0)
                {
                    bool uniqueUserName = service.CheckUsername(User.Username);
                    bool uniqueEmail = service.CheckEmail(User.Email);
                   
                    if (uniqueUserName && uniqueEmail)
                    {
                        int userId = service.AddHotelUser(User);
                        if (userId != 0)
                        {
                            UserWorker.HotelUserId = userId;
                            UserWorker.GenderId = selectedGender.GenderId;
                            UserWorker.HotelFloor = selectedFloor;
                            UserWorker.EngagmentId = selectedEngagment.EngagmentId;
                            UserWorker.QualificationLevelId = selectedQualificationLevel.QualificationLevelId;
                            UserWorker.ManagerId = service.GetManagerByFloorNumber(selectedFloor);

                            if (service.AddNewWorker(UserWorker) != 0)
                            {
                                MessageBox.Show("You have successfully added new worker");
                                OwnerView ownerView = new OwnerView();
                                ownerView.Show();
                                addworkerview.Close();
                            }
                        }
                    }
                    else if (!uniqueUserName)
                    {
                        MessageBox.Show("Username already exists!");
                    }
                    else if (!uniqueEmail)
                    {
                        MessageBox.Show("Email already exists!");
                    }
                    else
                    {
                        //int userId = service.AddClinicUser(User);
                        //if (userId != 0)
                        //{
                        //    UserDoctor.ClinicUserId = userId;
                        //    UserDoctor.DepartmentId = selectedDepartment.DepartmentId;
                        //    UserDoctor.WorkShiftId = selectedWorkShift.WorkShiftId;
                        //    UserDoctor.ClinicManagerId = selectedManager.ClinicManagerId;

                        //    if (service.AddNewDoctor(UserDoctor) != 0)
                        //    {
                        //        MessageBox.Show("You have successfully added new doctor");
                        //        Logging.LoggAction("AddDoctorViewModel", "Info", "Succesfull added new doctor");

                        //        DoctorView doctorView = new DoctorView(UserAdmin);
                        //        doctorView.Show();
                        //        addDoctorView.Close();
                        //    }
                        //}
                    }
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
                OwnerView ownerView = new OwnerView();
                ownerView.Show();
                addworkerview.Close();
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
