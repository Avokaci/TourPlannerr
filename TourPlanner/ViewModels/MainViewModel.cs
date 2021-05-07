using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Input;
using TourPlanner.BL;
using TourPlanner.BusinessLayer;
using TourPlanner.Models;
using TourPlanner.ViewModels;

namespace TourPlanner.Views
{
    public class MainViewModel : BaseViewModel
    {
        #region Instances
        private ObservableCollection<Tour> tours;
        private ObservableCollection<DataGridItem> logs;
        private Tour tour;
        private string searchCommand;
        private ITourPlannerFactory tourfactory;

        #endregion

        #region Properties
        public IEnumerable<Tour> MyFilteredItems
        {
            get
            {
                if (searchCommand == null) return tours;

                return tours.Where(x => x.Name.ToUpper().StartsWith(searchCommand.ToUpper()));
            }
        }
        public ObservableCollection<Tour> Tours { get => tours; set => tours = value; }
        public ObservableCollection<DataGridItem> Logs { get => logs; set => logs = value; }
        public Tour Tour
        {
            get
            {
                return tour;
            }
            set
            {
                if ((tour != value) && (value != null))
                {
                    tour = value;
                    RaisePropertyChangedEvent(nameof(tour));
                }
            }
        }
        public string SearchCommand
        {
            get
            {
                return searchCommand;
            }
            set
            {
                if (searchCommand != value)
                {
                    searchCommand = value;
                    RaisePropertyChangedEvent("SearchText");
                    RaisePropertyChangedEvent("MyFilteredItems");
                }
            }
        }

        private ICommand popUpAdd;
        public ICommand PopUpAdd => popUpAdd ??= new RelayCommand(OpenAddTourWindow);


        #endregion

        #region Constructor
        public MainViewModel()
        {
            this.tourfactory = TourPlannerFactory.GetInstance();
            tours = new ObservableCollection<Tour>() ;
            logs = new ObservableCollection<DataGridItem>();
            foreach (Tour item in this.tourfactory.GetItems())
            {
                tours.Add(item);
            }
          
        }
        #endregion

        #region Methods
        private void OpenAddTourWindow(object commandParameter)
        {
            AddTourWindow atw = new AddTourWindow();
            atw.DataContext = new AddTourViewModel();
            atw.ShowDialog();
        }
        #endregion

    }
}
