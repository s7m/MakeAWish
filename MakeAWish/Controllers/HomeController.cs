using MakeAWish.Dtos;
using MakeAWish.Models;
using MakeAWish.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MakeAWish.Controllers
{
    public class HomeController : Controller
    {
        private IToDoRepository _toDoRepository;

        public HomeController()
        {
            _toDoRepository = new ToDoRepository();
        }

        public async Task<ActionResult> Index()
        {
            //Redirect if the user not logged in
            if (Session["userId"] == null)
            {
                return RedirectToAction("Welcome", "Auth");
            }

            int userId = Convert.ToInt32(Session["userId"]);

            ToDoViewModel viewModel = new ToDoViewModel();
            viewModel.toDoModels = new List<ToDoModel>();
            viewModel.toDoModels = await _toDoRepository.GetList(userId);

            return View("Index", viewModel);
        }

        [HttpPost]
        public async Task AddTask(TaskDto task)
        {
            int userId = Convert.ToInt32(Session["userId"]);
            await _toDoRepository.AddTask(userId, task);
        }

        public async Task UpdateTask(TaskDto task)
        {
            //returns the number of saved items
            int saveStatus = await _toDoRepository.UpdateTask(task);
        }

        public async Task DeleteTask(int id)
        {
            await _toDoRepository.DeleteTask(id);
        }
    }
}