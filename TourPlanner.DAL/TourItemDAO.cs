using System;
using System.Collections.Generic;
using TourPlanner.DAL;
using TourPlanner.Models;

namespace TourPlanner.DataAccessLayer
{

    public class TourItemDAO
    {
        private IDataAccess dataAccess;

        public TourItemDAO()
        {
            //check with datasource to use
            //dataAccess = new Database();
            dataAccess = new FileSystem();
        }

        public string CreateImage(string from, string to, string path)
        {
            return dataAccess.CreateImage(from, to,path);
        }

        public List<Tour> GetItems()
        {
            return dataAccess.GetItems();
        }
        public List<TourLog> GetLogs(string tourName)
        {
            return dataAccess.GetLogs(tourName);
        }

        public void AddTour(string name, string from, string to, string description,string imagePath)
        {
            dataAccess.AddTour(name, from, to, description, imagePath);
        }

        public void DeleteTour(string tourName)
        {
            dataAccess.DeleteTour(tourName);
        }

        public void DeleteImage(string path)
        {
            dataAccess.DeleteImage(path);
        }

        public void SaveImagePath(string path)
        {
            dataAccess.SaveImagePath(path);
        }

        public void AddLog(string tourName, DateTime date, DateTime duration, long distance, string comment)
        {
            dataAccess.AddLog(tourName, date,duration,distance,comment);
        }

        public void DeleteLog(string tourName)
        {
            dataAccess.DeleteLog( tourName);
        }

        public void ModifyTour(Tour currentTour, string name, string from, string to, string description, string imagePath)
        {
            dataAccess.ModifyTour(currentTour, name, from, to, description,imagePath);
        }

    }
}
