using System;
using System.Collections.Generic;
using System.Text;
using TourPlanner.BusinessLayer;

namespace TourPlanner.BL
{
    public class TourFactory
    {
        private static ITourFactory instance;

        public static ITourFactory GetInstance()
        {
            if (instance == null)
            {
                instance = new TourFactoryImpl();
            }
            return instance;
        }
    }
}
