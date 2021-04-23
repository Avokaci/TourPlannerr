using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TourPlanner.BusinessLayer;
using TourPlanner.DataAccessLayer;
using TourPlanner.Models;

namespace TourPlanner.BL
{

    public class TourFactoryImpl : ITourFactory
    {
        private TourItemDAO databaseTourItemDAO;
        private TourItemDAO filesystemTourItemDAO;

        public TourFactoryImpl()
        {
            databaseTourItemDAO = new TourItemDAO(DataType.Database);
            filesystemTourItemDAO = new TourItemDAO(DataType.Filesystem);
        }


        public void AddTour(string tourName, string route, string description, long distance)
        {
            //WIP
            //string imagePath = filesystemTourItemDAO.CreateImage(description);
            databaseTourItemDAO.AddItem(tourName, route, description, distance);
        }

        public void ChangeTour(string tourName, string route, string description, long distance)
        {
            //databaseTourItemDAO.ChangeItem(tourName, route, description, distance);
        }

        public void DeleteTour(string tourName)
        {
            databaseTourItemDAO.DeleteItem(tourName);
        }

        public IEnumerable<Tour> GetItems()
        {
            return databaseTourItemDAO.GetItems();
        }

        public IEnumerable<Tour> Search(string itemName, bool caseSensitive = false)
        {
            IEnumerable<Tour> items = GetItems();

            if (caseSensitive)
            {
                return items.Where(x => x.Name.Contains(itemName));
            }
            return items.Where(x => x.Name.ToLower().Contains(itemName.ToLower()));
        }
    }
}
