using System;
using VoteApp.ViewModels;

namespace VoteApp.BLL.Service
{
	public interface IAccountService
	{
		LoginViewModel Login(LoginViewModel vm);

		bool AddTeacher(UserViewModel vm);

		PagedResult<UserViewModel> GetAllTeachers(int pageNumber, int pageSize);
	}
}

