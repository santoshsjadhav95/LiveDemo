using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudUsingAdo.Net.Models
{
    public class Student
    {
        public int RollNumber { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public Nullable<int> TrainerId { get; set; }

        public Trainer Trainer { get; set; }
    }
}