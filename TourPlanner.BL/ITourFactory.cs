using System;
using System.Collections.Generic;
using TourPlanner.Models;

namespace TourPlanner.BusinessLayer
{
    public interface ITourFactory
    {
        //tour
        IEnumerable<Tour> GetItems();
        IEnumerable<Tour> Search(string itemName, bool caseSensitive = false);

        public void AddTour(string name, string from, string to, string description, string imagePath);
        public void ModifyTour(Tour currentTour, string name, string from, string to, string description, string imagePath);

        //log
        IEnumerable<TourLog> GetLogs(string tourName);
        public void AddLog(string tourName, DateTime date, DateTime duration, long distance, string comment);
        public void DeleteLog(string tourName);

        //images
        public void DeleteItemAndSavePath(string tourName, string path);
        public void DeleteImages(string path);
        

    }
}
