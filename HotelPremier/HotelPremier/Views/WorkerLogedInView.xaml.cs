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
    /// Interaction logic for WorkerLogedInView.xaml
    /// </summary>
    public partial class WorkerLogedInView : Window
    {
        WorkerLogedInViewModel workerLogedInViewModel;

        public WorkerLogedInView(HotelUser worker)
        {
            InitializeComponent();
            WorkerLogedInViewModel workerLogedInViewModel = new WorkerLogedInViewModel(worker, this);
            this.DataContext = workerLogedInViewModel;
            this.workerLogedInViewModel = workerLogedInViewModel;
        }
    }
}
