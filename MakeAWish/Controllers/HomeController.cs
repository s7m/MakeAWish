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
        public async Task AddTask(string id, string data, string state, string color)
        {
            int userId = Convert.ToInt32(Session["userId"]);
            await _toDoRepository.AddTask(userId, data, state, color);
        }

        public async Task UpdateTask(int id, string data, string state, string color)
        {
            //returns the number of saved items
            int saveStatus = await _toDoRepository.UpdateTask(id, data, state, color);
        }

        public async Task DeleteTask(int id)
        {
            await _toDoRepository.DeleteTask(id);
        }
    }
}