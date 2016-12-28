using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorityGames.Domain.Models;

namespace AuthorityGames.Domain.Abstraction.DAL
{
    public interface IAuthorityGamesDbContext
    {
		#region PROPERTIES
		IDbSet<User> Users { get; set; }
		IDbSet<Score> Scores { get; set; }
		#endregion

		#region METHODS
		DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
		DbSet<TEntity> Set<TEntity>() where TEntity : class;
		int SaveChanges();
		void Dispose();
		#endregion
	}
}
