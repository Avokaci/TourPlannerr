using System;
using System.Collections.Generic;
using System.Text;
using TourPlanner.Models;

namespace TourPlanner.DAL.DAO
{
    public interface ILogDAO
    {
        TourLog FindById(int id);
        TourLog AddNewItemLog(DateTime publishingDate, string author, DateTime tripStart, DateTime tripEnd, Rating rating, string report, Tour tourItem);
        IEnumerable<TourLog> GetLogsForTour(Tour tourItem);
    }
}
