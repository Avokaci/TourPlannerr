using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TourPlanner.BusinessLayer;
using TourPlanner.DAL.Common;
using TourPlanner.DAL.DAO;
using TourPlanner.Models;

namespace TourPlanner.BL
{

    internal class TourPlannerFactoryImpl : ITourPlannerFactory
    {
        public IEnumerable<Tour> GetTours()
        {
            ITourDAO tourDAO = DALFactory.CreateTourDAO();
            return tourDAO.GetTours();
        }

        public IEnumerable<Tour> Search(string itemName, bool caseSensitive = false)
        {
            IEnumerable<Tour> items = GetTours();

            if (caseSensitive)
            {
                return items.Where(x => x.Name.Contains(itemName));
            }
            else
            {
                return items.Where(x => x.Name.ToLower().Contains(itemName.ToLower()));
            }
        }

        public Tour CreateTour(string name, string tourDescription, string tourDistance, string from, string to, string routeInformation)
        {
            ITourDAO tourDAO = DALFactory.CreateTourDAO();
            return tourDAO.AddNewItem(name, tourDescription, tourDistance, from, to, routeInformation);
        }

        public TourLog CreateLog(DateTime publishingDate, string author, DateTime tripStart, DateTime tripEnd, Rating rating, string report, Tour tourItem)
        {
            ILogDAO logDAO = DALFactory.CreateLogDAO();
            return logDAO.AddNewItemLog(publishingDate, author, tripStart, tripEnd, rating, report, tourItem);
        }

        public IEnumerable<TourLog> GetLogs(Tour item)
        {
            ILogDAO logDAO = DALFactory.CreateLogDAO();
            return logDAO.GetLogsForTour(item);
        }
    }
}
