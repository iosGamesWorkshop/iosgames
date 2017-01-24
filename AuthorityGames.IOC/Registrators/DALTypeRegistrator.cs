using AuthorityGames.DAL;
using AuthorityGames.DAL.Models;
using AuthorityGames.DAL.Repositories;
using AuthorityGames.Domain.DAL.Repositories;
using Microsoft.Practices.Unity;

namespace AuthorityGames.IOC.Registrators
{
	public class DALTypeRegistrator
    {
		public static void RegisterTypes(IUnityContainer container)
		{
			container.RegisterType<IRepository<GameBattleshipMatch>, Repository<GameBattleshipMatch>>();
			container.RegisterType<IRepository<ShipType>, Repository<ShipType>>();
			container.RegisterType<IRepository<User>, Repository<User>>();
			container.RegisterType<IRepository<UserMatchHistory>, Repository<UserMatchHistory>>();
			container.RegisterType<IRepository<UserApiKey>, Repository<UserApiKey>>();
			container.RegisterType<IAppDbContext, AppDbContext>();
			container.RegisterType<IUnitOfWork, UnitOfWork>();
		}
	}
}
