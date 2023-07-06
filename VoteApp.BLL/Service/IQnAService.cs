using System;
using VoteApp.DAL;
using VoteApp.ViewModels;

namespace VoteApp.BLL.Service
{
	public interface IQnAService
	{
		PagedResult<QnAsViewModel> GetAll(int pageNumber, int pageSize);

		Task<ExamViewModel> AddAsync(QnAsViewModel examVM);

		IEnumerable<QnAs> GetAllExams();
	}
}

