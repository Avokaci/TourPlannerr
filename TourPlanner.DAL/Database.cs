using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TourPlanner.Models;

namespace TourPlanner.DAL
{
    class Database : IDataAccess
    {
        private string connectionString;
        private List<Tour> tourItems = new List<Tour>();
        private List<TourLog> logItems = new List<TourLog>();


        public Database()
        {
            //get connection string from config file
            connectionString = "...";
        }
        public List<Tour> GetItems()
        {
            //select SQL querry           
            //return tourItems;

            //fake: 
            Tour ex1 = new Tour(1, "Tour-1", "Das ist route1", "Wien", "Salzburg", "WIP");
            Tour ex2 = new Tour(2, "Tour-2", "Das ist route2", "Salzburg", "Graz", "WIP");
            Tour ex3 = new Tour(3, "Tour-3", "Das ist route3", "Wien", "Graz", "WIP");

            List<Tour> mylist = new List<Tour>() { ex1, ex2, ex3 };
            return mylist;
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
