using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ParkingLot.Startup))]
namespace ParkingLot
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
