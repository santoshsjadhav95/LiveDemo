using CrudUsingAdo.Net.Data_Layer;
using CrudUsingAdo.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudUsingAdo.Net.Business_Layer
{
    public class TrainerBL
    {
        TainerDB _db;
        public TrainerBL()
        {
            _db = new TainerDB();
        }
        public List<Trainer> GetAllTrainer()
        {
            return _db.GetAllTrainer();
        }

        public List<Student> GetStudentByTrainerId(int trainerId)
        {
            return _db.GetStudentByTrainerId(trainerId);
        }

        public bool Create(Trainer trainer)
        {
            return _db.Create(trainer);
        }

        public bool Update(Trainer trainer)
        {
            return _db.Update(trainer);
        }

        public bool Delete(int trainerId)
        {
            return _db.Delete(trainerId);
        }
    }
}