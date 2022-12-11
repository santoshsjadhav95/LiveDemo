using CrudUsingAdo.Net.Data_Layer;
using CrudUsingAdo.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudUsingAdo.Net.Business_Layer
{
    public class StudentBL
    {
        public StudentDB _db;
        public StudentBL()
        {
            _db = new StudentDB();
        }

        public Student GetStudentDetailsByRollNumber(int rollnumber)
        {
            return _db.GetStudentDetailsByRollNumber(rollnumber);
        }
    }
}