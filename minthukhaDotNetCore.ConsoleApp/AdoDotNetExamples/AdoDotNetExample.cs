using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;

namespace LemonDotNetCore.ConsoleApp.AdoDotNetExamples
{
    public class AdoDotNetExample
    {
        public void Run()
        {
            //Read();
            //Edit(2);
            //Edit(12);
            //Delete(1);
            // Update(1, "hello title", "hello author", "hello content");
            Create("hello title", "hello author", "hello content");

        }
        private void Read()
        {
            Console.WriteLine("Hello, World!");

            //SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            //sqlConnectionStringBuilde.DataSource = ".";
            //sqlConnectionStringBuilder.InitialCatalog = "LemonDotNetCore";
            //sqlConnectionStringBuilder.UserID = "sa";
            //sqlConnectionStringBuilder.Password = "sasasu";

            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "LemonDotNetCore",
                UserID = "sa",
                Password = "sasa@123"
            };
            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            Console.WriteLine("Connection is opened");

            string query = @"SELECT [Blog_Id]
                          ,[Blog_Title]
                          ,[Blog_Author]
                          ,[Blog_Content]
                      FROM [dbo].[Tbl_Blog]";

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connection.Close();
            Console.WriteLine("Connection is closed");

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("Id => " + dr["Blog_Id"]);
                Console.WriteLine($"Title => {dr["Blog_Title"]}");
                Console.WriteLine("Author => " + dr["Blog_Author"]);
                Console.WriteLine("Content => " + dr["Blog_Content"]);
                Console.WriteLine("_________________");
            }
        }
        public void Read(int pageNO, int pageSize)
        {
            Console.WriteLine("Hello, World!");

            //SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            //sqlConnectionStringBuilde.DataSource = ".";
            //sqlConnectionStringBuilder.InitialCatalog = "LemonDotNetCore";
            //sqlConnectionStringBuilder.UserID = "sa";
            //sqlConnectionStringBuilder.Password = "sasasu";

            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "LemonDotNetCore",
                UserID = "sa",
                Password = "sasasu"
            };
            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            Console.WriteLine("Connection is opened");

            string query = "Sp_GetBlogs";

            SqlCommand command = new SqlCommand(query, connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@pageNo", pageNO);
            command.Parameters.AddWithValue("@pageSize", pageSize);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connection.Close();
            Console.WriteLine("Connection is closed");

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("Id => " + dr["Blog_Id"]);
                Console.WriteLine($"Title => {dr["Blog_Title"]}");
                Console.WriteLine("Author => " + dr["Blog_Author"]);
                Console.WriteLine("Content => " + dr["Blog_Content"]);
                Console.WriteLine("_________________");
            }
        }

        private void Edit(int id)
        {

            //SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            //sqlConnectionStringBuilde.DataSource = ".";
            //sqlConnectionStringBuilder.InitialCatalog = "LemonDotNetCore";
            //sqlConnectionStringBuilder.UserID = "sa";
            //sqlConnectionStringBuilder.Password = "sasasu";

            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "LemonDotNetCore",
                UserID = "sa",
                Password = "sasasu"
            };
            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            connection.Open();

            string query = @"SELECT [Blog_Id]
                          ,[Blog_Title]
                          ,[Blog_Author]
                          ,[Blog_Content]
                      FROM [dbo].[Tbl_Blog] where Blog_Id = @Blog_Id";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Blog_Id", id);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connection.Close();
            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No Data not found!!!");
                return;
            }

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("Id => " + dr["Blog_Id"]);
                Console.WriteLine($"Title => {dr["Blog_Title"]}");
                Console.WriteLine("Author => " + dr["Blog_Author"]);
                Console.WriteLine("Content => " + dr["Blog_Content"]);
                Console.WriteLine("_________________");
            }
        }
        private void Create(string title, string author, string content)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "LemonDotNetCore",
                UserID = "sa",
                Password = "sasasu"
            };
            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            connection.Open();

            string query = @"INSERT INTO [dbo].[Tbl_Blog]
                           ([Blog_Title]
                           ,[Blog_Author]
                           ,[Blog_Content])
                     VALUES
                           (@Blog_Title
                           ,@Blog_Author
                           ,@Blog_Content)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Blog_Title", title);
            command.Parameters.AddWithValue("@Blog_Author", author);
            command.Parameters.AddWithValue("@Blog_Content", content);
            int result = command.ExecuteNonQuery();
            connection.Close();
            string message = result > 0 ? "Saving successful" : "Saving failed!!!";
            Console.WriteLine(result);
            Console.WriteLine(message);
        }
        private void Delete(int id)
        {
            {
                SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
                {
                    DataSource = ".",
                    InitialCatalog = "LemonDotNetCore",
                    UserID = "sa",
                    Password = "sasasu"
                };
                SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

                connection.Open();

                string query = @"DELETE FROM [dbo].[Tbl_Blog]
                               WHERE Blog_Id = @Blog_Id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Blog_Id", id);
                int result = command.ExecuteNonQuery();
                connection.Close();
                string message = result > 0 ? "Delete successful" : "Delete failed!!!";
                Console.WriteLine(result);
                Console.WriteLine(message);
            }
        }
        private void Update(int id, string title, string author, string content)
        {
            {
                SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
                {
                    DataSource = ".",
                    InitialCatalog = "LemonDotNetCore",
                    UserID = "sa",
                    Password = "sasasu"
                };
                SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

                connection.Open();

                string query = @"UPDATE [dbo].[Tbl_Blog]
                               SET [Blog_Title] = @Blog_Title
                                  ,[Blog_Author] = @Blog_Author
                                  ,[Blog_Content] = @Blog_Content
                             WHERE Blog_Id = @Blog_Id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Blog_Id", id);
                command.Parameters.AddWithValue("@Blog_Title", title);
                command.Parameters.AddWithValue("@Blog_Author", author);
                command.Parameters.AddWithValue("@Blog_Content", content);
                int result = command.ExecuteNonQuery();
                connection.Close();
                string message = result > 0 ? "Updating successful" : "Updating failed!!!";
                Console.WriteLine(result);
                Console.WriteLine(message);
            }
        }
    }
}