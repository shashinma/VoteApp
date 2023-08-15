using System;
using Microsoft.AspNetCore.Mvc;
using VoteApp.BLL.Service;
using VoteApp.ViewModels;

namespace VoteApp.Controllers
{ 
    public class UsersController : Controller 
    { 
        private readonly IAccountService _accountService;

        public UsersController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_accountService.GetAllTeachers(pageNumber, pageSize));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                _accountService.AddTeacher(userViewModel);
                return RedirectToAction("Index");
            }

            return View(userViewModel);
        }
    }
}

