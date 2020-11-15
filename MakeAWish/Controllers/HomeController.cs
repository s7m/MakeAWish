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

        public ActionResult Index()
        {
            //Redirect if the user not logged in
            if (Session["userId"] == null)
            {
                return RedirectToAction("Welcome", "Auth");
            }

            int userId = Convert.ToInt32(Session["userId"]);

            ToDoViewModel viewModel = new ToDoViewModel();
            using (var context = new ToDoContext())
            {
                viewModel.toDoModels = new List<ToDoModel>();
                viewModel.toDoModels = context.ToDoList.Where(u => u.userId == userId).ToList();
            }

            return View("Index", viewModel);
        }

        [HttpPost]
        public async Task AddTask(string id, string data, string state, string color)
        {
            int userId = Convert.ToInt32(Session["userId"]);
            _toDoRepository = new ToDoRepository();
            await _toDoRepository.AddTask(userId, data, state, color);
        }

        public async Task UpdateTask(int id, string data, string state, string color)
        {
            _toDoRepository = new ToDoRepository();
            await _toDoRepository.UpdateTask(id, data, state, color);
        }

        public async Task DeleteTask(int id)
        {
            _toDoRepository = new ToDoRepository();
            await _toDoRepository.DeleteTask(id);
        }
    }
}