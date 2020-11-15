using MakeAWish.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeAWish.Repository
{
    public interface IToDoRepository
    {
        Task<List<ToDoModel>> GetList(int userId);
        void UpdateTask(int id, string data, string state, string color);
        void DeleteTask(int id);
        void AddTask(int userId, string data, string state, string color);
    }
}
