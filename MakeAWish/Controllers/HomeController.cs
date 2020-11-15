using MakeAWish.Data;
using MakeAWish.Models;
using MakeAWish.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MakeAWish.Controllers
{
    public class HomeController : Controller
    {
        private IToDoRepository _toDoRepository;

        public HomeController()
        {

        }

        public HomeController(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public async Task<ActionResult> Index()
        {
            //Redirect if the user not logged in
            if (Session["userId"] == null)
            {
                return RedirectToAction("Welcome", "Auth");
            }
            _toDoRepository = new ToDoRepository();

            int userId = Convert.ToInt32(Session["userId"]);

            ToDoViewModel viewModel = new ToDoViewModel();
            viewModel.toDoModels = new List<ToDoModel>();
            viewModel.toDoModels = await _toDoRepository.GetList(userId);

            return View("Index", viewModel);
        }

        [HttpPost]
        public void AddTask(string id, string data, string state, string color)
        {
            int userId = Convert.ToInt32(Session["userId"]);
            _toDoRepository = new ToDoRepository();
             _toDoRepository.AddTask(userId, data, state, color);
        }

        public void UpdateTask(int id, string data, string state, string color)
        {
            _toDoRepository = new ToDoRepository();
             _toDoRepository.UpdateTask(id, data, state, color);
        }

        public void DeleteTask(int id)
        {
            _toDoRepository = new ToDoRepository();
             _toDoRepository.DeleteTask(id);
        }
    }
}