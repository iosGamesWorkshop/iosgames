using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorityGames.Domain.Models;

namespace AuthorityGames.Domain.Abstraction.DAL
{
    public interface IUnitOfWork
    {
		#region PROPERTIES
		IRepository<Score> ScoreRepository { get; }
		IRepository<User> UserRepository { get; }
		#endregion

		#region METHODS
		/// <summary>
		/// Saves current unit of work to database context.
		/// </summary>
		void Save();
		#endregion
	}
}
