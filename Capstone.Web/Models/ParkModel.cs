using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Models
{
    public class ParkModel
    {
        public string ParkCode { get; set; }
        public string ParkName { get; set; }
        public string State { get; set; }
        public int Acreage { get; set; }
        public int ElevationInFeet { get; set; }
        public int MilesOfTrail { get; set; }
        public int NumberOfCampSites { get; set; }
        public string Climate { get; set; }
        public int YearFounded { get; set; }
        public int AnnualVisitorCount { get; set; }
        public string InspirationalQuote { get; set; }
        public string InspirationalQuoteSource { get; set; }
        public string ParkDescription { get; set; }
        public int Entryfee { get; set; }
        public int NumberOfAnimalSpecies { get; set; }
        public List<int> FiveDayForecastvalue { get; set; } = new List<int>();
        public List<int> Low { get; set; } = new List<int>();
        public List<int> High { get; set; } = new List<int>();
        public List<string> Forecast { get; set; } = new List<string>();
        public List<string> ImageName
        {
            get
            {
                List<string> Images = new List<string>();
                for (int i = 0; i < Forecast.Count; i++)
                {
                    string name = Forecast[i].Replace(" ", "");

                    Images.Add(name);
                }
                return Images;

            }
        }
        public int GetTemp(int tempInF, bool isInF)
        {
            if (isInF)
            {
                return tempInF;
            }
            return ((tempInF - 32) * 5) / 9;
        }

       
    }
}