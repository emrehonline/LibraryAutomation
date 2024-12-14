using LibraryAutomation.Entities;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheArtOfDev.HtmlRenderer.Adapters;

namespace LibraryAutomation.Helpers
{

    public class BookCRUD
    {
        private readonly Database database;
        public BookCRUD()
        {
            database = new Database();
        }

        public List<object[]> GetBookList()
        {
            return database.GetList("Book", 3);
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
