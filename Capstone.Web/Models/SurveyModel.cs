﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Models
{
    public class SurveyModel
    {
        public int SurveyID { get; set; }
        public string ParkCode { get; set; }
        public string EmailAddress { get; set; }
        public string State { get; set; }
        public string ActivityLevel { get; set; }

        public static List<SelectListItem> ActivityLevels { get; } = new List<SelectListItem>()
        {
            new SelectListItem() {Text ="inactive", Value="inactive"},
            new SelectListItem() {Text ="sedentary", Value="sedentary"},
            new SelectListItem() {Text ="active", Value="active"},
            new SelectListItem() {Text ="extremely active", Value="extremely inactive"},
        };

        public static List<SelectListItem> Parks { get; } = new List<SelectListItem>()
        {
            new SelectListItem() {Text ="Cuyahoga Valley National Park", Value="CVNP"},
            new SelectListItem() {Text ="Everglades National Park", Value="ENP"},
            new SelectListItem() {Text ="Grand Canyon National Park", Value="GCNP"},
            new SelectListItem() {Text ="Glacier National Park", Value="GCP"},
            new SelectListItem() {Text ="Great Smoky Mountains National Park", Value="GSMNP"},
            new SelectListItem() {Text ="Mount Rainier National Park", Value="MRNP"},
            new SelectListItem() {Text ="Grand Teton National Park", Value="GTNP"},
            new SelectListItem() {Text ="Rocky Mountain National Park", Value="RMNP"},
            new SelectListItem() {Text ="Yellowstone National Park", Value="YNP"},
            new SelectListItem() {Text ="Yosemita National Park", Value="YNP2"},
        };
    }
}