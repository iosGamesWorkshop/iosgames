using System;
using AuthorityGames.IOC.Registrators;
using Microsoft.Practices.Unity;

namespace AuthorityGames.IOC
{
	public class Container
    {
		private static readonly Lazy<IUnityContainer> instance = new Lazy<IUnityContainer>(() =>
		{
			var container = new UnityContainer();
			DALTypeRegistrator.RegisterTypes(container);
			DomainHelpersTypeRegistrator.RegisterTypes(container);
			DomainServicesTypeRegistrator.RegisterTypes(container);

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
