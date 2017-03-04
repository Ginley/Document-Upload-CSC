using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Document_Upload.Startup))]
namespace Document_Upload
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
