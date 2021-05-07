using System;
using System.Collections.Generic;
using System.Text;
using TourPlanner.Models;

namespace TourPlanner.DAL.DAO
{
    public interface ITourDAO
    {
        Tour FindById(int id);

        Tour AddNewItem(string name, string tourDescription, string tourDistance, string from, string to, string routeInformation);
        IEnumerable<Tour> GetTours();
    }
}
