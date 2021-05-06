using System;
using System.Collections.Generic;
using System.Text;

namespace TourPlanner.Models
{
    public class TourLog
    {
        private string tourName;
        private DateTime date;
        private DateTime duration;
        private long distance;
        private string comment;

        public TourLog(string tourName, DateTime date, DateTime duration, long distance, string comment)
        {
            this.tourName = tourName;
            this.date = date;
            this.duration = duration;
            this.distance = distance;
            this.comment = comment;
        }

        public string TourName { get => tourName; set => tourName = value; }
        public DateTime Date { get => date; set => date = value; }
        public DateTime Duration { get => duration; set => duration = value; }
        public long Distance { get => distance; set => distance = value; }
        public string Comment { get => comment; set => comment = value; }
    }
}
