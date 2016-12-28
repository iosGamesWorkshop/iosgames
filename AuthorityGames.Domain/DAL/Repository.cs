using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AuthorityGames.Domain.Abstraction.DAL;

namespace AuthorityGames.Domain.DAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
		#region FIELDS
		internal IAuthorityGamesDbContext _dbContext;
		internal IDbSet<TEntity> _dbSet;
		#endregion

		#region CONSTRUCTORS
		public Repository(IAuthorityGamesDbContext dbContext)
		{
			_dbContext = dbContext;
			_dbSet = dbContext.Set<TEntity>();
		}
		#endregion

		#region METHODS
		/// <summary>
		/// Returns specified entities filtered by provided search criteria.
		/// </summary>
		/// <param name="filter">Filter expression.</param>
		/// <param name="orderBy">Ordering expression.</param>
		/// <param name="includeProperties">Include properties comma separated string list.</param>
		/// <returns>Filtered entity collection.</returns>
		public virtual IEnumerable<TEntity> Get(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string includeProperties = "")
		{
			IQueryable<TEntity> query = _dbSet;

			// Apply provided filter expression.
			if (filter != null)
			{
				query = query.Where(filter);
			}

			// Apply provided include properties expression.
			foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				query = query.Include(includeProperty);
			}

			// Apply ordering expression.
			if (orderBy != null)
			{
				return orderBy(query).ToList();
			}

			return query.ToList();
		}

		/// <summary>
		/// Returns specific entity by provided id.
		/// </summary>
		/// <param name="id">Object that will be used for search.</param>
		/// <returns>Filtered entity.</returns>
		public virtual TEntity GetById(object id)
		{
			return _dbSet.Find(id);
		}

		/// <summary>
		/// Inserts provided entity to repository collection of entities.
		/// </summary>
		/// <param name="entity">Entity to be inserted.</param>
		/// <returns>Inserted entity object.</returns>
		public virtual TEntity Insert(TEntity entity)
		{
			var newEntity = _dbSet.Add(entity);
			return newEntity;
		}

		/// <summary>
		/// Deletes entity from repository collection of entities by provided id.
		/// </summary>
		/// <param name="id">Object that will be used to identify entity to be deleted.</param>
		public virtual void Delete(object id)
		{
			var entityToDelete = _dbSet.Find(id);
			Delete(entityToDelete);
		}

		/// <summary>
		/// Deletes provided entity in repository collection of entities.
		/// </summary>
		/// <param name="entity">Entity to be deleted.</param>
		public virtual void Delete(TEntity entity)
		{
			if (_dbContext.Entry(entity).State == EntityState.Detached)
			{
				_dbSet.Attach(entity);
			}

			_dbSet.Remove(entity);
		}

		/// <summary>
		/// Updates provided entity in repository collection of entities.
		/// </summary>
		/// <param name="entity">Entity to be updated.</param>
		public virtual void Update(TEntity entity)
		{
			_dbSet.Attach(entity);
			_dbContext.Entry(entity).State = EntityState.Modified;
		}
		#endregion
	}
}
