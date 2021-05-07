using System;
using System.Collections.Generic;
using TourPlanner.Models;

namespace TourPlanner.BusinessLayer
{
    public interface ITourPlannerFactory
    {
        IEnumerable<Tour> GetTours();
        IEnumerable<TourLog> GetLogs(Tour item);
        IEnumerable<Tour> Search(string itemName, bool caseSensitive = false);

        Tour CreateTour(string name, string tourDescription, string tourDistance, string from, string to, string routeInformation);

        TourLog CreateLog(DateTime publishingDate, string author, DateTime tripStart, DateTime tripEnd, Rating rating, string report, Tour tourItem);
    }
}
