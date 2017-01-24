using AuthorityGame.Domain.Services;
using AuthorityGame.Domain.Services.Concretes;
using Microsoft.Practices.Unity;

namespace AuthorityGames.IOC.Registrators
{
	public class DomainServicesTypeRegistrator
    {
		public static void RegisterTypes(IUnityContainer container)
		{
			container.RegisterType<IAuthService, AuthService>();
		}
	}
}
