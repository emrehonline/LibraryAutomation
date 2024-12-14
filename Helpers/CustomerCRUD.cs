using LibraryAutomation.Entities;
using System.Collections.Generic;

namespace LibraryAutomation.Helpers
{
    public class CustomerCRUD
    {
        private readonly Database database;
        public CustomerCRUD()
        {
            database = new Database();
        }

        public List<object[]> GetCustomerList()
        {
            return database.GetList("Customer", 3);
        }

        public List<Customer> GetFormattedCustomerList()
        {
            var result = GetCustomerList();
            List<Customer> authors = new List<Customer>();
            foreach (var data in result)
            {
                authors.Add(new Customer()
                {
                    ID = int.Parse(data[0].ToString()),
                    Name = data[1].ToString(),
                    LastName = data[2].ToString(),
                });
            }

            return authors;
        }

        public bool CheckIfCustomerExist(string name, string lastName)
        {
            string query = "Select * from Customer where Name = @Name and LastName = @LastName";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Name", name);
            parameters.Add("@LastName", lastName);

            return database.CheckIfDataExist(query, parameters, 1);
        }

        public bool CreateCustomer(string name, string lastName)
        {
            string query = "Insert Into Customer(Name, LastName) Values(@Name, @LastName)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Name", name);
            parameters.Add("@LastName", lastName);

            return database.ExecuteCommand(query, parameters);
        }

        public bool UpdateCustomer(Customer author)
        {
            string query = $"Update Customer set Name=\"{author.Name}\", LastName=\"{author.LastName}\" where ID={author.ID}";
            return database.ExecuteCommand(query);
        }

        public bool DeleteCustomer(int id)
        {
            string query = $"Delete from Customer where ID={id}";
            return database.ExecuteCommand(query);
        }



    }
}
