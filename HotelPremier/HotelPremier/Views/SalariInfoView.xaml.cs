using HotelPremier.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HotelPremier.Views
{
    /// <summary>
    /// Interaction logic for SalariInfoView.xaml
    /// </summary>
    public partial class SalariInfoView : Window
    {
        SalaryInfoViewModel salaryInfoViewModel;
        public SalariInfoView(HotelUser user, vwWorker worker)
        {
            InitializeComponent();
            SalaryInfoViewModel salaryInfoViewModel = new SalaryInfoViewModel(user, worker, this);
            this.DataContext = salaryInfoViewModel;
            this.salaryInfoViewModel = salaryInfoViewModel;
        }
    }
}

