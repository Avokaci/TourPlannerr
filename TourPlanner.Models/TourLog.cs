﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TourPlanner.Models
{
    public class TourLog
    {
        private int id;
        private Tour tourLogItem;
        private DateTime date;
        private DateTime totalTime;
        private string report;
        private long distance;
        private int rating;
        //additional properties
        private int averageSpeed;
        private int maxSpeed;
        private int minSpeed;
        private int averageStepCount;
        private int burntCalories;

        public TourLog(int id, Tour tourLogItem, DateTime date, 
            DateTime totalTime, string report, long distance, 
            int rating, int averageSpeed, int maxSpeed, int minSpeed, int averageStepCount, int burntCalories)
        {
            this.id = id;
            this.tourLogItem = tourLogItem;
            this.date = date;
            this.totalTime = totalTime;
            this.report = report;
            this.distance = distance;
            this.rating = rating;
            this.averageSpeed = averageSpeed;
            this.maxSpeed = maxSpeed;
            this.minSpeed = minSpeed;
            this.averageStepCount = averageStepCount;
            this.burntCalories = burntCalories;
        }

        public int Id { get => id; set => id = value; }
        public Tour TourLogItem { get => tourLogItem; set => tourLogItem = value; }
        public DateTime Date { get => date; set => date = value; }
        public DateTime TotalTime { get => totalTime; set => totalTime = value; }
        public string Report { get => report; set => report = value; }
        public long Distance { get => distance; set => distance = value; }
        public int Rating { get => rating; set => rating = value; }
        public int AverageSpeed { get => averageSpeed; set => averageSpeed = value; }
        public int MaxSpeed { get => maxSpeed; set => maxSpeed = value; }
        public int MinSpeed { get => minSpeed; set => minSpeed = value; }
        public int AverageStepCount { get => averageStepCount; set => averageStepCount = value; }
        public int BurntCalories { get => burntCalories; set => burntCalories = value; }
    }
}
