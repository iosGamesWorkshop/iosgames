using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorityGames.Domain.Abstraction.DAL;
using AuthorityGames.Domain.DAL;
using AuthorityGames.Domain.Models;
using Microsoft.Practices.Unity;

namespace AuthorityGames.Domain.IOC
{
    public class UnityTypeRegistrator
    {
		public static void RegisterTypes(IUnityContainer container)
		{
			container.RegisterType<IAuthorityGamesDbContext, AuthorityGamesDbContext>();
			container.RegisterType<IRepository<Score>, Repository<Score>>();
			container.RegisterType<IRepository<User>, Repository<User>>();
			container.RegisterType<IUnitOfWork, UnitOfWork>();
		}
	}
}
