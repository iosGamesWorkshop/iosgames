using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorityGames.API.IOC;
using Microsoft.Practices.Unity;
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
