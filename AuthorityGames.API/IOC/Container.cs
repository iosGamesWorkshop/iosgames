using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace AuthorityGames.API.IOC
{
    public class Container
    {
		private static readonly Lazy<IUnityContainer> instance = new Lazy<IUnityContainer>(() =>
		{
			var container = new UnityContainer();
			Domain.IOC.UnityTypeRegistrator.RegisterTypes(container);

			return container;
		});

		// private to prevent direct instantiation.
		private Container()
		{
		}

		// accessor for instance
		public static IUnityContainer GetConfiguredContainer()
		{
			return instance.Value;
		}
	}
}
