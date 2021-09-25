using MakeAWish.Dtos;
using MakeAWish.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MakeAWish.Repository
{
    public interface IToDoRepository
    {
        Task<List<ToDoModel>> GetList(int userId);
        Task<int> UpdateTask(TaskDto task);
        Task DeleteTask(int id);
        Task AddTask(int userId, TaskDto task);
    }
}
