using MakeAWish.Data;
using MakeAWish.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakeAWish.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ToDoViewModel viewModel = new ToDoViewModel();
            using (var context = new ToDoContext())
            {
                viewModel.toDoModels = new List<ToDoModel>();
                viewModel.toDoModels = context.ToDoList.ToList();
                
                //viewModel.toDoModels.Add(new ToDoModel

                //{ id = 1, state = "new", label = "Make a new Dashboard", tags = "dashboard", hex = "#36c7d0", resourceId = 3 }
                //);

                //viewModel.toDoModels.Add(new ToDoModel
                //{ id = 2, state = "new", label = "Test", tags = "dashboard", hex = "#36c7d0", resourceId = 3 }
                //);

                //viewModel.toDoModels.Add(new ToDoModel
                //{ id = 1156, state = "work", label = "Test", tags = "dashboard", hex = "#36c7d0", resourceId = 3 }
                //);

                //viewModel.toDoModels.Add(new ToDoModel
                //{ id = 123, state = "done", label = "Test", tags = "dashboard", hex = "#36c7d0", resourceId = 3 }
                //);
            }

            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public void Save(string id, string data, string state, string isDelete)
        {
            using (var context = new ToDoContext())
            {
                ToDoModel dataToSave = new ToDoModel();
                //dataToSave.id = 11;
                dataToSave.label = data;
                dataToSave.state = state;

                context.ToDoList.Add(dataToSave);
                context.SaveChanges();
            }
        }

    }
}