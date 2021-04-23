using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourPlanner.BL;
using TourPlanner.BusinessLayer;
using TourPlanner.ViewModels;

namespace TourPlanner.Views
{
    public class AddTourViewModel : BaseViewModel
    {
        #region instances
        private string tourName;
        private string routeText;
        private string descriptionText;
        private long distanceText;
        private ITourFactory tourFactory;

        private ICommand addCommand;
        public ICommand AddCommand => addCommand ??= new RelayCommand(AddTour);



        #endregion
        #region properties
        public string TourName
        {
            get
            {
                return tourName;
            }
            set
            {
                if (tourName != value)
                {
                    tourName = value;
                    RaisePropertyChangedEvent(nameof(TourName));
                }
            }
        }
        public string RouteText
        {
            get
            {
                return routeText;
            }
            set
            {
                if (routeText != value)
                {
                    routeText = value;
                    RaisePropertyChangedEvent(nameof(RouteText));
                }
            }
        }
        public string DescriptionText
        {
            get
            {
                return descriptionText;
            }
            set
            {
                if (descriptionText != value)
                {
                    descriptionText = value;
                    RaisePropertyChangedEvent(nameof(DescriptionText));
                }
            }
        }

        public long DistanceText
        {
            get
            {
                return distanceText;
            }
            set
            {
                if (distanceText != value)
                {
                    distanceText = value;
                    RaisePropertyChangedEvent(nameof(DescriptionText));
                }
            }
        }
        #endregion
        #region constructor
        public AddTourViewModel()
        {
            this.tourFactory = TourFactory.GetInstance();

        }
        #endregion
        #region methods
        private void AddTour(object commandParameter)
        {

            this.tourFactory.AddTour(TourName, RouteText, DescriptionText, DistanceText);


            TourName = "";
            RouteText = "";
            DescriptionText = "";
            DistanceText = 0;

        }
        #endregion
    }
}
