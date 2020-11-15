using MakeAWish.Data;
using MakeAWish.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeAWish.Repository
{
    public class ToDoRepository : IToDoRepository
    {
        public void DeleteTask(int id)
        {
            using (var context = new ToDoContext())
            {
                var result = context.ToDoList.SingleOrDefault(t => t.id == id);
                //Delete task if exists
                if (result != null)
                {
                    context.ToDoList.Remove(result);
                    context.SaveChanges();
                }
            }
        }

        public void UpdateTask(int id, string data, string state, string color)
        {
            using (var context = new ToDoContext())
            {
                //Check if exists
                var result = context.ToDoList.SingleOrDefault(t => t.id == id);
                if (result != null)
                {
                    result.state = state;
                    result.hex = color;
                    context.SaveChanges();
                }
            }
        }

        public void AddTask(int userId, string data, string state, string color)
        {
            using (var context = new ToDoContext())
            {
                ToDoModel dataToSave = new ToDoModel();
                dataToSave.label = data;
                dataToSave.userId = userId;
                dataToSave.state = state;
                dataToSave.hex = color;
                context.ToDoList.Add(dataToSave);
                context.SaveChanges();
            }
        }

        public async Task<List<ToDoModel>> GetList(int userId)
        {
            using (var context = new ToDoContext())
            {
                return await context.ToDoList.Where(u => u.userId == userId).ToListAsync();
            }
        }
    }
}
