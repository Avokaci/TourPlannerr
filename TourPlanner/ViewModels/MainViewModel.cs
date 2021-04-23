using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Input;
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
        private string searchText;

        #endregion

        #region Properties
        public IEnumerable<Tour> MyFilteredItems
        {
            get
            {
                if (searchText == null) return tours;

                return tours.Where(x => x.Name.ToUpper().StartsWith(searchText.ToUpper()));
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
        public string SearchText
        {
            get
            {
                return searchText;
            }
            set
            {
                if (searchText != value)
                {
                    searchText = value;
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
            Tour ex1 = new Tour("Tour-1", "Das ist route1", "Salzburg-Wien", 1250);
            Tour ex2 = new Tour("Tour-2", "Das ist route2", "wien-Graz", 300);

            tours = new ObservableCollection<Tour>() { ex1, ex2 };
            logs = new ObservableCollection<DataGridItem>();
        }
        #endregion

        #region Methods
        private void OpenAddTourWindow(object commandParameter)
        {
            AddTourWindow atw = new AddTourWindow();
            atw.ShowDialog();
        }
        #endregion

    }
}
