using System;

namespace TourPlanner.Models
{
    public class Tour
    {
        private string name;
        private string description;
        private string route;
        private long distance;

        public Tour(string name, string description, string route, long distance)
        {
            this.name = name;
            this.description = description;
            this.route = route;
            this.distance = distance;
        }

        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string Route { get => route; set => route = value; }
        public long Distance { get => distance; set => distance = value; }


    }
}
