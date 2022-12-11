using CrudUsingAdo.Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrudUsingAdo.Net.Data_Layer
{
    public class StudentDB
    {
        public Student GetStudentDetailsByRollNumber(int rollnumber)
        {
            Student student = new Student();
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(DbConstant.ConnectionString);
                SqlCommand cmd = new SqlCommand(DbConstant.spGetStudentDetailsByRollNumber, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RollNumber", rollnumber);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        student = new Student()
                        {
                            RollNumber = (int)reader["RollNumber"],
                            Name = reader["StudentName"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            

                            Trainer = new Trainer()
                            {
                                TrainerId = (int)reader["TrainerId"],
                                Name = reader["TainerName"].ToString()
                            }
                        };
                       
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return student;
        }
    }
}