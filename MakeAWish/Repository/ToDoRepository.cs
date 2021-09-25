using MakeAWish.Data;
using MakeAWish.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MakeAWish.Repository
{
    public class ToDoRepository : IToDoRepository
    {
        public async Task DeleteTask(int id)
        {
            using (var context = new ToDoContext())
            {
                var result = context.ToDoList.SingleOrDefault(t => t.id == id);
                //Delete task if exists
                if (result != null)
                {
                    context.ToDoList.Remove(result);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<int> UpdateTask(int id, string data, string state, string color)
        {
            int saveCount = 0;
            using (var context = new ToDoContext())
            {
                //Check if exists
                var existingTask = context.ToDoList.SingleOrDefault(t => t.id == id);
                if (existingTask != null)
                {
                    existingTask.state = state;
                    existingTask.hex = color;
                    saveCount = await context.SaveChangesAsync();
                }
            }

            return saveCount;
        }

        public async Task AddTask(int userId, string data, string state, string color)
        {
            using (var context = new ToDoContext())
            {
                ToDoModel dataToSave = new ToDoModel();
                dataToSave.label = data;
                dataToSave.userId = userId;
                dataToSave.state = state;
                dataToSave.hex = color;
                context.ToDoList.Add(dataToSave);
                await context.SaveChangesAsync();
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
