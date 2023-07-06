using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace VoteApp.DAL.Repository
{
	public interface IGenericRepository<T> : IDisposable
	{
		IEnumerable<T> GetAll(
			Expression<Func<T, bool>> filter = null,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			string includeProperties = "");

		T GetByID(object id);

		Task<T> GetByIdAsync(object id);

		void Add(T entity);

		Task<T> AddAsync(T entity);

		void DeleteByID(object id);

		void Delete(T entityToDelete);

        void Update(T entityToUpdate);

		Task<T> UpdateAsync(T entityToDelete);

		Task<T> DeleteAsync(T entityToDelete);
    }
}

