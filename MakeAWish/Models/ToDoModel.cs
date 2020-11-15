using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeAWish.Models
{
    public class ToDoModel
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string state { get; set; }
        public string label { get; set; }
        public string tags { get; set; }
        public string hex { get; set; }
        public int resourceId { get; set; }
    }
}