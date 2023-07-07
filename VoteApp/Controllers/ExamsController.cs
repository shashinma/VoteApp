using System;
using Microsoft.AspNetCore.Mvc;
using VoteApp.BLL.Service;
using VoteApp.ViewModels;

namespace VoteApp.Controllers
{
	public class ExamsController : Controller
	{
		private readonly IExamService _examService;
		private readonly IGroupService _groupService;

        public ExamsController(IExamService examService, IGroupService groupService)
        {
            _examService = examService;
            _groupService = groupService;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_examService.GetAll(pageNumber, pageSize));
        }

        public IActionResult Create()
        {
            var model = new ExamViewModel();
            model.GroupList = _groupService.GetAllGroups();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExamViewModel examViewModel)
        {
            if (ModelState.IsValid)
            {
                await _examService.AddAsync(examViewModel);
                return RedirectToAction(nameof(Index));
            }

            return View(examViewModel);
        }
    }
}

