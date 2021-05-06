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
            //get connection data e.g .from config file
            connectionString = "...";
            // establosh connection with db
        }

        public void AddLog(string tourName, DateTime date, DateTime duration, long distance, string comment)
        {
            throw new NotImplementedException();
        }

        public void AddTour(string name, string from, string to, string description, string imagePath)
        {
            throw new NotImplementedException();
        }

        public string CreateImage(string from, string to, string path)
        {
            throw new NotImplementedException();
        }

        public void DeleteImage(string path)
        {
            throw new NotImplementedException();
        }

        public void DeleteLog(string tourName)
        {
            throw new NotImplementedException();
        }

        public void DeleteTour(string name)
        {
            throw new NotImplementedException();
        }

        public List<Tour> GetItems()
        {
            //select SQL querry           
            //return tourItems;

            //fake: 
            Tour ex1 = new Tour("Tour-1", "Das ist route1", "Wien", "Salzburg", "WIP");
            Tour ex2 = new Tour("Tour-2", "Das ist route2", "Salzburg", "Graz", "WIP");
            Tour ex3 = new Tour("Tour-3", "Das ist route3", "Wien", "Graz", "WIP");

            List<Tour> mylist = new List<Tour>() { ex1, ex2, ex3 };
            return mylist;


        }

        public List<TourLog> GetLogs(string tourName)
        {
            throw new NotImplementedException();
        }

        public void ModifyTour(Tour currentTour, string name, string from, string to, string description, string imagePath)
        {
            throw new NotImplementedException();
        }

        public void SaveImagePath(string path)
        {
            throw new NotImplementedException();
        }
    }
}
