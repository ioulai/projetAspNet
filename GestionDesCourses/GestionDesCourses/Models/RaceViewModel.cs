using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionDesCourses.Models
{
    public class RaceViewModel
    {
        public Race Race { get; set; }

        public List<Category> Categories { get; set; } // = new List<Category>();

        public List<Poi> lesPoisVM { get; set; }

        public int? IdPoisSelected { get; set; }

        public int? IdSelectedCategory { get; set; }
    }
}