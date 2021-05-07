using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TourPlanner.Models;

namespace TourPlanner.DAL.Common
{
    public interface IFileAccess
    {
        int CreateNewTourFile(string name, string tourDescription, string tourDistance, string from, string to, string routeInformation);
        int CreateNewLogFile(DateTime publishingDate, string author, DateTime tripStart, DateTime tripEnd, Rating rating, string report, Tour tourItem);
        IEnumerable<FileInfo> SearchFiles(string searchTerm, MediaType searchType);

        IEnumerable<FileInfo> GetAllFiles(MediaType searchType);
    }
}
