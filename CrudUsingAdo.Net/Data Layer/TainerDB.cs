using CrudUsingAdo.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace CrudUsingAdo.Net.Data_Layer
{
    public class TainerDB
    {
        public List<Trainer> GetAllTrainer()
        {
            List<Trainer> trainers = new List<Trainer>();
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(DbConstant.ConnectionString);
                SqlCommand cmd = new SqlCommand(DbConstant.spGetAllTrainers, con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        Trainer t = new Trainer()
                        {
                            TrainerId = (int)reader["TrainerId"],
                            Name = reader["Name"].ToString(),
                            Salary = (long)reader["Salary"]
                        };
                        trainers.Add(t);
                    }
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                if(con != null)
                {
                    con.Close();
                }
            }
            return trainers;
        }

        public List<Student> GetStudentByTrainerId(int trainerId)
        {
            List<Student> students = new List<Student>();
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(DbConstant.ConnectionString);
                SqlCommand cmd = new SqlCommand(DbConstant.spGetAllStudentByTrainerId, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TrainerId", trainerId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Student s = new Student()
                        {
                            RollNumber = (int)reader["TrainerId"],
                            Name = reader["Name"].ToString(),
                            Gender= reader["Gender"].ToString(),
                            TrainerId=(int)reader["TrainerId"]
                           
                        };
                        students.Add(s);
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
            return students;
        }

        public bool Create(Trainer trainer)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(DbConstant.ConnectionString);
                SqlCommand cmd = new SqlCommand(DbConstant.spCreateTrainer, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", trainer.Name);
                cmd.Parameters.AddWithValue("@Salary", trainer.Salary);

                SqlParameter insertStatus = new SqlParameter() 
                {
                   ParameterName = "@insertStatus",
                   SqlDbType = SqlDbType.Bit,
                   Direction = ParameterDirection.Output
                
                };
                cmd.Parameters.Add(insertStatus);
                con.Open();
                cmd.ExecuteNonQuery();

                return (bool)insertStatus.Value;
            }
            catch(Exception ex)
            {
                return false;
            }
            finally
            {
                if(con != null)
                {
                    con.Close();
                }
            }
        }

        public bool Update(Trainer trainer)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(DbConstant.ConnectionString);
                SqlCommand cmd = new SqlCommand(DbConstant.spUpdateTrainer, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TrainerId", trainer.TrainerId);
                cmd.Parameters.AddWithValue("@Name", trainer.Name);
                cmd.Parameters.AddWithValue("@Salary", trainer.Salary);

                SqlParameter updateStatus = new SqlParameter()
                {
                    ParameterName = "@updateStatus",
                    SqlDbType = SqlDbType.Bit,
                    Direction = ParameterDirection.Output

                };
                cmd.Parameters.Add(updateStatus);
                con.Open();
                cmd.ExecuteNonQuery();

                return (bool)updateStatus.Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        public bool Delete(int trainerId)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(DbConstant.ConnectionString);
                SqlCommand cmd = new SqlCommand(DbConstant.spDeleteTrainer, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TrainerId", trainerId);

                SqlParameter deleteStatus = new SqlParameter()
                {
                    ParameterName = "@deleteStatus",
                    SqlDbType = SqlDbType.Bit,
                    Direction = ParameterDirection.Output

                };
                cmd.Parameters.Add(deleteStatus);
                con.Open();
                cmd.ExecuteNonQuery();

                return (bool)deleteStatus.Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
    }
}