using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GestionCourse.Models
{
    public class ContextGestionCourse : DbContext
    {
        public System.Data.Entity.DbSet<BO.Category> Categories { get; set; }
        public System.Data.Entity.DbSet<BO.UniteDistance> UniteDistance { get; set; }
        public System.Data.Entity.DbSet<BO.DisplayConfiguration> DisplayConfigurations { get; set; }

    }
}