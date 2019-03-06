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
            : base("ContextGestionCourse", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<BO.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<BO.DisplayConfiguration> DisplayConfigurations { get; set; }

        public System.Data.Entity.DbSet<BO.UniteDistance> UniteDistances { get; set; }

        public System.Data.Entity.DbSet<BO.TypeInscription> TypeInscriptions { get; set; }

        public System.Data.Entity.DbSet<BO.UserRole> UserRoles { get; set; }

        public System.Data.Entity.DbSet<BO.Race> Races { get; set; }

<<<<<<< HEAD
        public System.Data.Entity.DbSet<BO.Inscription> Inscriptions { get; set; }
        
=======
        //public System.Data.Entity.DbSet<GestionDesCourses.Models.ApplicationUser> ApplicationUsers { get; set; }
>>>>>>> 5baae3940ea1f1e2d00f3d843683c799573f6f35
    }
}