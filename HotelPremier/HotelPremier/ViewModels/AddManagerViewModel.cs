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
using System.Windows.Controls;
using System.Windows.Input;

namespace HotelPremier.ViewModels
{
    public class AddManagerViewModel:ViewModelBase
    {
        AddManagerView addManagerView;
        ServiceCode service = new ServiceCode();

        #region Constructor
        public AddManagerViewModel(AddManagerView addManagerViewOpen)
        {
            addManagerView = addManagerViewOpen;
            QualificationLevelList = new ObservableCollection<QualificationLevel>(service.GetAllQualificationLevel());
            User = new HotelUser();
            UserManager = new Manager();
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

        private Manager userManager;
        public Manager UserManager
        {
            get
            {
                return userManager;
            }
            set
            {
                userManager = value;
                OnPropertyChanged("UserManager");
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
            User.RoleId = 2;
            try
            {               
                if (User.HotelUserId == 0)
                {
                    bool uniqueUserName = service.CheckUsername(User.Username);
                    bool uniqueEmail = service.CheckEmail(User.Email);
                    bool uniqueFloor = service.CheckHotelFloor(UserManager.HotelFloor);
                    if (uniqueUserName && uniqueEmail && uniqueFloor)
                    {
                        int userId = service.AddHotelUser(User);
                        if (userId != 0)
                        {
                            UserManager.HotelUserId = userId;
                            UserManager.QualificationLevelId = selectedQualificationLevel.QualificationLevelId;

                            if (service.AddNewManger(UserManager) != 0)
                            {
                                MessageBox.Show("You have successfully added new manager");                                

                                OwnerView ownerView = new OwnerView();
                                ownerView.Show();
                                addManagerView.Close();
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
                    else if (!uniqueFloor)
                    {
                        MessageBox.Show("The floor is occupied select another!");
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
                addManagerView.Close();
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
