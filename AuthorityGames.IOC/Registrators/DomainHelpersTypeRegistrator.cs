using AuthorityGames.Domain;
using AuthorityGames.Domain.Helpers;
using Microsoft.Practices.Unity;

namespace AuthorityGames.IOC.Registrators
{
	public class DomainHelpersTypeRegistrator
    {
		public static void RegisterTypes(IUnityContainer container)
		{
			container.RegisterType<IDbHelper, DbHelper>();
			container.RegisterType<IEncyptHelper, SHA256EncryptionHelper>();
		}
	}
}
