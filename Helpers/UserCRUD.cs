using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LibraryAutomation.Helpers
{

    public class UserCRUD
    {
        private readonly Database database;
        public UserCRUD()
        {
            database = new Database();
        }

        public bool CheckIfUserExist(string userName)
        {
            string query = "Select * from User where Name = @Name";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Name", userName);

            return database.CheckIfDataExist(query, parameters, 1);
        }

        public bool Login(string userName, string password)
        {
            string query = "Select * from User where Name = @Name and Password = @Password";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Name", userName);
            parameters.Add("@Password", password);

            return database.CheckIfDataExist(query, parameters, 1);
        }

        public bool CreateUser(string userName, string password)
        {
            string query = "Insert Into User(Name, Password) Values(@Name, @Password)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Name", userName);
            parameters.Add("@Password", password);

            return database.ExecuteCommand(query, parameters);
        }

        public bool ResetPassword(string userName, string password)
        {
            string query = "Update User set Password = @Password where Name = @Name";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Name", userName);
            parameters.Add("@Password", password);

            return database.ExecuteCommand(query, parameters);
        }
    }
}