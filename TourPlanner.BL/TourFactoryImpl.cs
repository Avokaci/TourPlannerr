using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TourPlanner.BusinessLayer;
using TourPlanner.DataAccessLayer;
using TourPlanner.Models;

namespace TourPlanner.BL
{

    internal class TourFactoryImpl : ITourFactory
    {
        private TourItemDAO databaseTourItemDAO;
        private TourItemDAO filesystemTourItemDAO ;

        public TourFactoryImpl()
        {
            databaseTourItemDAO = new TourItemDAO();
            filesystemTourItemDAO = new TourItemDAO();
        }

        public void AddLog(string tourName, DateTime date, DateTime duration, long distance, string comment)
        {
            databaseTourItemDAO.AddLog(tourName, date, duration, distance, comment);
        }

        public void AddTour(string name, string from, string to, string description, string imagePath)
        {
            string path = filesystemTourItemDAO.CreateImage(from, to, imagePath);
            databaseTourItemDAO.AddTour(name, from, to, description, imagePath);
        }

        public void DeleteImages(string path)
        {
            filesystemTourItemDAO.DeleteImage(path);
        }

        public void DeleteItemAndSavePath(string tourName, string path)
        {
            filesystemTourItemDAO.SaveImagePath(path);
            databaseTourItemDAO.DeleteTour(tourName);
        }

       

        public void DeleteLog(string tourName)
        {
            databaseTourItemDAO.DeleteLog(tourName);
        }

        public IEnumerable<Tour> GetItems()
        {
            return databaseTourItemDAO.GetItems();
        }

        public IEnumerable<TourLog> GetLogs(string tourName)
        {
            return databaseTourItemDAO.GetLogs(tourName);
        }

        public void ModifyTour(Tour currentTour, string name, string from, string to, string description, string imagePath)
        {
            databaseTourItemDAO.ModifyTour(currentTour, name,from,to,description,imagePath);
        }

        public IEnumerable<Tour> Search(string itemName, bool caseSensitive = false)
        {
            IEnumerable<Tour> items = GetItems();

            if (caseSensitive)
            {
                return items.Where(x => x.Name.Contains(itemName));
            }
            return items.Where(x => x.Name.ToLower().Contains(itemName.ToLower()));
        }

       
    }
}
