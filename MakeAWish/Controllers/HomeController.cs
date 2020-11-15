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
        public void AddTask(string id, string data, string state)
        {
            using (var context = new ToDoContext())
            {
                ToDoModel dataToSave = new ToDoModel();
                dataToSave.label = data;
                dataToSave.state = state;
                dataToSave.hex = "#6bbd49";
                context.ToDoList.Add(dataToSave);
                context.SaveChanges();
            }
        }


        public void UpdateTask(int id, string data, string state)
        {
            using (var context = new ToDoContext())
            {
                var result = context.ToDoList.SingleOrDefault(t => t.id == id);
                if (result != null)
                {
                    result.state = state;
                    result.hex = GetColor(state);
                    //context.ToDoList.(dataToSave);
                    context.SaveChanges();
                }
            }
        }

        public void DeleteTask(int id)
        {
            using (var context = new ToDoContext())
            {
                var result = context.ToDoList.SingleOrDefault(t => t.id == id);
                if (result != null)
                {
                    context.ToDoList.Remove(result);
                    context.SaveChanges();
                }
            }
        }

        private string GetColor(string state)
        {
            switch (state)
            {
                case "new":
                    return "#6bbd49";

                case "work":
                    return "#f19b60";

                case "done":
                    return "#5dc3f0";
                default:
                    return "#dddddd";
            }

        }
    }
}