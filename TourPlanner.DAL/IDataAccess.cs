using System;
using System.Collections.Generic;
using System.Text;
using TourPlanner.Models;

namespace TourPlanner.DAL
{
    public interface IDataAccess
    {
        public List<Tour> GetItems();
        public void AddTour(string tourName, string route, string description, long distance);
        public void DeleteTour(string tourName);
        public void ChangeTour(string tourName, string route, string description, long distance);
    }
}
