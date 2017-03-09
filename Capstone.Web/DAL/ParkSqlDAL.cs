using Capstone.Web.Models;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.DAL
{
    public class ParkSqlDAL : IParkDAL
    {
        private const string SQL_GetPark = "SELECT * FROM park JOIN weather ON weather.parkCode = park.parkCode WHERE park.parkCode = (@parkCode);";
        private const string SQL_GetParks = "SELECT * FROM park;";

        private string connectionString;

        public ParkSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public ParkModel GetPark(string parkCode)
        {
            ParkModel park = new ParkModel();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetPark, conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        park.ParkCode = Convert.ToString(reader["parkCode"]);
                        park.ParkName = Convert.ToString(reader["parkName"]);
                        park.State = Convert.ToString(reader["state"]);
                        park.Acreage = Convert.ToInt32(reader["acreage"]);
                        park.ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]);
                        park.MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]);
                        park.NumberOfCampSites = Convert.ToInt32(reader["numberOfCampsites"]);
                        park.Climate = Convert.ToString(reader["climate"]);
                        park.YearFounded = Convert.ToInt32(reader["yearFounded"]);
                        park.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
                        park.InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]);
                        park.InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                        park.ParkDescription = Convert.ToString(reader["parkDescription"]);
                        park.Entryfee = Convert.ToInt32(reader["entryFee"]);
                        park.NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);
                        park.FiveDayForecastvalue.Add(Convert.ToInt32(reader["fiveDayForecastValue"]));
                        park.Low.Add(Convert.ToInt32(reader["low"]));
                        park.High.Add(Convert.ToInt32(reader["high"]));
                        park.Forecast.Add(Convert.ToString(reader["forecast"]));
                    }
                }
                return park;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public List<ParkModel> GetParks()
        {
            List<ParkModel> output = new List<ParkModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetParks, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ParkModel p = new ParkModel()
                        {
                            ParkCode = Convert.ToString(reader["parkCode"]),
                            ParkName = Convert.ToString(reader["parkName"]),
                            State = Convert.ToString(reader["state"]),
                            Acreage = Convert.ToInt32(reader["acreage"]),
                            ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]),
                            MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]),
                            NumberOfCampSites = Convert.ToInt32(reader["numberOfCampsites"]),
                            Climate = Convert.ToString(reader["climate"]),
                            YearFounded = Convert.ToInt32(reader["yearFounded"]),
                            AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]),
                            InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]),
                            InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]),
                            ParkDescription = Convert.ToString(reader["parkDescription"]),
                            Entryfee = Convert.ToInt32(reader["entryFee"]),
                            NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"])


                        };

                        output.Add(p);
                    }
                    
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return output;
        }
    }
}