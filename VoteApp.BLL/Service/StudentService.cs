using Microsoft.Extensions.Logging;
using VoteApp.DAL;
using VoteApp.DAL.UnitOfWork;
using VoteApp.ViewModels;

namespace VoteApp.BLL.Service
{
    public class StudentService : IStudentService
	{
		IUnitOfWork _unitOfWork;
        ILogger<StudentService> _iLogger;

        public StudentService(IUnitOfWork unitOfWork, ILogger<StudentService> iLogger)
        {
            _unitOfWork = unitOfWork;
            _iLogger = iLogger;
        }

        public async Task<StudentViewModel> AddAsync(StudentViewModel vm)
        {
            try
            {
                Students obj = vm.ConvertViewModel(vm);
                object value = await _unitOfWork.GenericRepository<Students>().AddAsync(obj);
            }
            catch (Exception ex)
            {
                return null;
            }
            return vm;
        }

        public PagedResult<StudentViewModel> GetAll(int pageNumber, int pageSize)
        {
            var model = new StudentViewModel();
            try
            {
                int ExcludeRecord = (pageSize - pageNumber) * pageSize;
                List<StudentViewModel> detailList = new List<StudentViewModel>();
                var modelList = _unitOfWork.GenericRepository<Students>().GetAll().Skip(ExcludeRecord).Take(pageSize).ToList();
                var totalCount = _unitOfWork.GenericRepository<Students>().GetAll().ToList();
                detailList = GroupListInfo(modelList);

                if (detailList != null)
                {
                    model.StudentList = detailList;
                    model.TotalCount = totalCount.Count();
                }
            }
            catch (Exception ex)
            {
                _iLogger.LogError(ex.Message);
            }

            var result = new PagedResult<StudentViewModel>
            {
                Data = model.StudentList,
                TotalItems = model.TotalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return result;
        }

        private List<StudentViewModel> GroupListInfo(List<Students> modelList)
        {
            return modelList.Select(o => new StudentViewModel(o)).ToList();
        }

        public IEnumerable<Students> GetAllStudents()
        {
            
        }

        public IEnumerable<ResultViewModel> GetExamResult(int studentId)
        {
            try
            {
                var examResults = _unitOfWork.GenericRepository<ExamResults>().GetAll().Where(a => a.StudentId == studentId);
                var students = _unitOfWork.GenericRepository<Students>().GetAll();
                var exams = _unitOfWork.GenericRepository<Exams>().GetAll();
                var qnas = _unitOfWork.GenericRepository<QnAs>().GetAll();

                var requiredData = examResults.Join(students, er => er.StudentId, s => s.Id,
                    (er, st) => new { er, st }).Join(exams, erj => erj.er.ExamsId, ex => ex.Id,
                    (erj, ex) => new { erj, ex }).Join(qnas, exj => exj.erj.er.QnAsId, q => q.Id,
                    (exj, q) => new ResultViewModel()
                    {
                        StudentId = studentId,
                        ExamName = exj.ex.Title,
                        TotalQuestion = examResults.Count(a => a.StudentId == studentId && a.ExamsId == exj.ex.Id),
                        CorrectAnswer = examResults.Count(a => a.StudentId == studentId && a.ExamsId == exj.ex.Id && a.Answer == q.Answer),
                        WrongAnswer = examResults.Count(a => a.StudentId == studentId && a.ExamsId == exj.ex.Id && a.Answer != q.Answer)
                    });
                return requiredData;
            }
            catch (Exception ex)
            {
                _iLogger.LogError(ex.Message);
            }
            return Enumerable.Empty<ResultViewModel>();
        }

        public StudentViewModel GetStudentDetails(int studentId)
        {
            try
            {
                var student = _unitOfWork.GenericRepository<Students>().GetByID(studentId);
                return student != null ? new StudentViewModel(student) : null;
            }
            catch (Exception ex)
            {
                _iLogger.LogError(ex.Message);
            }

            return null;
        }

        public bool SetExamResult(AttendExamViewModel vm)
        {
            throw new NotImplementedException();
        }

        public bool SetGroupIdToStudents(GroupViewModel vm)
        {
            throw new NotImplementedException();
        }

        public Task<StudentViewModel> UpdateAsync(StudentViewModel vm)
        {
            throw new NotImplementedException();
        }
    }
}

