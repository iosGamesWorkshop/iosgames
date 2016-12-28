using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorityGames.Domain.Abstraction.DAL;
using AuthorityGames.Domain.Models;

namespace AuthorityGames.Domain.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
		#region FIELDS
		private bool disposed = false;
		private IAuthorityGamesDbContext _dbContext;
		private IRepository<User> _userRepository;
		private IRepository<Score> _scoreRepository;
		#endregion

		#region CONSTRUCTORS
		public UnitOfWork(IAuthorityGamesDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		#endregion

		#region PROPERTIES
		public IRepository<User> UserRepository
		{
			get
			{
				if (_userRepository == null)
				{
					_userRepository = new Repository<User>(_dbContext);
				}

				return _userRepository;
			}
		}

		public IRepository<Score> ScoreRepository
		{
			get
			{
				if (_scoreRepository == null)
				{
					_scoreRepository = new Repository<Score>(_dbContext);
				}

				return _scoreRepository;
			}
		}
		#endregion

		#region METHODS
		public void Save()
		{
			_dbContext.SaveChanges();
		}
		#endregion

		#region IDisposable Implementation
		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed && disposing)
			{
				_dbContext.Dispose();
			}

			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		#endregion
	}
}
