using System;
using VoteApp.DAL.Repository;

namespace VoteApp.DAL.UnitOfWork
{
	public interface IUnitOfWork
	{
		IGenericRepository<T> GenericRepository<T>() where T : class;

		void Save();
	}
}

