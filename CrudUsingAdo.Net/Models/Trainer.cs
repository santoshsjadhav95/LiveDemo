using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudUsingAdo.Net.Models
{
    public interface ITrainer
    {
        int TrainerId { get; set; }
        string Name { get; set; }
    }
    public class Trainer : ITrainer
    {
        public int TrainerId {get;set;}
        public string Name { get; set; }
        public Nullable<long> Salary { get; set; }
    }
}