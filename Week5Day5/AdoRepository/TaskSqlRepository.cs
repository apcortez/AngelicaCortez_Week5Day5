using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5Day5.Entity;
using Week5Day5.Interface;

namespace Week5Day5.AdoRepository
{
    class TaskSqlRepository : ITaskDbManager
    {
        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;" +
                                      "Initial Catalog = GestioneImpegni;" +
                                      "Integrated Security = true;";
        public void Delete(TaskWork task)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from TaskWork where Id = @id";
                command.Parameters.AddWithValue("@id", task.Id);

                command.ExecuteNonQuery();
            }
        }

        public List<TaskWork> Fetch()
        {
            List<TaskWork> tasks = new List<TaskWork>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from TaskWork";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var title = (string)reader["Title"];
                    var description = (string)reader["Description"];
                    var expdate = (DateTime)reader["ExpirationDate"];
                    var priority = (_Priority)reader["Priority"];
                    var isdone = (bool)reader["Finished"];
                    var id = (int)reader["Id"];

                    TaskWork task = new TaskWork(title, description, expdate, priority,isdone,id);

                    tasks.Add(task);
                }
            }
            return tasks;
        }

        public List<TaskWork> GetByDate(DateTime date)
        {
            List<TaskWork> tasks = new List<TaskWork>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from TaskWork where ExpirationDate >= @date";
                command.Parameters.AddWithValue("@date", date);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var title = (string)reader["Title"];
                    var description = (string)reader["Description"];
                    var expdate = (DateTime)reader["ExpirationDate"];
                    var priority = (_Priority)reader["Priority"];
                    var isdone = (bool)reader["Finished"];
                    var id = (int)reader["Id"];

                    TaskWork task = new TaskWork(title, description, expdate, priority, isdone, id);

                    tasks.Add(task);
                }
            }
            return tasks;
        }

        public List<TaskWork> GetByFinishedTasks()
        {
            List<TaskWork> tasks = new List<TaskWork>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from TaskWork where Finished  = @finished";
                command.Parameters.AddWithValue("@finished", true);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var title = (string)reader["Title"];
                    var description = (string)reader["Description"];
                    var expdate = (DateTime)reader["ExpirationDate"];
                    var priority = (_Priority)reader["Priority"];
                    var isdone = (bool)reader["Finished"];
                    var id = (int)reader["Id"];

                    TaskWork task = new TaskWork(title, description, expdate, priority, isdone, id);

                    tasks.Add(task);
                }
            }
            return tasks;
        }

        public TaskWork GetById(int? id)
        {
            TaskWork task = new TaskWork();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from TaskWork where Id = @id";
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var title = (string)reader["Title"];
                    var description = (string)reader["Description"];
                    var expdate = (DateTime)reader["ExpirationDate"];
                    var priority = (_Priority)reader["Priority"];
                    var isdone = (bool)reader["Finished"];
                

                    task = new TaskWork(title, description, expdate, priority, isdone, id);

                }
            }
            return task;
        }

        public List<TaskWork> GetByPriority(_Priority priority)
        {
            List<TaskWork> tasks = new List<TaskWork>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from TaskWork where Priority = @priority";
                command.Parameters.AddWithValue("@priority", (int)priority);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var title = (string)reader["Title"];
                    var description = (string)reader["Description"];
                    var expdate = (DateTime)reader["ExpirationDate"];
                    var isdone = (bool)reader["Finished"];
                    var id = (int)reader["Id"];

                    TaskWork task = new TaskWork(title, description, expdate, priority, isdone, id);

                    tasks.Add(task);
                }
            }
            return tasks;
        }

        public List<TaskWork> GetUnfinishedTasks()
        {
            List<TaskWork> tasks = new List<TaskWork>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from TaskWork where Finished  = @finished";
                command.Parameters.AddWithValue("@finished", false);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var title = (string)reader["Title"];
                    var description = (string)reader["Description"];
                    var expdate = (DateTime)reader["ExpirationDate"];
                    var priority = (_Priority)reader["Priority"];
                    var isdone = (bool)reader["Finished"];
                    var id = (int)reader["Id"];

                    TaskWork task = new TaskWork(title, description, expdate, priority, isdone, id);

                    tasks.Add(task);
                }
            }
            return tasks;
        }

        public void Insert(TaskWork task)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;


                command.CommandText = "insert into TaskWork values (@title, @description, @expdate, @priority, @finished)";
                command.Parameters.AddWithValue("@title", task.Title);
                command.Parameters.AddWithValue("@description", task.Description);
                command.Parameters.AddWithValue("@expdate", task.ExpirationDate);
                command.Parameters.AddWithValue("@priority", task.Priority);
                command.Parameters.AddWithValue("@finished", task.Finished);


                command.ExecuteNonQuery();
            }
        }

        public void Update(TaskWork task)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update TaskWork " +
                                      "set Title = @title, Description = @description, ExpirationDate = @expdate, Priority = @priority, Finished = @finished " +
                                      "where Id = @id";
                command.Parameters.AddWithValue("@title", task.Title);
                command.Parameters.AddWithValue("@description", task.Description);
                command.Parameters.AddWithValue("@expdate", task.ExpirationDate);
                command.Parameters.AddWithValue("@priority", task.Priority);
                command.Parameters.AddWithValue("@finished", task.Finished);
                command.Parameters.AddWithValue("@id", task.Id);
                command.ExecuteNonQuery();
            }
        }
    }
}
