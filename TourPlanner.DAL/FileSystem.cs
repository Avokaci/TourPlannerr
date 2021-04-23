using System;
using System.Collections.Generic;
using System.Text;
using TourPlanner.Models;

namespace TourPlanner.DAL
{
    class FileSystem : IDataAccess
    {
        private string filePath;

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
