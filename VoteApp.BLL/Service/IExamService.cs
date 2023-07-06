using System;
using VoteApp.DAL;
using VoteApp.ViewModels;

namespace VoteApp.BLL.Service
{
	public interface IExamService
	{
		PagedResult<ExamViewModel> GetAll(int pageNumber, int pageSize);

		Task<ExamViewModel> AddAsync(ExamViewModel examVM);

		IEnumerable<Exams> GetAllExams();
	}
}

