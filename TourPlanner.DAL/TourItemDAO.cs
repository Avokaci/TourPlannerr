using System;
using System.Collections.Generic;
using TourPlanner.DAL;
using TourPlanner.Models;

namespace TourPlanner.DataAccessLayer
{
    public enum DataType
    {
        Database,
        Filesystem
    }

    public class TourItemDAO
    {
        private IDataAccess dataAccess;

        public TourItemDAO(DataType dataType)
        {
            if (dataType == DataType.Database)
            {
                dataAccess = new Database();
            }
            else if (dataType == DataType.Filesystem)
            {
                dataAccess = new FileSystem();
            }
        }

        //public string CreateImage(string from, string to)
        //{
        //    return dataAccess.CreateImage(from, to);
        //}

        public List<Tour> GetItems()
        {
            return dataAccess.GetItems();
        }

        public void AddItem(string name, string route, string description, long distance)
        {
            dataAccess.AddTour(name, route, description, distance);
        }

        public void DeleteItem(string name)
        {
            dataAccess.DeleteTour(name);
        }
    }
}
