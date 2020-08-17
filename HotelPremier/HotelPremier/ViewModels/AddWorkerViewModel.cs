using HotelPremier.Service;
using HotelPremier.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
        #endregion

        #region Properties
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
        #endregion


    }
}
