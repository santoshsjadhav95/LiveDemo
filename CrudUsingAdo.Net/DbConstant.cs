using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace CrudUsingAdo.Net
{
    public static class DbConstant
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["Task"].ConnectionString;
            }
        }

        public static string spGetAllTrainers = "usp_GetAllTrainers";
        public static string spGetAllStudentByTrainerId = "usp_GetAllStudentByTrainerId";
        public static string spGetStudentDetailsByRollNumber = "uspGetStudentDetailsByRollNumber";
        public static string spCreateTrainer = "usp_CreateTrainer";
        public static string spUpdateTrainer = "usp_UpdateTrainer";
        public static string spDeleteTrainer = "usp_DeleteTrainer";
    }
}