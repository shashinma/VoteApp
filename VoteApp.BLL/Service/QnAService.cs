using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using VoteApp.DAL;
using VoteApp.DAL.UnitOfWork;
using VoteApp.ViewModels;

namespace VoteApp.BLL.Service
{
	public class QnAService : IQnAService
	{
        IUnitOfWork _unitofwork;
        ILogger<QnAService> _iLogger;

        public QnAService(IUnitOfWork unitofwork, ILogger<QnAService> iLogger)
        {
            _unitofwork = unitofwork;
            _iLogger = iLogger;
        }

        public async Task<QnAsViewModel> AddAsync(QnAsViewModel QnAVM)
        {
            try
            {
                QnAs objGroup = QnAVM.ConvertViewModel(QnAVM);
                await _unitofwork.GenericRepository<QnAs>().AddAsync(objGroup);
                _unitofwork.Save();
            }
            catch (Exception ex)
            {
                return null;
            }

            return QnAVM;
        }

        public PagedResult<QnAsViewModel> GetAll(int pageNumber, int pageSize)
        {
            var model = new QnAsViewModel();
            try
            {
                int ExcludeRecord = (pageNumber * pageSize) - pageSize;
                List<QnAsViewModel> detailList = new List<QnAsViewModel>();
                var modelList = _unitofwork.GenericRepository<QnAs>().GetAll().Skip(ExcludeRecord).Take(pageSize).ToList();
                var totalCount = _unitofwork.GenericRepository<QnAs>().GetAll().ToList();
                detailList = ListInfo(modelList);
                if (detailList != null)
                {
                    model.QnAsList = detailList;
                    model.TotalCount = totalCount.Count();
                }
            }
            catch (Exception ex)
            {
                _iLogger.LogError(ex.Message);
            }

            var result = new PagedResult<QnAsViewModel>
            {
                Data = model.QnAsList,
                TotalItems = model.TotalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return result;
        }

        private List<QnAsViewModel> ListInfo(List<QnAs> modelList)
        {
            return modelList.Select(o => new QnAsViewModel(o)).ToList();
        }

        public IEnumerable<QnAsViewModel> GetAllQnAByExams(int examId)
        {
            try
            {
                var qnaList = _unitofwork.GenericRepository<QnAs>().GetAll().Where(x => x.ExamsId == examId);
                return ListInfo(qnaList.ToList());
            }
            catch (Exception ex)
            {
                _iLogger.LogError(ex.Message);
            }

            return Enumerable.Empty<QnAsViewModel>();
        }

        public bool IsExamAttended(int examId, int studentId)
        {
            try
            {
                var qnaRecord = _unitofwork.GenericRepository<ExamResults>().GetAll()
                    .FirstOrDefault(x => x.ExamsId == examId && x.StudentId == studentId);
                return qnaRecord == null ? false : true;
            }
            catch (Exception ex)
            {
                _iLogger.LogError(ex.Message);
            }
            return false;
        }
    }
}

