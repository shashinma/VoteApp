using System;
using VoteApp.DAL;
using VoteApp.ViewModels;

namespace VoteApp.BLL.Service
{
	public interface IStudentService
	{
		PagedResult<StudentViewModel> GetAll(int pageNumber, int pageSize);

		Task<StudentViewModel> AddAsync(StudentViewModel vm);

		IEnumerable<Students> GetAllStudents();

		bool SetGroupIdToStudents(GroupViewModel vm);

		bool SetExamResult(AttendExamViewModel vm);

		IEnumerable<ResultViewModel> GetExamResult(int studentId);

		StudentViewModel GetStudentDetails(int studentId);

		Task<StudentViewModel> UpdateAsync(StudentViewModel vm);
	}
}

