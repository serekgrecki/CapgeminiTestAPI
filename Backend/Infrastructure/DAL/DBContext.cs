using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Backend.Infrastructure.DAL
{
    public class DBContext : IDisposable
    {
        SqlConnection connection;

        public DBContext()
        {
            string Server = WebConfigurationManager.AppSettings["Server"].ToString();
            string Database = WebConfigurationManager.AppSettings["Database"].ToString();
            string User = WebConfigurationManager.AppSettings["User"].ToString();
            string Password = WebConfigurationManager.AppSettings["Password"].ToString();
            string connectionString = String.Format("Server={0};uid={1};pwd={2};Database={3};Connect Timeout=20;MultipleActiveResultSets=true", Server, User, Password, Database);
            this.connection = new SqlConnection(connectionString);
        }

        private void Open()
        {
            this.connection.Open();
        }

        public void Dispose()
        {
            if (this.connection != null)
            {
                this.connection.Dispose();
                this.connection = null;
            }
        }

        public SqlCommand CreateCommand(string storedProcedureName)
        {
            SqlCommand command = new SqlCommand(storedProcedureName);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = this.connection;
            return command;
        }
    }
}