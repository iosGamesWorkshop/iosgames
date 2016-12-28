using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuthorityGames.Domain.Abstraction.DAL
{
    public interface IRepository<TEntity> where TEntity : class
    {
		#region METHODS
		/// <summary>
		/// Returns specified entities filtered by provided search criteria.
		/// </summary>
		/// <param name="filter">Filter expression.</param>
		/// <param name="orderBy">Ordering expression.</param>
		/// <param name="includeProperties">Include properties comma separated string list.</param>
		/// <returns>Filtered entity collection.</returns>
		IEnumerable<TEntity> Get(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string includeProperties = "");

		/// <summary>
		/// Returns specific entity by provided id.
		/// </summary>
		/// <param name="id">Object that will be used for search.</param>
		/// <returns>Filtered entity.</returns>
		TEntity GetById(object id);

		/// <summary>
		/// Inserts provided entity to repository collection of entities.
		/// </summary>
		/// <param name="entity">Entity to be inserted.</param>
		/// <returns>Inserted entity object.</returns>
		TEntity Insert(TEntity entity);

		/// <summary>
		/// Deletes entity from repository collection of entities by provided id.
		/// </summary>
		/// <param name="id">Object that will be used to identify entity to be deleted.</param>
		void Delete(object id);

		/// <summary>
		/// Deletes provided entity in repository collection of entities.
		/// </summary>
		/// <param name="entity">Entity to be deleted.</param>
		void Delete(TEntity entity);

		/// <summary>
		/// Updates provided entity in repository collection of entities.
		/// </summary>
		/// <param name="entity">Entity to be updated.</param>
		void Update(TEntity entity);
		#endregion
	}
}
