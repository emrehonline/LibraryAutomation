using LibraryAutomation.Entities;
using System.Collections.Generic;

namespace LibraryAutomation.Helpers
{
    public class AuthorCRUD
    {
        private readonly Database database;
        public AuthorCRUD()
        {
            database = new Database();
        }

        public List<object[]> GetAuthorList()
        {
            return database.GetList("Author", 3);
        }

        public List<Author> GetFormattedAuthorList()
        {
            var result = GetAuthorList();
            List<Author> authors = new List<Author>();
            foreach (var data in result)
            {
                authors.Add(new Author()
                {
                    ID = int.Parse(data[0].ToString()),
                    Name = data[1].ToString(),
                    LastName = data[2].ToString(),
                });
            }

            return authors;
        }

        public bool CheckIfAuthorExist(string name, string lastName)
        {
            string query = "Select * from Author where Name = @Name and LastName = @LastName";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Name", name);
            parameters.Add("@LastName", lastName);

            return database.CheckIfDataExist(query, parameters, 1);
        }

        public bool CreateAuthor(string name, string lastName)
        {
            string query = "Insert Into Author(Name, LastName) Values(@Name, @LastName)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Name", name);
            parameters.Add("@LastName", lastName);

            return database.ExecuteCommand(query, parameters);
        }

        public bool UpdateAuthor(Author author)
        {
            string query = $"Update Author set Name=\"{author.Name}\", LastName=\"{author.LastName}\" where ID={author.ID}";
            return database.ExecuteCommand(query);
        }

        public bool DeleteAuthor(int id)
        {
            string query = $"Delete from Author where ID={id}";
            return database.ExecuteCommand(query);
        }



    }
}
