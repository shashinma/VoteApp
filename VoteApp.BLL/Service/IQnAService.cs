using System;
using VoteApp.DAL;
using VoteApp.ViewModels;

namespace VoteApp.BLL.Service
{
	public interface IQnAService
	{
		PagedResult<QnAsViewModel> GetAll(int pageNumber, int pageSize);

		Task<QnAsViewModel> AddAsync(QnAsViewModel QnAVM);

		IEnumerable<QnAsViewModel> GetAllExams();

		bool IsExamAttended(int examId, int studentId);
	}
}

