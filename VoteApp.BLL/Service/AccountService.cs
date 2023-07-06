using System;
using Microsoft.Extensions.Logging;
using VoteApp.DAL;
using VoteApp.DAL.UnitOfWork;
using VoteApp.ViewModels;

namespace VoteApp.BLL.Service
{
    public class AccountService : IAccountService
    {
        IUnitOfWork _unitOfWork;
        ILogger<StudentService> _iLogger;

        public AccountService(IUnitOfWork unitOfWork, ILogger<StudentService> iLogger)
        {
            _unitOfWork = unitOfWork;
            _iLogger = iLogger;
        }

        public bool AddTeacher(UserViewModel vm)
        {
            throw new NotImplementedException();
        }

        public PagedResult<UserViewModel> GetAllTeachers(int pageNumber, int pageSize)
        {
            var model = new UserViewModel();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;
                List<UserViewModel> detailList = new List<UserViewModel>();
                var modelList = _unitOfWork.GenericRepository<Users>().GetAll()
                    .Where(x => x.Role == (int)EnumRoles.Teacher).Skip(ExcludeRecords).Take(pageSize).ToList();
                detailList = ListInfo(modelList);
                if (detailList != null)
                {
                    model.UserList = detailList;
                    model.TotalCount = _unitOfWork.GenericRepository<Users>().GetAll().Count(x => x.Role == (int)EnumRoles.Teacher);
                }
            }
            catch (Exception ex)
            {
                _iLogger.LogError(ex.Message);
            }

            var result = new PagedResult<UserViewModel>
            {
                Data = model.UserList,
                TotalItems = model.TotalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }

        private List<UserViewModel> ListInfo(List<Users> modelList)
        {
            throw new NotImplementedException();
        }

        public LoginViewModel Login(LoginViewModel vm)
        {
            if (vm.Role == (int)EnumRoles.Admin || vm.Role == (int)EnumRoles.Teacher)
            {
                var user = _unitOfWork.GenericRepository<UserViewModel>().GetAll()
                    .FirstOrDefault(a => a.UserName == vm.UserName.Trim() && a.Password == vm.Password.Trim() && a.Role == vm.Role);
                if(user != null)
                {
                    vm.Id = user.Id;
                    return vm;
                }
            }
            else
            {
                var student = _unitOfWork.GenericRepository<Students>().GetAll()
                    .FirstOrDefault(a => a.UserName == vm.UserName.Trim() && a.Password == vm.Password.Trim());
                if (student != null)
                {
                    vm.Id = student.Id;
                }
                return vm;
            }
            return null;
        }
    }
}

