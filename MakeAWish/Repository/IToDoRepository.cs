using MakeAWish.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MakeAWish.Repository
{
    public interface IToDoRepository
    {
        Task<List<ToDoModel>> GetList(int userId);
        Task<int> UpdateTask(int id, string data, string state, string color);
        Task DeleteTask(int id);
        Task AddTask(int userId, string data, string state, string color);
    }
}
