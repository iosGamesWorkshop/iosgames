using AuthorityGames.IOC;
using Nancy.Owin;
using Owin;

namespace AuthorityGames.API
{
	public class Startup
    {
        public void Configuration(IAppBuilder app)
		{
			app.UseNancy(new NancyOptions
			{
				EnableClientCertificates = true,
				Bootstrapper = new UnityBootstrapper(Container.GetConfiguredContainer())
			});
		}
    }
}
