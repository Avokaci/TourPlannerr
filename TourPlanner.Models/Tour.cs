using System;

namespace TourPlanner.Models
{
    public class Tour
    {
        private int id;
        private string name;
        private string description;
        private string from;
        private string to;
        private string imagepath;

        public Tour(int id, string name, string description, string from, string to, string imagepath)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.from = from;
            this.to = to;
            this.imagepath = imagepath;
        }

        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string From { get => from; set => from = value; }
        public string To { get => to; set => to = value; }
        public string Imagepath { get => imagepath; set => imagepath = value; }
        public int Id { get => id; set => id = value; }
    }
}
