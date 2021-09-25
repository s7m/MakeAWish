using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeAWish.Dtos
{
    public class TaskDto
    {
        public int id { get; set; }
        public string data { get; set; }
        public string state { get; set; }
        public string color { get; set; }
    }
}