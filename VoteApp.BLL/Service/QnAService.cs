using System;
using VoteApp.ViewModels;

namespace VoteApp.BLL.Service
{
	public class QnAService : IQnAService
	{
		public QnAService()
		{
		}

        public Task<QnAsViewModel> AddAsync(QnAsViewModel QnAVM)
        {
            throw new NotImplementedException();
        }

        public PagedResult<QnAsViewModel> GetAll(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<QnAsViewModel> GetAllExams()
        {
            throw new NotImplementedException();
        }

        public bool IsExamAttended(int examId, int studentId)
        {
            throw new NotImplementedException();
        }
    }
}

