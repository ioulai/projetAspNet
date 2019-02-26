using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GestionCourse.Startup))]
namespace GestionCourse
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
