using System;
using System.Collections.Generic;
using TourPlanner.Models;

namespace TourPlanner.BusinessLayer
{
    public interface ITourFactory
    {
        IEnumerable<Tour> GetItems();
        IEnumerable<Tour> Search(string itemName, bool caseSensitive = false);
        public void AddTour(string tourName, string route, string description, long distance);
        public void DeleteTour(string tourName);
        public void ChangeTour(string tourName, string route, string description, long distance);

    }
}
