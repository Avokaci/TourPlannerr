using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using TourPlanner.Models;

namespace TourPlanner.DAL
{
    class FileSystem : IDataAccess
    {
        private string filePath;

        public FileSystem()
        {
            //get filepath from config file
            this.filePath = "...";
        }

        public List<Tour> GetItems()
        {
            //get media items from file system
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
            //string key = configFile.fileSystemSettings.Key;
            string key = "tTz9lIg7C5SWXJsGlSgT6yRST3mjerGR";
            string imageNumber;
            string imageFilePath;
            string url = @"https://www.mapquestapi.com/staticmap/v5/map?start=" + from + "&end=" + to + "&size=600,400@2x&key=" + key;

            if (path == "")
            {
                path = filePath;
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse lxResponse = (HttpWebResponse)request.GetResponse())
            {
                using (BinaryReader reader = new BinaryReader(lxResponse.GetResponseStream()))
                {
                    Byte[] lnByte = reader.ReadBytes(1 * 1024 * 1024 * 10);
                    Random rnd = new Random();
                    imageNumber = Convert.ToString(rnd.Next(100000));
                    imageFilePath = path + imageNumber + ".jpg";
                    using (FileStream lxFS = new FileStream(imageFilePath, FileMode.Create))
                    {
                        lxFS.Write(lnByte, 0, lnByte.Length);
                    }
                }
            }
            return imageFilePath;
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
