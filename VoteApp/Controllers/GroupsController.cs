using System;
using Microsoft.AspNetCore.Mvc;
using VoteApp.BLL.Service;
using VoteApp.ViewModels;

namespace VoteApp.Controllers
{
	public class GroupsController : Controller
	{
		private readonly IGroupService _groupService;
		private readonly IStudentService _studentService;

        public GroupsController(IGroupService groupService, IStudentService studentService)
        {
            _groupService = groupService;
            _studentService = studentService;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_groupService.GetAllGroups(pageNumber, pageSize));
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Create(GroupViewModel groupViewModel)
        {
            if (ModelState.IsValid)
            {
                groupViewModel.UserId = 1;
                await _groupService.AddGroupAsync(groupViewModel);
                return RedirectToAction(nameof(Index));
            }

            return View(groupViewModel);
        }

        public IActionResult Details(string groupId)
        {
            var model = _groupService.GetById(Convert.ToInt32(groupId));
            model.StudentCheckList = _studentService.GetAllStudents().Select(
                a => new StudentCheckBoxListViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Selected = a.GroupsId == Convert.ToInt32(groupId)
                }).ToList();

            return View(model);
        }

        public IActionResult Details(GroupViewModel groupViewModel)
        {
            bool result = _studentService.SetGroupIdToStudents(groupViewModel);

            if (result)
                return RedirectToAction("Details", new { Id = groupViewModel.Id });

            return View(groupViewModel);
        }
    }
}