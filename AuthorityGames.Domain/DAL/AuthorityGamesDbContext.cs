using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorityGames.Domain.Abstraction.DAL;
using AuthorityGames.Domain.Models;

namespace AuthorityGames.Domain.DAL
{
    public class AuthorityGamesDbContext : DbContext, IAuthorityGamesDbContext
	{
		#region CONSTRUCTORS
		public AuthorityGamesDbContext() : base("DefaultConnection")
		{
		}
		#endregion

		#region PROPERTIES
		public IDbSet<Score> Scores { get; set; }
		public IDbSet<User> Users { get; set; }
		#endregion

		#region METHODS
		#endregion
	}
}
