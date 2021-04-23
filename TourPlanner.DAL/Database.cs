using System;
using System.Collections.Generic;
using System.Text;
using TourPlanner.Models;

namespace TourPlanner.DAL
{
    class Database : IDataAccess
    {
        private string connectionString;
        private List<Tour> tourItems = new List<Tour>();

        public Database()
        {
            connectionString = "...";
        }

        public void AddTour(string tourName, string route, string description, long distance)
        {
            throw new NotImplementedException();
        }

        public void ChangeTour(string tourName, string route, string description, long distance)
        {
            throw new NotImplementedException();
        }

        public void DeleteTour(string tourName)
        {
            throw new NotImplementedException();
        }

        public List<Tour> GetItems()
        {
            throw new NotImplementedException();
        }
    }
}
