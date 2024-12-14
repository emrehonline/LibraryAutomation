using LibraryAutomation.Entities;
using System.Collections.Generic;

namespace LibraryAutomation.Helpers
{

    public class BookCRUD
    {
        private readonly Database database;
        public BookCRUD()
        {
            database = new Database();
        }

        public List<object[]> GetBookListByQuery()
        {
            string query = "Select b.ID, b.Name, a.Name || ' ' || a.LastName as Author from Book b inner join Author a ON b.AuthorID = a.ID";
            return database.GetListByQuery(query, 3);
        }
        public List<object[]> GetBookList()
        {
            return database.GetList("Book", 3);
        }

        public List<Book> GetFormattedBookList()
        {
            var result = GetBookList();
            List<Book> authors = new List<Book>();
            foreach (var data in result)
            {
                authors.Add(new Book()
                {
                    ID = int.Parse(data[0].ToString()),
                    Name = data[1].ToString(),
                    AuthorId = int.Parse(data[2].ToString()),
                });
            }

            return authors;
        }

        public bool CheckIfBookExist(string name, int authorId)
        {
            string query = "Select * from Book where Name = @Name and AuthorID = @AuthorID";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Name", name);
            parameters.Add("@AuthorID", authorId);

            return database.CheckIfDataExist(query, parameters, 1);
        }

        public bool CreateBook(string name, int authorId)
        {
            string query = "Insert Into Book(Name, AuthorID) Values(@Name, @AuthorID)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Name", name);
            parameters.Add("@AuthorID", authorId);

            return database.ExecuteCommand(query, parameters);
        }

        public bool UpdateBook(Book book)
        {
            string query = $"Update Book set Name=\"{book.Name}\", AuthorID=\"{book.AuthorId}\" where ID={book.ID}";
            return database.ExecuteCommand(query);
        }

        public bool DeleteBook(int id)
        {
            string query = $"Delete from Book where ID={id}";
            return database.ExecuteCommand(query);
        }

    }
}
