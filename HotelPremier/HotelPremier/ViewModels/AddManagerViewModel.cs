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
    public class AddManagerViewModel:ViewModelBase
    {
        AddManagerView addManagerView;
        ServiceCode service = new ServiceCode();

        #region Constructor
        public AddManagerViewModel(AddManagerView addManagerViewOpen)
        {
            addManagerView = addManagerViewOpen;

            QualificationLevelList = new ObservableCollection<QualificationLevel>(service.GetAllQualificationLevel());
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
        #endregion

    }
}
