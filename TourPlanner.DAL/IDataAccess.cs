using System;
using System.Collections.Generic;
using System.Text;
using TourPlanner.Models;

namespace TourPlanner.DAL
{
    public interface IDataAccess
    {
        //tour
        public List<Tour> GetItems();
        public void AddTour(string name, string from, string to, string description, string imagePath);
        public void DeleteTour(string name);
        public void ModifyTour(Tour currentTour, string name, string from, string to, string description, string imagePath);

        //image
        public string CreateImage(string from, string to, string path);
        public void DeleteImage(string path);
        public void SaveImagePath(string path);

        //log
        public List<TourLog> GetLogs(string tourName);
        public void AddLog(string tourName, DateTime date, DateTime duration, long distance, string comment);
        public void DeleteLog(string tourName);

    }
}
