using System;
using VoteApp.DAL.UnitOfWork;
using VoteApp.ViewModels;

namespace VoteApp.BLL.Service
{
    public class AccountService : IAccountService
    {
        IUnitOfWork _unitOfWork;

        public AccountService()
        {

        }

        public bool AddTeacher(UserViewModel vm)
        {
            throw new NotImplementedException();
        }

        public PagedResult<UserViewModel> GetAllTeachers(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public LoginViewModel Login(LoginViewModel vm)
        {
            throw new NotImplementedException();
        }
    }
}

