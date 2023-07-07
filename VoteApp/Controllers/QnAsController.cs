
using System;
using Microsoft.AspNetCore.Mvc;
using VoteApp.BLL.Service;
using VoteApp.ViewModels;

namespace VoteApp.Controllers
{
	public class QnAsController : Controller
	{
		private readonly IExamService _examService;
		private readonly IQnAService _qnAService;

        public QnAsController(IExamService examService, IQnAService qnAService)
        {
            _examService = examService;
            _qnAService = qnAService;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
		{
			return View(_qnAService.GetAll(pageNumber, pageSize));
		}

		public IActionResult Create()
		{
			var model = new QnAsViewModel();
			model.ExamList = _examService.GetAllExams();

			return View(model);
		}

		public async Task<IActionResult> Create(QnAsViewModel qnViewModel)
		{
			if (ModelState.IsValid)
			{
				await _qnAService.AddAsync(qnViewModel);

				return RedirectToAction(nameof(Index));
			}

			return View(qnViewModel);
		}
	}
}

