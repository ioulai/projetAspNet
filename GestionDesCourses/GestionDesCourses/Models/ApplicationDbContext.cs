using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionDesCourses.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<BO.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<BO.DisplayConfiguration> DisplayConfigurations { get; set; }

        public System.Data.Entity.DbSet<BO.UniteDistance> UniteDistances { get; set; }
    }
}