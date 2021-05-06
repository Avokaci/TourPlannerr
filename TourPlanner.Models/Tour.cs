using System;

namespace TourPlanner.Models
{
    public class Tour
    {
        private string name;
        private string description;
        private string from;
        private string to;
        private string imagepath;

        public Tour(string name, string description, string from, string to, string imagepath)
        {
            this.Name = name;
            this.Description = description;
            this.From = from;
            this.To = to;
            this.Imagepath = imagepath;
        }

        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string From { get => from; set => from = value; }
        public string To { get => to; set => to = value; }
        public string Imagepath { get => imagepath; set => imagepath = value; }
    }
}
