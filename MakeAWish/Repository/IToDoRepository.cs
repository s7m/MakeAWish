using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeAWish.Repository
{
    public interface IToDoRepository
    {
         Task UpdateTask(int id, string data, string state, string color);
         Task DeleteTask(int id);
         Task AddTask(int userId, string data, string state, string color);
    }
}
