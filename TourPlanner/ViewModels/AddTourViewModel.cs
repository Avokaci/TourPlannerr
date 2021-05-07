using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        private string from;
        private string to;
        private string descriptionText;
        private ITourPlannerFactory tourFactory;

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
        public string From 
        {
            get
            {
                return from;
            }
            set
            {
                if (from != value)
                {
                    from = value;
                    RaisePropertyChangedEvent(nameof(from));
                }
            }
        }
        public string To 
        {
            get
            {
                return to;
            }
            set
            {
                if (to != value)
                {
                    to = value;
                    RaisePropertyChangedEvent(nameof(to));
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
                    RaisePropertyChangedEvent(nameof(descriptionText));
                }
            }
        }



        #endregion
        #region constructor
        public AddTourViewModel()
        {
            this.tourFactory = TourPlannerFactory.GetInstance();

        }
        #endregion
        #region methods
        private void AddTour(object commandParameter)
        {
            this.tourFactory.AddTour(TourName, From, To, DescriptionText,"");
            var window = (Window)commandParameter;
            tourName = string.Empty;
            from = string.Empty;
            to = string.Empty;
            descriptionText = string.Empty;
            window.Close();

        }
        #endregion
    }
}
